<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagHandlerSample
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TagHandlerSample))
        Me.BtnConnect = New System.Windows.Forms.Button()
        Me.BtnInventory = New System.Windows.Forms.Button()
        Me.BtnTagAction = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnConnect
        '
        Me.BtnConnect.Location = New System.Drawing.Point(53, 24)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Size = New System.Drawing.Size(75, 23)
        Me.BtnConnect.TabIndex = 0
        Me.BtnConnect.Text = "Connect"
        Me.BtnConnect.UseVisualStyleBackColor = True
        '
        'BtnInventory
        '
        Me.BtnInventory.Location = New System.Drawing.Point(53, 72)
        Me.BtnInventory.Name = "BtnInventory"
        Me.BtnInventory.Size = New System.Drawing.Size(75, 23)
        Me.BtnInventory.TabIndex = 1
        Me.BtnInventory.Text = "Inventory"
        Me.BtnInventory.UseVisualStyleBackColor = True
        '
        'BtnTagAction
        '
        Me.BtnTagAction.Location = New System.Drawing.Point(53, 122)
        Me.BtnTagAction.Name = "BtnTagAction"
        Me.BtnTagAction.Size = New System.Drawing.Size(75, 23)
        Me.BtnTagAction.TabIndex = 2
        Me.BtnTagAction.Text = "Tag Action"
        Me.BtnTagAction.UseVisualStyleBackColor = True
        '
        'TagHandlerSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(186, 163)
        Me.Controls.Add(Me.BtnTagAction)
        Me.Controls.Add(Me.BtnInventory)
        Me.Controls.Add(Me.BtnConnect)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TagHandlerSample"
        Me.Text = "TagHandlerSample"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnConnect As System.Windows.Forms.Button
    Friend WithEvents BtnInventory As System.Windows.Forms.Button
    Friend WithEvents BtnTagAction As System.Windows.Forms.Button

End Class
