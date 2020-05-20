<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalarySetupStartTypeFrom
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
        Me.startTypeListBox = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'startTypeListBox
        '
        Me.startTypeListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.startTypeListBox.FormattingEnabled = True
        Me.startTypeListBox.ItemHeight = 17
        Me.startTypeListBox.Items.AddRange(New Object() {"", "Copy From Parent Value", "Start Afresh"})
        Me.startTypeListBox.Location = New System.Drawing.Point(0, 0)
        Me.startTypeListBox.Margin = New System.Windows.Forms.Padding(4)
        Me.startTypeListBox.Name = "startTypeListBox"
        Me.startTypeListBox.Size = New System.Drawing.Size(200, 71)
        Me.startTypeListBox.TabIndex = 0
        '
        'SalarySetupStartTypeFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(200, 71)
        Me.Controls.Add(Me.startTypeListBox)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SalarySetupStartTypeFrom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Start Type"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents startTypeListBox As ListBox
End Class
