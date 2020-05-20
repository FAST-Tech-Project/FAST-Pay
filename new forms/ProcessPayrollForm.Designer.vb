<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProcessPayrollForm
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.attendOrProductVoucherSetupPanel = New System.Windows.Forms.Panel()
        Me.payrollPeriodTextBox = New System.Windows.Forms.TextBox()
        Me.payPeriodIDTextBox = New System.Windows.Forms.TextBox()
        Me.processingInfoLabel = New System.Windows.Forms.Label()
        Me.processPayrollButton = New System.Windows.Forms.Button()
        Me.empOrGroupIDTextBox = New System.Windows.Forms.TextBox()
        Me.empOrGroupTypeTextBox = New System.Windows.Forms.TextBox()
        Me.empCatIDTextBox = New System.Windows.Forms.TextBox()
        Me.empOrGroupNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.empCategoryComboBox = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.processPayrollTimer = New System.Windows.Forms.Timer(Me.components)
        Me.employeesDataGridView = New System.Windows.Forms.DataGridView()
        Me.earningsDataGridView = New System.Windows.Forms.DataGridView()
        Me.deductionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.contributionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.applicableEarningsDataGridView = New System.Windows.Forms.DataGridView()
        Me.applicableDeductionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.applicableContributionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.speciFiedFormulaDataGridView = New System.Windows.Forms.DataGridView()
        Me.attendOrProductVoucherSetupPanel.SuspendLayout()
        CType(Me.employeesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.earningsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deductionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.contributionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.applicableEarningsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.applicableDeductionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.applicableContributionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.speciFiedFormulaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'attendOrProductVoucherSetupPanel
        '
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.payrollPeriodTextBox)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.payPeriodIDTextBox)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.processingInfoLabel)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.processPayrollButton)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.empOrGroupIDTextBox)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.empOrGroupTypeTextBox)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.empCatIDTextBox)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.empOrGroupNameTextBox)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.Label26)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.Label30)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.Label31)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.Label32)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.empCategoryComboBox)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.Label36)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.Label37)
        Me.attendOrProductVoucherSetupPanel.Controls.Add(Me.Label38)
        Me.attendOrProductVoucherSetupPanel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.attendOrProductVoucherSetupPanel.Location = New System.Drawing.Point(1, 0)
        Me.attendOrProductVoucherSetupPanel.Name = "attendOrProductVoucherSetupPanel"
        Me.attendOrProductVoucherSetupPanel.Size = New System.Drawing.Size(432, 240)
        Me.attendOrProductVoucherSetupPanel.TabIndex = 8
        '
        'payrollPeriodTextBox
        '
        Me.payrollPeriodTextBox.BackColor = System.Drawing.Color.Snow
        Me.payrollPeriodTextBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.payrollPeriodTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.payrollPeriodTextBox.Location = New System.Drawing.Point(217, 59)
        Me.payrollPeriodTextBox.Name = "payrollPeriodTextBox"
        Me.payrollPeriodTextBox.ReadOnly = True
        Me.payrollPeriodTextBox.Size = New System.Drawing.Size(182, 22)
        Me.payrollPeriodTextBox.TabIndex = 122
        '
        'payPeriodIDTextBox
        '
        Me.payPeriodIDTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.payPeriodIDTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.payPeriodIDTextBox.Location = New System.Drawing.Point(402, 59)
        Me.payPeriodIDTextBox.Name = "payPeriodIDTextBox"
        Me.payPeriodIDTextBox.ReadOnly = True
        Me.payPeriodIDTextBox.Size = New System.Drawing.Size(25, 22)
        Me.payPeriodIDTextBox.TabIndex = 113
        Me.payPeriodIDTextBox.Text = "1"
        '
        'processingInfoLabel
        '
        Me.processingInfoLabel.AutoSize = True
        Me.processingInfoLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.processingInfoLabel.Location = New System.Drawing.Point(25, 203)
        Me.processingInfoLabel.Name = "processingInfoLabel"
        Me.processingInfoLabel.Size = New System.Drawing.Size(101, 15)
        Me.processingInfoLabel.TabIndex = 111
        Me.processingInfoLabel.Text = "Employee/Group"
        '
        'processPayrollButton
        '
        Me.processPayrollButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.processPayrollButton.Location = New System.Drawing.Point(301, 186)
        Me.processPayrollButton.Name = "processPayrollButton"
        Me.processPayrollButton.Size = New System.Drawing.Size(98, 32)
        Me.processPayrollButton.TabIndex = 110
        Me.processPayrollButton.Text = "Process Payroll"
        Me.processPayrollButton.UseVisualStyleBackColor = True
        '
        'empOrGroupIDTextBox
        '
        Me.empOrGroupIDTextBox.BackColor = System.Drawing.Color.Snow
        Me.empOrGroupIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.empOrGroupIDTextBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.empOrGroupIDTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empOrGroupIDTextBox.Location = New System.Drawing.Point(334, 142)
        Me.empOrGroupIDTextBox.Name = "empOrGroupIDTextBox"
        Me.empOrGroupIDTextBox.ReadOnly = True
        Me.empOrGroupIDTextBox.Size = New System.Drawing.Size(48, 15)
        Me.empOrGroupIDTextBox.TabIndex = 109
        Me.empOrGroupIDTextBox.Text = "0"
        '
        'empOrGroupTypeTextBox
        '
        Me.empOrGroupTypeTextBox.BackColor = System.Drawing.Color.Snow
        Me.empOrGroupTypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.empOrGroupTypeTextBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.empOrGroupTypeTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empOrGroupTypeTextBox.Location = New System.Drawing.Point(217, 142)
        Me.empOrGroupTypeTextBox.Name = "empOrGroupTypeTextBox"
        Me.empOrGroupTypeTextBox.ReadOnly = True
        Me.empOrGroupTypeTextBox.Size = New System.Drawing.Size(105, 15)
        Me.empOrGroupTypeTextBox.TabIndex = 108
        Me.empOrGroupTypeTextBox.Text = "All Items"
        '
        'empCatIDTextBox
        '
        Me.empCatIDTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.empCatIDTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empCatIDTextBox.Location = New System.Drawing.Point(402, 88)
        Me.empCatIDTextBox.Name = "empCatIDTextBox"
        Me.empCatIDTextBox.ReadOnly = True
        Me.empCatIDTextBox.Size = New System.Drawing.Size(25, 22)
        Me.empCatIDTextBox.TabIndex = 107
        Me.empCatIDTextBox.Text = "1"
        '
        'empOrGroupNameTextBox
        '
        Me.empOrGroupNameTextBox.BackColor = System.Drawing.Color.Snow
        Me.empOrGroupNameTextBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.empOrGroupNameTextBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empOrGroupNameTextBox.Location = New System.Drawing.Point(217, 116)
        Me.empOrGroupNameTextBox.Name = "empOrGroupNameTextBox"
        Me.empOrGroupNameTextBox.ReadOnly = True
        Me.empOrGroupNameTextBox.Size = New System.Drawing.Size(182, 22)
        Me.empOrGroupNameTextBox.TabIndex = 105
        Me.empOrGroupNameTextBox.Text = "All Items"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(149, 13)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(138, 17)
        Me.Label26.TabIndex = 103
        Me.Label26.Text = "Payroll Process Setup"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(201, 68)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(10, 15)
        Me.Label30.TabIndex = 97
        Me.Label30.Text = ":"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(201, 94)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(10, 15)
        Me.Label31.TabIndex = 96
        Me.Label31.Text = ":"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(201, 118)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(10, 15)
        Me.Label32.TabIndex = 95
        Me.Label32.Text = ":"
        '
        'empCategoryComboBox
        '
        Me.empCategoryComboBox.BackColor = System.Drawing.Color.Snow
        Me.empCategoryComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.empCategoryComboBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empCategoryComboBox.FormattingEnabled = True
        Me.empCategoryComboBox.Location = New System.Drawing.Point(217, 88)
        Me.empCategoryComboBox.Name = "empCategoryComboBox"
        Me.empCategoryComboBox.Size = New System.Drawing.Size(182, 21)
        Me.empCategoryComboBox.TabIndex = 10
        Me.empCategoryComboBox.Text = "Primary Cost Category"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(25, 120)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(93, 13)
        Me.Label36.TabIndex = 6
        Me.Label36.Text = "Employee/Group"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(25, 96)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(105, 13)
        Me.Label37.TabIndex = 5
        Me.Label37.Text = "Employee Category"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(25, 68)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(77, 13)
        Me.Label38.TabIndex = 4
        Me.Label38.Text = "Payroll Period"
        '
        'processPayrollTimer
        '
        Me.processPayrollTimer.Interval = 1
        '
        'employeesDataGridView
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.employeesDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.employeesDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.employeesDataGridView.ColumnHeadersHeight = 40
        Me.employeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.employeesDataGridView.Location = New System.Drawing.Point(15, 13)
        Me.employeesDataGridView.Name = "employeesDataGridView"
        Me.employeesDataGridView.RowHeadersVisible = False
        Me.employeesDataGridView.Size = New System.Drawing.Size(197, 215)
        Me.employeesDataGridView.TabIndex = 9
        Me.employeesDataGridView.Visible = False
        '
        'earningsDataGridView
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.earningsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.earningsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.earningsDataGridView.ColumnHeadersHeight = 40
        Me.earningsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.earningsDataGridView.Location = New System.Drawing.Point(218, 14)
        Me.earningsDataGridView.Name = "earningsDataGridView"
        Me.earningsDataGridView.RowHeadersVisible = False
        Me.earningsDataGridView.Size = New System.Drawing.Size(374, 214)
        Me.earningsDataGridView.TabIndex = 10
        Me.earningsDataGridView.Visible = False
        '
        'deductionsDataGridView
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.deductionsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.deductionsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.deductionsDataGridView.ColumnHeadersHeight = 40
        Me.deductionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.deductionsDataGridView.Location = New System.Drawing.Point(598, 13)
        Me.deductionsDataGridView.Name = "deductionsDataGridView"
        Me.deductionsDataGridView.RowHeadersVisible = False
        Me.deductionsDataGridView.Size = New System.Drawing.Size(358, 215)
        Me.deductionsDataGridView.TabIndex = 11
        Me.deductionsDataGridView.Visible = False
        '
        'contributionsDataGridView
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.contributionsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.contributionsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.contributionsDataGridView.ColumnHeadersHeight = 40
        Me.contributionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.contributionsDataGridView.Location = New System.Drawing.Point(962, 13)
        Me.contributionsDataGridView.Name = "contributionsDataGridView"
        Me.contributionsDataGridView.RowHeadersVisible = False
        Me.contributionsDataGridView.Size = New System.Drawing.Size(304, 215)
        Me.contributionsDataGridView.TabIndex = 12
        Me.contributionsDataGridView.Visible = False
        '
        'applicableEarningsDataGridView
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        Me.applicableEarningsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.applicableEarningsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.applicableEarningsDataGridView.ColumnHeadersHeight = 40
        Me.applicableEarningsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.applicableEarningsDataGridView.Location = New System.Drawing.Point(218, 234)
        Me.applicableEarningsDataGridView.Name = "applicableEarningsDataGridView"
        Me.applicableEarningsDataGridView.RowHeadersVisible = False
        Me.applicableEarningsDataGridView.Size = New System.Drawing.Size(374, 156)
        Me.applicableEarningsDataGridView.TabIndex = 13
        '
        'applicableDeductionsDataGridView
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        Me.applicableDeductionsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.applicableDeductionsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.applicableDeductionsDataGridView.ColumnHeadersHeight = 40
        Me.applicableDeductionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.applicableDeductionsDataGridView.Location = New System.Drawing.Point(598, 234)
        Me.applicableDeductionsDataGridView.Name = "applicableDeductionsDataGridView"
        Me.applicableDeductionsDataGridView.RowHeadersVisible = False
        Me.applicableDeductionsDataGridView.Size = New System.Drawing.Size(358, 156)
        Me.applicableDeductionsDataGridView.TabIndex = 14
        '
        'applicableContributionsDataGridView
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.applicableContributionsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.applicableContributionsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.applicableContributionsDataGridView.ColumnHeadersHeight = 40
        Me.applicableContributionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.applicableContributionsDataGridView.Location = New System.Drawing.Point(962, 234)
        Me.applicableContributionsDataGridView.Name = "applicableContributionsDataGridView"
        Me.applicableContributionsDataGridView.RowHeadersVisible = False
        Me.applicableContributionsDataGridView.Size = New System.Drawing.Size(304, 156)
        Me.applicableContributionsDataGridView.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.speciFiedFormulaDataGridView)
        Me.Panel1.Controls.Add(Me.employeesDataGridView)
        Me.Panel1.Controls.Add(Me.applicableContributionsDataGridView)
        Me.Panel1.Controls.Add(Me.earningsDataGridView)
        Me.Panel1.Controls.Add(Me.applicableDeductionsDataGridView)
        Me.Panel1.Controls.Add(Me.deductionsDataGridView)
        Me.Panel1.Controls.Add(Me.applicableEarningsDataGridView)
        Me.Panel1.Controls.Add(Me.contributionsDataGridView)
        Me.Panel1.Location = New System.Drawing.Point(54, 279)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1280, 458)
        Me.Panel1.TabIndex = 16
        '
        'speciFiedFormulaDataGridView
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        Me.speciFiedFormulaDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.speciFiedFormulaDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.speciFiedFormulaDataGridView.ColumnHeadersHeight = 40
        Me.speciFiedFormulaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.speciFiedFormulaDataGridView.Location = New System.Drawing.Point(15, 234)
        Me.speciFiedFormulaDataGridView.Name = "speciFiedFormulaDataGridView"
        Me.speciFiedFormulaDataGridView.RowHeadersVisible = False
        Me.speciFiedFormulaDataGridView.Size = New System.Drawing.Size(197, 156)
        Me.speciFiedFormulaDataGridView.TabIndex = 16
        '
        'ProcessPayrollForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 749)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.attendOrProductVoucherSetupPanel)
        Me.Name = "ProcessPayrollForm"
        Me.Text = "ProcessPayrollForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.attendOrProductVoucherSetupPanel.ResumeLayout(False)
        Me.attendOrProductVoucherSetupPanel.PerformLayout()
        CType(Me.employeesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.earningsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deductionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.contributionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.applicableEarningsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.applicableDeductionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.applicableContributionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.speciFiedFormulaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents attendOrProductVoucherSetupPanel As Panel
    Friend WithEvents empOrGroupIDTextBox As TextBox
    Friend WithEvents empOrGroupTypeTextBox As TextBox
    Friend WithEvents empCatIDTextBox As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents empCategoryComboBox As ComboBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents processPayrollButton As Button
    Friend WithEvents processingInfoLabel As Label
    Friend WithEvents processPayrollTimer As Timer
    Friend WithEvents payPeriodIDTextBox As TextBox
    Friend WithEvents employeesDataGridView As DataGridView
    Friend WithEvents earningsDataGridView As DataGridView
    Friend WithEvents deductionsDataGridView As DataGridView
    Friend WithEvents contributionsDataGridView As DataGridView
    Friend WithEvents applicableEarningsDataGridView As DataGridView
    Friend WithEvents applicableDeductionsDataGridView As DataGridView
    Friend WithEvents applicableContributionsDataGridView As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents payrollPeriodTextBox As TextBox
    Friend WithEvents empOrGroupNameTextBox As TextBox
    Friend WithEvents speciFiedFormulaDataGridView As DataGridView
End Class
