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

    Public Class AuthentMifare
        Inherits System.Windows.Forms.Form

        Private fedm As FedmIscReader

#Region " Vom Windows Form Designer generierter Code "

        Public Sub New(ByRef reader As FedmIscReader)
            MyBase.New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()
            ' Init Controls
            Me.ComboBox_KeyLoc.Enabled = True
            Me.ComboBox_KeyLoc.SelectedIndex = 1 ' Key from Reader

            Me.ComboBox_KeyType.Enabled = True
            Me.ComboBox_KeyType.SelectedIndex = 0 ' Key A

            Me.NumericUpDown_DBAdr.Enabled = True
            Me.NumericUpDown_KeyAdr.Enabled = True

            Me.TextBox_Key1.Enabled = False
            Me.TextBox_Key1.Text = "00"

            Me.TextBox_Key2.Enabled = False
            Me.TextBox_Key2.Text = "00"

            Me.TextBox_Key3.Enabled = False
            Me.TextBox_Key3.Text = "00"

            Me.TextBox_Key4.Enabled = False
            Me.TextBox_Key4.Text = "00"

            Me.TextBox_Key5.Enabled = False
            Me.TextBox_Key5.Text = "00"

            Me.TextBox_Key6.Enabled = False
            Me.TextBox_Key6.Text = "00"

            Me.Reader = reader
        End Sub


        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AuthentMifare))
            Me.Label_KeyLoc = New System.Windows.Forms.Label()
            Me.Label_KeyType = New System.Windows.Forms.Label()
            Me.Label_DBAdr = New System.Windows.Forms.Label()
            Me.Label_KeyAdr = New System.Windows.Forms.Label()
            Me.Lable_Key = New System.Windows.Forms.Label()
            Me.NumericUpDown_DBAdr = New System.Windows.Forms.NumericUpDown()
            Me.NumericUpDown_KeyAdr = New System.Windows.Forms.NumericUpDown()
            Me.ComboBox_KeyType = New System.Windows.Forms.ComboBox()
            Me.ComboBox_KeyLoc = New System.Windows.Forms.ComboBox()
            Me.TextBox_Key1 = New System.Windows.Forms.TextBox()
            Me.TextBox_Key2 = New System.Windows.Forms.TextBox()
            Me.TextBox_Key3 = New System.Windows.Forms.TextBox()
            Me.TextBox_Key4 = New System.Windows.Forms.TextBox()
            Me.TextBox_Key5 = New System.Windows.Forms.TextBox()
            Me.TextBox_Key6 = New System.Windows.Forms.TextBox()
            Me.Button_AuthMifare = New System.Windows.Forms.Button()
            Me.Button_Cancel = New System.Windows.Forms.Button()
            CType(Me.NumericUpDown_DBAdr, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericUpDown_KeyAdr, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label_KeyLoc
            '
            Me.Label_KeyLoc.AutoSize = True
            Me.Label_KeyLoc.Location = New System.Drawing.Point(34, 35)
            Me.Label_KeyLoc.Name = "Label_KeyLoc"
            Me.Label_KeyLoc.Size = New System.Drawing.Size(69, 13)
            Me.Label_KeyLoc.TabIndex = 0
            Me.Label_KeyLoc.Text = "Key Location"
            '
            'Label_KeyType
            '
            Me.Label_KeyType.AutoSize = True
            Me.Label_KeyType.Location = New System.Drawing.Point(34, 67)
            Me.Label_KeyType.Name = "Label_KeyType"
            Me.Label_KeyType.Size = New System.Drawing.Size(52, 13)
            Me.Label_KeyType.TabIndex = 1
            Me.Label_KeyType.Text = "Key-Type"
            '
            'Label_DBAdr
            '
            Me.Label_DBAdr.AutoSize = True
            Me.Label_DBAdr.Location = New System.Drawing.Point(34, 106)
            Me.Label_DBAdr.Name = "Label_DBAdr"
            Me.Label_DBAdr.Size = New System.Drawing.Size(71, 13)
            Me.Label_DBAdr.TabIndex = 2
            Me.Label_DBAdr.Text = "DB-Adr. (dec)"
            '
            'Label_KeyAdr
            '
            Me.Label_KeyAdr.AutoSize = True
            Me.Label_KeyAdr.Location = New System.Drawing.Point(34, 147)
            Me.Label_KeyAdr.Name = "Label_KeyAdr"
            Me.Label_KeyAdr.Size = New System.Drawing.Size(74, 13)
            Me.Label_KeyAdr.TabIndex = 3
            Me.Label_KeyAdr.Text = "Key-Adr. (dec)"
            '
            'Lable_Key
            '
            Me.Lable_Key.AutoSize = True
            Me.Lable_Key.Location = New System.Drawing.Point(34, 182)
            Me.Lable_Key.Name = "Lable_Key"
            Me.Lable_Key.Size = New System.Drawing.Size(70, 13)
            Me.Lable_Key.TabIndex = 4
            Me.Lable_Key.Text = "Key (00 .. FF)"
            '
            'NumericUpDown_DBAdr
            '
            Me.NumericUpDown_DBAdr.Location = New System.Drawing.Point(131, 106)
            Me.NumericUpDown_DBAdr.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me.NumericUpDown_DBAdr.Name = "NumericUpDown_DBAdr"
            Me.NumericUpDown_DBAdr.Size = New System.Drawing.Size(50, 20)
            Me.NumericUpDown_DBAdr.TabIndex = 5
            Me.NumericUpDown_DBAdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'NumericUpDown_KeyAdr
            '
            Me.NumericUpDown_KeyAdr.Location = New System.Drawing.Point(131, 140)
            Me.NumericUpDown_KeyAdr.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
            Me.NumericUpDown_KeyAdr.Name = "NumericUpDown_KeyAdr"
            Me.NumericUpDown_KeyAdr.Size = New System.Drawing.Size(50, 20)
            Me.NumericUpDown_KeyAdr.TabIndex = 6
            Me.NumericUpDown_KeyAdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'ComboBox_KeyType
            '
            Me.ComboBox_KeyType.FormattingEnabled = True
            Me.ComboBox_KeyType.Items.AddRange(New Object() {"Key A", "Key B"})
            Me.ComboBox_KeyType.Location = New System.Drawing.Point(131, 67)
            Me.ComboBox_KeyType.Name = "ComboBox_KeyType"
            Me.ComboBox_KeyType.Size = New System.Drawing.Size(121, 21)
            Me.ComboBox_KeyType.TabIndex = 7
            '
            'ComboBox_KeyLoc
            '
            Me.ComboBox_KeyLoc.DisplayMember = "1"
            Me.ComboBox_KeyLoc.FormattingEnabled = True
            Me.ComboBox_KeyLoc.Items.AddRange(New Object() {"Key from Protocol", "Key from Reader"})
            Me.ComboBox_KeyLoc.Location = New System.Drawing.Point(131, 35)
            Me.ComboBox_KeyLoc.Name = "ComboBox_KeyLoc"
            Me.ComboBox_KeyLoc.Size = New System.Drawing.Size(121, 21)
            Me.ComboBox_KeyLoc.TabIndex = 8
            Me.ComboBox_KeyLoc.Tag = ""
            '
            'TextBox_Key1
            '
            Me.TextBox_Key1.Location = New System.Drawing.Point(131, 182)
            Me.TextBox_Key1.MaxLength = 2
            Me.TextBox_Key1.Name = "TextBox_Key1"
            Me.TextBox_Key1.Size = New System.Drawing.Size(22, 20)
            Me.TextBox_Key1.TabIndex = 9
            Me.TextBox_Key1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TextBox_Key2
            '
            Me.TextBox_Key2.Location = New System.Drawing.Point(159, 182)
            Me.TextBox_Key2.MaxLength = 2
            Me.TextBox_Key2.Name = "TextBox_Key2"
            Me.TextBox_Key2.Size = New System.Drawing.Size(22, 20)
            Me.TextBox_Key2.TabIndex = 10
            Me.TextBox_Key2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TextBox_Key3
            '
            Me.TextBox_Key3.Location = New System.Drawing.Point(187, 182)
            Me.TextBox_Key3.MaxLength = 2
            Me.TextBox_Key3.Name = "TextBox_Key3"
            Me.TextBox_Key3.Size = New System.Drawing.Size(22, 20)
            Me.TextBox_Key3.TabIndex = 11
            Me.TextBox_Key3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TextBox_Key4
            '
            Me.TextBox_Key4.Location = New System.Drawing.Point(215, 182)
            Me.TextBox_Key4.MaxLength = 2
            Me.TextBox_Key4.Name = "TextBox_Key4"
            Me.TextBox_Key4.Size = New System.Drawing.Size(22, 20)
            Me.TextBox_Key4.TabIndex = 12
            Me.TextBox_Key4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TextBox_Key5
            '
            Me.TextBox_Key5.Location = New System.Drawing.Point(243, 182)
            Me.TextBox_Key5.MaxLength = 2
            Me.TextBox_Key5.Name = "TextBox_Key5"
            Me.TextBox_Key5.Size = New System.Drawing.Size(22, 20)
            Me.TextBox_Key5.TabIndex = 13
            Me.TextBox_Key5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TextBox_Key6
            '
            Me.TextBox_Key6.Location = New System.Drawing.Point(271, 182)
            Me.TextBox_Key6.MaxLength = 2
            Me.TextBox_Key6.Name = "TextBox_Key6"
            Me.TextBox_Key6.Size = New System.Drawing.Size(22, 20)
            Me.TextBox_Key6.TabIndex = 14
            Me.TextBox_Key6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Button_AuthMifare
            '
            Me.Button_AuthMifare.Location = New System.Drawing.Point(304, 32)
            Me.Button_AuthMifare.Name = "Button_AuthMifare"
            Me.Button_AuthMifare.Size = New System.Drawing.Size(75, 23)
            Me.Button_AuthMifare.TabIndex = 15
            Me.Button_AuthMifare.Text = "Authent"
            Me.Button_AuthMifare.UseVisualStyleBackColor = True
            '
            'Button_Cancel
            '
            Me.Button_Cancel.Location = New System.Drawing.Point(304, 67)
            Me.Button_Cancel.Name = "Button_Cancel"
            Me.Button_Cancel.Size = New System.Drawing.Size(75, 23)
            Me.Button_Cancel.TabIndex = 16
            Me.Button_Cancel.Text = "Cancel"
            Me.Button_Cancel.UseVisualStyleBackColor = True
            '
            'AuthentMifare
            '
            Me.ClientSize = New System.Drawing.Size(403, 218)
            Me.Controls.Add(Me.Button_Cancel)
            Me.Controls.Add(Me.Button_AuthMifare)
            Me.Controls.Add(Me.TextBox_Key6)
            Me.Controls.Add(Me.TextBox_Key5)
            Me.Controls.Add(Me.TextBox_Key4)
            Me.Controls.Add(Me.TextBox_Key3)
            Me.Controls.Add(Me.TextBox_Key2)
            Me.Controls.Add(Me.TextBox_Key1)
            Me.Controls.Add(Me.ComboBox_KeyLoc)
            Me.Controls.Add(Me.ComboBox_KeyType)
            Me.Controls.Add(Me.NumericUpDown_KeyAdr)
            Me.Controls.Add(Me.NumericUpDown_DBAdr)
            Me.Controls.Add(Me.Lable_Key)
            Me.Controls.Add(Me.Label_KeyAdr)
            Me.Controls.Add(Me.Label_DBAdr)
            Me.Controls.Add(Me.Label_KeyType)
            Me.Controls.Add(Me.Label_KeyLoc)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AuthentMifare"
            Me.Text = "Authent Mifare"
            CType(Me.NumericUpDown_DBAdr, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericUpDown_KeyAdr, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label_KeyLoc As System.Windows.Forms.Label
        Friend WithEvents Label_KeyType As System.Windows.Forms.Label
        Friend WithEvents Label_DBAdr As System.Windows.Forms.Label
        Friend WithEvents Label_KeyAdr As System.Windows.Forms.Label
        Friend WithEvents Lable_Key As System.Windows.Forms.Label
        Friend WithEvents NumericUpDown_DBAdr As System.Windows.Forms.NumericUpDown
        Friend WithEvents NumericUpDown_KeyAdr As System.Windows.Forms.NumericUpDown
        Friend WithEvents ComboBox_KeyType As System.Windows.Forms.ComboBox
        Friend WithEvents ComboBox_KeyLoc As System.Windows.Forms.ComboBox
        Friend WithEvents TextBox_Key1 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox_Key2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox_Key3 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox_Key4 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox_Key5 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox_Key6 As System.Windows.Forms.TextBox
        Friend WithEvents Button_AuthMifare As System.Windows.Forms.Button
        Friend WithEvents Button_Cancel As System.Windows.Forms.Button
#End Region

        Private Sub Button_AuthMifare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_AuthMifare.Click
            Dim strKey As String
            Dim bKeyLoc As Byte
            Dim bKeyAdr As Byte
            Dim bDBAdr As Byte
            Dim bKeyType As Byte

            ' get Key
            strKey = String.Concat(Me.TextBox_Key1.Text, Me.TextBox_Key2.Text, Me.TextBox_Key3.Text, Me.TextBox_Key4.Text, Me.TextBox_Key5.Text, Me.TextBox_Key6.Text)

            bKeyLoc = Me.ComboBox_KeyLoc.SelectedIndex
            bKeyAdr = Me.NumericUpDown_KeyAdr.Value
            bDBAdr = Me.NumericUpDown_DBAdr.Value
            bKeyType = Me.ComboBox_KeyType.SelectedIndex

            ' ------ perform Authent Mifare
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_CMD, &HB0)  ' Sub-Command
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_MODE, &H0) ' delete value Mode Byte (MODE_KL and MODE_ADR)
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_MODE_ADR, FedmIscReaderConst.ISO_MODE_SEL) ' Fixed Selected Mode
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_DB_ADR, bDBAdr) ' requested DataBlock Addr
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_KEY_TYPE, bKeyType) ' Key type (A or B)


            If (bKeyLoc = 1) Then
                ' EEPROM Addr. where Key is stored
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_KEY_ADR, bKeyAdr)
            Else
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_ISO14443A_KEY, strKey)
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_MODE_KL, True) ' choose Key Location - from Protocol
            End If

            Try
                fedm.SendProtocol(&HB2)
            Catch ex As System.Exception
                MessageBox.Show(Me, ex.ToString(), "Error")
                Return
            End Try

            ' Close window after authent command
            Me.Close()
        End Sub

        Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Cancel.Click
            Me.Close()
        End Sub

        Private Sub TextBox_Key1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Key1.Leave
            Dim strKey As String
            Dim chKeyValue As Char()
            Dim i As Integer

            strKey = Me.TextBox_Key1.Text
            If strKey.Length <> 2 Then
                MessageBox.Show("Key-No. 1 has a wrong Format! \n Value must be between 00 and FF !")
            End If

            chKeyValue = strKey.ToCharArray()
            For i = 0 To strKey.Length - 1
                If (Not ((chKeyValue(i) >= "0" And chKeyValue(i) <= "9") Or (chKeyValue(i) >= "a" And chKeyValue(i) <= "f") Or (chKeyValue(i) >= "A" And chKeyValue(i) <= "F"))) Then
                    MessageBox.Show("Key-No. 1 has a wrong Format! \n Value must be between 00 and FF !")
                End If
            Next
        End Sub

        Private Sub TextBox_Key2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Key2.Leave
            Dim strKey As String
            Dim chKeyValue As Char()
            Dim i As Integer

            strKey = Me.TextBox_Key2.Text
            If strKey.Length <> 2 Then
                MessageBox.Show("Key-No. 2 has a wrong Format! \n Value must be between 00 and FF !")
            End If

            chKeyValue = strKey.ToCharArray()
            For i = 0 To strKey.Length - 1
                If (Not ((chKeyValue(i) >= "0" And chKeyValue(i) <= "9") Or (chKeyValue(i) >= "a" And chKeyValue(i) <= "f") Or (chKeyValue(i) >= "A" And chKeyValue(i) <= "F"))) Then
                    MessageBox.Show("Key-No. 2 has a wrong Format! \n Value must be between 00 and FF !")
                End If
            Next
        End Sub

        Private Sub TextBox_Key3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Key3.Leave
            Dim strKey As String
            Dim chKeyValue As Char()
            Dim i As Integer

            strKey = Me.TextBox_Key3.Text
            If strKey.Length <> 2 Then
                MessageBox.Show("Key-No. 3 has a wrong Format! \n Value must be between 00 and FF !")
            End If

            chKeyValue = strKey.ToCharArray()
            For i = 0 To strKey.Length - 1
                If (Not ((chKeyValue(i) >= "0" And chKeyValue(i) <= "9") Or (chKeyValue(i) >= "a" And chKeyValue(i) <= "f") Or (chKeyValue(i) >= "A" And chKeyValue(i) <= "F"))) Then
                    MessageBox.Show("Key-No. 3 has a wrong Format! \n Value must be between 00 and FF !")
                End If
            Next
        End Sub

        Private Sub TextBox_Key4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Key4.Leave
            Dim strKey As String
            Dim chKeyValue As Char()
            Dim i As Integer

            strKey = Me.TextBox_Key4.Text
            If strKey.Length <> 2 Then
                MessageBox.Show("Key-No. 4 has a wrong Format! \n Value must be between 00 and FF !")
            End If

            chKeyValue = strKey.ToCharArray()
            For i = 0 To strKey.Length - 1
                If (Not ((chKeyValue(i) >= "0" And chKeyValue(i) <= "9") Or (chKeyValue(i) >= "a" And chKeyValue(i) <= "f") Or (chKeyValue(i) >= "A" And chKeyValue(i) <= "F"))) Then
                    MessageBox.Show("Key-No. 4 has a wrong Format! \n Value must be between 00 and FF !")
                End If
            Next
        End Sub

        Private Sub TextBox_Key5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Key5.Leave
            Dim strKey As String
            Dim chKeyValue As Char()
            Dim i As Integer

            strKey = Me.TextBox_Key5.Text
            If strKey.Length <> 2 Then
                MessageBox.Show("Key-No. 5 has a wrong Format! \n Value must be between 00 and FF !")
            End If

            chKeyValue = strKey.ToCharArray()
            For i = 0 To strKey.Length - 1
                If (Not ((chKeyValue(i) >= "0" And chKeyValue(i) <= "9") Or (chKeyValue(i) >= "a" And chKeyValue(i) <= "f") Or (chKeyValue(i) >= "A" And chKeyValue(i) <= "F"))) Then
                    MessageBox.Show("Key-No. 5 has a wrong Format! \n Value must be between 00 and FF !")
                End If
            Next
        End Sub

        Private Sub TextBox_Key6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Key6.Leave
            Dim strKey As String
            Dim chKeyValue As Char()
            Dim i As Integer

            strKey = Me.TextBox_Key6.Text
            If strKey.Length <> 2 Then
                MessageBox.Show("Key-No. 6 has a wrong Format! \n Value must be between 00 and FF !")
            End If

            chKeyValue = strKey.ToCharArray()
            For i = 0 To strKey.Length - 1
                If (Not ((chKeyValue(i) >= "0" And chKeyValue(i) <= "9") Or (chKeyValue(i) >= "a" And chKeyValue(i) <= "f") Or (chKeyValue(i) >= "A" And chKeyValue(i) <= "F"))) Then
                    MessageBox.Show("Key-No. 6 has a wrong Format! \n Value must be between 00 and FF !")
                End If
            Next
        End Sub

        Public WriteOnly Property Reader()
            Set(ByVal Value)
                fedm = Value
            End Set
        End Property

        Private Sub ComboBox_KeyLoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_KeyLoc.SelectedIndexChanged
            If (Me.ComboBox_KeyLoc.SelectedIndex = 0) Then
                Me.NumericUpDown_KeyAdr.Enabled = False
                Me.TextBox_Key1.Enabled = True
                Me.TextBox_Key2.Enabled = True
                Me.TextBox_Key3.Enabled = True
                Me.TextBox_Key4.Enabled = True
                Me.TextBox_Key5.Enabled = True
                Me.TextBox_Key6.Enabled = True
            Else
                Me.NumericUpDown_KeyAdr.Enabled = True
                Me.TextBox_Key1.Enabled = False
                Me.TextBox_Key2.Enabled = False
                Me.TextBox_Key3.Enabled = False
                Me.TextBox_Key4.Enabled = False
                Me.TextBox_Key5.Enabled = False
                Me.TextBox_Key6.Enabled = False
            End If
        End Sub
    End Class
End Namespace
