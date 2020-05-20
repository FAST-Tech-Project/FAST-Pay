<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalaryDetailsSetupForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.EmployeeSalaryDetailsDataGridView = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pay_head = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.period = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pay_head_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.calculation_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.compute_on = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pay_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.empOrGroupNameTextBox = New System.Windows.Forms.TextBox()
        Me.underTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SavesSalaryDetailsButton = New System.Windows.Forms.Button()
        Me.CancelSalarySetupButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.empOrGroupTypeTextBox = New System.Windows.Forms.TextBox()
        Me.clickedRowIndexTextBox = New System.Windows.Forms.TextBox()
        Me.empOrGroupIDTextBox = New System.Windows.Forms.TextBox()
        Me.selectedStartTypeTextBox = New System.Windows.Forms.TextBox()
        Me.addPayHeadsButton = New System.Windows.Forms.Button()
        Me.empGroupIDTextBox = New System.Windows.Forms.TextBox()
        Me.payPeriodIDTextBox = New System.Windows.Forms.TextBox()
        Me.clickedDgvItemTextBox = New System.Windows.Forms.TextBox()
        Me.payrollPeriodTextBox = New System.Windows.Forms.TextBox()
        Me.clickedGroupRowIndexTextBox = New System.Windows.Forms.TextBox()
        Me.GroupDgvTotalRowsTextBox = New System.Windows.Forms.TextBox()
        Me.LoadedSalaryDetailsIDDataGridView = New System.Windows.Forms.DataGridView()
        Me.GrpSalaryDetailsDataGridView = New System.Windows.Forms.DataGridView()
        Me.remove_row = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.empSalariesComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.EmployeeSalaryDetailsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.LoadedSalaryDetailsIDDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrpSalaryDetailsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmployeeSalaryDetailsDataGridView
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.EmployeeSalaryDetailsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.EmployeeSalaryDetailsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.EmployeeSalaryDetailsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EmployeeSalaryDetailsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.EmployeeSalaryDetailsDataGridView.ColumnHeadersHeight = 50
        Me.EmployeeSalaryDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.EmployeeSalaryDetailsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.pay_head, Me.rate, Me.period, Me.pay_head_type, Me.calculation_type, Me.compute_on, Me.Column1, Me.pay_type})
        Me.EmployeeSalaryDetailsDataGridView.GridColor = System.Drawing.Color.White
        Me.EmployeeSalaryDetailsDataGridView.Location = New System.Drawing.Point(169, 241)
        Me.EmployeeSalaryDetailsDataGridView.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EmployeeSalaryDetailsDataGridView.Name = "EmployeeSalaryDetailsDataGridView"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(10)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EmployeeSalaryDetailsDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.EmployeeSalaryDetailsDataGridView.RowHeadersVisible = False
        Me.EmployeeSalaryDetailsDataGridView.Size = New System.Drawing.Size(981, 446)
        Me.EmployeeSalaryDetailsDataGridView.TabIndex = 0
        '
        'id
        '
        Me.id.HeaderText = "SNo."
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 50
        '
        'pay_head
        '
        Me.pay_head.HeaderText = "Pay Head"
        Me.pay_head.Name = "pay_head"
        Me.pay_head.ReadOnly = True
        Me.pay_head.Width = 200
        '
        'rate
        '
        Me.rate.HeaderText = "Rate"
        Me.rate.Name = "rate"
        '
        'period
        '
        Me.period.HeaderText = "Period"
        Me.period.Name = "period"
        '
        'pay_head_type
        '
        Me.pay_head_type.HeaderText = "Pay Head Type"
        Me.pay_head_type.Name = "pay_head_type"
        Me.pay_head_type.ReadOnly = True
        Me.pay_head_type.Width = 195
        '
        'calculation_type
        '
        Me.calculation_type.HeaderText = "Calculation Type"
        Me.calculation_type.Name = "calculation_type"
        Me.calculation_type.ReadOnly = True
        Me.calculation_type.Width = 120
        '
        'compute_on
        '
        Me.compute_on.HeaderText = "Compute On"
        Me.compute_on.Name = "compute_on"
        Me.compute_on.ReadOnly = True
        Me.compute_on.Width = 250
        '
        'Column1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Tomato
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Tomato
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.FillWeight = 50.0!
        Me.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.Text = "x"
        Me.Column1.UseColumnTextForButtonValue = True
        Me.Column1.Width = 15
        '
        'pay_type
        '
        Me.pay_type.HeaderText = "PAY TYPE"
        Me.pay_type.Name = "pay_type"
        Me.pay_type.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(166, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(166, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Under :"
        '
        'empOrGroupNameTextBox
        '
        Me.empOrGroupNameTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.empOrGroupNameTextBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.empOrGroupNameTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empOrGroupNameTextBox.Location = New System.Drawing.Point(237, 68)
        Me.empOrGroupNameTextBox.Name = "empOrGroupNameTextBox"
        Me.empOrGroupNameTextBox.ReadOnly = True
        Me.empOrGroupNameTextBox.Size = New System.Drawing.Size(298, 23)
        Me.empOrGroupNameTextBox.TabIndex = 3
        '
        'underTextBox
        '
        Me.underTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.underTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.underTextBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.underTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.underTextBox.Location = New System.Drawing.Point(237, 101)
        Me.underTextBox.Name = "underTextBox"
        Me.underTextBox.ReadOnly = True
        Me.underTextBox.Size = New System.Drawing.Size(298, 16)
        Me.underTextBox.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.SavesSalaryDetailsButton)
        Me.GroupBox3.Controls.Add(Me.CancelSalarySetupButton)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1319, 37)
        Me.GroupBox3.TabIndex = 88
        Me.GroupBox3.TabStop = False
        '
        'SavesSalaryDetailsButton
        '
        Me.SavesSalaryDetailsButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SavesSalaryDetailsButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavesSalaryDetailsButton.Location = New System.Drawing.Point(169, 12)
        Me.SavesSalaryDetailsButton.Name = "SavesSalaryDetailsButton"
        Me.SavesSalaryDetailsButton.Size = New System.Drawing.Size(72, 20)
        Me.SavesSalaryDetailsButton.TabIndex = 85
        Me.SavesSalaryDetailsButton.Text = "Save"
        Me.SavesSalaryDetailsButton.UseVisualStyleBackColor = True
        '
        'CancelSalarySetupButton
        '
        Me.CancelSalarySetupButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CancelSalarySetupButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelSalarySetupButton.Location = New System.Drawing.Point(247, 12)
        Me.CancelSalarySetupButton.Name = "CancelSalarySetupButton"
        Me.CancelSalarySetupButton.Size = New System.Drawing.Size(49, 20)
        Me.CancelSalarySetupButton.TabIndex = 86
        Me.CancelSalarySetupButton.Text = "Cancel"
        Me.CancelSalarySetupButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(166, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Pay Period :"
        '
        'empOrGroupTypeTextBox
        '
        Me.empOrGroupTypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.empOrGroupTypeTextBox.Enabled = False
        Me.empOrGroupTypeTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empOrGroupTypeTextBox.Location = New System.Drawing.Point(444, 48)
        Me.empOrGroupTypeTextBox.Name = "empOrGroupTypeTextBox"
        Me.empOrGroupTypeTextBox.Size = New System.Drawing.Size(91, 16)
        Me.empOrGroupTypeTextBox.TabIndex = 92
        '
        'clickedRowIndexTextBox
        '
        Me.clickedRowIndexTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clickedRowIndexTextBox.Enabled = False
        Me.clickedRowIndexTextBox.Location = New System.Drawing.Point(169, 221)
        Me.clickedRowIndexTextBox.Name = "clickedRowIndexTextBox"
        Me.clickedRowIndexTextBox.Size = New System.Drawing.Size(40, 16)
        Me.clickedRowIndexTextBox.TabIndex = 93
        Me.clickedRowIndexTextBox.Text = "0"
        '
        'empOrGroupIDTextBox
        '
        Me.empOrGroupIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.empOrGroupIDTextBox.Enabled = False
        Me.empOrGroupIDTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empOrGroupIDTextBox.Location = New System.Drawing.Point(393, 48)
        Me.empOrGroupIDTextBox.Name = "empOrGroupIDTextBox"
        Me.empOrGroupIDTextBox.Size = New System.Drawing.Size(45, 16)
        Me.empOrGroupIDTextBox.TabIndex = 94
        '
        'selectedStartTypeTextBox
        '
        Me.selectedStartTypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.selectedStartTypeTextBox.Enabled = False
        Me.selectedStartTypeTextBox.Location = New System.Drawing.Point(218, 221)
        Me.selectedStartTypeTextBox.Name = "selectedStartTypeTextBox"
        Me.selectedStartTypeTextBox.Size = New System.Drawing.Size(45, 16)
        Me.selectedStartTypeTextBox.TabIndex = 95
        '
        'addPayHeadsButton
        '
        Me.addPayHeadsButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.addPayHeadsButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addPayHeadsButton.Location = New System.Drawing.Point(169, 175)
        Me.addPayHeadsButton.Name = "addPayHeadsButton"
        Me.addPayHeadsButton.Size = New System.Drawing.Size(96, 23)
        Me.addPayHeadsButton.TabIndex = 96
        Me.addPayHeadsButton.Text = "Add Pay Heads"
        Me.addPayHeadsButton.UseVisualStyleBackColor = True
        '
        'empGroupIDTextBox
        '
        Me.empGroupIDTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.empGroupIDTextBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.empGroupIDTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empGroupIDTextBox.Location = New System.Drawing.Point(535, 98)
        Me.empGroupIDTextBox.Name = "empGroupIDTextBox"
        Me.empGroupIDTextBox.ReadOnly = True
        Me.empGroupIDTextBox.Size = New System.Drawing.Size(20, 23)
        Me.empGroupIDTextBox.TabIndex = 98
        '
        'payPeriodIDTextBox
        '
        Me.payPeriodIDTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.payPeriodIDTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.payPeriodIDTextBox.Location = New System.Drawing.Point(535, 128)
        Me.payPeriodIDTextBox.Name = "payPeriodIDTextBox"
        Me.payPeriodIDTextBox.ReadOnly = True
        Me.payPeriodIDTextBox.Size = New System.Drawing.Size(21, 22)
        Me.payPeriodIDTextBox.TabIndex = 117
        Me.payPeriodIDTextBox.Text = "1"
        '
        'clickedDgvItemTextBox
        '
        Me.clickedDgvItemTextBox.Location = New System.Drawing.Point(865, 194)
        Me.clickedDgvItemTextBox.Name = "clickedDgvItemTextBox"
        Me.clickedDgvItemTextBox.ReadOnly = True
        Me.clickedDgvItemTextBox.Size = New System.Drawing.Size(24, 23)
        Me.clickedDgvItemTextBox.TabIndex = 118
        '
        'payrollPeriodTextBox
        '
        Me.payrollPeriodTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.payrollPeriodTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.payrollPeriodTextBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.payrollPeriodTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.payrollPeriodTextBox.Location = New System.Drawing.Point(237, 130)
        Me.payrollPeriodTextBox.Name = "payrollPeriodTextBox"
        Me.payrollPeriodTextBox.ReadOnly = True
        Me.payrollPeriodTextBox.Size = New System.Drawing.Size(298, 16)
        Me.payrollPeriodTextBox.TabIndex = 121
        '
        'clickedGroupRowIndexTextBox
        '
        Me.clickedGroupRowIndexTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clickedGroupRowIndexTextBox.Enabled = False
        Me.clickedGroupRowIndexTextBox.Location = New System.Drawing.Point(333, 221)
        Me.clickedGroupRowIndexTextBox.Name = "clickedGroupRowIndexTextBox"
        Me.clickedGroupRowIndexTextBox.Size = New System.Drawing.Size(40, 16)
        Me.clickedGroupRowIndexTextBox.TabIndex = 123
        '
        'GroupDgvTotalRowsTextBox
        '
        Me.GroupDgvTotalRowsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GroupDgvTotalRowsTextBox.Enabled = False
        Me.GroupDgvTotalRowsTextBox.Location = New System.Drawing.Point(379, 221)
        Me.GroupDgvTotalRowsTextBox.Name = "GroupDgvTotalRowsTextBox"
        Me.GroupDgvTotalRowsTextBox.Size = New System.Drawing.Size(40, 16)
        Me.GroupDgvTotalRowsTextBox.TabIndex = 124
        '
        'LoadedSalaryDetailsIDDataGridView
        '
        Me.LoadedSalaryDetailsIDDataGridView.ColumnHeadersHeight = 50
        Me.LoadedSalaryDetailsIDDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.LoadedSalaryDetailsIDDataGridView.Location = New System.Drawing.Point(1156, 241)
        Me.LoadedSalaryDetailsIDDataGridView.Name = "LoadedSalaryDetailsIDDataGridView"
        Me.LoadedSalaryDetailsIDDataGridView.RowHeadersVisible = False
        Me.LoadedSalaryDetailsIDDataGridView.Size = New System.Drawing.Size(36, 446)
        Me.LoadedSalaryDetailsIDDataGridView.TabIndex = 126
        '
        'GrpSalaryDetailsDataGridView
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.GrpSalaryDetailsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GrpSalaryDetailsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GrpSalaryDetailsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrpSalaryDetailsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GrpSalaryDetailsDataGridView.ColumnHeadersHeight = 50
        Me.GrpSalaryDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GrpSalaryDetailsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.remove_row})
        Me.GrpSalaryDetailsDataGridView.Location = New System.Drawing.Point(153, 251)
        Me.GrpSalaryDetailsDataGridView.Name = "GrpSalaryDetailsDataGridView"
        Me.GrpSalaryDetailsDataGridView.RowHeadersVisible = False
        Me.GrpSalaryDetailsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrpSalaryDetailsDataGridView.Size = New System.Drawing.Size(981, 446)
        Me.GrpSalaryDetailsDataGridView.TabIndex = 127
        Me.GrpSalaryDetailsDataGridView.Visible = False
        '
        'remove_row
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Tomato
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI Emoji", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        Me.remove_row.DefaultCellStyle = DataGridViewCellStyle7
        Me.remove_row.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.remove_row.HeaderText = ""
        Me.remove_row.Name = "remove_row"
        Me.remove_row.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.remove_row.Text = "x"
        Me.remove_row.UseColumnTextForButtonValue = True
        Me.remove_row.Width = 15
        '
        'empSalariesComboBox
        '
        Me.empSalariesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.empSalariesComboBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empSalariesComboBox.FormattingEnabled = True
        Me.empSalariesComboBox.Location = New System.Drawing.Point(895, 196)
        Me.empSalariesComboBox.Name = "empSalariesComboBox"
        Me.empSalariesComboBox.Size = New System.Drawing.Size(255, 21)
        Me.empSalariesComboBox.TabIndex = 128
        Me.empSalariesComboBox.Text = "Employees' Salary"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(606, 217)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 21)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Salary Details"
        '
        'SalaryDetailsSetupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1319, 749)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.empSalariesComboBox)
        Me.Controls.Add(Me.GrpSalaryDetailsDataGridView)
        Me.Controls.Add(Me.clickedDgvItemTextBox)
        Me.Controls.Add(Me.LoadedSalaryDetailsIDDataGridView)
        Me.Controls.Add(Me.GroupDgvTotalRowsTextBox)
        Me.Controls.Add(Me.clickedGroupRowIndexTextBox)
        Me.Controls.Add(Me.payrollPeriodTextBox)
        Me.Controls.Add(Me.payPeriodIDTextBox)
        Me.Controls.Add(Me.empGroupIDTextBox)
        Me.Controls.Add(Me.addPayHeadsButton)
        Me.Controls.Add(Me.selectedStartTypeTextBox)
        Me.Controls.Add(Me.empOrGroupIDTextBox)
        Me.Controls.Add(Me.clickedRowIndexTextBox)
        Me.Controls.Add(Me.empOrGroupTypeTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.underTextBox)
        Me.Controls.Add(Me.empOrGroupNameTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.EmployeeSalaryDetailsDataGridView)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(426, 251)
        Me.Name = "SalaryDetailsSetupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SetupSalaryForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EmployeeSalaryDetailsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.LoadedSalaryDetailsIDDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrpSalaryDetailsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EmployeeSalaryDetailsDataGridView As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents empOrGroupNameTextBox As TextBox
    Friend WithEvents underTextBox As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents SavesSalaryDetailsButton As Button
    Friend WithEvents CancelSalarySetupButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents empOrGroupTypeTextBox As TextBox
    Friend WithEvents clickedRowIndexTextBox As TextBox
    Friend WithEvents empOrGroupIDTextBox As TextBox
    Friend WithEvents selectedStartTypeTextBox As TextBox
    Friend WithEvents addPayHeadsButton As Button
    Friend WithEvents empGroupIDTextBox As TextBox
    Friend WithEvents payPeriodIDTextBox As TextBox
    Friend WithEvents clickedDgvItemTextBox As TextBox
    Friend WithEvents payrollPeriodTextBox As TextBox
    Friend WithEvents clickedGroupRowIndexTextBox As TextBox
    Friend WithEvents GroupDgvTotalRowsTextBox As TextBox
    Friend WithEvents LoadedSalaryDetailsIDDataGridView As DataGridView
    Friend WithEvents GrpSalaryDetailsDataGridView As DataGridView
    Friend WithEvents empSalariesComboBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents pay_head As DataGridViewTextBoxColumn
    Friend WithEvents rate As DataGridViewTextBoxColumn
    Friend WithEvents period As DataGridViewTextBoxColumn
    Friend WithEvents pay_head_type As DataGridViewTextBoxColumn
    Friend WithEvents calculation_type As DataGridViewTextBoxColumn
    Friend WithEvents compute_on As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewButtonColumn
    Friend WithEvents pay_type As DataGridViewTextBoxColumn
    Friend WithEvents remove_row As DataGridViewButtonColumn
End Class
