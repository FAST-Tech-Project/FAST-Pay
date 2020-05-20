<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayHeadsForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.payHeadsDataGridView = New System.Windows.Forms.DataGridView()
        CType(Me.payHeadsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'payHeadsDataGridView
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Me.payHeadsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.payHeadsDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.payHeadsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.payHeadsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.payHeadsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.payHeadsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.payHeadsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.payHeadsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.payHeadsDataGridView.Name = "payHeadsDataGridView"
        Me.payHeadsDataGridView.RowHeadersVisible = False
        Me.payHeadsDataGridView.Size = New System.Drawing.Size(185, 236)
        Me.payHeadsDataGridView.TabIndex = 10
        '
        'PayHeadsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(185, 236)
        Me.Controls.Add(Me.payHeadsDataGridView)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(201, 275)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(201, 275)
        Me.Name = "PayHeadsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PayHeadsForm"
        CType(Me.payHeadsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents payHeadsDataGridView As DataGridView
End Class
