'---------------------------------------------------------------
'Copyright © 2003-2008	FEIG ELECTRONIC GmbH, All Rights Reserved.
'						Lange Strasse 4
'						D-35781 Weilburg
'						Federal Republic of Germany
'						phone    : +49 6471 31090
'						fax      : +49 6471 310999
'						e-mail   : info@feig.de
'						Internet : http://www.feig.de
'
'OBID® and OBID i-scan® are registered trademarks of FEIG ELECTRONIC GmbH
'----------------------------------------------------------------

Namespace OBID
    Public Class BRMSample
        Inherits System.Windows.Forms.Form
		Implements FeIscListener


#Region " Vom Windows Form Designer generierter Code "

        Public Sub New()
            MyBase.New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()

		End Sub

        ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        ' Für Windows Form-Designer erforderlich
        Private components As System.ComponentModel.IContainer

        'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
        'Sie kann mit dem Windows Form-Designer modifiziert werden.
        'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents startBRM As System.Windows.Forms.CheckBox
        Friend WithEvents resetBrm As System.Windows.Forms.Button
        Friend WithEvents ButtonPortConfig As System.Windows.Forms.Button
        Friend WithEvents ButtonExit As System.Windows.Forms.Button
        Friend WithEvents ListViewData As System.Windows.Forms.ListView
        Friend WithEvents ButtonClearProt As System.Windows.Forms.Button
        Friend WithEvents ButtonClear As System.Windows.Forms.Button
        Friend WithEvents protocolData As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BRMSample))
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.ButtonClearProt = New System.Windows.Forms.Button()
            Me.ButtonExit = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.ButtonClear = New System.Windows.Forms.Button()
            Me.startBRM = New System.Windows.Forms.CheckBox()
            Me.resetBrm = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.ButtonPortConfig = New System.Windows.Forms.Button()
            Me.protocolData = New System.Windows.Forms.TextBox()
            Me.ListViewData = New System.Windows.Forms.ListView()
            Me.Panel1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.ButtonClearProt)
            Me.Panel1.Controls.Add(Me.ButtonExit)
            Me.Panel1.Controls.Add(Me.GroupBox2)
            Me.Panel1.Controls.Add(Me.GroupBox1)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel1.Location = New System.Drawing.Point(1133, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(150, 685)
            Me.Panel1.TabIndex = 0
            '
            'ButtonClearProt
            '
            Me.ButtonClearProt.Location = New System.Drawing.Point(8, 604)
            Me.ButtonClearProt.Name = "ButtonClearProt"
            Me.ButtonClearProt.Size = New System.Drawing.Size(136, 28)
            Me.ButtonClearProt.TabIndex = 3
            Me.ButtonClearProt.Text = "Clear protocol"
            Me.ButtonClearProt.UseVisualStyleBackColor = True
            '
            'ButtonExit
            '
            Me.ButtonExit.Location = New System.Drawing.Point(8, 648)
            Me.ButtonExit.Name = "ButtonExit"
            Me.ButtonExit.Size = New System.Drawing.Size(136, 28)
            Me.ButtonExit.TabIndex = 2
            Me.ButtonExit.Text = "Exit"
            '
            'GroupBox2
            '
            Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox2.Controls.Add(Me.ButtonClear)
            Me.GroupBox2.Controls.Add(Me.startBRM)
            Me.GroupBox2.Controls.Add(Me.resetBrm)
            Me.GroupBox2.Location = New System.Drawing.Point(8, 80)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(136, 146)
            Me.GroupBox2.TabIndex = 1
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "BRM"
            '
            'ButtonClear
            '
            Me.ButtonClear.Location = New System.Drawing.Point(16, 112)
            Me.ButtonClear.Name = "ButtonClear"
            Me.ButtonClear.Size = New System.Drawing.Size(106, 28)
            Me.ButtonClear.TabIndex = 5
            Me.ButtonClear.Text = "Clear"
            Me.ButtonClear.UseVisualStyleBackColor = True
            '
            'startBRM
            '
            Me.startBRM.Appearance = System.Windows.Forms.Appearance.Button
            Me.startBRM.Enabled = False
            Me.startBRM.Location = New System.Drawing.Point(16, 24)
            Me.startBRM.Name = "startBRM"
            Me.startBRM.Size = New System.Drawing.Size(106, 28)
            Me.startBRM.TabIndex = 4
            Me.startBRM.Text = "Start BRM"
            Me.startBRM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'resetBrm
            '
            Me.resetBrm.Enabled = False
            Me.resetBrm.Location = New System.Drawing.Point(16, 68)
            Me.resetBrm.Name = "resetBrm"
            Me.resetBrm.Size = New System.Drawing.Size(106, 28)
            Me.resetBrm.TabIndex = 1
            Me.resetBrm.Text = "Reset BRM"
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Controls.Add(Me.ButtonPortConfig)
            Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(136, 64)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Setup"
            '
            'ButtonPortConfig
            '
            Me.ButtonPortConfig.Location = New System.Drawing.Point(16, 24)
            Me.ButtonPortConfig.Name = "ButtonPortConfig"
            Me.ButtonPortConfig.Size = New System.Drawing.Size(106, 28)
            Me.ButtonPortConfig.TabIndex = 0
            Me.ButtonPortConfig.Text = "Connection..."
            '
            'protocolData
            '
            Me.protocolData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.protocolData.Location = New System.Drawing.Point(8, 376)
            Me.protocolData.Multiline = True
            Me.protocolData.Name = "protocolData"
            Me.protocolData.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.protocolData.Size = New System.Drawing.Size(1115, 304)
            Me.protocolData.TabIndex = 1
            Me.protocolData.WordWrap = False
            '
            'ListViewData
            '
            Me.ListViewData.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.ListViewData.Location = New System.Drawing.Point(8, 8)
            Me.ListViewData.Name = "ListViewData"
            Me.ListViewData.Size = New System.Drawing.Size(1115, 362)
            Me.ListViewData.TabIndex = 3
            Me.ListViewData.UseCompatibleStateImageBehavior = False
            Me.ListViewData.View = System.Windows.Forms.View.Details
            '
            'BRMSample
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1283, 685)
            Me.Controls.Add(Me.ListViewData)
            Me.Controls.Add(Me.protocolData)
            Me.Controls.Add(Me.Panel1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BRMSample"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "BRMSample for Standard and Advanced Buffered Read Mode  -  FEIG ELECTRONIC  -  ad" & _
        "vanced reader techology"
            Me.Panel1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Delegate Sub DelegateDisplayRecSets(ByVal recSets As Integer, ByVal type() As Byte, ByVal serialNumber() As String, ByVal dataBlock() As String, ByVal timer() As String, ByVal datum() As String, ByVal antennaNr() As Byte, ByVal DictRSSI() As Dictionary(Of Byte, FedmIscRssiItem), ByVal input() As Byte, ByVal state() As Byte)
        Delegate Sub DelegateOnSendProtocol(ByVal protocol As String)
        Delegate Sub DelegateOnRecProtocol(ByVal protocol As String)
        Delegate Sub DelegateListViewClear()
        Private ReaderType As Byte
        Private portCfg As PortConfig
        Private reader As FedmIscReader
        Private ReaderInfo As FedmIscReaderInfo
        Private busAddress As Integer
        Private count As Long
        Private running As Boolean
        Private myThread As New Threading.Thread(AddressOf ReadThread)

        Private Sub BRMSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                reader = New FedmIscReader
                reader.SetTableSize(FedmIscReaderConst.BRM_TABLE, 255)
            Catch ex As FedmException
                End
            End Try
            portCfg = New PortConfig(reader)

            count = 1
            ReaderType = 0
            running = False
            myThread.IsBackground = True
            myThread.Start()

        End Sub

        Private Sub startBRM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startBRM.CheckedChanged
            If reader.Connected Then
                If startBRM.Checked Then

                    ' rename the button
                    startBRM.Text = "Stop BRM"
                    running = True
                Else
                    startBRM.Text = "Start BRM"
                    running = False
                End If
            End If
        End Sub

        Private Sub ResetBrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resetBrm.Click
            If reader.Connected Then
                InitBuffer()
            End If
        End Sub

        Private Sub InitBuffer()
            Try
                ' initialize Buffered Read Mode
                reader.SendProtocol(&H33)
            Catch e As FePortDriverException
                System.Console.WriteLine(e.ToString)
            Catch e As FeReaderDriverException
                System.Console.WriteLine(e.ToString)
            End Try
        End Sub

        Private ReadOnly Property Time() As String
            Get
                Dim d As Date
                d = Date.Now

                Dim t As String

                ' Get the Date
                If Len(Trim(Str(d.Month))) = 1 Then
                    t = "0" + Trim(Str(d.Month)) + "/"
                Else
                    t = Trim(Str(d.Month)) + "/"
                End If
                If Len(Trim(Str(d.Day))) = 1 Then
                    t += "0" + Trim(Str(d.Day)) + "/"
                Else
                    t += Trim(Str(d.Day)) + "/"
                End If
                t += Trim(Str(d.Year)) + " "

                ' Get the time
                If Len(Trim(Str(d.Hour))) = 1 Then
                    t += "0" + Trim(Str(d.Hour)) + ":"
                Else
                    t += Trim(Str(d.Hour)) + ":"
                End If
                If Len(Trim(Str(d.Minute))) = 1 Then
                    t += "0" + Trim(Str(d.Minute)) + ":"
                Else
                    t += Trim(Str(d.Minute)) + ":"
                End If
                If Len(Trim(Str(d.Second))) = 1 Then
                    t += "0" + Trim(Str(d.Second)) + "."
                Else
                    t += Trim(Str(d.Second)) + "."
                End If
                If Len(Trim(Str(d.Millisecond))) = 1 Then
                    t += "00" + Trim(Str(d.Millisecond)) + "."
                ElseIf Len(Trim(Str(d.Millisecond))) = 2 Then
                    t += "0" + Trim(Str(d.Millisecond)) + "."
                Else
                    t += Trim(Str(d.Millisecond)) + "."
                End If

                Return t
            End Get
        End Property

        Private Sub ButtonBrmSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If startBRM.Checked Then
                startBRM_CheckedChanged(sender, e)
            End If

        End Sub

        Private Sub ButtonPortConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPortConfig.Click
            reader.RemoveEventListener(Me, FeIscListenerConst.RECEIVE_STRING_EVENT)
            reader.RemoveEventListener(Me, FeIscListenerConst.SEND_STRING_EVENT)

            portCfg.ShowDialog()

            If reader.Connected Then
                Try
                    ' query the reader type
                    ReaderInfo = reader.ReadReaderInfo()
                    InitBuffer()
                Catch ex As System.Exception

                End Try

                Try
                    If (ReaderInfo.ReaderType <> FedmIscReaderConst.TYPE_ISCLR200) Then
                        reader.SetProtocolFrameSupport(Fedm.PRT_FRAME_ADVANCED)
                    End If
                    reader.AddEventListener(Me, FeIscListenerConst.RECEIVE_STRING_EVENT)
                    reader.AddEventListener(Me, FeIscListenerConst.SEND_STRING_EVENT)
                Catch ex As System.Exception

                End Try
                Me.resetBrm.Enabled = True
                Me.startBRM.Enabled = True
            Else
                Me.resetBrm.Enabled = False
                Me.startBRM.Enabled = False
            End If
        End Sub

        Public Sub DisplayRecSets(ByVal recSets As Integer, ByVal type() As Byte, ByVal serialNumber() As String, ByVal dataBlock() As String, ByVal timer() As String, ByVal datum() As String, ByVal antennaNr() As Byte, ByVal DictRSSI() As Dictionary(Of Byte, FedmIscRssiItem), ByVal input() As Byte, ByVal state() As Byte)
            Dim dr(50) As String
            Dim i As Integer
            Dim ivitem As ListViewItem
            Dim TabHeader() As String = {"Count", "Tr-Type", "SNR", "DB", "Time", "Date", "Ant-Nr", "RSSI Ant-Nr1", "RSSI Ant-Nr2", "RSSI Ant-Nr3", "RSSI Ant-Nr4", "Input", "State"}
            Dim TabLen As Integer = TabHeader.Length
            Dim cnt As Integer

            Dim RSSIval As Dictionary(Of Byte, FedmIscRssiItem)
            Dim RSSIitem As FedmIscRssiItem
            Dim bcheck As Boolean
            Dim antNo As Byte



            'Table with colmns 
            For cnt = 0 To TabLen - 1
                'Table wiht the same columns
                If ListViewData.Columns.Count > cnt Then
                ElseIf (cnt = 2 Or cnt = 3) Then
                    ListViewData.Columns.Add(TabHeader(cnt), 180, HorizontalAlignment.Left)
                ElseIf (cnt = 4 Or cnt = 5) Then
                    ListViewData.Columns.Add(TabHeader(cnt), 80, HorizontalAlignment.Center)
                ElseIf (cnt = 7 Or cnt = 8 Or cnt = 9 Or cnt = 10) Then
                    ListViewData.Columns.Add(TabHeader(cnt), 80, HorizontalAlignment.Center)
                Else
                    ListViewData.Columns.Add(TabHeader(cnt), 50, HorizontalAlignment.Center)
                End If
            Next
            'for each row in Table
            For i = 0 To recSets - 1
                With ListViewData
                    For cnt = 0 To TabLen - 1
                        dr(cnt) = Trim(Str(count))
                        ivitem = .Items.Add(dr(cnt).ToString)
                        dr(cnt) = ""
                        count = count + 1
                        cnt += 1

                        ' Tag Type
                        If type(i) >= 0 Then
                            dr(cnt) += "0x" + Strings.Right(FeHexConvert.IntegerToHexString(type(i)), 2)
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            dr(cnt) = ""
                            'next column
                            cnt += 1
                        End If

                        ' Serial Number
                        If Not serialNumber(i) Is Nothing Then
                            dr(cnt) += serialNumber(i)
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            dr(cnt) = ""
                            cnt += 1
                        Else
                            dr(cnt) = ""
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            cnt += 1
                        End If

                        ' Data Blocks
                        If Not dataBlock(i) Is Nothing Then
                            'dr(cnt) += FeHexConvert.ByteArrayToHexString(dataBlock(i), 0, dataBlock(i).Length)
                            dr(cnt) += dataBlock(i)
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            dr(cnt) = ""
                            cnt += 1
                        Else
                            dr(cnt) = ""
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            cnt += 1
                        End If

                        ' Time
                        If Not timer(i) Is Nothing Then
                            dr(cnt) += timer(i)
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            dr(cnt) = ""
                            cnt += 1
                        Else
                            dr(cnt) = ""
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            cnt += 1
                        End If

                        ' Date
                        If Not datum(i) Is Nothing Then
                            dr(cnt) += datum(i)
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            dr(cnt) = ""
                            cnt += 1
                        Else
                            dr(cnt) = ""
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            cnt += 1
                        End If

                        'It is possible either to output the ANT_NR or the RSSI value (this is also important for the reader config!)
                        ' Antenna Number
                        If Not antennaNr(i) = 0 Then
                            dr(cnt) += Trim(Str(antennaNr(i)))
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            dr(cnt) = ""
                            cnt += 1
                        Else
                            dr(cnt) = ""
                            ivitem.SubItems.Add(dr(cnt).ToString)
                            cnt += 1
                        End If

                        'It is possible either to output the ANT_NR or the RSSI value (this is also important for the reader config!)
                        'Output RSSI
                        'For antNo = 1 To 4 ' max. 4 Antennas in this sample
                        If DictRSSI.Length <> 0 Then
                            If Not DictRSSI(i) Is Nothing Then
                                RSSIval = DictRSSI(i)
                                For antNo = 1 To 4 ' max. 4 Antennas in this sample
                                    bcheck = RSSIval.TryGetValue(antNo, RSSIitem)
                                    If Not bcheck Then
                                        dr(cnt) += "---"
                                        ivitem.SubItems.Add(dr(cnt).ToString)
                                        dr(cnt) = ""
                                        cnt += 1
                                        Continue For
                                    End If
                                    dr(cnt) += "-" + RSSIitem.RSSI.ToString + "dBm"
                                    ivitem.SubItems.Add(dr(cnt).ToString)
                                    dr(cnt) = ""
                                    cnt += 1
                                Next
                            Else
                                For antNo = 1 To 4 ' max. 4 Antennas in this sample
                                    dr(cnt) += "---"
                                    ivitem.SubItems.Add(dr(cnt).ToString)
                                    dr(cnt) = ""
                                    cnt += 1
                                Next
                            End If
                        End If

                        ' Input
                        dr(cnt) += Trim(Str(input(i)))
                        ivitem.SubItems.Add(dr(cnt).ToString)
                        dr(cnt) = ""
                        cnt += 1

                        ' State
                        dr(cnt) += Trim(Str(state(i)))
                        ivitem.SubItems.Add(dr(cnt).ToString)
                        dr(cnt) = ""
                        ivitem.EnsureVisible()
                    Next
                End With
            Next

        End Sub

        Public Sub ListViewClear()
            ListViewData.Columns.Add("")
        End Sub

        Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
            running = False
            reader.RemoveEventListener(Me, FeIscListenerConst.RECEIVE_STRING_EVENT)
            reader.RemoveEventListener(Me, FeIscListenerConst.SEND_STRING_EVENT)
            portCfg.Close()
            Me.Close()
        End Sub

        Public Overloads Sub OnReceiveProtocol(ByVal reader As FedmIscReader, ByVal receiveProtocol() As Byte) Implements FeIscListener.OnReceiveProtocol
        End Sub

        Public Overloads Sub OnSendProtocol(ByVal reader As FedmIscReader, ByVal sendProtocol() As Byte) Implements FeIscListener.OnSendProtocol
        End Sub

        Public Overloads Sub OnReceiveProtocol(ByVal reader As FedmIscReader, ByVal receiveProtocol As String) Implements FeIscListener.OnReceiveProtocol
            Dim result As IAsyncResult
            Dim method As New DelegateOnRecProtocol(AddressOf DisplayReceiveProtocol)
            result = Invoke(method, receiveProtocol)
        End Sub

        Public Overloads Sub OnSendProtocol(ByVal reader As FedmIscReader, ByVal sendProtocol As String) Implements FeIscListener.OnSendProtocol
            Dim result As IAsyncResult
            Dim method As New DelegateOnSendProtocol(AddressOf DisplaySendProtocol)
            result = Invoke(method, sendProtocol)
        End Sub

        Public Sub DisplayReceiveProtocol(ByVal protocol As String)
            protocolData.Text += protocol
        End Sub

        Public Sub DisplaySendProtocol(ByVal protocol As String)
            protocolData.Text += protocol
        End Sub

        Public Sub ReadThread()
            Dim ReqSets As Integer
            Dim status As Integer
            Dim DisplayRecSetMethod As New DelegateDisplayRecSets(AddressOf DisplayRecSets)
            Dim ListViewClearMethod As New DelegateListViewClear(AddressOf ListViewClear)
            Dim obj(9) As Object
            Dim result As IAsyncResult
            Dim i As Integer
            Dim cnt As Integer

            ReqSets = 255

            While (True)
                If running And reader.Connected Then

                    ' read data from reader
                    ' read max. possible no. of data sets: request 255 data sets

                    Try
                        If (ReaderInfo.ReaderType = FedmIscReaderConst.TYPE_ISCLR200) Then
                            reader.SetData(FedmIscReaderID.FEDM_ISCLR_TMP_BRM_SETS, ReqSets)
                            status = reader.SendProtocol(&H21)
                        Else
                            reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_ADV_BRM_SETS, ReqSets)
                            status = reader.SendProtocol(&H22)
                        End If

                        If (status = &H0) Or _
                           (status = &H83) Or _
                           (status = &H84) Or _
                           (status = &H85) Or _
                           (status = &H93) Or _
                           (status = &H94) Then

                            Dim brmItems() As FedmBrmTableItem
                            brmItems = reader.GetTable(FedmIscReaderConst.BRM_TABLE)

                            If Not brmItems Is Nothing Then
                                Dim serialnumber(brmItems.Length - 1) As String
                                Dim dataBlock(brmItems.Length - 1) As String
                                Dim timer(brmItems.Length - 1) As String
                                Dim readerDate(brmItems.Length - 1) As String
                                Dim type(brmItems.Length - 1) As Byte
                                Dim antennaNr(brmItems.Length - 1) As Byte
                                Dim DictRSSI(brmItems.Length) As Dictionary(Of Byte, FedmIscRssiItem)
                                Dim input(brmItems.Length - 1) As Byte
                                Dim state(brmItems.Length - 1) As Byte

                                Dim db As String

                                'Init
                                DictRSSI(brmItems.Length) = New Dictionary(Of Byte, FedmIscRssiItem)
                                db = ""


                                For i = 0 To brmItems.Length - 1
                                    If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_SNR) Then
                                        brmItems(i).GetData(FedmIscReaderConst.DATA_SNR, serialnumber(i))
                                    End If
                                    If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_RxDB) Then
                                        Dim adr As Integer
                                        ' Note: request of [0x21] Read Buffer contains a valid block address
                                        ' while request of [0x22] Read Buffer has no block address
                                        ' if you need no compatibility with ID ISC.LR200 you should remove adr (is always 0)
                                        adr = brmItems(i).GetBlockAddress()
                                        For cnt = 0 To brmItems(i).GetBlockCount() - 1
                                            brmItems(i).GetData(FedmIscReaderConst.DATA_RxDB, cnt + adr, db)
                                            dataBlock(i) = dataBlock(i) + db
                                        Next

                                    End If

                                    If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_TRTYPE) Then
                                        brmItems(i).GetData(FedmIscReaderConst.DATA_TRTYPE, type(i))
                                    End If

                                    If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_TIMER) Then
                                        timer(i) = brmItems(i).GetReaderTime().GetTime()
                                    End If

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

                                    If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_INPUT) Then
                                        brmItems(i).GetData(FedmIscReaderConst.DATA_INPUT, input(i))
                                        brmItems(i).GetData(FedmIscReaderConst.DATA_STATE, state(i))
                                    End If
                                    If brmItems(i).IsDataValid(FedmIscReaderConst.DATA_DATE) Then
                                        readerDate(i) = brmItems(i).GetReaderTime().GetDate()
                                    End If

                                Next
                                obj(0) = brmItems.Length
                                obj(1) = type
                                obj(2) = serialnumber
                                obj(3) = dataBlock
                                obj(4) = timer
                                obj(5) = readerDate
                                obj(6) = antennaNr
                                obj(7) = DictRSSI
                                obj(8) = input
                                obj(9) = state


                                result = Invoke(DisplayRecSetMethod, obj)
                                ClearBuffer()
                            Else
                                'If not data in Table don't shoe this in ListView
                                result = Invoke(ListViewClearMethod)
                                EndInvoke(result)
                            End If

                        End If
                    Catch ex As System.Exception
                        MessageBox.Show(ex.ToString)
                    End Try
                End If
            End While
        End Sub

        Private Sub ClearBuffer()
            Try
                reader.SendProtocol(&H32)
            Catch ex As FePortDriverException

            End Try

        End Sub

        Private Sub BRMSample_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            running = False
            reader.RemoveEventListener(Me, FeIscListenerConst.RECEIVE_STRING_EVENT)
            reader.RemoveEventListener(Me, FeIscListenerConst.SEND_STRING_EVENT)
            portCfg.Close()
        End Sub

        Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
            Me.ListViewData.Clear()
            count = 1
        End Sub

        Private Sub ButtonClearProt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearProt.Click
            Me.protocolData.Text = ""
        End Sub

        'show the last line in textbox
        Private Sub protocolData_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles protocolData.TextChanged
            Me.protocolData.SelectionStart = Me.protocolData.Text.Length
            Me.protocolData.SelectionLength = Me.protocolData.Text.Length
            Me.protocolData.ScrollToCaret()
            Me.protocolData.Refresh()
        End Sub
    End Class
End Namespace