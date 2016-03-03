'---------------------------------------------------------------
'Copyright © 2003-2008	FEIG ELECTRONIC GmbH, All Rights Reserved.
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

Imports System

Namespace OBID

    Public Class ISOHostSample
        Inherits System.Windows.Forms.Form
        Implements FeIscListener

#Region " Vom Windows Form Designer generierter Code "

        Public Sub New()
            MyBase.New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()

            ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

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
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents ComboBoxMode As System.Windows.Forms.ComboBox
        Friend WithEvents NumericUpDownDBSize As System.Windows.Forms.NumericUpDown
        Friend WithEvents NumericUpDownDBN As System.Windows.Forms.NumericUpDown
        Friend WithEvents NumericUpDownAdr As System.Windows.Forms.NumericUpDown
        Friend WithEvents ButtonClear As System.Windows.Forms.Button
        Friend WithEvents ButtonWrite As System.Windows.Forms.Button
        Friend WithEvents ButtonRead As System.Windows.Forms.Button
        Friend WithEvents CheckBoxRun As System.Windows.Forms.CheckBox
        Friend WithEvents ButtonClearList As System.Windows.Forms.Button
        Friend WithEvents ButtonProtClear As System.Windows.Forms.Button
        Friend WithEvents CheckBoxEnabled As System.Windows.Forms.CheckBox
        Friend WithEvents ListBoxTags As System.Windows.Forms.ListBox
        Friend WithEvents TextBoxProtocol As System.Windows.Forms.TextBox
        Friend WithEvents ComboBox_MemoryBank As System.Windows.Forms.ComboBox
        Friend WithEvents Label_MemBank As System.Windows.Forms.Label
        Friend WithEvents Button_Auth_Mifare As System.Windows.Forms.Button
        Friend WithEvents Button_Auth_MYD As System.Windows.Forms.Button
        Friend WithEvents HexEdit As HexEditor

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ISOHostSample))
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label_MemBank = New System.Windows.Forms.Label()
            Me.ComboBox_MemoryBank = New System.Windows.Forms.ComboBox()
            Me.HexEdit = New OBID.HexEditor()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ComboBoxMode = New System.Windows.Forms.ComboBox()
            Me.NumericUpDownDBSize = New System.Windows.Forms.NumericUpDown()
            Me.NumericUpDownDBN = New System.Windows.Forms.NumericUpDown()
            Me.NumericUpDownAdr = New System.Windows.Forms.NumericUpDown()
            Me.ButtonClear = New System.Windows.Forms.Button()
            Me.ButtonWrite = New System.Windows.Forms.Button()
            Me.ButtonRead = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Button_Auth_Mifare = New System.Windows.Forms.Button()
            Me.Button_Auth_MYD = New System.Windows.Forms.Button()
            Me.ButtonClearList = New System.Windows.Forms.Button()
            Me.CheckBoxRun = New System.Windows.Forms.CheckBox()
            Me.ListBoxTags = New System.Windows.Forms.ListBox()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.CheckBoxEnabled = New System.Windows.Forms.CheckBox()
            Me.ButtonProtClear = New System.Windows.Forms.Button()
            Me.TextBoxProtocol = New System.Windows.Forms.TextBox()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.GroupBox1.SuspendLayout()
            CType(Me.NumericUpDownDBSize, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericUpDownDBN, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericUpDownAdr, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Controls.Add(Me.Label_MemBank)
            Me.GroupBox1.Controls.Add(Me.ComboBox_MemoryBank)
            Me.GroupBox1.Controls.Add(Me.HexEdit)
            Me.GroupBox1.Controls.Add(Me.Label4)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.ComboBoxMode)
            Me.GroupBox1.Controls.Add(Me.NumericUpDownDBSize)
            Me.GroupBox1.Controls.Add(Me.NumericUpDownDBN)
            Me.GroupBox1.Controls.Add(Me.NumericUpDownAdr)
            Me.GroupBox1.Controls.Add(Me.ButtonClear)
            Me.GroupBox1.Controls.Add(Me.ButtonWrite)
            Me.GroupBox1.Controls.Add(Me.ButtonRead)
            Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(749, 352)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Read/Write Multiple Blocks"
            '
            'Label_MemBank
            '
            Me.Label_MemBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label_MemBank.Location = New System.Drawing.Point(565, 324)
            Me.Label_MemBank.Name = "Label_MemBank"
            Me.Label_MemBank.Size = New System.Drawing.Size(74, 17)
            Me.Label_MemBank.TabIndex = 28
            Me.Label_MemBank.Text = "Memory Bank"
            '
            'ComboBox_MemoryBank
            '
            Me.ComboBox_MemoryBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBox_MemoryBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ComboBox_MemoryBank.Items.AddRange(New Object() {"reserved", "EPC Bank", "TID Bank", "User Bank"})
            Me.ComboBox_MemoryBank.Location = New System.Drawing.Point(645, 322)
            Me.ComboBox_MemoryBank.Name = "ComboBox_MemoryBank"
            Me.ComboBox_MemoryBank.Size = New System.Drawing.Size(96, 21)
            Me.ComboBox_MemoryBank.TabIndex = 27
            '
            'HexEdit
            '
            Me.HexEdit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.HexEdit.ColumnCount = 4
            Me.HexEdit.Location = New System.Drawing.Point(8, 16)
            Me.HexEdit.Name = "HexEdit"
            Me.HexEdit.Size = New System.Drawing.Size(551, 329)
            Me.HexEdit.TabIndex = 26
            '
            'Label4
            '
            Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label4.Location = New System.Drawing.Point(565, 298)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(37, 16)
            Me.Label4.TabIndex = 25
            Me.Label4.Text = "Mode"
            '
            'Label3
            '
            Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label3.Location = New System.Drawing.Point(565, 273)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(52, 16)
            Me.Label3.TabIndex = 24
            Me.Label3.Text = "DB-Size"
            '
            'Label2
            '
            Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label2.Location = New System.Drawing.Point(565, 246)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(39, 16)
            Me.Label2.TabIndex = 23
            Me.Label2.Text = "DBN"
            '
            'Label1
            '
            Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label1.Location = New System.Drawing.Point(565, 225)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(33, 16)
            Me.Label1.TabIndex = 22
            Me.Label1.Text = "ADR"
            '
            'ComboBoxMode
            '
            Me.ComboBoxMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ComboBoxMode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.ComboBoxMode.Items.AddRange(New Object() {"non addressed", "addressed", "selected"})
            Me.ComboBoxMode.Location = New System.Drawing.Point(645, 295)
            Me.ComboBoxMode.Name = "ComboBoxMode"
            Me.ComboBoxMode.Size = New System.Drawing.Size(96, 21)
            Me.ComboBoxMode.TabIndex = 8
            '
            'NumericUpDownDBSize
            '
            Me.NumericUpDownDBSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericUpDownDBSize.Location = New System.Drawing.Point(693, 271)
            Me.NumericUpDownDBSize.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
            Me.NumericUpDownDBSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericUpDownDBSize.Name = "NumericUpDownDBSize"
            Me.NumericUpDownDBSize.Size = New System.Drawing.Size(48, 20)
            Me.NumericUpDownDBSize.TabIndex = 7
            Me.NumericUpDownDBSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'NumericUpDownDBN
            '
            Me.NumericUpDownDBN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericUpDownDBN.Location = New System.Drawing.Point(693, 247)
            Me.NumericUpDownDBN.Maximum = New Decimal(New Integer() {128, 0, 0, 0})
            Me.NumericUpDownDBN.Name = "NumericUpDownDBN"
            Me.NumericUpDownDBN.Size = New System.Drawing.Size(48, 20)
            Me.NumericUpDownDBN.TabIndex = 6
            '
            'NumericUpDownAdr
            '
            Me.NumericUpDownAdr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericUpDownAdr.Location = New System.Drawing.Point(693, 223)
            Me.NumericUpDownAdr.Maximum = New Decimal(New Integer() {128, 0, 0, 0})
            Me.NumericUpDownAdr.Name = "NumericUpDownAdr"
            Me.NumericUpDownAdr.Size = New System.Drawing.Size(48, 20)
            Me.NumericUpDownAdr.TabIndex = 5
            '
            'ButtonClear
            '
            Me.ButtonClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonClear.Location = New System.Drawing.Point(667, 86)
            Me.ButtonClear.Name = "ButtonClear"
            Me.ButtonClear.Size = New System.Drawing.Size(75, 23)
            Me.ButtonClear.TabIndex = 4
            Me.ButtonClear.Text = "&Clear"
            '
            'ButtonWrite
            '
            Me.ButtonWrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonWrite.Location = New System.Drawing.Point(667, 44)
            Me.ButtonWrite.Name = "ButtonWrite"
            Me.ButtonWrite.Size = New System.Drawing.Size(75, 24)
            Me.ButtonWrite.TabIndex = 3
            Me.ButtonWrite.Text = "&Write"
            '
            'ButtonRead
            '
            Me.ButtonRead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonRead.Location = New System.Drawing.Point(667, 16)
            Me.ButtonRead.Name = "ButtonRead"
            Me.ButtonRead.Size = New System.Drawing.Size(75, 23)
            Me.ButtonRead.TabIndex = 1
            Me.ButtonRead.Text = "&Read"
            '
            'GroupBox2
            '
            Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox2.Controls.Add(Me.Button_Auth_Mifare)
            Me.GroupBox2.Controls.Add(Me.Button_Auth_MYD)
            Me.GroupBox2.Controls.Add(Me.ButtonClearList)
            Me.GroupBox2.Controls.Add(Me.CheckBoxRun)
            Me.GroupBox2.Controls.Add(Me.ListBoxTags)
            Me.GroupBox2.Location = New System.Drawing.Point(763, 8)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(368, 352)
            Me.GroupBox2.TabIndex = 3
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "TagList"
            '
            'Button_Auth_Mifare
            '
            Me.Button_Auth_Mifare.Location = New System.Drawing.Point(278, 230)
            Me.Button_Auth_Mifare.Name = "Button_Auth_Mifare"
            Me.Button_Auth_Mifare.Size = New System.Drawing.Size(83, 44)
            Me.Button_Auth_Mifare.TabIndex = 4
            Me.Button_Auth_Mifare.Text = "Authent Mifare"
            Me.Button_Auth_Mifare.UseVisualStyleBackColor = True
            '
            'Button_Auth_MYD
            '
            Me.Button_Auth_MYD.Location = New System.Drawing.Point(278, 293)
            Me.Button_Auth_MYD.Name = "Button_Auth_MYD"
            Me.Button_Auth_MYD.Size = New System.Drawing.Size(83, 47)
            Me.Button_Auth_MYD.TabIndex = 3
            Me.Button_Auth_MYD.Text = "Authent my-d"
            Me.Button_Auth_MYD.UseVisualStyleBackColor = True
            '
            'ButtonClearList
            '
            Me.ButtonClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonClearList.Location = New System.Drawing.Point(280, 56)
            Me.ButtonClearList.Name = "ButtonClearList"
            Me.ButtonClearList.Size = New System.Drawing.Size(75, 23)
            Me.ButtonClearList.TabIndex = 2
            Me.ButtonClearList.Text = "C&lear"
            '
            'CheckBoxRun
            '
            Me.CheckBoxRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxRun.Appearance = System.Windows.Forms.Appearance.Button
            Me.CheckBoxRun.Location = New System.Drawing.Point(280, 24)
            Me.CheckBoxRun.Name = "CheckBoxRun"
            Me.CheckBoxRun.Size = New System.Drawing.Size(75, 23)
            Me.CheckBoxRun.TabIndex = 0
            Me.CheckBoxRun.Text = "R&un"
            Me.CheckBoxRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ListBoxTags
            '
            Me.ListBoxTags.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ListBoxTags.Location = New System.Drawing.Point(6, 24)
            Me.ListBoxTags.Name = "ListBoxTags"
            Me.ListBoxTags.Size = New System.Drawing.Size(266, 316)
            Me.ListBoxTags.TabIndex = 1
            '
            'GroupBox3
            '
            Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox3.Controls.Add(Me.CheckBoxEnabled)
            Me.GroupBox3.Controls.Add(Me.ButtonProtClear)
            Me.GroupBox3.Controls.Add(Me.TextBoxProtocol)
            Me.GroupBox3.Controls.Add(Me.GroupBox4)
            Me.GroupBox3.Location = New System.Drawing.Point(8, 369)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(1124, 191)
            Me.GroupBox3.TabIndex = 4
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Protocol Window"
            '
            'CheckBoxEnabled
            '
            Me.CheckBoxEnabled.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxEnabled.Location = New System.Drawing.Point(1035, 48)
            Me.CheckBoxEnabled.Name = "CheckBoxEnabled"
            Me.CheckBoxEnabled.Size = New System.Drawing.Size(72, 24)
            Me.CheckBoxEnabled.TabIndex = 3
            Me.CheckBoxEnabled.Text = "Enabled"
            '
            'ButtonProtClear
            '
            Me.ButtonProtClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonProtClear.Location = New System.Drawing.Point(1035, 16)
            Me.ButtonProtClear.Name = "ButtonProtClear"
            Me.ButtonProtClear.Size = New System.Drawing.Size(75, 23)
            Me.ButtonProtClear.TabIndex = 2
            Me.ButtonProtClear.Text = "Cl&ear"
            '
            'TextBoxProtocol
            '
            Me.TextBoxProtocol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxProtocol.Location = New System.Drawing.Point(8, 16)
            Me.TextBoxProtocol.Multiline = True
            Me.TextBoxProtocol.Name = "TextBoxProtocol"
            Me.TextBoxProtocol.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.TextBoxProtocol.Size = New System.Drawing.Size(1019, 168)
            Me.TextBoxProtocol.TabIndex = 1
            Me.TextBoxProtocol.WordWrap = False
            '
            'GroupBox4
            '
            Me.GroupBox4.Location = New System.Drawing.Point(8, -232)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(352, 232)
            Me.GroupBox4.TabIndex = 0
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Read/Write Multiple Blocks"
            '
            'ISOHostSample
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1139, 566)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.GroupBox2)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ISOHostSample"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "ISOHostModeSample  -  FEIG ELECTRONIC  -  advanced reader technology"
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.NumericUpDownDBSize, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericUpDownDBN, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericUpDownAdr, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Delegate Sub DelegateLastError(ByVal err As String)
        Delegate Sub DelegateTagChanged(ByVal tagType() As String, ByVal serialNumber() As String)
        Delegate Sub DelegateTagListClear()
        Delegate Sub DelegateOnSendProtocol(ByVal protocol As String)
        Delegate Sub DelegateOnRecProtocol(ByVal protocol As String)

        Private config As PortConfig
        Private authmifare_config As AuthentMifare
        Private authMYD_config As AuthentMYD
        Private fedm As FedmIscReader
        Private serialNumber As String
        Private serialNumberLen As Byte
        Private BnkIdx As Integer
        Private running As Boolean
        Private IsUhfTag As Boolean
        Private persistenceResetTime As UInteger
        Private myThread As New Threading.Thread(AddressOf ReadThread)

        Private Sub ISOHostSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            fedm = New FedmIscReader
            'Event Listener
            fedm.AddEventListener(Me, FeIscListenerConst.SEND_STRING_EVENT)
            fedm.AddEventListener(Me, FeIscListenerConst.RECEIVE_STRING_EVENT)

            fedm.SetTableSize(FedmIscReaderConst.ISO_TABLE, 128)

            ' Init Dialogs
            config = New PortConfig(fedm)
            config.ShowDialog()

            ' Get Reader Info
            Dim Back As Integer
            persistenceResetTime = 0

            authmifare_config = New AuthentMifare(fedm)
            authMYD_config = New AuthentMYD(fedm)

            ' set Persistence Reset Time in Reader Configuration to zero
            ' this speeds up inventory cycles
            Back = -150 'OBID.Fedm.ERROR_UNSUPPORTED_NAMESPACE

            Try
                Back = fedm.TestConfigPara(OBID.ReaderConfig.Transponder.PersistenceReset.Antenna.No1.PersistenceResetTime)
            Catch ex As System.Exception
                'ignore Exception
            End Try

            ' if reader supports this parameter, set it !
            If (Back = 0) Then
                Try
                    Back = fedm.GetConfigPara(OBID.ReaderConfig.Transponder.PersistenceReset.Antenna.No1.PersistenceResetTime, persistenceResetTime, False)
                    Back = fedm.SetConfigPara(OBID.ReaderConfig.Transponder.PersistenceReset.Antenna.No1.PersistenceResetTime, 0, False)
                    If (Back = 1) Then ' return value 1 indicates modified parameter
                        Back = fedm.ApplyConfiguration(False)
                    End If

                Catch ex As System.Exception
                    MessageBox.Show(Me, ex.ToString(), "Error")
                End Try
            End If

            Me.ComboBoxMode.SelectedIndex = 1

            ' set the blockSize
            Me.NumericUpDownDBSize.Minimum = 1
            Me.NumericUpDownDBSize.Maximum = 16
            Me.NumericUpDownDBSize.Increment = 1
            Me.NumericUpDownDBSize.Value = 4

            ' set the number of blocks
            Me.NumericUpDownDBN.Minimum = 1
            Me.NumericUpDownDBN.Maximum = 255
            Me.NumericUpDownDBN.Increment = 1
            Me.NumericUpDownDBN.Value = 1

            Me.CheckBoxEnabled.Checked = True

            ' set Memory Bank for UHF tags
            Me.ComboBox_MemoryBank.SelectedIndex = 3
            Me.ComboBox_MemoryBank.Enabled = False

            'Init Authent Buttons
            Me.Button_Auth_Mifare.Enabled = False
            Me.Button_Auth_MYD.Enabled = False

            running = False
            myThread.IsBackground = True
            myThread.Start()
        End Sub

        Private Sub ComboBoxMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMode.SelectedIndexChanged

        End Sub

        Private Sub NumericUpDownDBSize_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDownDBSize.ValueChanged
            HexEdit.SetSize(HexEdit.RowCount, Me.NumericUpDownDBSize.Value)
        End Sub

        Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
            Dim i As Integer
            Dim initData As Byte() = {0, 0, 0, 0}

            HexEdit.SetSize(128, 4)
            For i = 0 To 128
                HexEdit.InsertData((i) * 4, initData)
            Next
            HexEdit.Refresh()
            Me.NumericUpDownDBSize.Value = 4
        End Sub

        Private Sub ButtonClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearList.Click
            ListBoxTags.Items.Clear()

            ' Refresh Dialog
            Me.ComboBox_MemoryBank.Enabled = False
            Me.Button_Auth_Mifare.Enabled = False
            Me.Button_Auth_MYD.Enabled = False
        End Sub

        Private Sub ButtonRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRead.Click
            Dim data As Byte()
            Dim blockSize As Byte
            Dim idx As Integer
            Dim dbn As Integer
            Dim address As Integer
            Dim mode As Integer
            Dim back As Integer
            Dim datalocation As Long
            ' Init Variables
            datalocation = FedmIscReaderConst.DATA_RxDB

            mode = Me.ComboBoxMode.SelectedIndex

            If (mode = 0) And (Me.ListBoxTags.Items.Count > 2) Then
                MessageBox.Show(Me, "Too much transponder in the reader field for address mode 'non-addressed'.", "Error")
                Return
            End If

            Dim selRow As Integer
            selRow = Me.ListBoxTags.SelectedIndex
            If (selRow = -1) Then
                MessageBox.Show(Me, "There was no tag selected.", "Error")
                Return
            End If

            ' set IscTable-Parameter
            dbn = Me.NumericUpDownDBN.Value
            address = Me.NumericUpDownAdr.Value
            Try
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, &H0)
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_UID, serialNumber)
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, &H23)
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DBN, dbn)
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, mode)

                'If uhfTransponder is found 
                If (IsUhfTag = True) Then
                    If (mode = 2) Then
                        MessageBox.Show("UHF Transponder cannot be read in mode selected mode.")
                        Return
                    End If

                    BnkIdx = Me.ComboBox_MemoryBank.SelectedIndex

                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_UID_LF, True)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_EXT_ADR, True)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_UID_LEN, serialNumberLen)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_BANK, &H0)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_BANK_BANK_NR, BnkIdx)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_ACCESS_PW_LENGTH, &H0)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_ADR_EXT, address)
                End If

                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_ADR, address)

            Catch ex As System.Exception
                MessageBox.Show(Me, ex.ToString(), "Error")
            End Try

            ' Send ReadMultipleBlocks-Protocol
            Try
                back = fedm.SendProtocol(&HB0)
            Catch ex As System.Exception
                MessageBox.Show(Me, ex.ToString(), "Error")
                Return
            End Try

            If back > 0 Then
                MessageBox.Show("No Transponder in Field or other Error!")
                Return
            End If

            Select Case mode
                Case 0
                    idx = 0
                Case 1
                    idx = fedm.FindTableIndex(0, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR, serialNumber)
                Case 2
                    idx = fedm.FindTableIndex(0, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_IS_SELECTED, True)
                Case Else
                    Return
            End Select

            If (IsUhfTag = True) Then
                If (mode = 2) Then
                    MessageBox.Show("UHF Transponder cannot be read in mode selected mode.")
                End If

                BnkIdx = Me.ComboBox_MemoryBank.SelectedIndex

                Select Case BnkIdx
                    Case 0
                        datalocation = FedmIscReaderConst.DATA_RxDB_RES_BANK
                    Case 1
                        datalocation = FedmIscReaderConst.DATA_RxDB_EPC_BANK
                    Case 2
                        datalocation = FedmIscReaderConst.DATA_RxDB_TID_BANK
                    Case 3
                        datalocation = FedmIscReaderConst.DATA_RxDB
                    Case Else
                        datalocation = FedmIscReaderConst.DATA_RxDB_EPC_BANK
                End Select
            End If

            ' get blockSize from ISC-table, default = 4
            Dim item As FedmTableItem
            Try
                item = fedm.GetTableItem(idx, FedmIscReaderConst.ISO_TABLE)
                item.GetData(FedmIscReaderConst.DATA_BLOCK_SIZE, blockSize)
            Catch ex As System.Exception
                MessageBox.Show(Me, ex.ToString(), "Error")
                Return
            End Try
            If blockSize = 0 Then blockSize = 4 ' default value

            ' set current blockSize
            Me.NumericUpDownDBSize.Value = blockSize
            HexEdit.SetSize(128, blockSize)

            ' Set DataBlockData from ResponseBuffer to HexEdit
            Dim i As Integer
            For i = 0 To dbn - 1
                item.GetData(datalocation, address + i, data)
                HexEdit.InsertData((address + i) * blockSize, data)
            Next
        End Sub

        Private Sub CheckBoxRun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxRun.CheckedChanged
            If Me.CheckBoxRun.Checked Then
                running = True
                Me.ButtonRead.Enabled = False
                ButtonWrite.Enabled = False
                CheckBoxRun.Text = "Sto&p"
            Else
                ButtonRead.Enabled = True
                ButtonWrite.Enabled = True
                CheckBoxRun.Text = "R&un"
                running = False
            End If
        End Sub

        Public Sub TagChanged(ByVal tagType() As String, ByVal serialNumber() As String)
            Dim i As Integer

            If running Then
                ListBoxTags.Items.Clear()
                For i = 0 To serialNumber.Length - 1
                    If Not ListBoxTags.Items.Contains(serialNumber(i)) Then
                        ListBoxTags.Items.Add(serialNumber(i) + " - " + tagType(i))
                    End If
                Next
            End If
        End Sub

        Public Sub TagListClear()
            If running Then
                ListBoxTags.Items.Clear()
            End If
        End Sub

        Public Sub LastError(ByVal err As String)
            CheckBoxRun.Checked = False
            CheckBoxRun.Text = "R&un"
            MessageBox.Show(Me, err, "Error")
        End Sub

        Private Sub ButtonWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWrite.Click
            Dim data As Byte()
            Dim blockSize As Integer
            Dim dbn As Integer
            Dim address As Integer
            Dim idx As Integer
            Dim mode As Integer
            Dim datalocation As Long

            mode = Me.ComboBoxMode.SelectedIndex
            If (mode = 0) And (Me.ListBoxTags.Items.Count > 2) Then
                MessageBox.Show(Me, "Too much transponder in the reader field for address mode 'non-addressed'.", "Error")
                Return
            End If

            Dim selRow As Integer
            selRow = Me.ListBoxTags.SelectedIndex
            If selRow = -1 Then
                MessageBox.Show(Me, "There was no tag selected.", "Error")
                Return
            End If

            ' set IscTable-Parameter
            dbn = Me.NumericUpDownDBN.Value
            address = Me.NumericUpDownAdr.Value
            blockSize = Me.NumericUpDownDBSize.Value

            Try
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, &H24) ' write multiple blocks
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DBN, dbn)
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_ADR, address)
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, mode)
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_UID, serialNumber)
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_SIZE, blockSize)
                ' if uhfTransponder is found 
                If (IsUhfTag) Then
                    BnkIdx = Me.ComboBox_MemoryBank.SelectedIndex
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_UID_LF, True)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_EXT_ADR, True)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_UID_LEN, serialNumberLen)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_BANK, &H0)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_BANK_BANK_NR, BnkIdx)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_ACCESS_PW_LENGTH, &H0)
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_ADR_EXT, address)
                End If

            Catch ex As System.Exception
                MessageBox.Show(Me, ex.ToString(), "Error")
                Return
            End Try

            Select Case mode
                Case 0
                    idx = 0
                Case 1
                    idx = fedm.FindTableIndex(0, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR, serialNumber)
                Case 2
                    idx = fedm.FindTableIndex(0, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_IS_SELECTED, True)
                Case Else
                    Return
            End Select
            Dim item As FedmTableItem
            Try
                item = fedm.GetTableItem(idx, FedmIscReaderConst.ISO_TABLE)
            Catch ex As System.Exception
                MessageBox.Show(Me, ex.ToString(), "Error")
                Return
            End Try

            data = HexEdit.GetData(0, HexEdit.RowCount * HexEdit.ColumnCount)
            item.SetData(FedmIscReaderConst.DATA_BLOCK_SIZE, blockSize)

            Dim i As Integer
            For i = address To address + dbn - 1
                Dim datablock(blockSize) As Byte
                System.Array.Copy(data, i * blockSize, datablock, 0, blockSize)
                'default Data Location - User Data
                datalocation = FedmIscReaderConst.DATA_TxDB
                'for uhftransponder
                If (IsUhfTag = True) Then
                    BnkIdx = Me.ComboBox_MemoryBank.SelectedIndex
                    Select Case BnkIdx
                        Case 0
                            datalocation = FedmIscReaderConst.DATA_TxDB_RES_BANK
                        Case 1
                            datalocation = FedmIscReaderConst.DATA_TxDB_EPC_BANK
                        Case 2
                            datalocation = FedmIscReaderConst.DATA_TxDB_TID_BANK
                        Case 3
                            datalocation = FedmIscReaderConst.DATA_TxDB
                    End Select
                End If

                item.SetData(datalocation, i, datablock)

            Next

            Try
                fedm.SetTableItem(idx, item)
            Catch ex As System.Exception
                MessageBox.Show(Me, e.ToString(), "Error")
                Return
            End Try

            'Send WriteMultipleBlocks-Protocol
            Try
                fedm.SendProtocol(&HB0)
            Catch ex As System.Exception
                MessageBox.Show(Me, e.ToString(), "Error")
                Return
            End Try

        End Sub

        Private Sub ListBoxTags_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxTags.SelectedIndexChanged
            Dim selRow As Integer
            Dim mode As Integer
            Dim index As Integer
            Dim iBack As Integer
            Dim tagType As String
            'Init variables
            tagType = "00"


            selRow = Me.ListBoxTags.SelectedIndex
            If selRow = -1 Then
                MessageBox.Show(Me, "There was no tag selected.", "Error")
                Return
            End If

            serialNumber = Me.ListBoxTags.SelectedItem()

            ' only use the serial number out of the whole string
            index = serialNumber.IndexOf(" -")
            If (index > 0) Then
                'extract serial number
                serialNumber = serialNumber.Remove(index)
            End If
            ' Length of serialnumber - important for UHF tags
            serialNumberLen = Convert.ToByte(serialNumber.Length / 2)

            ' Get Mode
            fedm.GetTableData(selRow, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_TRTYPE, tagType)
            If (tagType.Equals("04") Or tagType.Equals("05")) Then
                mode = FedmIscReaderConst.ISO_MODE_SEL
                ' Enable Authent Buttons
                Me.Button_Auth_Mifare.Enabled = True
                Me.Button_Auth_MYD.Enabled = True
                Me.ComboBox_MemoryBank.Enabled = False
                IsUhfTag = False
            ElseIf (tagType.Equals("84")) Then
                Me.Button_Auth_Mifare.Enabled = False
                Me.Button_Auth_MYD.Enabled = False
                Me.ComboBox_MemoryBank.Enabled = True
                IsUhfTag = True
            Else
                mode = Me.ComboBoxMode.SelectedIndex
                Me.Button_Auth_Mifare.Enabled = False
                Me.Button_Auth_MYD.Enabled = True
                Me.ComboBox_MemoryBank.Enabled = False
                IsUhfTag = False
            End If

            ' prepare Protocol
            Try
                iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_UID, serialNumber)
                If (tagType.Equals("04") Or tagType.Equals("05")) Then
                    iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_UID, serialNumber)
                End If
            Catch ex As System.Exception
                MessageBox.Show(Me, ex.ToString(), "Error")
            End Try

            ' If tag is ISO14443 perform a "[0x25] Select" command in addressed mode
            If (mode = 2) Then
                Try
                    Me.ComboBoxMode.SelectedIndex = 2
                    iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, &H1)   ' in addressed mode
                    iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, &H25)   ' Select command
                    iBack = fedm.SendProtocol(&HB0)                                   ' Send Protocol to reader
                Catch ex As System.Exception
                    MessageBox.Show(Me, ex.ToString(), "Error")
                End Try
            End If
        End Sub

        Public Overloads Sub OnReceiveProtocol(ByVal reader As FedmIscReader, ByVal receiveProtocol() As Byte) Implements FeIscListener.OnReceiveProtocol
        End Sub

        Public Overloads Sub OnReceiveProtocol(ByVal reader As FedmIscReader, ByVal receiveProtocol As String) Implements FeIscListener.OnReceiveProtocol
            Dim result As IAsyncResult
            Dim method As New DelegateOnRecProtocol(AddressOf DisplayReceiveProtocol)
            If running Then
                result = Invoke(method, receiveProtocol)
            End If
        End Sub

        Public Overloads Sub OnSendProtocol(ByVal reader As FedmIscReader, ByVal sendProtocol() As Byte) Implements FeIscListener.OnSendProtocol
        End Sub

        Public Overloads Sub OnSendProtocol(ByVal reader As FedmIscReader, ByVal sendProtocol As String) Implements FeIscListener.OnSendProtocol
            Dim result As IAsyncResult
            Dim method As New DelegateOnSendProtocol(AddressOf DisplaySendProtocol)
            If running Then
                result = Invoke(method, sendProtocol)
            End If
        End Sub

        Public Sub DisplayReceiveProtocol(ByVal protocol As String)
            If Me.CheckBoxEnabled.Checked Then
                Me.TextBoxProtocol.Text += protocol
            End If
        End Sub

        Public Sub DisplaySendProtocol(ByVal protocol As String)
            If Me.CheckBoxEnabled.Checked Then
                Me.TextBoxProtocol.Text += protocol
            End If
        End Sub

        Private Sub CheckBoxEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxEnabled.CheckedChanged
            If fedm Is Nothing Then Exit Sub
            If CheckBoxEnabled.Checked Then
                fedm.AddEventListener(Me, FeIscListenerConst.SEND_STRING_EVENT)
                fedm.AddEventListener(Me, FeIscListenerConst.RECEIVE_STRING_EVENT)
            Else
                fedm.RemoveEventListener(Me, FeIscListenerConst.SEND_STRING_EVENT)
                fedm.RemoveEventListener(Me, FeIscListenerConst.RECEIVE_STRING_EVENT)
            End If
        End Sub

        Private Sub ButtonProtClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonProtClear.Click
            Me.TextBoxProtocol.Text = ""
        End Sub

        Public Sub ReadThread()
            Dim back As Int32
            Dim LastErrorMethod As New DelegateLastError(AddressOf LastError)
            Dim TagChangedMethod As New DelegateTagChanged(AddressOf TagChanged)
            Dim TagListClearMethod As New DelegateTagListClear(AddressOf TagListClear)
            Dim obj1(0) As Object
            Dim obj2(1) As Object
            Dim result As IAsyncResult

            While (True)
                If running Then
                    Dim tagType As String()
                    Dim serialNumber As String()

                    Try
                        back = fedm.ResetTable(FedmIscReaderConst.ISO_TABLE)

                        back = fedm.SendProtocol(&H69) ' RFReset

                        back = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, 1)
                        back = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, 0)
                        back = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_SIZE, 4)

                        'back = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_ANT, True)
                        'back = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_ANT_SEL, &H2) ' for ANT2, &HF for all 4 antennas, &H4 for ANT3, &H8 for ANT4


                        back = fedm.SendProtocol(&HB0) ' ISOCmd


                        While fedm.GetLastStatus = &H94 ' more flag set?
                            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_MORE, &H1)
                            fedm.SendProtocol(&HB0)
                        End While

                        ReDim serialNumber(fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE) - 1)
                        ReDim tagType(fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE) - 1)

                        Console.WriteLine("number of tags in response: " + fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE).ToString())
                        If fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE) > 0 Then
                            Dim i As Integer
                            For i = 0 To fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE) - 1
                                fedm.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR, serialNumber(i))
                                fedm.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_TRTYPE, tagType(i))
                                If tagType(i).Equals("00") Then tagType(i) = "Philips I-Code1"
                                If tagType(i).Equals("01") Then tagType(i) = "Texas Instruments Tag-it HF"
                                If tagType(i).Equals("03") Then tagType(i) = "ISO15693 Tag"
                                If tagType(i).Equals("04") Then tagType(i) = "ISO14443A Tag"
                                If tagType(i).Equals("05") Then tagType(i) = "ISO14443B Tag"
                                If tagType(i).Equals("06") Then tagType(i) = "EPC Tag"
                                If tagType(i).Equals("84") Then tagType(i) = "UHF EPC Gen2 Tag"
                            Next
                            obj2(0) = tagType
                            obj2(1) = serialNumber
                            result = BeginInvoke(TagChangedMethod, obj2)
                            EndInvoke(result)
                        Else
                            result = BeginInvoke(TagListClearMethod)
                            EndInvoke(result)
                        End If

                    Catch ex As Exception
                        obj1(0) = ex.ToString()
                        result = BeginInvoke(LastErrorMethod, obj1)
                        EndInvoke(result)
                        running = False
                    End Try
                End If
            End While
        End Sub

        Private Sub ISOHostSample_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            ' stop reading
            running = False
            Dim Back As Integer


            ' set Persistence Reset Time in Reader Configuration back to old value
            Back = -150 'OBID.Fedm.ERROR_UNSUPPORTED_NAMESPACE

            Try
                Back = fedm.TestConfigPara(OBID.ReaderConfig.Transponder.PersistenceReset.Antenna.No1.PersistenceResetTime)
            Catch ex As System.Exception
                'ignore Exception
            End Try

            ' if reader supports this parameter, set it !
            If (Back = 0) Then
                Try
                    Back = fedm.SetConfigPara(OBID.ReaderConfig.Transponder.PersistenceReset.Antenna.No1.PersistenceResetTime, persistenceResetTime, False)
                    If (Back = 1) Then ' return value 1 indicates modified parameter
                        Back = fedm.ApplyConfiguration(False)
                    End If

                Catch ex As System.Exception
                    MessageBox.Show(Me, ex.ToString(), "Error")
                End Try
            End If

            ' remove event handler
            fedm.RemoveEventListener(Me, FeIscListenerConst.SEND_STRING_EVENT)
            fedm.RemoveEventListener(Me, FeIscListenerConst.RECEIVE_STRING_EVENT)

            ' close port
            config.Close()
        End Sub

        Private Sub Button_Auth_Mifare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Auth_Mifare.Click
            authmifare_config.ShowDialog()
        End Sub

        Private Sub Button_AuthMYD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Auth_MYD.Click
            Dim mode As Byte

            mode = Me.ComboBoxMode.SelectedIndex
            authMYD_config.setMode(mode)
            authMYD_config.ShowDialog()
        End Sub
    End Class
End Namespace

