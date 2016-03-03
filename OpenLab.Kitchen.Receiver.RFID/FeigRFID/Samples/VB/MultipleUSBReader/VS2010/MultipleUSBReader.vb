Imports OBID
Imports System
Imports MultipleUSBReader

Public Class MultipleUSBReader
    Implements FeIscListener, FeUsbListener

    Dim UsbPort As FeUsb
    Dim ActReader As FedmIscReader
    Dim map As New SortedList
    Dim idx As Integer
    Dim devID As Long
    Dim DeviceID As Long


    Delegate Sub DelegateOnAddNewReader(ByVal DeviceID As Long)
    Delegate Sub DelegateOnRemoveReader(ByVal DeviceID As Long)

    Private Sub MultipleUSBReader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UsbPort = New FeUsb

        Try
            'event listener for conect/disconect events
            UsbPort.AddEventListener(0, CType(Me, FeUsbListener), FeUsbListenerConst.FEUSB_CONNECT_EVENT)
            UsbPort.AddEventListener(0, CType(Me, FeUsbListener), FeUsbListenerConst.FEUSB_DISCONNECT_EVENT)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub OnConnectReader(ByVal DeviceHandle As Integer, ByVal DeviceID As Long) Implements OBID.FeUsbListener.OnConnectReader
        Dim result As IAsyncResult
        Dim method As New DelegateOnAddNewReader(AddressOf AddDevice)

        result = Invoke(method, DeviceID)
    End Sub

    Public Sub OnDisConnectReader(ByVal DeviceHandle As Integer, ByVal DeviceID As Long) Implements OBID.FeUsbListener.OnDisConnectReader
        Dim result As IAsyncResult
        Dim method As New DelegateOnRemoveReader(AddressOf RemoveDevice)

        result = Invoke(method, DeviceID)
    End Sub

    Private Sub ButtonInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInventory.Click
        'If not selected deviceID 
        If idx <> -1 Then
            Dim Reader = New FedmIscReader
            'Look if DeviceID is in map
            If map.ContainsKey(devID) = True Then
                ReadActiveReader(devID)
            Else
                MsgBox(" No Readers are selected! ")
            End If
        Else
            MsgBox(" Please select Reader! ")
        End If
    End Sub

    Private Sub ListBoxUSBReader_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxUSBReader.SelectedIndexChanged
        'Select DeviceID
        idx = Me.ListBoxUSBReader.SelectedIndex
        If idx <> -1 Then
            devID = Me.ListBoxUSBReader.Text
        End If
    End Sub
    Private Sub Button_CleanListBoxTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_CleanListBoxTag.Click
        Me.ListBoxTag.Items.Clear()
    End Sub

    Private Sub ButtonClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClean.Click
        Me.TextBoxProtocol.Clear()
    End Sub

    'Add  and Connect Reader
    Public Sub AddDevice(ByVal DeviceID As Long)
        Dim UsbSearch As FeUsbScanSearch
        Dim AdUSBReader As FedmIscReader
        Dim iStatus As Integer

        AdUSBReader = New FedmIscReader
        UsbSearch = New FeUsbScanSearch
        UsbSearch.Mask = 0

        ' event listener for protocol window
        AdUSBReader.AddEventListener(CType(Me, FeIscListener), FeIscListenerConst.SEND_STRING_EVENT)
        AdUSBReader.AddEventListener(CType(Me, FeIscListener), FeIscListenerConst.RECEIVE_STRING_EVENT)

        AdUSBReader.SetTableSize(FedmIscReaderConst.ISO_TABLE, 128)

        'Search new readers on USB not in  ScanList
        iStatus = UsbPort.Scan(FeUsbScanSearch.SCAN_NEW, UsbSearch)
        iStatus = UsbPort.ScanListSize()

        'Try to connect Readers
        Try
            'Connect USB_Port
            AdUSBReader.ConnectUSB(DeviceID)
            map.Add(DeviceID, AdUSBReader)
            Me.ListBoxUSBReader.Items.Add(DeviceID.ToString)
            ReaderCount()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    'Remove and disconnect Reader 
    Public Sub RemoveDevice(ByVal DeviceID As Long)
        Dim RemUSBReader As FedmIscReader
        Dim UsbSearch As FeUsbScanSearch

        UsbSearch = New FeUsbScanSearch
        UsbSearch.Mask = 0

        Try
            If DeviceID <> 0 Then
                'Readers with their correct DeviceID 
                RemUSBReader = map.Item(DeviceID)
                'Remove Reader from USB
                RemUSBReader.DisConnect()
                'pack internal scanlist
                UsbPort.Scan(FeUsbScanSearch.SCAN_PACK, UsbSearch)
                'Remove DeviceID from map
                map.Remove(DeviceID)
                ReaderCount()
                ListBoxUSBReader.Items.Remove(DeviceID.ToString)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    'Count Readers
    Public Sub ReaderCount()
        Me.LabelReadersSum.Text = map.Count.ToString
    End Sub

    'Read activated/selected Reader
    Public Sub ReadActiveReader(ByVal DeviceID As Long)

        Dim serialNumber As String()

        ActReader = New FedmIscReader

        'Activate from selected reader
        ActReader = map.Item(DeviceID)

        ActReader.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, &H1)
        ActReader.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, &H0)

        Try
            ' clear always in front of an Inventory the internal table
            ActReader.ResetTable(FedmIscReaderConst.ISO_TABLE)

            ActReader.SendProtocol(&H69) ' RFReset
            ActReader.SendProtocol(&HB0) ' ISOCmd

            While ActReader.GetLastStatus = &H94 ' more flag set?
                ActReader.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_MORE, &H1)
                ActReader.SendProtocol(&HB0)
            End While

            'number of tags in the table
            ReDim serialNumber(ActReader.GetTableLength(FedmIscReaderConst.ISO_TABLE) - 1)

            Me.LabelTagsnumber.Text = ActReader.GetTableLength(FedmIscReaderConst.ISO_TABLE).ToString()
            If ActReader.GetTableLength(FedmIscReaderConst.ISO_TABLE) > 0 Then
                Dim i As Integer
                ' get all UIDs from table
                For i = 0 To ActReader.GetTableLength(FedmIscReaderConst.ISO_TABLE) - 1
                    ActReader.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR, serialNumber(i))
                Next
                TagChanged(serialNumber)
            Else
                ListBoxTag.Items.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    'Show multiple TranspondersID
    Public Sub TagChanged(ByVal serialNumber() As String)
        Dim i As Integer
        ListBoxTag.Items.Clear()
        For i = 0 To serialNumber.Length - 1
            If Not ListBoxTag.Items.Contains(serialNumber(i)) Then
                ListBoxTag.Items.Add(serialNumber(i))
            End If
        Next
    End Sub

    Public Sub OnReceiveProtocol(ByVal reader As OBID.FedmIscReader, ByVal receiveProtocol() As Byte) Implements OBID.FeIscListener.OnReceiveProtocol

    End Sub

    Public Sub OnReceiveProtocol(ByVal reader As OBID.FedmIscReader, ByVal receiveProtocol As String) Implements OBID.FeIscListener.OnReceiveProtocol
        DisplayReceiveProtocol(receiveProtocol)
    End Sub

    Public Sub OnSendProtocol(ByVal reader As OBID.FedmIscReader, ByVal sendProtocol() As Byte) Implements OBID.FeIscListener.OnSendProtocol

    End Sub

    Public Sub OnSendProtocol(ByVal reader As OBID.FedmIscReader, ByVal sendProtocol As String) Implements OBID.FeIscListener.OnSendProtocol
        DisplaySendProtocol(sendProtocol)
    End Sub

    'show received Protocol
    Public Sub DisplayReceiveProtocol(ByVal protocol As String)
        Me.TextBoxProtocol.Text += protocol
    End Sub

    'show sent Protocol
    Public Sub DisplaySendProtocol(ByVal protocol As String)
        Me.TextBoxProtocol.Text += protocol
    End Sub

    'ever show the last line from textbox
    Private Sub TextBoxProtocol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxProtocol.TextChanged
        Me.TextBoxProtocol.SelectionStart = Me.TextBoxProtocol.Text.Length
        Me.TextBoxProtocol.SelectionLength = Me.TextBoxProtocol.Text.Length
        Me.TextBoxProtocol.ScrollToCaret()
        Me.TextBoxProtocol.Refresh()
    End Sub


End Class
