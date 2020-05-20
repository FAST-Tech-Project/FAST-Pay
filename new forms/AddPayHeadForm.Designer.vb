<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPayHeadForm
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
        Me.PayHeadsDataGridView = New System.Windows.Forms.DataGridView()
        CType(Me.PayHeadsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PayHeadsDataGridView
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan
        Me.PayHeadsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.PayHeadsDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.PayHeadsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PayHeadsDataGridView.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PayHeadsDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.PayHeadsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PayHeadsDataGridView.GridColor = System.Drawing.SystemColors.Control
        Me.PayHeadsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.PayHeadsDataGridView.MaximumSize = New System.Drawing.Size(182, 217)
        Me.PayHeadsDataGridView.MinimumSize = New System.Drawing.Size(182, 217)
        Me.PayHeadsDataGridView.Name = "PayHeadsDataGridView"
        Me.PayHeadsDataGridView.RowHeadersVisible = False
        Me.PayHeadsDataGridView.Size = New System.Drawing.Size(182, 217)
        Me.PayHeadsDataGridView.TabIndex = 0
        '
        'AddPayHeadForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(182, 217)
        Me.Controls.Add(Me.PayHeadsDataGridView)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddPayHeadForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pay Heads"
        CType(Me.PayHeadsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PayHeadsDataGridView As DataGridView
End Class
