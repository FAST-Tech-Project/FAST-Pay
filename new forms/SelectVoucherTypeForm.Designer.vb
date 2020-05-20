<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectVoucherTypeForm
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
        Me.empOrGroupComboBox = New System.Windows.Forms.ComboBox()
        Me.EmpOrGroupNameDataGridView = New System.Windows.Forms.DataGridView()
        Me.empOrGroupTypeTextBox = New System.Windows.Forms.TextBox()
        Me.callFromTextBox = New System.Windows.Forms.TextBox()
        CType(Me.EmpOrGroupNameDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'empOrGroupComboBox
        '
        Me.empOrGroupComboBox.FormattingEnabled = True
        Me.empOrGroupComboBox.Items.AddRange(New Object() {"All Items", "Employee", "Group"})
        Me.empOrGroupComboBox.Location = New System.Drawing.Point(43, 12)
        Me.empOrGroupComboBox.Name = "empOrGroupComboBox"
        Me.empOrGroupComboBox.Size = New System.Drawing.Size(136, 21)
        Me.empOrGroupComboBox.TabIndex = 0
        '
        'EmpOrGroupNameDataGridView
        '
        Me.EmpOrGroupNameDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.EmpOrGroupNameDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EmpOrGroupNameDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.EmpOrGroupNameDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EmpOrGroupNameDataGridView.Location = New System.Drawing.Point(-1, 45)
        Me.EmpOrGroupNameDataGridView.Name = "EmpOrGroupNameDataGridView"
        Me.EmpOrGroupNameDataGridView.RowHeadersVisible = False
        Me.EmpOrGroupNameDataGridView.Size = New System.Drawing.Size(191, 257)
        Me.EmpOrGroupNameDataGridView.TabIndex = 10
        '
        'empOrGroupTypeTextBox
        '
        Me.empOrGroupTypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.empOrGroupTypeTextBox.Enabled = False
        Me.empOrGroupTypeTextBox.Location = New System.Drawing.Point(6, 20)
        Me.empOrGroupTypeTextBox.Name = "empOrGroupTypeTextBox"
        Me.empOrGroupTypeTextBox.Size = New System.Drawing.Size(31, 13)
        Me.empOrGroupTypeTextBox.TabIndex = 94
        '
        'callFromTextBox
        '
        Me.callFromTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.callFromTextBox.Enabled = False
        Me.callFromTextBox.Location = New System.Drawing.Point(6, 1)
        Me.callFromTextBox.Name = "callFromTextBox"
        Me.callFromTextBox.Size = New System.Drawing.Size(31, 13)
        Me.callFromTextBox.TabIndex = 95
        '
        'SelectVoucherTypeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(191, 314)
        Me.Controls.Add(Me.callFromTextBox)
        Me.Controls.Add(Me.empOrGroupTypeTextBox)
        Me.Controls.Add(Me.EmpOrGroupNameDataGridView)
        Me.Controls.Add(Me.empOrGroupComboBox)
        Me.Name = "SelectVoucherTypeForm"
        Me.Text = "AttendanceOrProductionVoucherSetupForm"
        CType(Me.EmpOrGroupNameDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents empOrGroupComboBox As ComboBox
    Friend WithEvents EmpOrGroupNameDataGridView As DataGridView
    Friend WithEvents empOrGroupTypeTextBox As TextBox
    Friend WithEvents callFromTextBox As TextBox
End Class
