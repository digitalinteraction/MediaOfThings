<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AuthentMifare
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button_AuthMifare = New System.Windows.Forms.Button
        Me.Button_Cancel = New System.Windows.Forms.Button
        Me.Label_KeyLoc = New System.Windows.Forms.Label
        Me.Label_KeyType = New System.Windows.Forms.Label
        Me.Lable_DBAdr = New System.Windows.Forms.Label
        Me.Label_KeyAdr = New System.Windows.Forms.Label
        Me.Label_Key = New System.Windows.Forms.Label
        Me.NumericUpDown_KeyAdr = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown_DBAdr = New System.Windows.Forms.NumericUpDown
        Me.ComboBox_KeyType = New System.Windows.Forms.ComboBox
        Me.ComboBox_KeyLoc = New System.Windows.Forms.ComboBox
        Me.TextBox_Key1 = New System.Windows.Forms.TextBox
        Me.TextBox_Key2 = New System.Windows.Forms.TextBox
        Me.TextBox_Key3 = New System.Windows.Forms.TextBox
        Me.TextBox_Key4 = New System.Windows.Forms.TextBox
        Me.TextBox_Key5 = New System.Windows.Forms.TextBox
        Me.TextBox_Key6 = New System.Windows.Forms.TextBox
        CType(Me.NumericUpDown_KeyAdr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_DBAdr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_AuthMifare
        '
        Me.Button_AuthMifare.Location = New System.Drawing.Point(278, 22)
        Me.Button_AuthMifare.Name = "Button_AuthMifare"
        Me.Button_AuthMifare.Size = New System.Drawing.Size(75, 23)
        Me.Button_AuthMifare.TabIndex = 0
        Me.Button_AuthMifare.Text = "Authent"
        Me.Button_AuthMifare.UseVisualStyleBackColor = True
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Location = New System.Drawing.Point(278, 66)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cancel.TabIndex = 1
        Me.Button_Cancel.Text = "Cancel"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Label_KeyLoc
        '
        Me.Label_KeyLoc.AutoSize = True
        Me.Label_KeyLoc.Location = New System.Drawing.Point(13, 25)
        Me.Label_KeyLoc.Name = "Label_KeyLoc"
        Me.Label_KeyLoc.Size = New System.Drawing.Size(69, 13)
        Me.Label_KeyLoc.TabIndex = 2
        Me.Label_KeyLoc.Text = "Key Location"
        '
        'Label_KeyType
        '
        Me.Label_KeyType.AutoSize = True
        Me.Label_KeyType.Location = New System.Drawing.Point(12, 51)
        Me.Label_KeyType.Name = "Label_KeyType"
        Me.Label_KeyType.Size = New System.Drawing.Size(52, 13)
        Me.Label_KeyType.TabIndex = 3
        Me.Label_KeyType.Text = "Key-Type"
        '
        'Lable_DBAdr
        '
        Me.Lable_DBAdr.AutoSize = True
        Me.Lable_DBAdr.Location = New System.Drawing.Point(12, 82)
        Me.Lable_DBAdr.Name = "Lable_DBAdr"
        Me.Lable_DBAdr.Size = New System.Drawing.Size(71, 13)
        Me.Lable_DBAdr.TabIndex = 4
        Me.Lable_DBAdr.Text = "DB-Adr. (dec)"
        '
        'Label_KeyAdr
        '
        Me.Label_KeyAdr.AutoSize = True
        Me.Label_KeyAdr.Location = New System.Drawing.Point(13, 108)
        Me.Label_KeyAdr.Name = "Label_KeyAdr"
        Me.Label_KeyAdr.Size = New System.Drawing.Size(74, 13)
        Me.Label_KeyAdr.TabIndex = 5
        Me.Label_KeyAdr.Text = "Key-Adr. (dec)"
        '
        'Label_Key
        '
        Me.Label_Key.AutoSize = True
        Me.Label_Key.Location = New System.Drawing.Point(13, 144)
        Me.Label_Key.Name = "Label_Key"
        Me.Label_Key.Size = New System.Drawing.Size(70, 13)
        Me.Label_Key.TabIndex = 6
        Me.Label_Key.Text = "Key (00 .. FF)"
        '
        'NumericUpDown_KeyAdr
        '
        Me.NumericUpDown_KeyAdr.Location = New System.Drawing.Point(111, 106)
        Me.NumericUpDown_KeyAdr.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.NumericUpDown_KeyAdr.Name = "NumericUpDown_KeyAdr"
        Me.NumericUpDown_KeyAdr.Size = New System.Drawing.Size(46, 20)
        Me.NumericUpDown_KeyAdr.TabIndex = 7
        Me.NumericUpDown_KeyAdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NumericUpDown_DBAdr
        '
        Me.NumericUpDown_DBAdr.Location = New System.Drawing.Point(111, 80)
        Me.NumericUpDown_DBAdr.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NumericUpDown_DBAdr.Name = "NumericUpDown_DBAdr"
        Me.NumericUpDown_DBAdr.Size = New System.Drawing.Size(46, 20)
        Me.NumericUpDown_DBAdr.TabIndex = 8
        Me.NumericUpDown_DBAdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBox_KeyType
        '
        Me.ComboBox_KeyType.FormattingEnabled = True
        Me.ComboBox_KeyType.Items.AddRange(New Object() {"Key A", "Key B"})
        Me.ComboBox_KeyType.Location = New System.Drawing.Point(111, 48)
        Me.ComboBox_KeyType.Name = "ComboBox_KeyType"
        Me.ComboBox_KeyType.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_KeyType.TabIndex = 9
        '
        'ComboBox_KeyLoc
        '
        Me.ComboBox_KeyLoc.FormattingEnabled = True
        Me.ComboBox_KeyLoc.Items.AddRange(New Object() {"Key from Reader", "Key from Protocol"})
        Me.ComboBox_KeyLoc.Location = New System.Drawing.Point(111, 22)
        Me.ComboBox_KeyLoc.Name = "ComboBox_KeyLoc"
        Me.ComboBox_KeyLoc.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_KeyLoc.TabIndex = 10
        '
        'TextBox_Key1
        '
        Me.TextBox_Key1.Location = New System.Drawing.Point(111, 141)
        Me.TextBox_Key1.MaxLength = 2
        Me.TextBox_Key1.Name = "TextBox_Key1"
        Me.TextBox_Key1.Size = New System.Drawing.Size(21, 20)
        Me.TextBox_Key1.TabIndex = 11
        Me.TextBox_Key1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_Key2
        '
        Me.TextBox_Key2.Location = New System.Drawing.Point(138, 141)
        Me.TextBox_Key2.MaxLength = 2
        Me.TextBox_Key2.Name = "TextBox_Key2"
        Me.TextBox_Key2.Size = New System.Drawing.Size(21, 20)
        Me.TextBox_Key2.TabIndex = 12
        Me.TextBox_Key2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_Key3
        '
        Me.TextBox_Key3.Location = New System.Drawing.Point(165, 141)
        Me.TextBox_Key3.MaxLength = 2
        Me.TextBox_Key3.Name = "TextBox_Key3"
        Me.TextBox_Key3.Size = New System.Drawing.Size(21, 20)
        Me.TextBox_Key3.TabIndex = 13
        Me.TextBox_Key3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_Key4
        '
        Me.TextBox_Key4.Location = New System.Drawing.Point(192, 141)
        Me.TextBox_Key4.MaxLength = 2
        Me.TextBox_Key4.Name = "TextBox_Key4"
        Me.TextBox_Key4.Size = New System.Drawing.Size(21, 20)
        Me.TextBox_Key4.TabIndex = 14
        Me.TextBox_Key4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_Key5
        '
        Me.TextBox_Key5.Location = New System.Drawing.Point(219, 141)
        Me.TextBox_Key5.MaxLength = 2
        Me.TextBox_Key5.Name = "TextBox_Key5"
        Me.TextBox_Key5.Size = New System.Drawing.Size(21, 20)
        Me.TextBox_Key5.TabIndex = 15
        Me.TextBox_Key5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_Key6
        '
        Me.TextBox_Key6.Location = New System.Drawing.Point(246, 141)
        Me.TextBox_Key6.MaxLength = 2
        Me.TextBox_Key6.Name = "TextBox_Key6"
        Me.TextBox_Key6.Size = New System.Drawing.Size(21, 20)
        Me.TextBox_Key6.TabIndex = 16
        Me.TextBox_Key6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AuthentMifare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 176)
        Me.Controls.Add(Me.TextBox_Key6)
        Me.Controls.Add(Me.TextBox_Key5)
        Me.Controls.Add(Me.TextBox_Key4)
        Me.Controls.Add(Me.TextBox_Key3)
        Me.Controls.Add(Me.TextBox_Key2)
        Me.Controls.Add(Me.TextBox_Key1)
        Me.Controls.Add(Me.ComboBox_KeyLoc)
        Me.Controls.Add(Me.ComboBox_KeyType)
        Me.Controls.Add(Me.NumericUpDown_DBAdr)
        Me.Controls.Add(Me.NumericUpDown_KeyAdr)
        Me.Controls.Add(Me.Label_Key)
        Me.Controls.Add(Me.Label_KeyAdr)
        Me.Controls.Add(Me.Lable_DBAdr)
        Me.Controls.Add(Me.Label_KeyType)
        Me.Controls.Add(Me.Label_KeyLoc)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_AuthMifare)
        Me.Name = "AuthentMifare"
        Me.Text = "Authent Mifare"
        CType(Me.NumericUpDown_KeyAdr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_DBAdr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_AuthMifare As System.Windows.Forms.Button
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label_KeyLoc As System.Windows.Forms.Label
    Friend WithEvents Label_KeyType As System.Windows.Forms.Label
    Friend WithEvents Lable_DBAdr As System.Windows.Forms.Label
    Friend WithEvents Label_KeyAdr As System.Windows.Forms.Label
    Friend WithEvents Label_Key As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown_KeyAdr As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown_DBAdr As System.Windows.Forms.NumericUpDown
    Friend WithEvents ComboBox_KeyType As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox_KeyLoc As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox_Key1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Key2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Key3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Key4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Key5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Key6 As System.Windows.Forms.TextBox

End Class
