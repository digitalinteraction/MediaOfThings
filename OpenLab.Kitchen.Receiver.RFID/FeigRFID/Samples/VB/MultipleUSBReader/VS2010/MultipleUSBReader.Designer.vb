<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultipleUSBReader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultipleUSBReader))
        Me.GroupBoxUSBReaderList = New System.Windows.Forms.GroupBox()
        Me.LabelReadSumtitel = New System.Windows.Forms.Label()
        Me.LabelReadersSum = New System.Windows.Forms.Label()
        Me.ListBoxUSBReader = New System.Windows.Forms.ListBox()
        Me.GroupBoxTaglist = New System.Windows.Forms.GroupBox()
        Me.Button_CleanListBoxTag = New System.Windows.Forms.Button()
        Me.LabelTagsNumberTitel = New System.Windows.Forms.Label()
        Me.LabelTagsnumber = New System.Windows.Forms.Label()
        Me.ButtonInventory = New System.Windows.Forms.Button()
        Me.ListBoxTag = New System.Windows.Forms.ListBox()
        Me.GroupBoxProtocolWindow = New System.Windows.Forms.GroupBox()
        Me.TextBoxProtocol = New System.Windows.Forms.TextBox()
        Me.ButtonClean = New System.Windows.Forms.Button()
        Me.GroupBoxUSBReaderList.SuspendLayout()
        Me.GroupBoxTaglist.SuspendLayout()
        Me.GroupBoxProtocolWindow.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxUSBReaderList
        '
        Me.GroupBoxUSBReaderList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxUSBReaderList.Controls.Add(Me.LabelReadSumtitel)
        Me.GroupBoxUSBReaderList.Controls.Add(Me.LabelReadersSum)
        Me.GroupBoxUSBReaderList.Controls.Add(Me.ListBoxUSBReader)
        Me.GroupBoxUSBReaderList.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxUSBReaderList.Name = "GroupBoxUSBReaderList"
        Me.GroupBoxUSBReaderList.Size = New System.Drawing.Size(297, 177)
        Me.GroupBoxUSBReaderList.TabIndex = 0
        Me.GroupBoxUSBReaderList.TabStop = False
        Me.GroupBoxUSBReaderList.Text = "USBReaderList"
        '
        'LabelReadSumtitel
        '
        Me.LabelReadSumtitel.AutoSize = True
        Me.LabelReadSumtitel.Location = New System.Drawing.Point(3, 19)
        Me.LabelReadSumtitel.Name = "LabelReadSumtitel"
        Me.LabelReadSumtitel.Size = New System.Drawing.Size(159, 13)
        Me.LabelReadSumtitel.TabIndex = 4
        Me.LabelReadSumtitel.Text = "Number of connected Readers :"
        Me.LabelReadSumtitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelReadersSum
        '
        Me.LabelReadersSum.AutoSize = True
        Me.LabelReadersSum.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelReadersSum.Location = New System.Drawing.Point(168, 19)
        Me.LabelReadersSum.Name = "LabelReadersSum"
        Me.LabelReadersSum.Size = New System.Drawing.Size(13, 13)
        Me.LabelReadersSum.TabIndex = 3
        Me.LabelReadersSum.Text = "0"
        '
        'ListBoxUSBReader
        '
        Me.ListBoxUSBReader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxUSBReader.FormattingEnabled = True
        Me.ListBoxUSBReader.Location = New System.Drawing.Point(6, 45)
        Me.ListBoxUSBReader.Name = "ListBoxUSBReader"
        Me.ListBoxUSBReader.ScrollAlwaysVisible = True
        Me.ListBoxUSBReader.Size = New System.Drawing.Size(285, 121)
        Me.ListBoxUSBReader.TabIndex = 0
        '
        'GroupBoxTaglist
        '
        Me.GroupBoxTaglist.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxTaglist.Controls.Add(Me.Button_CleanListBoxTag)
        Me.GroupBoxTaglist.Controls.Add(Me.LabelTagsNumberTitel)
        Me.GroupBoxTaglist.Controls.Add(Me.LabelTagsnumber)
        Me.GroupBoxTaglist.Controls.Add(Me.ButtonInventory)
        Me.GroupBoxTaglist.Controls.Add(Me.ListBoxTag)
        Me.GroupBoxTaglist.Location = New System.Drawing.Point(331, 12)
        Me.GroupBoxTaglist.Name = "GroupBoxTaglist"
        Me.GroupBoxTaglist.Size = New System.Drawing.Size(393, 177)
        Me.GroupBoxTaglist.TabIndex = 1
        Me.GroupBoxTaglist.TabStop = False
        Me.GroupBoxTaglist.Text = "TagList"
        '
        'Button_CleanListBoxTag
        '
        Me.Button_CleanListBoxTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_CleanListBoxTag.Location = New System.Drawing.Point(305, 134)
        Me.Button_CleanListBoxTag.Name = "Button_CleanListBoxTag"
        Me.Button_CleanListBoxTag.Size = New System.Drawing.Size(82, 32)
        Me.Button_CleanListBoxTag.TabIndex = 4
        Me.Button_CleanListBoxTag.Text = "Clean"
        Me.Button_CleanListBoxTag.UseVisualStyleBackColor = True
        '
        'LabelTagsNumberTitel
        '
        Me.LabelTagsNumberTitel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelTagsNumberTitel.AutoSize = True
        Me.LabelTagsNumberTitel.Location = New System.Drawing.Point(6, 19)
        Me.LabelTagsNumberTitel.Name = "LabelTagsNumberTitel"
        Me.LabelTagsNumberTitel.Size = New System.Drawing.Size(190, 13)
        Me.LabelTagsNumberTitel.TabIndex = 3
        Me.LabelTagsNumberTitel.Text = "Number of Tags on selceted Readers :"
        Me.LabelTagsNumberTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTagsnumber
        '
        Me.LabelTagsnumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelTagsnumber.AutoSize = True
        Me.LabelTagsnumber.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelTagsnumber.Location = New System.Drawing.Point(202, 19)
        Me.LabelTagsnumber.Name = "LabelTagsnumber"
        Me.LabelTagsnumber.Size = New System.Drawing.Size(13, 13)
        Me.LabelTagsnumber.TabIndex = 2
        Me.LabelTagsnumber.Text = "0"
        '
        'ButtonInventory
        '
        Me.ButtonInventory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonInventory.Location = New System.Drawing.Point(305, 45)
        Me.ButtonInventory.Name = "ButtonInventory"
        Me.ButtonInventory.Size = New System.Drawing.Size(82, 33)
        Me.ButtonInventory.TabIndex = 1
        Me.ButtonInventory.Text = "Inventory"
        Me.ButtonInventory.UseVisualStyleBackColor = True
        '
        'ListBoxTag
        '
        Me.ListBoxTag.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxTag.FormattingEnabled = True
        Me.ListBoxTag.HorizontalScrollbar = True
        Me.ListBoxTag.Location = New System.Drawing.Point(9, 45)
        Me.ListBoxTag.Name = "ListBoxTag"
        Me.ListBoxTag.ScrollAlwaysVisible = True
        Me.ListBoxTag.Size = New System.Drawing.Size(275, 121)
        Me.ListBoxTag.TabIndex = 0
        '
        'GroupBoxProtocolWindow
        '
        Me.GroupBoxProtocolWindow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxProtocolWindow.Controls.Add(Me.TextBoxProtocol)
        Me.GroupBoxProtocolWindow.Controls.Add(Me.ButtonClean)
        Me.GroupBoxProtocolWindow.Location = New System.Drawing.Point(12, 195)
        Me.GroupBoxProtocolWindow.Name = "GroupBoxProtocolWindow"
        Me.GroupBoxProtocolWindow.Size = New System.Drawing.Size(712, 203)
        Me.GroupBoxProtocolWindow.TabIndex = 2
        Me.GroupBoxProtocolWindow.TabStop = False
        Me.GroupBoxProtocolWindow.Text = "ProtocolWindow"
        '
        'TextBoxProtocol
        '
        Me.TextBoxProtocol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxProtocol.Location = New System.Drawing.Point(6, 19)
        Me.TextBoxProtocol.Multiline = True
        Me.TextBoxProtocol.Name = "TextBoxProtocol"
        Me.TextBoxProtocol.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxProtocol.Size = New System.Drawing.Size(597, 169)
        Me.TextBoxProtocol.TabIndex = 2
        '
        'ButtonClean
        '
        Me.ButtonClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClean.Location = New System.Drawing.Point(624, 156)
        Me.ButtonClean.Name = "ButtonClean"
        Me.ButtonClean.Size = New System.Drawing.Size(82, 32)
        Me.ButtonClean.TabIndex = 1
        Me.ButtonClean.Text = "Clean"
        Me.ButtonClean.UseVisualStyleBackColor = True
        '
        'MultipleUSBReader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 410)
        Me.Controls.Add(Me.GroupBoxProtocolWindow)
        Me.Controls.Add(Me.GroupBoxTaglist)
        Me.Controls.Add(Me.GroupBoxUSBReaderList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MultipleUSBReader"
        Me.Text = "MultipleUSBReaderSample  -  FEIG ELECTRONIC  -  advanced reader technology"
        Me.GroupBoxUSBReaderList.ResumeLayout(False)
        Me.GroupBoxUSBReaderList.PerformLayout()
        Me.GroupBoxTaglist.ResumeLayout(False)
        Me.GroupBoxTaglist.PerformLayout()
        Me.GroupBoxProtocolWindow.ResumeLayout(False)
        Me.GroupBoxProtocolWindow.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxUSBReaderList As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxTaglist As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxProtocolWindow As System.Windows.Forms.GroupBox
    Friend WithEvents ListBoxUSBReader As System.Windows.Forms.ListBox
    Friend WithEvents ButtonInventory As System.Windows.Forms.Button
    Friend WithEvents ListBoxTag As System.Windows.Forms.ListBox
    Friend WithEvents ButtonClean As System.Windows.Forms.Button
    Friend WithEvents LabelReadersSum As System.Windows.Forms.Label
    Friend WithEvents LabelReadSumtitel As System.Windows.Forms.Label
    Friend WithEvents LabelTagsNumberTitel As System.Windows.Forms.Label
    Friend WithEvents LabelTagsnumber As System.Windows.Forms.Label
    Friend WithEvents TextBoxProtocol As System.Windows.Forms.TextBox
    Friend WithEvents Button_CleanListBoxTag As System.Windows.Forms.Button

End Class
