<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddEmployeeOrGroupForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EmpOrGroupComboBox = New System.Windows.Forms.ComboBox()
        Me.EmpOrGroupNameDataGridView = New System.Windows.Forms.DataGridView()
        Me.empOrGroupTypeTextBox = New System.Windows.Forms.TextBox()
        CType(Me.EmpOrGroupNameDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(9, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Employee/Group :"
        '
        'EmpOrGroupComboBox
        '
        Me.EmpOrGroupComboBox.FormattingEnabled = True
        Me.EmpOrGroupComboBox.Items.AddRange(New Object() {"Employee", "Group"})
        Me.EmpOrGroupComboBox.Location = New System.Drawing.Point(108, 6)
        Me.EmpOrGroupComboBox.Name = "EmpOrGroupComboBox"
        Me.EmpOrGroupComboBox.Size = New System.Drawing.Size(97, 25)
        Me.EmpOrGroupComboBox.TabIndex = 8
        '
        'EmpOrGroupNameDataGridView
        '
        Me.EmpOrGroupNameDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.EmpOrGroupNameDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EmpOrGroupNameDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.EmpOrGroupNameDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EmpOrGroupNameDataGridView.Location = New System.Drawing.Point(9, 54)
        Me.EmpOrGroupNameDataGridView.Name = "EmpOrGroupNameDataGridView"
        Me.EmpOrGroupNameDataGridView.RowHeadersVisible = False
        Me.EmpOrGroupNameDataGridView.Size = New System.Drawing.Size(196, 282)
        Me.EmpOrGroupNameDataGridView.TabIndex = 9
        '
        'empOrGroupTypeTextBox
        '
        Me.empOrGroupTypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.empOrGroupTypeTextBox.Enabled = False
        Me.empOrGroupTypeTextBox.Location = New System.Drawing.Point(9, 30)
        Me.empOrGroupTypeTextBox.Name = "empOrGroupTypeTextBox"
        Me.empOrGroupTypeTextBox.Size = New System.Drawing.Size(31, 18)
        Me.empOrGroupTypeTextBox.TabIndex = 93
        '
        'AddEmployeeOrGroupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(213, 345)
        Me.Controls.Add(Me.empOrGroupTypeTextBox)
        Me.Controls.Add(Me.EmpOrGroupNameDataGridView)
        Me.Controls.Add(Me.EmpOrGroupComboBox)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(229, 384)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(229, 384)
        Me.Name = "AddEmployeeOrGroupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.EmpOrGroupNameDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents EmpOrGroupComboBox As ComboBox
    Friend WithEvents EmpOrGroupNameDataGridView As DataGridView
    Friend WithEvents empOrGroupTypeTextBox As TextBox
End Class
