<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectSlabTypeForm
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
        Me.slabTypeListBox = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'slabTypeListBox
        '
        Me.slabTypeListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.slabTypeListBox.FormattingEnabled = True
        Me.slabTypeListBox.ItemHeight = 17
        Me.slabTypeListBox.Items.AddRange(New Object() {"", "Percentage", "Value"})
        Me.slabTypeListBox.Location = New System.Drawing.Point(0, 0)
        Me.slabTypeListBox.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.slabTypeListBox.Name = "slabTypeListBox"
        Me.slabTypeListBox.Size = New System.Drawing.Size(120, 71)
        Me.slabTypeListBox.TabIndex = 1
        '
        'SelectSlabTypeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(120, 71)
        Me.Controls.Add(Me.slabTypeListBox)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectSlabTypeForm"
        Me.Text = "SelectSlabTypeForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents slabTypeListBox As ListBox
End Class
