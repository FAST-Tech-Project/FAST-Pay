Imports System.ComponentModel

Public Class PayrollForm

    Private Sub PayrollForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PayrollSetupButton_Click(sender As Object, e As EventArgs) Handles PayrollSetupButton.Click
        clickedMenuButtonTextBox.Text = 1
        CreatePayHeadPanel.Visible = False
        salarySetupPanel.Visible = False
        attendOrProdPanel.Visible = False
        processPayrollPanel.Visible = False
        CreatePayHeadPanel.Dock = DockStyle.None
        salarySetupPanel.Dock = DockStyle.None
        attendOrProdPanel.Dock = DockStyle.None
        processPayrollPanel.Dock = DockStyle.None
        titleHeaderLabel.Text = PayrollSetupButton.Text
        titleHeaderLabel.Visible = True
        setupPanel.Dock = DockStyle.Fill
        setupPanel.Visible = True

        'Items List Panel & Datagridview
        'itemsListTitleLabel.Text = "Created Employee Salaries"
        'itemsListTitleLabel.Visible = True
        LoadDataIntoDatagrid(ItemsListDataGridView, "SELECT `id`, `name` FROM `tbl_payroll_units`")
        ItemsListDataGridView.Columns(0).Visible = False
        ItemsListDataGridView.Columns(1).Width = ItemsListDataGridView.Width - 11
        ItemsListDataGridView.Columns(1).HeaderText = "UNITS"
        ItemsListDataGridView.ColumnHeadersHeight = 40
        ItemsListDataGridView.Height = 230

        LoadDataIntoDatagrid(itemsListDataGridView2, "SELECT `id`, `name` FROM `tbl_attendance_or_production`")
        itemsListDataGridView2.Columns(0).Visible = False
        itemsListDataGridView2.Columns(1).Width = ItemsListDataGridView.Width - 11
        itemsListDataGridView2.Columns(1).HeaderText = "ATTENDANCE/PRODUCTION"
        itemsListDataGridView2.ColumnHeadersHeight = 40
        itemsListDataGridView2.Height = 230

        itemsListDataGridView2.Visible = True
        ItemsListPanel.Visible = True

    End Sub

    Private Sub CreatePayHeadButton_Click(sender As Object, e As EventArgs) Handles CreatePayHeadButton.Click
        clickedMenuButtonTextBox.Text = 2
        setupPanel.Visible = False
        salarySetupPanel.Visible = False
        attendOrProdPanel.Visible = False
        processPayrollPanel.Visible = False
        setupPanel.Dock = DockStyle.None
        salarySetupPanel.Dock = DockStyle.None
        attendOrProdPanel.Dock = DockStyle.None
        processPayrollPanel.Dock = DockStyle.None
        titleHeaderLabel.Text = CreatePayHeadButton.Text
        titleHeaderLabel.Visible = True
        CreatePayHeadPanel.Dock = DockStyle.Fill
        CreatePayHeadPanel.Visible = True

        'Items List Panel & Datagridview
        'itemsListTitleLabel.Text = "Created Pay Heads"
        'itemsListTitleLabel.Visible = True
        'LoadDataIntoDatagrid(ItemsListDataGridView, "SELECT `id`, `name` FROM  `tbl_pay_head`")
        'ItemsListDataGridView.Columns(0).Visible = False
        'ItemsListDataGridView.Columns(1).Width = ItemsListDataGridView.Width - 11
        'ItemsListDataGridView.Columns(1).HeaderText = "PAY HEADS"
        'ItemsListDataGridView.ColumnHeadersHeight = 40
        'ItemsListDataGridView.Height = 500
        'itemsListDataGridView2.Visible = False
        'ItemsListPanel.Visible = True

        PayHeadCreationForm.Show()
        Me.Hide()

    End Sub

    Private Sub SalarySetupButton_Click(sender As Object, e As EventArgs) Handles SalarySetupButton.Click
        clickedMenuButtonTextBox.Text = 3
        setupPanel.Visible = False
        CreatePayHeadPanel.Visible = False
        attendOrProdPanel.Visible = False
        processPayrollPanel.Visible = False
        setupPanel.Dock = DockStyle.None
        CreatePayHeadPanel.Dock = DockStyle.None
        attendOrProdPanel.Dock = DockStyle.None
        processPayrollPanel.Dock = DockStyle.None
        titleHeaderLabel.Text = SalarySetupButton.Text
        titleHeaderLabel.Visible = True
        salarySetupPanel.Dock = DockStyle.Fill
        salarySetupPanel.Visible = True

        'Items List Panel & Datagridview
        'itemsListTitleLabel.Text = "Created Employee Salaries"
        'itemsListTitleLabel.Visible = True
        'LoadDataIntoDatagrid(ItemsListDataGridView, "SELECT DISTINCT e.`id`, CONCAT(e.`surname`, ' ', e.`first_name`) AS 'name' 
        '                                            FROM `tbl_employee` AS e, `tbl_salary_details_setup` AS s 
        '                                            WHERE  e.`id` = s.`empOrGrID` AND s.`type` = 'Employee'")
        'ItemsListDataGridView.Columns(0).Visible = False
        'ItemsListDataGridView.Columns(1).Width = ItemsListDataGridView.Width - 11
        'ItemsListDataGridView.Columns(1).HeaderText = "EMPLOYEES"
        'ItemsListDataGridView.ColumnHeadersHeight = 40
        'ItemsListDataGridView.Height = 500
        'itemsListDataGridView2.Visible = False
        'ItemsListPanel.Visible = True

        SalaryDetailsSetupForm.Show()
        Me.Hide()

    End Sub

    Private Sub ProcessPayrollButton_Click(sender As Object, e As EventArgs) Handles ProcessPayrollButton.Click
        clickedMenuButtonTextBox.Text = 5
        setupPanel.Visible = False
        salarySetupPanel.Visible = False
        CreatePayHeadPanel.Visible = False
        attendOrProdPanel.Visible = False
        setupPanel.Dock = DockStyle.None
        salarySetupPanel.Dock = DockStyle.None
        CreatePayHeadPanel.Dock = DockStyle.None
        attendOrProdPanel.Dock = DockStyle.None
        titleHeaderLabel.Text = ProcessPayrollButton.Text
        titleHeaderLabel.Visible = True
        processPayrollPanel.Dock = DockStyle.Fill
        ItemsListPanel.Visible = False
        processPayrollPanel.Visible = True

        ProcessPayrollForm.Show()

    End Sub

    Private Sub PayrollForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        LoginForm.Show()
    End Sub

    Private Sub AttendanceButton_Click(sender As Object, e As EventArgs) Handles AttendanceButton.Click
        clickedMenuButtonTextBox.Text = 4
        setupPanel.Visible = False
        salarySetupPanel.Visible = False
        CreatePayHeadPanel.Visible = False
        processPayrollPanel.Visible = False
        setupPanel.Dock = DockStyle.None
        salarySetupPanel.Dock = DockStyle.None
        CreatePayHeadPanel.Dock = DockStyle.None
        processPayrollPanel.Dock = DockStyle.None
        titleHeaderLabel.Text = AttendanceButton.Text
        titleHeaderLabel.Visible = True
        attendOrProdPanel.Dock = DockStyle.Fill
        attendOrProdPanel.Visible = True

        'Items List Panel & Datagridview
        'itemsListTitleLabel.Text = "Created Attendence Voucher"
        'itemsListTitleLabel.Visible = True
        'LoadDataIntoDatagrid(ItemsListDataGridView, "SELECT DISTINCT e.`id`, CONCAT(e.`surname`, ' ', e.`first_name`) AS 'name' 
        '                                            FROM `tbl_employee` AS e, `tbl_emp_attend_or_product_voucher` AS s 
        '                                            WHERE  e.`id` = s.`empid`")
        'ItemsListDataGridView.Columns(0).Visible = False
        'ItemsListDataGridView.Columns(1).Width = ItemsListDataGridView.Width - 11
        'ItemsListDataGridView.Columns(1).HeaderText = "EMPLOYEES"
        'ItemsListDataGridView.ColumnHeadersHeight = 40
        'ItemsListDataGridView.Height = 500
        'itemsListDataGridView2.Visible = False
        'ItemsListPanel.Visible = True

        AttendaceOrProductionVoucherForm.Show()

    End Sub

    Private Sub PayPeriodButton_Click(sender As Object, e As EventArgs) Handles PayPeriodButton.Click
        CreatePayPeriodForm.Show()
    End Sub

    Private Sub EmployeeButton_Click(sender As Object, e As EventArgs) Handles EmployeeButton.Click
        EmployeeForm.Show()
        Me.Hide()
    End Sub
End Class