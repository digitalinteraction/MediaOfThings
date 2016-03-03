<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AuthentMYD
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
        Me.Label_KeyAdrTAG = New System.Windows.Forms.Label
        Me.Label_KeyAdrSAM = New System.Windows.Forms.Label
        Me.Label_AuthCntAdr = New System.Windows.Forms.Label
        Me.Label_AuthSequence = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button_AuthMYD = New System.Windows.Forms.Button
        Me.Button_Cancel = New System.Windows.Forms.Button
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(177, 31)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(46, 20)
        Me.NumericUpDown1.TabIndex = 4
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown1.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(177, 66)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {28, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(46, 20)
        Me.NumericUpDown2.TabIndex = 5
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Location = New System.Drawing.Point(177, 104)
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(46, 20)
        Me.NumericUpDown3.TabIndex = 6
        Me.NumericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Accelerated card authentification", "Entire card authentification"})
        Me.ComboBox1.Location = New System.Drawing.Point(177, 150)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(188, 21)
        Me.ComboBox1.TabIndex = 7
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
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.NumericUpDown3)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label_AuthSequence)
        Me.Controls.Add(Me.Label_AuthCntAdr)
        Me.Controls.Add(Me.Label_KeyAdrSAM)
        Me.Controls.Add(Me.Label_KeyAdrTAG)
        Me.Name = "AuthentMYD"
        Me.Text = "Authent my-d"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_KeyAdrTAG As System.Windows.Forms.Label
    Friend WithEvents Label_KeyAdrSAM As System.Windows.Forms.Label
    Friend WithEvents Label_AuthCntAdr As System.Windows.Forms.Label
    Friend WithEvents Label_AuthSequence As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button_AuthMYD As System.Windows.Forms.Button
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button

End Class
