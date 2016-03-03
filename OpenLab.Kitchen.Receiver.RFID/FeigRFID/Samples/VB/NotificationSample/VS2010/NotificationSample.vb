'---------------------------------------------------------------
'Copyright © 2006-2008	FEIG ELECTRONIC GmbH, All Rights Reserved.
'						Lange Strasse 4
'						D-35781 Weilburg
'						Federal Republic of Germany
'						phone    : +49 6471 31090
'						fax      : +49 6471 310999
'						e-mail   : obid-support@feig.de
'						Internet : http://www.feig.de
'
'OBID® and OBID i-scan® are registered trademarks of FEIG ELECTRONIC GmbH
'----------------------------------------------------------------

Imports OBID

Public Class NotificationSample
    Implements FedmTaskListener


    Delegate Sub DelegateDisplayRecSets(ByVal recSets As Integer, ByVal type() As Byte, ByVal serialNumber() As String, ByVal dataBlock() As String, ByVal readerdate() As String, ByVal readertime() As String, ByVal antennaNr() As Byte, ByVal DictRSSI() As Dictionary(Of Byte, FedmIscRssiItem), ByVal input() As Byte, ByVal state() As Byte, ByVal ip As String)
    Delegate Sub DelegateDisplayDiagnose(ByVal diagData As String, ByVal ip As String)

    Private count As Long = 1
    Private reader As FedmIscReader
    Private taskOpt As FedmTaskOption

    Private Sub NotificationSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            reader = New FedmIscReader
            reader.SetTableSize(FedmIscReaderConst.BRM_TABLE, 255) ' max 255 tag with each notification
            taskOpt = New FedmTaskOption()
        Catch ex As FedmException
            End
        End Try
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        labelData.Clear()
        count = 1
    End Sub

    Public Sub OnNewNotification(ByVal iError As Integer, ByVal IP As String, ByVal PortNr As UInteger) Implements OBID.FedmTaskListener.OnNewNotification

        Dim i As Integer
        Dim cnt As Integer
        Dim brmItems() As FedmBrmTableItem
        brmItems = reader.GetTable(FedmIscReaderConst.BRM_TABLE)
        Dim DisplayRecSetMethod As New DelegateDisplayRecSets(AddressOf DisplayRecSets)
        Dim obj(10) As Object
        Dim result As IAsyncResult
        Dim db As String

        'Init
        db = ""

        If Not brmItems Is Nothing Then
            Dim serialnumber(brmItems.Length) As String
            Dim dataBlock(brmItems.Length) As String
            Dim readerdate(brmItems.Length) As String
            Dim readertime(brmItems.Length) As String
            Dim type(brmItems.Length) As Byte
            Dim antennaNr(brmItems.Length) As Byte
            Dim DictRSSI(brmItems.Length) As Dictionary(Of Byte, FedmIscRssiItem)
            Dim input(brmItems.Length) As Byte
            Dim state(brmItems.Length) As Byte

            DictRSSI(brmItems.Length) = New Dictionary(Of Byte, FedmIscRssiItem)

            For i = 0 To brmItems.Length - 1
                'Serial Number
                If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_SNR) Then
                    brmItems(i).GetData(FedmIscReaderConst.DATA_SNR, serialnumber(i))
                End If

                'Data Blocks
                If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_RxDB) Then
                    For cnt = 0 To brmItems(i).GetBlockCount() - 1
                        brmItems(i).GetData(FedmIscReaderConst.DATA_RxDB, cnt, db)
                        dataBlock(i) = dataBlock(i) + db
                    Next
                End If

                'Transponder Type
                If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_TRTYPE) Then
                    brmItems(i).GetData(FedmIscReaderConst.DATA_TRTYPE, type(i))
                End If

                'Date
                If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_DATE) Then
                    readerdate(i) = brmItems(i).GetReaderTime().GetDate()
                End If

                'Time
                If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_TIMER) Then
                    readertime(i) = brmItems(i).GetReaderTime().GetTime()
                End If

                'Antenna Number
                'It is possible either to output the ANT_NR or the RSSI value (this is also important for the reader config!) 
                If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_ANT_NR) Then
                    brmItems(i).GetData(FedmIscReaderConst.DATA_ANT_NR, antennaNr(i))
                End If

                'RSSI of Antenna Number
                'It is possible either to output the ANT_NR or the RSSI value (this is also important for the reader config!) 
                If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_ANT_RSSI) Then
                    DictRSSI(i) = brmItems(i).GetRSSI()
                Else
                    DictRSSI(i) = New Dictionary(Of Byte, FedmIscRssiItem)
                End If

                'Input + State
                If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_INPUT) Then
                    brmItems(i).GetData(FedmIscReaderConst.DATA_INPUT, input(i))
                    brmItems(i).GetData(FedmIscReaderConst.DATA_STATE, state(i))
                End If
            Next

            obj(0) = brmItems.Length
            obj(1) = type
            obj(2) = serialnumber
            obj(3) = dataBlock
            obj(4) = readerdate
            obj(5) = readertime
            obj(6) = antennaNr
            obj(7) = DictRSSI
            obj(8) = input
            obj(9) = state
            obj(10) = IP
            result = Invoke(DisplayRecSetMethod, obj)
        End If
    End Sub

    Public Sub OnNewApduResponse(ByVal iError As Integer) Implements OBID.FedmTaskListener.OnNewApduResponse
    End Sub

    Public Sub OnNewQueueResponse(ByVal iError As Integer) Implements OBID.FedmTaskListener.OnNewQueueResponse
    End Sub

    Public Sub OnNewSAMResponse(ByVal iError As Integer, ByVal responseData() As Byte) Implements OBID.FedmTaskListener.OnNewSAMResponse
    End Sub

    Public Sub OnNewReaderDiagnostic(ByVal iError As Integer, ByVal IP As String, ByVal PortNr As UInteger) Implements OBID.FedmTaskListener.OnNewReaderDiagnostic
        Dim diagData As String
        Dim DisplayDiagnoseMethod As New DelegateDisplayDiagnose(AddressOf DisplayDiagnose)
        Dim obj(1) As Object
        Dim result As IAsyncResult

        'Init
        diagData = ""

        reader.GetData(OBID.FedmIscReaderID.FEDM_ISC_TMP_DIAG_DATA, diagData)

        ' only first 3 bytes (6 chars) with diagnostic mode 0x01 are valid
        obj(0) = diagData.Substring(0, 2) + " " + diagData.Substring(2, 2) + " " + diagData.Substring(4, 2)
        obj(1) = IP

        result = Invoke(DisplayDiagnoseMethod, obj)
    End Sub

    Public Sub OnNewTag(ByVal iError As Integer) Implements OBID.FedmTaskListener.OnNewTag

    End Sub

    Public Sub onNewPeopleCounterEvent(counter1 As UInteger, counter2 As UInteger, counter3 As UInteger, counter4 As UInteger, ip As String, portNr As UInteger, busAddress As UInteger) Implements OBID.FedmTaskListener.onNewPeopleCounterEvent

    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu
    End Sub

    Private Sub NotificationSample_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        reader.CancelAsyncTask()
    End Sub

    Private Sub ButtonListen_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListen.CheckStateChanged

        If Me.ButtonListen.Checked Then
            taskOpt.IPPort = Val(Me.TextPortNr.Text)
            If Me.ACK.Checked Then
                taskOpt.NotifyWithAck = 1
            Else
                taskOpt.NotifyWithAck = 0
            End If
            reader.StartAsyncTask(FedmTaskOption.ID_NOTIFICATION, Me, taskOpt)
        Else
            reader.CancelAsyncTask()
        End If

    End Sub

    Public Sub DisplayRecSets(ByVal recSets As Integer, ByVal type() As Byte, ByVal serialNumber() As String, ByVal dataBlock() As String, ByVal readerdate() As String, ByVal readertime() As String, ByVal antennaNr() As Byte, ByVal DictRSSI() As Dictionary(Of Byte, FedmIscRssiItem), ByVal input() As Byte, ByVal state() As Byte, ByVal ip As String)
        Dim dr As String
        Dim i As Integer
        Dim RSSIval As Dictionary(Of Byte, FedmIscRssiItem)
        Dim RSSIitem As FedmIscRssiItem

        Dim bcheck As Boolean
        Dim antNo As Byte


        For i = 0 To recSets - 1
            dr = Trim(Str(count)) + vbTab
            count = count + 1
            If type(i) >= 0 Then
                dr += "0x" + Strings.Right(FeHexConvert.IntegerToHexString(type(i)), 2) + vbTab
            End If

            'Output serial number
            If Not serialNumber(i) Is Nothing Then
                dr += serialNumber(i) + vbTab
            End If

            'Output data blocks
            If Not dataBlock(i) Is Nothing Then
                dr += dataBlock(i) + vbTab
            End If

            'Output Date
            If Not readerdate(i) Is Nothing Then
                dr += readerdate(i) + vbTab
            End If

            'Output Time 
            If Not readertime(i) Is Nothing Then
                dr += readertime(i) + vbTab
            End If

            'It is possible either to output the ANT_NR or the RSSI value (this is also important for the reader config!)
            'Output Antenna Number
            dr += Trim(Str(antennaNr(i))) + vbTab

            'It is possible either to output the ANT_NR or the RSSI value (this is also important for the reader config!)
            'Output RSSI
            If DictRSSI.Length <> 0 Then
                If Not DictRSSI(i) Is Nothing Then
                    RSSIval = DictRSSI(i)
                    For antNo = 1 To FedmBrmTableItem.TABLE_MAX_ANTENNA - 1
                        bcheck = RSSIval.TryGetValue(antNo, RSSIitem)
                        If Not bcheck Then
                            Continue For
                        End If
                        dr += "RSSI of AntNr. " + antNo.ToString() + " is " + "-" + RSSIitem.RSSI.ToString + "dBm   " + vbTab
                    Next
                End If
            End If

            dr += "IN: " + Trim(Str(input(i))) + vbTab
            dr += "State: " + Trim(Str(state(i))) + vbTab
            dr += "from " + ip
            labelData.Text = labelData.Text + dr + vbNewLine

        Next
    End Sub

    Public Sub DisplayDiagnose(ByVal data As String, ByVal ip As String)
        labelData.Text = labelData.Text + "Reader-Diagnostic : " + data + " from " + ip + vbNewLine
    End Sub

    'ever show the last line from textbox
    Private Sub labelData_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles labelData.TextChanged
        Me.labelData.SelectionStart = Me.labelData.Text.Length
        Me.labelData.SelectionLength = Me.labelData.Text.Length
        Me.labelData.ScrollToCaret()
        Me.labelData.Refresh()
    End Sub

End Class
