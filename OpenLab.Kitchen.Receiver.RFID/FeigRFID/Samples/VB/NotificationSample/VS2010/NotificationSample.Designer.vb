<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotificationSample
	Inherits System.Windows.Forms.Form

	'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso components IsNot Nothing Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Wird vom Windows Form-Designer benötigt.
	Private components As System.ComponentModel.IContainer

	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotificationSample))
        Me.labelData = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonListen = New System.Windows.Forms.CheckBox()
        Me.LabelPortNr = New System.Windows.Forms.Label()
        Me.TextPortNr = New System.Windows.Forms.TextBox()
        Me.ACK = New System.Windows.Forms.CheckBox()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelData
        '
        Me.labelData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelData.Location = New System.Drawing.Point(12, 12)
        Me.labelData.Multiline = True
        Me.labelData.Name = "labelData"
        Me.labelData.ReadOnly = True
        Me.labelData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.labelData.Size = New System.Drawing.Size(1013, 713)
        Me.labelData.TabIndex = 4
        Me.labelData.WordWrap = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ButtonListen)
        Me.GroupBox1.Controls.Add(Me.LabelPortNr)
        Me.GroupBox1.Controls.Add(Me.TextPortNr)
        Me.GroupBox1.Controls.Add(Me.ACK)
        Me.GroupBox1.Location = New System.Drawing.Point(1031, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(136, 151)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Notification Channel"
        '
        'ButtonListen
        '
        Me.ButtonListen.Appearance = System.Windows.Forms.Appearance.Button
        Me.ButtonListen.Location = New System.Drawing.Point(16, 31)
        Me.ButtonListen.Name = "ButtonListen"
        Me.ButtonListen.Size = New System.Drawing.Size(106, 24)
        Me.ButtonListen.TabIndex = 4
        Me.ButtonListen.Text = "Listen"
        Me.ButtonListen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ButtonListen.UseVisualStyleBackColor = True
        '
        'LabelPortNr
        '
        Me.LabelPortNr.AutoSize = True
        Me.LabelPortNr.Location = New System.Drawing.Point(13, 86)
        Me.LabelPortNr.Name = "LabelPortNr"
        Me.LabelPortNr.Size = New System.Drawing.Size(37, 13)
        Me.LabelPortNr.TabIndex = 3
        Me.LabelPortNr.Text = "PortNr"
        '
        'TextPortNr
        '
        Me.TextPortNr.Location = New System.Drawing.Point(64, 83)
        Me.TextPortNr.Name = "TextPortNr"
        Me.TextPortNr.Size = New System.Drawing.Size(57, 20)
        Me.TextPortNr.TabIndex = 2
        Me.TextPortNr.Text = "10005"
        '
        'ACK
        '
        Me.ACK.AutoSize = True
        Me.ACK.Location = New System.Drawing.Point(16, 122)
        Me.ACK.Name = "ACK"
        Me.ACK.Size = New System.Drawing.Size(102, 17)
        Me.ACK.TabIndex = 1
        Me.ACK.Text = "with Ack. [0x32]"
        Me.ACK.UseVisualStyleBackColor = True
        '
        'ButtonClear
        '
        Me.ButtonClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClear.Location = New System.Drawing.Point(1047, 702)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(106, 23)
        Me.ButtonClear.TabIndex = 6
        Me.ButtonClear.Text = "Clear"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'NotificationSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 737)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.labelData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NotificationSample"
        Me.Text = "Notification Sample  -  RFID by FEIG ELECTRONIC"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents labelData As System.Windows.Forms.TextBox
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents LabelPortNr As System.Windows.Forms.Label
	Friend WithEvents TextPortNr As System.Windows.Forms.TextBox
	Friend WithEvents ACK As System.Windows.Forms.CheckBox
	Friend WithEvents ButtonClear As System.Windows.Forms.Button
	Friend WithEvents ButtonListen As System.Windows.Forms.CheckBox

End Class
