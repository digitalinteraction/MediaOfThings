'---------------------------------------------------------------
'Copyright © 2003-2004	FEIG ELECTRONIC GmbH, All Rights Reserved.
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
    Public Class BRMSetup
        Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

        Public Sub New(ByRef reader As FedmIscReader)
            MyBase.New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()

            Me.reader = reader
            Me.ComboBoxDbAdr.SelectedIndex = 0
            Me.ComboBoxReadDBN.SelectedIndex = 0
            Me.ComboBoxSourceDBN.SelectedIndex = 0

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
        Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
        Friend WithEvents ButtonSend As System.Windows.Forms.Button
        Friend WithEvents ButtonRead As System.Windows.Forms.Button
        Friend WithEvents ButtonDefault As System.Windows.Forms.Button
        Friend WithEvents ButtonOk As System.Windows.Forms.Button
        Friend WithEvents ButtonCancel As System.Windows.Forms.Button
        Friend WithEvents CheckBoxBrmEnabled As System.Windows.Forms.CheckBox
        Friend WithEvents CheckBoxSerial As System.Windows.Forms.CheckBox
        Friend WithEvents CheckBoxDataBlock As System.Windows.Forms.CheckBox
        Friend WithEvents CheckBoxTime As System.Windows.Forms.CheckBox
        Friend WithEvents ComboBoxDbAdr As System.Windows.Forms.ComboBox
        Friend WithEvents ComboBoxReadDBN As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents RadioButtonSerial As System.Windows.Forms.RadioButton
        Friend WithEvents RadioButtonDataBlock As System.Windows.Forms.RadioButton
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents ComboBoxSourceDBN As System.Windows.Forms.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents TextBoxValidTime As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents CheckBoxAntenna As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.CheckBoxBrmEnabled = New System.Windows.Forms.CheckBox
            Me.GroupBox2 = New System.Windows.Forms.GroupBox
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label1 = New System.Windows.Forms.Label
            Me.ComboBoxReadDBN = New System.Windows.Forms.ComboBox
            Me.ComboBoxDbAdr = New System.Windows.Forms.ComboBox
            Me.CheckBoxTime = New System.Windows.Forms.CheckBox
            Me.CheckBoxDataBlock = New System.Windows.Forms.CheckBox
            Me.CheckBoxSerial = New System.Windows.Forms.CheckBox
            Me.GroupBox3 = New System.Windows.Forms.GroupBox
            Me.Label3 = New System.Windows.Forms.Label
            Me.ComboBoxSourceDBN = New System.Windows.Forms.ComboBox
            Me.RadioButtonDataBlock = New System.Windows.Forms.RadioButton
            Me.RadioButtonSerial = New System.Windows.Forms.RadioButton
            Me.GroupBox4 = New System.Windows.Forms.GroupBox
            Me.Label5 = New System.Windows.Forms.Label
            Me.TextBoxValidTime = New System.Windows.Forms.TextBox
            Me.Label4 = New System.Windows.Forms.Label
            Me.GroupBox5 = New System.Windows.Forms.GroupBox
            Me.ButtonCancel = New System.Windows.Forms.Button
            Me.ButtonOk = New System.Windows.Forms.Button
            Me.GroupBox6 = New System.Windows.Forms.GroupBox
            Me.ButtonDefault = New System.Windows.Forms.Button
            Me.ButtonRead = New System.Windows.Forms.Button
            Me.ButtonSend = New System.Windows.Forms.Button
            Me.CheckBoxAntenna = New System.Windows.Forms.CheckBox
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.GroupBox5.SuspendLayout()
            Me.GroupBox6.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.CheckBoxBrmEnabled)
            Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(296, 48)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "System Modes"
            '
            'CheckBoxBrmEnabled
            '
            Me.CheckBoxBrmEnabled.Checked = True
            Me.CheckBoxBrmEnabled.CheckState = System.Windows.Forms.CheckState.Checked
            Me.CheckBoxBrmEnabled.Location = New System.Drawing.Point(16, 16)
            Me.CheckBoxBrmEnabled.Name = "CheckBoxBrmEnabled"
            Me.CheckBoxBrmEnabled.TabIndex = 0
            Me.CheckBoxBrmEnabled.Text = "BRM enabled"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.CheckBoxAntenna)
            Me.GroupBox2.Controls.Add(Me.Label2)
            Me.GroupBox2.Controls.Add(Me.Label1)
            Me.GroupBox2.Controls.Add(Me.ComboBoxReadDBN)
            Me.GroupBox2.Controls.Add(Me.ComboBoxDbAdr)
            Me.GroupBox2.Controls.Add(Me.CheckBoxTime)
            Me.GroupBox2.Controls.Add(Me.CheckBoxDataBlock)
            Me.GroupBox2.Controls.Add(Me.CheckBoxSerial)
            Me.GroupBox2.Location = New System.Drawing.Point(8, 64)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(296, 128)
            Me.GroupBox2.TabIndex = 1
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Read Data"
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(160, 88)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 16)
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "DB-N"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(160, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 15)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "DB-ADR"
            '
            'ComboBoxReadDBN
            '
            Me.ComboBoxReadDBN.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16"})
            Me.ComboBoxReadDBN.Location = New System.Drawing.Point(208, 89)
            Me.ComboBoxReadDBN.Name = "ComboBoxReadDBN"
            Me.ComboBoxReadDBN.Size = New System.Drawing.Size(64, 21)
            Me.ComboBoxReadDBN.TabIndex = 4
            '
            'ComboBoxDbAdr
            '
            Me.ComboBoxDbAdr.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"})
            Me.ComboBoxDbAdr.Location = New System.Drawing.Point(208, 58)
            Me.ComboBoxDbAdr.Name = "ComboBoxDbAdr"
            Me.ComboBoxDbAdr.Size = New System.Drawing.Size(64, 21)
            Me.ComboBoxDbAdr.TabIndex = 3
            '
            'CheckBoxTime
            '
            Me.CheckBoxTime.Location = New System.Drawing.Point(16, 87)
            Me.CheckBoxTime.Name = "CheckBoxTime"
            Me.CheckBoxTime.TabIndex = 2
            Me.CheckBoxTime.Text = "Time"
            '
            'CheckBoxDataBlock
            '
            Me.CheckBoxDataBlock.Location = New System.Drawing.Point(16, 56)
            Me.CheckBoxDataBlock.Name = "CheckBoxDataBlock"
            Me.CheckBoxDataBlock.TabIndex = 1
            Me.CheckBoxDataBlock.Text = "Data Block"
            '
            'CheckBoxSerial
            '
            Me.CheckBoxSerial.Checked = True
            Me.CheckBoxSerial.CheckState = System.Windows.Forms.CheckState.Checked
            Me.CheckBoxSerial.Location = New System.Drawing.Point(16, 24)
            Me.CheckBoxSerial.Name = "CheckBoxSerial"
            Me.CheckBoxSerial.TabIndex = 0
            Me.CheckBoxSerial.Text = "Serial No."
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.Label3)
            Me.GroupBox3.Controls.Add(Me.ComboBoxSourceDBN)
            Me.GroupBox3.Controls.Add(Me.RadioButtonDataBlock)
            Me.GroupBox3.Controls.Add(Me.RadioButtonSerial)
            Me.GroupBox3.Location = New System.Drawing.Point(8, 200)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(296, 96)
            Me.GroupBox3.TabIndex = 2
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "ID Source"
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(168, 61)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(40, 15)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "DB-N"
            '
            'ComboBoxSourceDBN
            '
            Me.ComboBoxSourceDBN.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"})
            Me.ComboBoxSourceDBN.Location = New System.Drawing.Point(208, 58)
            Me.ComboBoxSourceDBN.Name = "ComboBoxSourceDBN"
            Me.ComboBoxSourceDBN.Size = New System.Drawing.Size(64, 21)
            Me.ComboBoxSourceDBN.TabIndex = 7
            '
            'RadioButtonDataBlock
            '
            Me.RadioButtonDataBlock.Location = New System.Drawing.Point(16, 56)
            Me.RadioButtonDataBlock.Name = "RadioButtonDataBlock"
            Me.RadioButtonDataBlock.TabIndex = 1
            Me.RadioButtonDataBlock.Text = "Data Block"
            '
            'RadioButtonSerial
            '
            Me.RadioButtonSerial.Checked = True
            Me.RadioButtonSerial.Location = New System.Drawing.Point(16, 24)
            Me.RadioButtonSerial.Name = "RadioButtonSerial"
            Me.RadioButtonSerial.TabIndex = 0
            Me.RadioButtonSerial.TabStop = True
            Me.RadioButtonSerial.Text = "Serial No."
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.Label5)
            Me.GroupBox4.Controls.Add(Me.TextBoxValidTime)
            Me.GroupBox4.Controls.Add(Me.Label4)
            Me.GroupBox4.Location = New System.Drawing.Point(8, 304)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(296, 48)
            Me.GroupBox4.TabIndex = 3
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Valid Time"
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(104, 24)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(100, 16)
            Me.Label5.TabIndex = 2
            Me.Label5.Text = "* 100 ms"
            '
            'TextBoxValidTime
            '
            Me.TextBoxValidTime.Location = New System.Drawing.Point(64, 22)
            Me.TextBoxValidTime.Name = "TextBoxValidTime"
            Me.TextBoxValidTime.Size = New System.Drawing.Size(40, 20)
            Me.TextBoxValidTime.TabIndex = 1
            Me.TextBoxValidTime.Text = "10"
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(16, 24)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(48, 16)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "Reader:"
            '
            'GroupBox5
            '
            Me.GroupBox5.Controls.Add(Me.ButtonCancel)
            Me.GroupBox5.Controls.Add(Me.ButtonOk)
            Me.GroupBox5.Location = New System.Drawing.Point(312, 272)
            Me.GroupBox5.Name = "GroupBox5"
            Me.GroupBox5.Size = New System.Drawing.Size(88, 80)
            Me.GroupBox5.TabIndex = 4
            Me.GroupBox5.TabStop = False
            '
            'ButtonCancel
            '
            Me.ButtonCancel.Location = New System.Drawing.Point(16, 48)
            Me.ButtonCancel.Name = "ButtonCancel"
            Me.ButtonCancel.Size = New System.Drawing.Size(56, 23)
            Me.ButtonCancel.TabIndex = 2
            Me.ButtonCancel.Text = "Cancel"
            '
            'ButtonOk
            '
            Me.ButtonOk.Location = New System.Drawing.Point(16, 16)
            Me.ButtonOk.Name = "ButtonOk"
            Me.ButtonOk.Size = New System.Drawing.Size(56, 23)
            Me.ButtonOk.TabIndex = 1
            Me.ButtonOk.Text = "OK"
            '
            'GroupBox6
            '
            Me.GroupBox6.Controls.Add(Me.ButtonDefault)
            Me.GroupBox6.Controls.Add(Me.ButtonRead)
            Me.GroupBox6.Controls.Add(Me.ButtonSend)
            Me.GroupBox6.Location = New System.Drawing.Point(312, 8)
            Me.GroupBox6.Name = "GroupBox6"
            Me.GroupBox6.Size = New System.Drawing.Size(88, 112)
            Me.GroupBox6.TabIndex = 5
            Me.GroupBox6.TabStop = False
            Me.GroupBox6.Text = "E²-Prom"
            '
            'ButtonDefault
            '
            Me.ButtonDefault.Location = New System.Drawing.Point(16, 80)
            Me.ButtonDefault.Name = "ButtonDefault"
            Me.ButtonDefault.Size = New System.Drawing.Size(56, 23)
            Me.ButtonDefault.TabIndex = 2
            Me.ButtonDefault.Text = "default"
            '
            'ButtonRead
            '
            Me.ButtonRead.Location = New System.Drawing.Point(16, 48)
            Me.ButtonRead.Name = "ButtonRead"
            Me.ButtonRead.Size = New System.Drawing.Size(56, 23)
            Me.ButtonRead.TabIndex = 1
            Me.ButtonRead.Text = "read"
            '
            'ButtonSend
            '
            Me.ButtonSend.Location = New System.Drawing.Point(16, 16)
            Me.ButtonSend.Name = "ButtonSend"
            Me.ButtonSend.Size = New System.Drawing.Size(56, 23)
            Me.ButtonSend.TabIndex = 0
            Me.ButtonSend.Text = "send"
            '
            'CheckBoxAntenna
            '
            Me.CheckBoxAntenna.Checked = True
            Me.CheckBoxAntenna.CheckState = System.Windows.Forms.CheckState.Checked
            Me.CheckBoxAntenna.Location = New System.Drawing.Point(160, 24)
            Me.CheckBoxAntenna.Name = "CheckBoxAntenna"
            Me.CheckBoxAntenna.TabIndex = 7
            Me.CheckBoxAntenna.Text = "Antenna No."
            '
            'BRMSetup
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(408, 365)
            Me.Controls.Add(Me.GroupBox6)
            Me.Controls.Add(Me.GroupBox5)
            Me.Controls.Add(Me.GroupBox4)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Name = "BRMSetup"
            Me.Text = "BRM Settings"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox4.ResumeLayout(False)
            Me.GroupBox5.ResumeLayout(False)
            Me.GroupBox6.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub ButtonSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSend.Click
            Dim cfg As Long

            If reader.Connected Then
                ' read configuration parameter from the reader
                Try
                    reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_READ_CFG_ADR, &H8A)
                    reader.SendProtocol(&H80)
                    reader.GetData(FedmIscReaderID.FEDM_ISCLR_EE_SYSG_SYS_MODE, cfg)
                    ' set new configuration values
                    ' mode
                    ' set BRM bit only
                    If Me.CheckBoxBrmEnabled.Checked Then
                        cfg = cfg Or &H1
                    Else
                        cfg = cfg And &HFE
                    End If

                    ' write CFG10
                    reader.SetData(FedmIscReaderID.FEDM_ISCLR_EE_SYSG_SYS_MODE, cfg)
                    reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_WRITE_CFG_ADR, &H8A)
                    reader.SendProtocol(&H81)

                    ' read configuration parameter from reader
                    reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_READ_CFG_ADR, &H8B)
                    reader.SendProtocol(&H80)
                    reader.GetData(FedmIscReaderID.FEDM_ISCLR_EE_BRM_TR_DATA, &H8A)
                    ' set new configuration values
                    ' TR-data
                    cfg = 0
                    If Me.CheckBoxSerial.Checked Then
                        cfg = cfg Or &H1
                    End If
                    If Me.CheckBoxDataBlock.Checked Then
                        cfg = cfg Or &H2
                    End If
                    If Me.CheckBoxAntenna.Checked Then
                        cfg = cfg Or &H10
                    End If
                    If Me.CheckBoxTime.Checked Then
                        cfg = cfg Or &H20
                    End If
                    reader.SetData(FedmIscReaderID.FEDM_ISCLR_EE_BRM_TR_DATA, cfg)

                    ' DB-address
                    cfg = Me.ComboBoxDbAdr.SelectedItem

                    ' DB-N
                    cfg = Me.ComboBoxReadDBN.SelectedItem

                    ' Tr_ID
                    cfg = 0
                    If Me.RadioButtonSerial.Checked Then
                        cfg = &H80
                    End If
                    cfg = cfg Or Me.ComboBoxSourceDBN.SelectedItem
                    reader.SetData(FedmIscReaderID.FEDM_ISCLR_EE_BRM_TR_ID, cfg)

                    ' valid time
                    reader.SetData(FedmIscReaderID.FEDM_ISCLR_EE_BRM_VALID_TIME, Long.Parse(Me.TextBoxValidTime.Text))

                    ' write CFG11
                    reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_WRITE_CFG_ADR, &H8B)
                    reader.SendProtocol(&H81)

                    ' CPU reset
                    reader.SendProtocol(&H63)
                Catch ex As FePortDriverException
                    Exit Try
                Catch ex As FeReaderDriverException

                End Try
            End If
        End Sub

        Private Sub ButtonRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRead.Click
            Dim cfg As Long

            Try
                If reader.Connected Then
                    ' read configuration parameter from the reader
                    ' mode
                    reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_READ_CFG_ADR, &H8A)
                    reader.SendProtocol(&H80)
                    reader.GetData(FedmIscReaderID.FEDM_ISCLR_EE_SYSG_SYS_MODE, cfg)

                    If (cfg And &H1) = &H1 Then
                        Me.CheckBoxBrmEnabled.Checked = True
                    Else
                        Me.CheckBoxBrmEnabled.Checked = False
                    End If

                    ' TR-data
                    reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_READ_CFG_ADR, &H8B)
                    reader.SendProtocol(&H80)
                    reader.GetData(FedmIscReaderID.FEDM_ISCLR_EE_BRM_TR_DATA, cfg)

                    If (cfg And &H1) = &H1 Then
                        Me.CheckBoxSerial.Checked = True
                    Else
                        Me.CheckBoxSerial.Checked = False
                    End If
                    If (cfg And &H10) = &H10 Then
                        Me.CheckBoxAntenna.Checked = True
                    Else
                        Me.CheckBoxAntenna.Checked = False
                    End If
                    If (cfg And &H2) = &H2 Then
                        Me.CheckBoxDataBlock.Checked = True
                    Else
                        Me.CheckBoxDataBlock.Checked = False
                    End If
                    If (cfg And &H20) = &H20 Then
                        Me.CheckBoxTime.Checked = True
                    Else
                        Me.CheckBoxTime.Checked = False
                    End If

                    ' DB-address
                    reader.GetData(FedmIscReaderID.FEDM_ISCLR_EE_BRM_DB_ADR, cfg)
                    Me.ComboBoxDbAdr.SelectedItem = Trim(Str(cfg And &H1F))

                    ' DB-length
                    reader.GetData(FedmIscReaderID.FEDM_ISCLR_EE_BRM_DBN, cfg)
                    Me.ComboBoxReadDBN.SelectedItem = Trim(Str(cfg And &HF))

                    ' ID-mode
                    reader.GetData(FedmIscReaderID.FEDM_ISCLR_EE_BRM_TR_ID, cfg)
                    If (cfg And &H80) = &H80 Then
                        Me.RadioButtonSerial.Checked = True
                    Else
                        Me.RadioButtonDataBlock.Checked = True
                    End If
                    Me.ComboBoxSourceDBN.SelectedItem = Trim(Str(cfg And &H1F))

                    ' valid time
                    reader.GetData(FedmIscReaderID.FEDM_ISCLR_EE_BRM_VALID_TIME, cfg)
                    Me.TextBoxValidTime.Text = cfg

                End If
            Catch ex As FePortDriverException
                Exit Try
            Catch ex As FeReaderDriverException
            End Try
        End Sub

        Private Sub ButtonDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDefault.Click
            If reader.Connected Then
                Try
                    ' reset configuration data 'CFG10' in reader
                    reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_RESET_CFG, &H8A)
                    reader.SendProtocol(&H83)

                    ' reset configuration data 'CFG11' in reader
                    reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_RESET_CFG, &H8B)
                    reader.SendProtocol(&H83)

                    ButtonRead_Click(sender, e)

                    ' CPU reset
                    reader.SendProtocol(&H63)
                Catch ex As FePortDriverException
                    Exit Try
                Catch ex As FeReaderDriverException

                End Try
            End If
        End Sub

        Private Sub ButtonOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOk.Click
            Me.Visible = False
        End Sub

        Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
            Me.Visible = False
        End Sub

        Public Property ReaderProperty() As FedmIscReader
            Get
                Return reader
            End Get
            Set(ByVal Value As FedmIscReader)
                reader = Value
            End Set
        End Property


        Private reader As FedmIscReader
    End Class
End Namespace