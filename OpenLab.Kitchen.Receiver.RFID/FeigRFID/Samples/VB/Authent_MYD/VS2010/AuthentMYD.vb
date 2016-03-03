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


    Public Class AuthentMYD
        Inherits System.Windows.Forms.Form

        Private fedm As FedmIscReader
        Private mode As Byte
#Region " Vom Windows Form Designer generierter Code "

        Public Sub New(ByRef reader As FedmIscReader)
            MyBase.New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()

            'Init Dialog
            Me.ComboBox_AuthSequence.SelectedIndex = 0


            Me.Reader = reader
        End Sub


        Friend WithEvents Label_KeyAdrTAG As System.Windows.Forms.Label
        Friend WithEvents Label_KeyAdrSAM As System.Windows.Forms.Label
        Friend WithEvents Label_AuthCntAdr As System.Windows.Forms.Label
        Friend WithEvents Label_AuthSequence As System.Windows.Forms.Label
        Friend WithEvents NumericUpDown_KeyAdrTAG As System.Windows.Forms.NumericUpDown
        Friend WithEvents NumericUpDown_KeyAdrSAM As System.Windows.Forms.NumericUpDown
        Friend WithEvents NumericUpDown_AuthCntAdr As System.Windows.Forms.NumericUpDown
        Friend WithEvents ComboBox_AuthSequence As System.Windows.Forms.ComboBox
        Friend WithEvents Button_AuthMYD As System.Windows.Forms.Button
        Friend WithEvents Button_Cancel As System.Windows.Forms.Button

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AuthentMYD))
            Me.Label_KeyAdrTAG = New System.Windows.Forms.Label()
            Me.Label_KeyAdrSAM = New System.Windows.Forms.Label()
            Me.Label_AuthCntAdr = New System.Windows.Forms.Label()
            Me.Label_AuthSequence = New System.Windows.Forms.Label()
            Me.NumericUpDown_KeyAdrTAG = New System.Windows.Forms.NumericUpDown()
            Me.NumericUpDown_KeyAdrSAM = New System.Windows.Forms.NumericUpDown()
            Me.NumericUpDown_AuthCntAdr = New System.Windows.Forms.NumericUpDown()
            Me.ComboBox_AuthSequence = New System.Windows.Forms.ComboBox()
            Me.Button_AuthMYD = New System.Windows.Forms.Button()
            Me.Button_Cancel = New System.Windows.Forms.Button()
            CType(Me.NumericUpDown_KeyAdrTAG, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericUpDown_KeyAdrSAM, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericUpDown_AuthCntAdr, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label_KeyAdrTAG
            '
            Me.Label_KeyAdrTAG.AutoSize = True
            Me.Label_KeyAdrTAG.Location = New System.Drawing.Point(29, 33)
            Me.Label_KeyAdrTAG.Name = "Label_KeyAdrTAG"
            Me.Label_KeyAdrTAG.Size = New System.Drawing.Size(99, 13)
            Me.Label_KeyAdrTAG.TabIndex = 0
            Me.Label_KeyAdrTAG.Text = "Key-Adr. TAG (dec)"
            '
            'Label_KeyAdrSAM
            '
            Me.Label_KeyAdrSAM.AutoSize = True
            Me.Label_KeyAdrSAM.Location = New System.Drawing.Point(29, 68)
            Me.Label_KeyAdrSAM.Name = "Label_KeyAdrSAM"
            Me.Label_KeyAdrSAM.Size = New System.Drawing.Size(100, 13)
            Me.Label_KeyAdrSAM.TabIndex = 1
            Me.Label_KeyAdrSAM.Text = "Key-Adr. SAM (dec)"
            '
            'Label_AuthCntAdr
            '
            Me.Label_AuthCntAdr.AutoSize = True
            Me.Label_AuthCntAdr.Location = New System.Drawing.Point(29, 106)
            Me.Label_AuthCntAdr.Name = "Label_AuthCntAdr"
            Me.Label_AuthCntAdr.Size = New System.Drawing.Size(121, 13)
            Me.Label_AuthCntAdr.TabIndex = 2
            Me.Label_AuthCntAdr.Text = "Auth. Counter Adr. (dec)"
            '
            'Label_AuthSequence
            '
            Me.Label_AuthSequence.AutoSize = True
            Me.Label_AuthSequence.Location = New System.Drawing.Point(29, 153)
            Me.Label_AuthSequence.Name = "Label_AuthSequence"
            Me.Label_AuthSequence.Size = New System.Drawing.Size(96, 13)
            Me.Label_AuthSequence.TabIndex = 3
            Me.Label_AuthSequence.Text = "Authent Sequence"
            '
            'NumericUpDown_KeyAdrTAG
            '
            Me.NumericUpDown_KeyAdrTAG.Location = New System.Drawing.Point(177, 31)
            Me.NumericUpDown_KeyAdrTAG.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
            Me.NumericUpDown_KeyAdrTAG.Minimum = New Decimal(New Integer() {4, 0, 0, 0})
            Me.NumericUpDown_KeyAdrTAG.Name = "NumericUpDown_KeyAdrTAG"
            Me.NumericUpDown_KeyAdrTAG.Size = New System.Drawing.Size(46, 20)
            Me.NumericUpDown_KeyAdrTAG.TabIndex = 4
            Me.NumericUpDown_KeyAdrTAG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.NumericUpDown_KeyAdrTAG.Value = New Decimal(New Integer() {4, 0, 0, 0})
            '
            'NumericUpDown_KeyAdrSAM
            '
            Me.NumericUpDown_KeyAdrSAM.Location = New System.Drawing.Point(177, 66)
            Me.NumericUpDown_KeyAdrSAM.Maximum = New Decimal(New Integer() {28, 0, 0, 0})
            Me.NumericUpDown_KeyAdrSAM.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericUpDown_KeyAdrSAM.Name = "NumericUpDown_KeyAdrSAM"
            Me.NumericUpDown_KeyAdrSAM.Size = New System.Drawing.Size(46, 20)
            Me.NumericUpDown_KeyAdrSAM.TabIndex = 5
            Me.NumericUpDown_KeyAdrSAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.NumericUpDown_KeyAdrSAM.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'NumericUpDown_AuthCntAdr
            '
            Me.NumericUpDown_AuthCntAdr.Location = New System.Drawing.Point(177, 104)
            Me.NumericUpDown_AuthCntAdr.Name = "NumericUpDown_AuthCntAdr"
            Me.NumericUpDown_AuthCntAdr.Size = New System.Drawing.Size(46, 20)
            Me.NumericUpDown_AuthCntAdr.TabIndex = 6
            Me.NumericUpDown_AuthCntAdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.NumericUpDown_AuthCntAdr.Value = New Decimal(New Integer() {3, 0, 0, 0})
            '
            'ComboBox_AuthSequence
            '
            Me.ComboBox_AuthSequence.Cursor = System.Windows.Forms.Cursors.Default
            Me.ComboBox_AuthSequence.FormattingEnabled = True
            Me.ComboBox_AuthSequence.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.ComboBox_AuthSequence.Items.AddRange(New Object() {"Accelerated card authentification", "Entire card authentification"})
            Me.ComboBox_AuthSequence.Location = New System.Drawing.Point(177, 150)
            Me.ComboBox_AuthSequence.Name = "ComboBox_AuthSequence"
            Me.ComboBox_AuthSequence.Size = New System.Drawing.Size(188, 21)
            Me.ComboBox_AuthSequence.TabIndex = 7
            '
            'Button_AuthMYD
            '
            Me.Button_AuthMYD.Location = New System.Drawing.Point(286, 31)
            Me.Button_AuthMYD.Name = "Button_AuthMYD"
            Me.Button_AuthMYD.Size = New System.Drawing.Size(79, 23)
            Me.Button_AuthMYD.TabIndex = 8
            Me.Button_AuthMYD.Text = "Authent"
            Me.Button_AuthMYD.UseVisualStyleBackColor = True
            '
            'Button_Cancel
            '
            Me.Button_Cancel.Location = New System.Drawing.Point(286, 77)
            Me.Button_Cancel.Name = "Button_Cancel"
            Me.Button_Cancel.Size = New System.Drawing.Size(79, 23)
            Me.Button_Cancel.TabIndex = 9
            Me.Button_Cancel.Text = "Cancel"
            Me.Button_Cancel.UseVisualStyleBackColor = True
            '
            'AuthentMYD
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(387, 202)
            Me.Controls.Add(Me.Button_Cancel)
            Me.Controls.Add(Me.Button_AuthMYD)
            Me.Controls.Add(Me.ComboBox_AuthSequence)
            Me.Controls.Add(Me.NumericUpDown_AuthCntAdr)
            Me.Controls.Add(Me.NumericUpDown_KeyAdrSAM)
            Me.Controls.Add(Me.NumericUpDown_KeyAdrTAG)
            Me.Controls.Add(Me.Label_AuthSequence)
            Me.Controls.Add(Me.Label_AuthCntAdr)
            Me.Controls.Add(Me.Label_KeyAdrSAM)
            Me.Controls.Add(Me.Label_KeyAdrTAG)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AuthentMYD"
            Me.Text = "Authent my-d"
            CType(Me.NumericUpDown_KeyAdrTAG, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericUpDown_KeyAdrSAM, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericUpDown_AuthCntAdr, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
#End Region

        Private Sub Button_AuthMYD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_AuthMYD.Click
            Dim keyAddressTag As Integer
            Dim keyAddressSam As Integer
            Dim authCntAddress As Integer
            Dim bAuthSequence As Byte

            keyAddressTag = Me.NumericUpDown_KeyAdrTAG.Value
            keyAddressSam = Me.NumericUpDown_KeyAdrSAM.Value
            authCntAddress = Me.NumericUpDown_AuthCntAdr.Value
            bAuthSequence = Me.ComboBox_AuthSequence.SelectedIndex

            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_KEY_ADR_TAG, keyAddressTag)
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_KEY_ADR_SAM, keyAddressSam)
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_AUTH_COUNTER_ADR, authCntAddress)
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_KEY_AUTH_SEQUENCE, bAuthSequence)
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_MODE_ADR, mode) ' addressed(for ISO15693) or selected(for ISO14443) Mode
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_CMD, &HB1)

            Try
                fedm.SendProtocol(&HB2)
            Catch ex As System.Exception
                MessageBox.Show(Me, ex.ToString(), "Error")
                Return
            End Try

            'Close Dialog
            Me.Close()
        End Sub

        Public Sub setMode(ByVal mode As Byte)
            Me.mode = mode
        End Sub

        Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Cancel.Click
            Me.Close()
        End Sub

        Public WriteOnly Property Reader()
            Set(ByVal Value)
                fedm = Value
            End Set
        End Property

    End Class
End Namespace