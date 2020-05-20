Public Class ProcessPayrollForm
    Dim seconds As Integer = 0
    Dim doneProcessing As Integer = 0

    Private Sub ProcessPayrollForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        payPeriodIDTextBox.Text = runQueryAndReturnValue("SELECT `id` FROM `tbl_pay_process` WHERE `processed` = 0", "id")
        payrollPeriodTextBox.Text = runQueryAndReturnValue("SELECT `comment` FROM `tbl_pay_process` WHERE `processed` = 0", "comment")

    End Sub

    Private Sub empCategoryComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles empCategoryComboBox.SelectedIndexChanged
        empCatIDTextBox.Text = empCategoryComboBox.SelectedValue.ToString
    End Sub

    Private Sub empCategoryComboBox_Click(sender As Object, e As EventArgs) Handles empCategoryComboBox.Click
        FetchComboData(empCategoryComboBox, "SELECT * FROM `tbl_category`", "name")
        empCategoryComboBox.Text = ""
        empCatIDTextBox.Text = ""
    End Sub

    Private Sub empOrGroupNameTextBox_Click(sender As Object, e As EventArgs) Handles empOrGroupNameTextBox.Click
        SelectVoucherTypeForm.Show()
        SelectVoucherTypeForm.callFromTextBox.Text = 2
    End Sub

    Private Sub processPayrollButton_Click(sender As Object, e As EventArgs) Handles processPayrollButton.Click
        If payrollPeriodTextBox.Text = "" Or payrollPeriodTextBox.Text = "Select" Then
            Exit Sub
        End If

        seconds = 0
        doneProcessing = 1
        processPayrollTimer.Start()

        If LCase(empOrGroupTypeTextBox.Text) = "employee" Then
            employeeInit()
        ElseIf LCase(empOrGroupTypeTextBox.Text) = "group" Then
            groupInit()
        ElseIf LCase(empOrGroupTypeTextBox.Text) = "all items" Then
            allItemInit()
        End If

        'calcBasicSalary()
        'fixedTotals()
        'doneProcessing = 2
        'processEarnings()
        'processDeductions()
        'processContributions()
        'finalProcessingTouches()
        'doneProcessing = 3

    End Sub

    Private Sub processPayrollTimer_Tick(sender As Object, e As EventArgs) Handles processPayrollTimer.Tick

        If doneProcessing <= 1 Then
            processingInfoLabel.Text = "Initializing..."
        ElseIf doneProcessing = 2 Then
            processingInfoLabel.Text = "Processing..."
        ElseIf doneProcessing = 3 Then
            processingInfoLabel.Text = "Done in " & (seconds / 1000).ToString("n2") & " secs..."
            processPayrollTimer.Stop()
        End If

        seconds += 1

    End Sub

    Private Sub employeesDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles employeesDataGridView.CellContentClick

    End Sub

    Private Sub earningsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles earningsDataGridView.CellContentClick

    End Sub

    Private Sub deductionsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles deductionsDataGridView.CellContentClick

    End Sub

    Private Sub contributionsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles contributionsDataGridView.CellContentClick

    End Sub

    Private Sub ProcessPayrollForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        PayrollForm.Show()
    End Sub

    Private Sub employeeInit()

        LoadDataIntoDatagrid(employeesDataGridView, "SELECT DISTINCT e.`id`, CONCAT(e.`surname`, ' ', e.`first_name`) AS 'NAME'  
	                                                FROM `tbl_employee` AS e, `tbl_salary_details_setup` AS s 
                                                    WHERE e.`id` = s.`empOrGrID` AND s.`type` = 'Employee' 
                                                    AND e.`id` = '" & empOrGroupIDTextBox.Text & "'")

        LoadDataIntoDatagrid(earningsDataGridView, "SELECT DISTINCT e.* FROM `tbl_emp_earnings` AS e,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = e.`empid` 
                                                    AND s.`type` = 'Employee' AND e.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                    AND e.`empid` = '" & empOrGroupIDTextBox.Text & "'")

        LoadDataIntoDatagrid(applicableEarningsDataGridView, "Select DISTINCT e.* FROM `tbl_emp_applicable_earnings` As e,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = e.`empid` 
                                                    AND s.`type` = 'Employee' AND e.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                    AND e.`empid` = '" & empOrGroupIDTextBox.Text & "'")

        LoadDataIntoDatagrid(deductionsDataGridView, "SELECT DISTINCT d.* FROM `tbl_emp_deductions` AS d,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = d.`empid` 
                                                    AND s.`type` = 'Employee' AND d.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                    AND d.`empid` = '" & empOrGroupIDTextBox.Text & "'")

        LoadDataIntoDatagrid(applicableDeductionsDataGridView, "SELECT DISTINCT d.* FROM `tbl_emp_applicable_deductions` AS d,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = d.`empid` 
                                                    AND s.`type` = 'Employee' AND d.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                    AND d.`empid` = '" & empOrGroupIDTextBox.Text & "'")

        LoadDataIntoDatagrid(contributionsDataGridView, "SELECT DISTINCT c.* FROM `tbl_emp_contributions` AS c,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = c.`empid` 
                                                    AND s.`type` = 'Employee' AND c.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                    AND c.`empid` = '" & empOrGroupIDTextBox.Text & "'")

        LoadDataIntoDatagrid(applicableContributionsDataGridView, "SELECT DISTINCT c.* FROM `tbl_emp_applicable_contributions` AS c,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = c.`empid` 
                                                    AND s.`type` = 'Employee' AND c.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                    AND c.`empid` = '" & empOrGroupIDTextBox.Text & "'")

        employeesDataGridView.Columns("id").Visible = False

        earningsDataGridView.Columns("id").Visible = False
        earningsDataGridView.Columns("payid").Visible = False
        earningsDataGridView.Columns("empid").Visible = False
        earningsDataGridView.Columns("total").Visible = False
        earningsDataGridView.Columns("added_at").Visible = False
        earningsDataGridView.Columns("updated_at").Visible = False

        applicableEarningsDataGridView.Columns("id").Visible = False
        applicableEarningsDataGridView.Columns("payid").Visible = False
        applicableEarningsDataGridView.Columns("empid").Visible = False

        deductionsDataGridView.Columns("id").Visible = False
        deductionsDataGridView.Columns("payid").Visible = False
        deductionsDataGridView.Columns("empid").Visible = False
        deductionsDataGridView.Columns("total").Visible = False
        deductionsDataGridView.Columns("added_at").Visible = False
        deductionsDataGridView.Columns("updated_at").Visible = False

        applicableDeductionsDataGridView.Columns("id").Visible = False
        applicableDeductionsDataGridView.Columns("payid").Visible = False
        applicableDeductionsDataGridView.Columns("empid").Visible = False

        contributionsDataGridView.Columns("id").Visible = False
        contributionsDataGridView.Columns("payid").Visible = False
        contributionsDataGridView.Columns("empid").Visible = False
        contributionsDataGridView.Columns("total").Visible = False
        contributionsDataGridView.Columns("added_at").Visible = False
        contributionsDataGridView.Columns("updated_at").Visible = False

        applicableContributionsDataGridView.Columns("id").Visible = False
        applicableContributionsDataGridView.Columns("payid").Visible = False
        applicableContributionsDataGridView.Columns("empid").Visible = False

    End Sub

    Private Sub groupInit()

        LoadDataIntoDatagrid(employeesDataGridView, "SELECT DISTINCT e.`id`, CONCAT(e.`surname`, ' ', e.`first_name`) AS 'NAME'  
	                                                FROM `tbl_employee` AS e, `tbl_salary_details_setup` AS s 
                                                    WHERE e.`id` = s.`empOrGrID` AND s.`type` = 'Employee' 
                                                    AND e.`group` = '" & empOrGroupNameTextBox.Text & "'")

        LoadDataIntoDatagrid(earningsDataGridView, "SELECT DISTINCT e.* FROM `tbl_emp_earnings` AS e, `tbl_employee` AS m, 
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = e.`empid` 
                                                    AND m.`id` = e.`empid` AND m.`id` = s.`empOrGrID` AND s.`type` = 'Employee' 
                                                    AND e.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                    AND m.`group` = '" & empOrGroupNameTextBox.Text & "'")

        LoadDataIntoDatagrid(applicableEarningsDataGridView, "SELECT DISTINCT e.* FROM `tbl_emp_applicable_earnings` AS e, 
                                                              `tbl_employee` AS m, `tbl_salary_details_setup` AS s 
                                                              WHERE s.`empOrGrID` = e.`empid` AND m.`id` = e.`empid` 
                                                              AND m.`id` = s.`empOrGrID` AND s.`type` = 'Employee' 
                                                              AND e.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                              AND m.`group` = '" & empOrGroupNameTextBox.Text & "'")

        LoadDataIntoDatagrid(deductionsDataGridView, "SELECT DISTINCT d.* FROM `tbl_emp_deductions` AS d, `tbl_employee` AS m, 
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = d.`empid` 
                                                    AND m.`id` = d.`empid` AND m.`id` = s.`empOrGrID` AND s.`type` = 'Employee' 
                                                    AND d.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                    AND m.`group` = '" & empOrGroupNameTextBox.Text & "'")

        LoadDataIntoDatagrid(applicableDeductionsDataGridView, "SELECT DISTINCT d.* FROM `tbl_emp_applicable_deductions` AS d, 
                                                                `tbl_employee` AS m, `tbl_salary_details_setup` AS s 
                                                                WHERE s.`empOrGrID` = d.`empid` AND m.`id` = d.`empid` 
                                                                AND m.`id` = s.`empOrGrID` AND s.`type` = 'Employee' 
                                                                AND d.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                                AND m.`group` = '" & empOrGroupNameTextBox.Text & "'")

        LoadDataIntoDatagrid(contributionsDataGridView, "SELECT DISTINCT c.* FROM `tbl_emp_contributions` AS c, `tbl_employee` AS m, 
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = c.`empid` 
                                                    AND m.`id` = c.`empid` AND m.`id` = s.`empOrGrID` AND s.`type` = 'Employee' 
                                                    AND c.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                    AND m.`group` = '" & empOrGroupNameTextBox.Text & "'")

        LoadDataIntoDatagrid(applicableContributionsDataGridView, "SELECT DISTINCT c.* FROM `tbl_emp_applicable_contributions` AS c, 
                                                                   `tbl_employee` AS m, `tbl_salary_details_setup` AS s 
                                                                   WHERE s.`empOrGrID` = c.`empid` AND m.`id` = c.`empid` 
                                                                   AND m.`id` = s.`empOrGrID` AND s.`type` = 'Employee' 
                                                                   AND c.`payid` = '" & payPeriodIDTextBox.Text & "' 
                                                                   AND m.`group` = '" & empOrGroupNameTextBox.Text & "'")

        employeesDataGridView.Columns("id").Visible = False

        earningsDataGridView.Columns("id").Visible = False
        earningsDataGridView.Columns("payid").Visible = False
        earningsDataGridView.Columns("empid").Visible = False
        earningsDataGridView.Columns("total").Visible = False
        earningsDataGridView.Columns("added_at").Visible = False
        earningsDataGridView.Columns("updated_at").Visible = False

        applicableEarningsDataGridView.Columns("id").Visible = False
        applicableEarningsDataGridView.Columns("payid").Visible = False
        applicableEarningsDataGridView.Columns("empid").Visible = False

        deductionsDataGridView.Columns("id").Visible = False
        deductionsDataGridView.Columns("payid").Visible = False
        deductionsDataGridView.Columns("empid").Visible = False
        deductionsDataGridView.Columns("total").Visible = False
        deductionsDataGridView.Columns("added_at").Visible = False
        deductionsDataGridView.Columns("updated_at").Visible = False

        applicableDeductionsDataGridView.Columns("id").Visible = False
        applicableDeductionsDataGridView.Columns("payid").Visible = False
        applicableDeductionsDataGridView.Columns("empid").Visible = False

        contributionsDataGridView.Columns("id").Visible = False
        contributionsDataGridView.Columns("payid").Visible = False
        contributionsDataGridView.Columns("empid").Visible = False
        contributionsDataGridView.Columns("total").Visible = False
        contributionsDataGridView.Columns("added_at").Visible = False
        contributionsDataGridView.Columns("updated_at").Visible = False

        applicableContributionsDataGridView.Columns("id").Visible = False
        applicableContributionsDataGridView.Columns("payid").Visible = False
        applicableContributionsDataGridView.Columns("empid").Visible = False

    End Sub

    Private Sub allItemInit()

        LoadDataIntoDatagrid(employeesDataGridView, "SELECT DISTINCT e.`id`, CONCAT(e.`surname`, ' ', e.`first_name`) AS 'NAME'  
	                                                FROM `tbl_employee` AS e, `tbl_salary_details_setup` AS s 
                                                    WHERE e.`id` = s.`empOrGrID` AND s.`type` = 'Employee'")

        LoadDataIntoDatagrid(earningsDataGridView, "SELECT DISTINCT e.* FROM `tbl_emp_earnings` AS e,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = e.`empid` 
                                                    AND s.`type` = 'Employee' AND e.`payid` = '" & payPeriodIDTextBox.Text & "'")

        LoadDataIntoDatagrid(applicableEarningsDataGridView, "SELECT DISTINCT e.* FROM `tbl_emp_applicable_earnings` AS e,
	                                                    `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = e.`empid` 
                                                        AND s.`type` = 'Employee' AND e.`payid` = '" & payPeriodIDTextBox.Text & "'")

        LoadDataIntoDatagrid(deductionsDataGridView, "SELECT DISTINCT d.* FROM `tbl_emp_deductions` AS d,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = d.`empid` 
                                                    AND s.`type` = 'Employee' AND d.`payid` = '" & payPeriodIDTextBox.Text & "'")

        LoadDataIntoDatagrid(applicableDeductionsDataGridView, "SELECT DISTINCT d.* FROM `tbl_emp_applicable_deductions` AS d,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = d.`empid` 
                                                    AND s.`type` = 'Employee' AND d.`payid` = '" & payPeriodIDTextBox.Text & "'")

        LoadDataIntoDatagrid(contributionsDataGridView, "SELECT DISTINCT c.* FROM `tbl_emp_contributions` AS c,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = c.`empid` 
                                                    AND s.`type` = 'Employee' AND c.`payid` = '" & payPeriodIDTextBox.Text & "'")

        LoadDataIntoDatagrid(applicableContributionsDataGridView, "SELECT DISTINCT c.* FROM `tbl_emp_applicable_contributions` AS c,
	                                                `tbl_salary_details_setup` AS s WHERE s.`empOrGrID` = c.`empid` 
                                                    AND s.`type` = 'Employee' AND c.`payid` = '" & payPeriodIDTextBox.Text & "'")

        employeesDataGridView.Columns("id").Visible = False

        earningsDataGridView.Columns("id").Visible = False
        earningsDataGridView.Columns("payid").Visible = False
        earningsDataGridView.Columns("empid").Visible = False
        earningsDataGridView.Columns("total").Visible = False
        earningsDataGridView.Columns("added_at").Visible = False
        earningsDataGridView.Columns("updated_at").Visible = False

        applicableEarningsDataGridView.Columns("id").Visible = False
        applicableEarningsDataGridView.Columns("payid").Visible = False
        applicableEarningsDataGridView.Columns("empid").Visible = False

        deductionsDataGridView.Columns("id").Visible = False
        deductionsDataGridView.Columns("payid").Visible = False
        deductionsDataGridView.Columns("empid").Visible = False
        deductionsDataGridView.Columns("total").Visible = False
        deductionsDataGridView.Columns("added_at").Visible = False
        deductionsDataGridView.Columns("updated_at").Visible = False

        applicableDeductionsDataGridView.Columns("id").Visible = False
        applicableDeductionsDataGridView.Columns("payid").Visible = False
        applicableDeductionsDataGridView.Columns("empid").Visible = False

        contributionsDataGridView.Columns("id").Visible = False
        contributionsDataGridView.Columns("payid").Visible = False
        contributionsDataGridView.Columns("empid").Visible = False
        contributionsDataGridView.Columns("total").Visible = False
        contributionsDataGridView.Columns("added_at").Visible = False
        contributionsDataGridView.Columns("updated_at").Visible = False

        applicableContributionsDataGridView.Columns("id").Visible = False
        applicableContributionsDataGridView.Columns("payid").Visible = False
        applicableContributionsDataGridView.Columns("empid").Visible = False
    End Sub

    Private Sub fixedTotals()

        Dim x As Integer = 0

        'For earnings
        For col = 3 To applicableEarningsDataGridView.ColumnCount - 1
            Dim query As String = ""

            If col = applicableEarningsDataGridView.ColumnCount - 1 Then
                query += " `" & applicableEarningsDataGridView.Columns(col).Name & "`"

                If runQuery("ALTER TABLE `tbl_emp_earnings` DROP column `total`") = 1 Then
                    If runQuery("ALTER TABLE `tbl_emp_earnings` ADD COLUMN `total` DECIMAL(10,2) AS (" & query & ") STORED 
                                AFTER `" & applicableEarningsDataGridView.Columns(col).Name & "`") = 1 Then
                        x += 1
                    End If
                End If

            Else
                query += "`" & applicableEarningsDataGridView.Columns(col).Name & "` + "

            End If
        Next

        'For Deductions
        For col = 3 To applicableDeductionsDataGridView.ColumnCount - 1
            Dim query As String = ""

            If col = applicableDeductionsDataGridView.ColumnCount - 1 Then
                query += " `" & applicableDeductionsDataGridView.Columns(col).Name & "`"

                If runQuery("ALTER TABLE `tbl_emp_deductions` DROP column `total`") = 1 Then
                    If runQuery("ALTER TABLE `tbl_emp_deductions` ADD COLUMN `total` DECIMAL(10,2) AS (" & query & ") STORED 
                                AFTER `" & applicableDeductionsDataGridView.Columns(col).Name & "`") = 1 Then
                        x += 1
                    End If
                End If

            Else
                query += "`" & applicableDeductionsDataGridView.Columns(col).Name & "` + "

            End If
        Next

        'For Contributions
        For col = 3 To applicableContributionsDataGridView.ColumnCount - 1
            Dim query As String = ""

            If col = applicableContributionsDataGridView.ColumnCount - 1 Then
                query += " `" & applicableContributionsDataGridView.Columns(col).Name & "`"

                If runQuery("ALTER TABLE `tbl_emp_contributions` DROP column `total`") = 1 Then
                    If runQuery("ALTER TABLE `tbl_emp_contributions` ADD COLUMN `total` DECIMAL(10,2) AS (" & query & ") STORED 
                                AFTER `" & applicableContributionsDataGridView.Columns(col).Name & "`") = 1 Then
                        x += 1
                    End If
                End If

            Else
                query += "`" & applicableContributionsDataGridView.Columns(col).Name & "` + "

            End If
        Next

        If x = 3 Then
            doneProcessing = 1
        End If

    End Sub

    Private Sub calcBasicSalary()
        Dim x As Integer = 0

        For col = 3 To applicableEarningsDataGridView.ColumnCount - 1
            For row = 0 To applicableEarningsDataGridView.RowCount - 2

                Dim calculation_type As String = runQueryAndReturnValue("SELECT `calculation_type` FROM `tbl_pay_head` 
                                              WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'", "calculation_type")

                'Here we don't need to compute for the by user defined and flat rate type
                'because they are cared for already. Only those involving calculations are care for here

                If calculation_type = "On Attendance" Then

                    If runQueryAndReturnValue("SELECT `pay_type` FROM `tbl_pay_head` 
                                              WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                              "pay_type") = "Basic Salary" Then
                        'Number of working days by company
                        Dim payAtt As String = runQueryAndReturnValue("SELECT `period_of` FROM `tbl_pay_head` 
                                            WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                   "period_of")
                        If payAtt <> "" Then
                            'get the type of attendance(present, absent) from pay head table
                            Dim attOrprod1 As String = runQueryAndReturnValue("SELECT `attend_or_prod_type` FROM `tbl_pay_head` 
                                                WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                          "attend_or_prod_type")

                            'get the type of attendance or production (present, absent, overtime etc) from pay head table
                            Dim attOrprod2 As String = runQueryAndReturnValue("SELECT `type` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                       "type")

                            'Check if 'attend_or_prod_type' in pay head table is the same as 'type' in 
                            'the tbl_emp_attend_or_product_voucher
                            If attOrprod1 = attOrprod2 Then

                                'get the pay head's id from the salary details setup table
                                Dim phid As Integer = runQueryAndReturnValue("SELECT DISTINCT s.`phid` FROM `tbl_salary_details_setup` AS s,  
                                             `tbl_pay_head` AS p WHERE p.`name` = '" & applicableEarningsDataGridView.Columns(col).Name & "' 
                                             AND p.`id` = s.`phid` AND p.`attend_or_prod_type` = '" & attOrprod1 & "'", "phid")

                                'get the pay rate of the employee for the pay head
                                Dim payRate As Decimal = runQueryAndReturnValue("SELECT `rate` FROM `tbl_salary_details_setup` 
                                            WHERE `type` = 'Employee' 
                                            AND `empOrGrID` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `phid` = '" & phid & "'", "rate")

                                'Get employee's working days in the set period/month
                                Dim empDaysAttend As Integer = runQueryAndReturnValue("SELECT `value` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `type` = '" & attOrprod1 & "' 
                                            AND `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                           "value")

                                Dim dailyWage As Decimal = payRate / CInt(payAtt)  'Daily wage of the employee
                                Dim monthEarning As Decimal = dailyWage * empDaysAttend 'Monthly salary of the employee

                                MsgBox("Basic: " & payRate & "Daily: " & dailyWage & " Month: " & monthEarning)

                                If runQuery("UPDATE `tbl_emp_earnings` 
                                            SET `" & applicableEarningsDataGridView.Columns(col).Name & "` = '" & monthEarning & "' 
                                            WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'") = 1 Then

                                    If runQuery("UPDATE `tbl_payroll` SET `daily_wage` = '" & dailyWage & "' 
                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'") = 1 Then
                                        x += 1
                                    End If

                                End If

                            End If

                        End If
                    End If

                End If

            Next
        Next

    End Sub

    Private Sub processEarnings()

        Dim x As Integer = 0

        For row = 0 To applicableEarningsDataGridView.RowCount - 2
            For col = 3 To applicableEarningsDataGridView.ColumnCount - 1

                Dim calculation_type As String = runQueryAndReturnValue("SELECT `calculation_type` FROM `tbl_pay_head` 
                                              WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                        "calculation_type")

                'Here we don't need to compute for the by user defined and flat rate type
                'because they are cared for already. Only those involving calculations are care for here
                If calculation_type = "On Production" Then

                    'get the type of attendance or production (present, absent, overtime etc) from pay head table
                    Dim attOrprod1 As String = runQueryAndReturnValue("SELECT `attend_or_prod_type` FROM `tbl_pay_head` 
                                                WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                          "attend_or_prod_type")

                    'get the type of attendance or production (overtime etc) from pay head table
                    Dim attOrprod2 As String = runQueryAndReturnValue("SELECT `type` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                       "type")

                    'Check to see if 'attend_or_prod_type' in pay head table is the same as 'type' in 
                    'the tbl_emp_attend_or_product_voucher
                    If attOrprod1 = attOrprod2 Then

                        Dim unit As String = runQueryAndReturnValue("SELECT `unit` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                       "unit")

                        'get the pay head's id from the salary details setup table
                        Dim phid As Integer = runQueryAndReturnValue("SELECT DISTINCT s.`phid` FROM `tbl_salary_details_setup` AS s,  
                                             `tbl_pay_head` AS p WHERE p.`name` = '" & applicableEarningsDataGridView.Columns(col).Name & "' 
                                             AND p.`id` = s.`phid` AND p.`attend_or_prod_type` = '" & attOrprod1 & "'", "phid")

                        'get the pay rate of the employee for the pay head
                        Dim payRate As Decimal = runQueryAndReturnValue("SELECT `rate` FROM `tbl_salary_details_setup` 
                                            WHERE `type` = 'Employee' 
                                            AND `empOrGrID` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `phid` = '" & phid & "'", "rate")

                        'Get employee's working days in the set period/month
                        Dim empProdHours As Integer = runQueryAndReturnValue("SELECT `value` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `type` = '" & attOrprod1 & "' 
                                            AND `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                               "value")
                        Dim prodEarning As Decimal = 0

                        If unit = "Hrs" Then
                            prodEarning = payRate * empProdHours     'monthly prod earnings of the employee
                        ElseIf unit = "Hrs of 60 Mins" Then
                            prodEarning = payRate * empProdHours     'monthly prod earnings of the employee
                        End If

                        If runQuery("UPDATE `tbl_emp_earnings` 
                                    SET `" & applicableEarningsDataGridView.Columns(col).Name & "` = '" & prodEarning & "' 
                                    WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' AND 
                                    `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'") = 1 Then
                            x = 1
                        End If

                    End If

                ElseIf calculation_type = "On Attendance" Then

                    'Number of working days by company
                    Dim payAtt As String = runQueryAndReturnValue("SELECT `period_of` FROM `tbl_pay_head` 
                                            WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                       "period_of")
                    If payAtt <> "" Then
                        'get the type of attendance(present, absent) from pay head table
                        Dim attOrprod1 As String = runQueryAndReturnValue("SELECT `attend_or_prod_type` FROM `tbl_pay_head` 
                                                WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                              "attend_or_prod_type")

                        'get the type of attendance or production (present, absent, overtime etc) from pay head table
                        Dim attOrprod2 As String = runQueryAndReturnValue("SELECT `type` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                           "type")

                        'Check if 'attend_or_prod_type' in pay head table is the same as 'type' in 
                        'the tbl_emp_attend_or_product_voucher
                        If attOrprod1 = attOrprod2 Then

                            'get the pay head's id from the salary details setup table
                            Dim phid As Integer = runQueryAndReturnValue("SELECT DISTINCT s.`phid` FROM `tbl_salary_details_setup` AS s,  
                                             `tbl_pay_head` AS p WHERE p.`name` = '" & applicableEarningsDataGridView.Columns(col).Name & "' 
                                             AND p.`id` = s.`phid` AND p.`attend_or_prod_type` = '" & attOrprod1 & "'", "phid")

                            'get the pay rate of the employee for the pay head
                            Dim payRate As Decimal = runQueryAndReturnValue("SELECT `rate` FROM `tbl_salary_details_setup` 
                                            WHERE `type` = 'Employee' 
                                            AND `empOrGrID` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `phid` = '" & phid & "'", "rate")

                            'Get employee's working days in the set period/month
                            Dim empDaysAttend As Integer = runQueryAndReturnValue("SELECT `value` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `type` = '" & attOrprod1 & "' 
                                            AND `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                               "value")

                            Dim dailyWage As Decimal = payRate / CInt(payAtt)  'Daily wage of the employee
                            Dim monthEarning As Decimal = dailyWage * empDaysAttend 'Monthly salary of the employee

                            If runQuery("UPDATE `tbl_emp_earnings` SET `" & applicableEarningsDataGridView.Columns(col).Name & "` = '" & monthEarning & "'") = 1 Then
                                If runQueryAndReturnValue("SELECT `pay_type` FROM `tbl_pay_head` 
                                                        WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                          "pay_type") = "Basic Salary" Then
                                    If runQuery("UPDATE `tbl_payroll` SET `daily_wage` = '" & dailyWage & "'") = 1 Then
                                        x += 1
                                    End If
                                Else
                                    x += 1
                                End If
                            End If

                        End If

                    End If

                ElseIf calculation_type = "As Computed Value" Then

                    Dim compute_on As String = runQueryAndReturnValue("SELECT `compute_on` FROM `tbl_pay_head` 
                                       WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'", "compute_on")

                    If LCase(compute_on) = "on specified formula" Then

                        Dim phid As Integer = runQueryAndReturnValue("SELECT f.`phid` FROM `tbl_specified_formula` AS f, 
                                                                    `tbl_pay_head` AS p WHERE p.`id` = f.`phid` 
                                                                    AND p.`name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                     "phid")

                        '
                        ' Computation Info part
                        '
                        If speciFiedFormulaDataGridView.Visible = True Then
                            speciFiedFormulaDataGridView.DataSource = DBNull.Value
                        End If

                        LoadDataIntoDatagrid(speciFiedFormulaDataGridView,
                                             "SELECT * FROM `tbl_specified_formula` WHERE `phid` = '" & phid & "'")
                        speciFiedFormulaDataGridView.Columns("id").Visible = False
                        speciFiedFormulaDataGridView.Columns("phid").Visible = False

                        If speciFiedFormulaDataGridView.RowCount - 1 = 1 Then

                            Dim amount As Decimal = 0

                            For index = 0 To speciFiedFormulaDataGridView.RowCount - 2

                                If runQueryAndReturnValue("SELECT p.`pay_type` FROM `tbl_specified_formula` AS s,  
                                                `tbl_pay_head` AS p WHERE p.`id` = s.`phid` 
                                                AND p.`name` = '" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "'
                                                AND s.`phid` = '" & phid & "'", "pay_type") = "Basic Salary" Then

                                    Dim fieldType As String = runQueryAndReturnValue("SELECT p.`pay_head_type` 
                                                            FROM `tbl_specified_formula` AS f, `tbl_pay_head` AS p 
                                                            WHERE p.`name` = '" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "'",
                                                                "pay_head_type")


                                    If speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Add Pay Head" Then

                                        If fieldType = "Earnings for Employees" Then
                                            amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                        ElseIf fieldType = "Deductions from Employees" Then
                                            amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                        ElseIf fieldType = "Contributions by Employer" Then
                                            amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                        End If


                                    ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Substract Pay Head" Then

                                        If fieldType = "Earnings for Employees" Then
                                            amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                        ElseIf fieldType = "Deductions from Employees" Then
                                            amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                        ElseIf fieldType = "Contributions by Employer" Then
                                            amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                        End If

                                    ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Divide by Attendance" Then

                                        If fieldType = "Earnings for Employees" Then
                                            amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                        ElseIf fieldType = "Deductions from Employees" Then
                                            amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                        ElseIf fieldType = "Contributions by Employer" Then
                                            amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                        End If
                                    ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Multiply by Attendance" Then

                                        If fieldType = "Earnings for Employees" Then
                                            amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                        ElseIf fieldType = "Deductions from Employees" Then
                                            amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                        ElseIf fieldType = "Contributions by Employer" Then
                                            amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                        End If
                                    End If

                                End If

                            Next

                            '
                            ' Computation Info part
                            '

                            'Empty dgv and load for computation info
                            speciFiedFormulaDataGridView.DataSource = DBNull.Value
                            LoadDataIntoDatagrid(speciFiedFormulaDataGridView,
                                                 "SELECT * FROM `tbl_computation_info` WHERE `phid` = '" & phid & "'")
                            speciFiedFormulaDataGridView.Columns("id").Visible = False
                            speciFiedFormulaDataGridView.Columns("phid").Visible = False

                            For index = 0 To speciFiedFormulaDataGridView.RowCount - 2
                                Dim value As Decimal = 0

                                'If speciFiedFormulaDataGridView.Rows(index).Cells("amount_from").Value = 0 Then

                                'End If

                                If amount >= speciFiedFormulaDataGridView.Rows(index).Cells("amount_from").Value Then
                                    If amount <= speciFiedFormulaDataGridView.Rows(index).Cells("amount_to").Value Or speciFiedFormulaDataGridView.Rows(index).Cells("amount_to").Value = 0 Then
                                        If speciFiedFormulaDataGridView.Rows(index).Cells("slab_type").Value = "Percentage" Then
                                            value = amount * speciFiedFormulaDataGridView.Rows(index).Cells("value_basis").Value
                                        ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("slab_type").Value = "Value" Then
                                            value = speciFiedFormulaDataGridView.Rows(index).Cells("value_basis").Value
                                        End If
                                    End If
                                End If

                                If runQuery("UPDATE `tbl_emp_earnings`  
                                                    SET `" & applicableEarningsDataGridView.Columns(col).Name & "` = '" & value & "' 
                                                    WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' AND 
                                                    `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'") = 1 Then
                                    x += 1
                                End If

                            Next

                        End If

                    End If

                End If

            Next
        Next

    End Sub

    Private Sub processEarningsGen()

        Dim x As Integer = 0

        For row = 0 To applicableEarningsDataGridView.RowCount - 2
            For col = 3 To applicableEarningsDataGridView.ColumnCount - 1

                Dim calculation_type As String = runQueryAndReturnValue("SELECT `calculation_type` FROM `tbl_pay_head` 
                                              WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                        "calculation_type")

                'Here we don't need to compute for the by user defined and flat rate type
                'because they are cared for already. Only those involving calculations are care for here
                If calculation_type = "On Production" Then

                    'get the type of attendance or production (present, absent, overtime etc) from pay head table
                    Dim attOrprod1 As String = runQueryAndReturnValue("SELECT `attend_or_prod_type` FROM `tbl_pay_head` 
                                                WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                          "attend_or_prod_type")

                    'get the type of attendance or production (overtime etc) from pay head table
                    Dim attOrprod2 As String = runQueryAndReturnValue("SELECT `type` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                       "type")

                    'Check to see if 'attend_or_prod_type' in pay head table is the same as 'type' in 
                    'the tbl_emp_attend_or_product_voucher
                    If attOrprod1 = attOrprod2 Then

                        Dim unit As String = runQueryAndReturnValue("SELECT `unit` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                       "unit")

                        'get the pay head's id from the salary details setup table
                        Dim phid As Integer = runQueryAndReturnValue("SELECT DISTINCT s.`phid` FROM `tbl_salary_details_setup` AS s,  
                                             `tbl_pay_head` AS p WHERE p.`name` = '" & applicableEarningsDataGridView.Columns(col).Name & "' 
                                             AND p.`id` = s.`phid` AND p.`attend_or_prod_type` = '" & attOrprod1 & "'", "phid")

                        'get the pay rate of the employee for the pay head
                        Dim payRate As Decimal = runQueryAndReturnValue("SELECT `rate` FROM `tbl_salary_details_setup` 
                                            WHERE `type` = 'Employee' 
                                            AND `empOrGrID` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `phid` = '" & phid & "'", "rate")

                        'Get employee's working days in the set period/month
                        Dim empProdHours As Integer = runQueryAndReturnValue("SELECT `value` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `type` = '" & attOrprod1 & "' 
                                            AND `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                               "value")
                        Dim prodEarning As Decimal = 0

                        If unit = "Hrs" Then
                            prodEarning = payRate * empProdHours     'monthly prod earnings of the employee
                        ElseIf unit = "Hrs of 60 Mins" Then
                            prodEarning = payRate * empProdHours     'monthly prod earnings of the employee
                        End If

                        If runQuery("UPDATE `tbl_emp_earnings` 
                                    SET `" & applicableEarningsDataGridView.Columns(col).Name & "` = '" & prodEarning & "' 
                                    WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' AND 
                                    `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'") = 1 Then
                            x = 1
                        End If

                    End If

                ElseIf calculation_type = "On Attendance" Then

                    'Number of working days by company
                    Dim payAtt As String = runQueryAndReturnValue("SELECT `period_of` FROM `tbl_pay_head` 
                                            WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                       "period_of")
                    If payAtt <> "" Then
                        'get the type of attendance(present, absent) from pay head table
                        Dim attOrprod1 As String = runQueryAndReturnValue("SELECT `attend_or_prod_type` FROM `tbl_pay_head` 
                                                WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                              "attend_or_prod_type")

                        'get the type of attendance or production (present, absent, overtime etc) from pay head table
                        Dim attOrprod2 As String = runQueryAndReturnValue("SELECT `type` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                           "type")

                        'Check if 'attend_or_prod_type' in pay head table is the same as 'type' in 
                        'the tbl_emp_attend_or_product_voucher
                        If attOrprod1 = attOrprod2 Then

                            'get the pay head's id from the salary details setup table
                            Dim phid As Integer = runQueryAndReturnValue("SELECT DISTINCT s.`phid` FROM `tbl_salary_details_setup` AS s,  
                                             `tbl_pay_head` AS p WHERE p.`name` = '" & applicableEarningsDataGridView.Columns(col).Name & "' 
                                             AND p.`id` = s.`phid` AND p.`attend_or_prod_type` = '" & attOrprod1 & "'", "phid")

                            'get the pay rate of the employee for the pay head
                            Dim payRate As Decimal = runQueryAndReturnValue("SELECT `rate` FROM `tbl_salary_details_setup` 
                                            WHERE `type` = 'Employee' 
                                            AND `empOrGrID` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `phid` = '" & phid & "'", "rate")

                            'Get employee's working days in the set period/month
                            Dim empDaysAttend As Integer = runQueryAndReturnValue("SELECT `value` FROM `tbl_emp_attend_or_product_voucher` 
                                            WHERE `type` = '" & attOrprod1 & "' 
                                            AND `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                            AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                               "value")

                            Dim dailyWage As Decimal = payRate / CInt(payAtt)  'Daily wage of the employee
                            Dim monthEarning As Decimal = dailyWage * empDaysAttend 'Monthly salary of the employee

                            If runQuery("UPDATE `tbl_emp_earnings` SET `" & applicableEarningsDataGridView.Columns(col).Name & "` = '" & monthEarning & "'") = 1 Then
                                If runQueryAndReturnValue("SELECT `pay_type` FROM `tbl_pay_head` 
                                                        WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                          "pay_type") = "Basic Salary" Then
                                    If runQuery("UPDATE `tbl_payroll` SET `daily_wage` = '" & dailyWage & "'") = 1 Then
                                        x += 1
                                    End If
                                Else
                                    x += 1
                                End If
                            End If

                        End If

                    End If

                ElseIf calculation_type = "As Computed Value" Then

                    Dim compute_on As String = runQueryAndReturnValue("SELECT `compute_on` FROM `tbl_pay_head` 
                                       WHERE `name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'", "compute_on")

                    If LCase(compute_on) = "on specified formula" Then

                        Dim phid As Integer = runQueryAndReturnValue("SELECT f.`phid` FROM `tbl_specified_formula` AS f, 
                                                                    `tbl_pay_head` AS p WHERE p.`id` = f.`phid` 
                                                                    AND p.`name` = '" & applicableEarningsDataGridView.Columns(col).Name & "'",
                                                                     "phid")


                        '
                        ' Computation Info part
                        '
                        If speciFiedFormulaDataGridView.Visible = True Then
                            speciFiedFormulaDataGridView.DataSource = DBNull.Value
                        End If

                        LoadDataIntoDatagrid(speciFiedFormulaDataGridView,
                                             "SELECT * FROM `tbl_specified_formula` WHERE `phid` = '" & phid & "'")
                        speciFiedFormulaDataGridView.Columns("id").Visible = False
                        speciFiedFormulaDataGridView.Columns("phid").Visible = False

                        If speciFiedFormulaDataGridView.RowCount - 1 > 0 Then

                            Dim amount As Decimal = 0

                            For index = 0 To speciFiedFormulaDataGridView.RowCount - 2

                                Dim fieldType As String = runQueryAndReturnValue("SELECT p.`pay_head_type` 
                                                            FROM `tbl_specified_formula` AS f, `tbl_pay_head` AS p 
                                                            WHERE p.`name` = '" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "'",
                                                                "pay_head_type")


                                If speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Add Pay Head" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If


                                ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Substract Pay Head" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If

                                ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Divide by Attendance" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If
                                ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Multiply by Attendance" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If
                                End If

                            Next

                            '
                            ' Computation Info part
                            '

                            'Empty dgv and load for computation info
                            speciFiedFormulaDataGridView.DataSource = DBNull.Value
                            LoadDataIntoDatagrid(speciFiedFormulaDataGridView,
                                                 "SELECT * FROM `tbl_computation_info` WHERE `phid` = '" & phid & "'")
                            speciFiedFormulaDataGridView.Columns("id").Visible = False
                            speciFiedFormulaDataGridView.Columns("phid").Visible = False

                            For index = 0 To speciFiedFormulaDataGridView.RowCount - 2
                                Dim value As Decimal = 0

                                'If speciFiedFormulaDataGridView.Rows(index).Cells("amount_from").Value = 0 Then

                                'End If

                                If amount >= speciFiedFormulaDataGridView.Rows(index).Cells("amount_from").Value Then
                                    If amount <= speciFiedFormulaDataGridView.Rows(index).Cells("amount_to").Value Or speciFiedFormulaDataGridView.Rows(index).Cells("amount_to").Value = 0 Then
                                        If speciFiedFormulaDataGridView.Rows(index).Cells("slab_type").Value = "Percentage" Then
                                            value = amount * speciFiedFormulaDataGridView.Rows(index).Cells("value_basis").Value
                                        ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("slab_type").Value = "Value" Then
                                            value = speciFiedFormulaDataGridView.Rows(index).Cells("value_basis").Value
                                        End If
                                    End If
                                End If

                                If runQuery("UPDATE `tbl_emp_earnings`  
                                                    SET `" & applicableEarningsDataGridView.Columns(col).Name & "` = '" & value & "' 
                                                    WHERE `empid` = '" & applicableEarningsDataGridView.Rows(row).Cells("empid").Value & "' AND 
                                                    `payid` = '" & applicableEarningsDataGridView.Rows(row).Cells("payid").Value & "'") = 1 Then
                                    x += 1
                                End If

                            Next

                        End If

                    End If

                End If

            Next
        Next

    End Sub

    Private Sub processDeductions()
        Dim app_ded_columns As Integer = applicableDeductionsDataGridView.ColumnCount

        Dim x As Integer = 0

        For row = 0 To applicableDeductionsDataGridView.RowCount - 2
            For col = 3 To applicableDeductionsDataGridView.ColumnCount - 1

                Dim calculation_type As String = runQueryAndReturnValue("SELECT `calculation_type` FROM `tbl_pay_head` 
                                              WHERE `name` = '" & applicableDeductionsDataGridView.Columns(col).Name & "'",
                                                                        "calculation_type")

                If calculation_type = "As Computed Value" Then

                    Dim compute_on As String = runQueryAndReturnValue("SELECT `compute_on` FROM `tbl_pay_head` 
                                       WHERE `name` = '" & applicableDeductionsDataGridView.Columns(col).Name & "'", "compute_on")

                    If LCase(compute_on) = "on specified formula" Then

                        Dim phid As Integer = runQueryAndReturnValue("SELECT f.`phid` FROM `tbl_specified_formula` AS f, 
                                                                    `tbl_pay_head` AS p WHERE p.`id` = f.`phid` 
                                                                    AND p.`name` = '" & applicableDeductionsDataGridView.Columns(col).Name & "'",
                                                                     "phid")


                        '
                        ' Computation Info part
                        '
                        If speciFiedFormulaDataGridView.Visible = True Then
                            speciFiedFormulaDataGridView.DataSource = DBNull.Value
                        End If

                        LoadDataIntoDatagrid(speciFiedFormulaDataGridView,
                                             "SELECT * FROM `tbl_specified_formula` WHERE `phid` = '" & phid & "'")
                        speciFiedFormulaDataGridView.Columns("id").Visible = False
                        speciFiedFormulaDataGridView.Columns("phid").Visible = False

                        If speciFiedFormulaDataGridView.RowCount - 1 > 0 Then

                            Dim amount As Decimal = 0

                            For index = 0 To speciFiedFormulaDataGridView.RowCount - 2

                                Dim fieldType As String = runQueryAndReturnValue("SELECT p.`pay_head_type` 
                                                            FROM `tbl_specified_formula` AS f, `tbl_pay_head` AS p 
                                                            WHERE p.`name` = '" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "'",
                                                                "pay_head_type")


                                If speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Add Pay Head" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If


                                ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Substract Pay Head" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If

                                ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Divide by Attendance" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If
                                ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Multiply by Attendance" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If
                                End If

                            Next

                            MsgBox(amount)

                            '
                            ' Computation Info part
                            '

                            'Empty dgv and load for computation info
                            speciFiedFormulaDataGridView.DataSource = DBNull.Value
                            LoadDataIntoDatagrid(speciFiedFormulaDataGridView,
                                                 "SELECT * FROM `tbl_computation_info` WHERE `phid` = '" & phid & "'")
                            speciFiedFormulaDataGridView.Columns("id").Visible = False
                            speciFiedFormulaDataGridView.Columns("phid").Visible = False

                            For index = 0 To speciFiedFormulaDataGridView.RowCount - 2
                                Dim value As Decimal = 0

                                'If speciFiedFormulaDataGridView.Rows(index).Cells("amount_from").Value = 0 Then

                                'End If

                                If amount >= speciFiedFormulaDataGridView.Rows(index).Cells("amount_from").Value Then
                                    If amount <= speciFiedFormulaDataGridView.Rows(index).Cells("amount_to").Value Or speciFiedFormulaDataGridView.Rows(index).Cells("amount_to").Value = 0 Then
                                        If speciFiedFormulaDataGridView.Rows(index).Cells("slab_type").Value = "Percentage" Then
                                            value = amount * speciFiedFormulaDataGridView.Rows(index).Cells("value_basis").Value
                                        ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("slab_type").Value = "Value" Then
                                            value = speciFiedFormulaDataGridView.Rows(index).Cells("value_basis").Value
                                        End If
                                    End If
                                End If

                                If runQuery("UPDATE `tbl_emp_deductions`  
                                                    SET `" & applicableDeductionsDataGridView.Columns(col).Name & "` = '" & value & "' 
                                                    WHERE `empid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("empid").Value & "' AND 
                                                    `payid` = '" & applicableDeductionsDataGridView.Rows(row).Cells("payid").Value & "'") = 1 Then
                                    x += 1
                                End If

                            Next

                        End If

                    End If

                End If

            Next
        Next
    End Sub

    Private Sub processContributions()
        Dim app_earn_columns As Integer = applicableContributionsDataGridView.ColumnCount

        Dim x As Integer = 0

        For row = 0 To applicableContributionsDataGridView.RowCount - 2
            For col = 3 To applicableContributionsDataGridView.ColumnCount - 1

                Dim calculation_type As String = runQueryAndReturnValue("SELECT `calculation_type` FROM `tbl_pay_head` 
                                              WHERE `name` = '" & applicableContributionsDataGridView.Columns(col).Name & "'",
                                                                        "calculation_type")

                If calculation_type = "As Computed Value" Then

                    Dim compute_on As String = runQueryAndReturnValue("SELECT `compute_on` FROM `tbl_pay_head` 
                                       WHERE `name` = '" & applicableContributionsDataGridView.Columns(col).Name & "'", "compute_on")

                    If LCase(compute_on) = "on specified formula" Then

                        Dim phid As Integer = runQueryAndReturnValue("SELECT f.`phid` FROM `tbl_specified_formula` AS f, 
                                                                    `tbl_pay_head` AS p WHERE p.`id` = f.`phid` 
                                                                    AND p.`name` = '" & applicableContributionsDataGridView.Columns(col).Name & "'",
                                                                     "phid")


                        '
                        ' Computation Info part
                        '
                        If speciFiedFormulaDataGridView.Visible = True Then
                            speciFiedFormulaDataGridView.DataSource = DBNull.Value
                        End If

                        LoadDataIntoDatagrid(speciFiedFormulaDataGridView,
                                             "SELECT * FROM `tbl_specified_formula` WHERE `phid` = '" & phid & "'")
                        speciFiedFormulaDataGridView.Columns("id").Visible = False
                        speciFiedFormulaDataGridView.Columns("phid").Visible = False

                        If speciFiedFormulaDataGridView.RowCount - 1 > 0 Then

                            Dim amount As Decimal = 0

                            For index = 0 To speciFiedFormulaDataGridView.RowCount - 2

                                Dim fieldType As String = runQueryAndReturnValue("SELECT p.`pay_head_type` 
                                                            FROM `tbl_specified_formula` AS f, `tbl_pay_head` AS p 
                                                            WHERE p.`name` = '" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "'",
                                                                "pay_head_type")


                                If speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Add Pay Head" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount += CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If


                                ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Substract Pay Head" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount -= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If

                                ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Divide by Attendance" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount /= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If
                                ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("function").Value = "Multiply by Attendance" Then

                                    If fieldType = "Earnings for Employees" Then
                                        amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_earnings` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                                "pay_amount"))

                                    ElseIf fieldType = "Deductions from Employees" Then
                                        amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_deductions` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))

                                    ElseIf fieldType = "Contributions by Employer" Then
                                        amount *= CDec(runQueryAndReturnValue("SELECT 
                                                                                `" & speciFiedFormulaDataGridView.Rows(index).Cells("pay_head").Value & "` 
                                                                                AS 'pay_amount' FROM `tbl_emp_contributions` 
                                                                                WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' 
                                                                                AND `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'",
                                                                              "pay_amount"))
                                    End If
                                End If

                            Next

                            '
                            ' Computation Info part
                            '

                            'Empty dgv and load for computation info
                            speciFiedFormulaDataGridView.DataSource = DBNull.Value
                            LoadDataIntoDatagrid(speciFiedFormulaDataGridView,
                                                 "SELECT * FROM `tbl_computation_info` WHERE `phid` = '" & phid & "'")
                            speciFiedFormulaDataGridView.Columns("id").Visible = False
                            speciFiedFormulaDataGridView.Columns("phid").Visible = False

                            For index = 0 To speciFiedFormulaDataGridView.RowCount - 2
                                Dim value As Decimal = 0

                                'If speciFiedFormulaDataGridView.Rows(index).Cells("amount_from").Value = 0 Then

                                'End If

                                If amount >= speciFiedFormulaDataGridView.Rows(index).Cells("amount_from").Value Then
                                    If amount <= speciFiedFormulaDataGridView.Rows(index).Cells("amount_to").Value Or speciFiedFormulaDataGridView.Rows(index).Cells("amount_to").Value = 0 Then
                                        If speciFiedFormulaDataGridView.Rows(index).Cells("slab_type").Value = "Percentage" Then
                                            value = amount * speciFiedFormulaDataGridView.Rows(index).Cells("value_basis").Value
                                        ElseIf speciFiedFormulaDataGridView.Rows(index).Cells("slab_type").Value = "Value" Then
                                            value = speciFiedFormulaDataGridView.Rows(index).Cells("value_basis").Value
                                        End If
                                    End If
                                End If

                                If runQuery("UPDATE `tbl_emp_contributions`  
                                                    SET `" & applicableContributionsDataGridView.Columns(col).Name & "` = '" & value & "' 
                                                    WHERE `empid` = '" & applicableContributionsDataGridView.Rows(row).Cells("empid").Value & "' AND 
                                                    `payid` = '" & applicableContributionsDataGridView.Rows(row).Cells("payid").Value & "'") = 1 Then
                                    x += 1
                                End If

                            Next

                        End If

                    End If

                End If

            Next
        Next
    End Sub

    Private Sub finalProcessingTouches()

    End Sub

    Private Sub empOrGroupNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles empOrGroupNameTextBox.TextChanged

    End Sub
End Class