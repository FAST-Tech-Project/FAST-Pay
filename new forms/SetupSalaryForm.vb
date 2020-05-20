Imports MySql.Data.MySqlClient

Public Class SalaryDetailsSetupForm
    Private Sub SetupSalaryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        payPeriodIDTextBox.Text = runQueryAndReturnValue("SELECT `id` FROM `tbl_pay_process` WHERE `processed` = 0", "id")
        payrollPeriodTextBox.Text = runQueryAndReturnValue("SELECT `comment` FROM `tbl_pay_process` WHERE `processed` = 0", "comment")

    End Sub

    Private Sub empNameOrGroupTextBox_Click(sender As Object, e As EventArgs) Handles empOrGroupNameTextBox.Click
        AddEmployeeOrGroupForm.Show()
    End Sub

    Private Sub addPayHeadsButton_Click(sender As Object, e As EventArgs) Handles addPayHeadsButton.Click
        If empOrGroupNameTextBox.Text = "" And empOrGroupIDTextBox.Text = "" Then
            empOrGroupNameTextBox.Focus()
        Else
            If LCase(empOrGroupTypeTextBox.Text) = "employee" Then
                empGroupIDTextBox.Text = runQueryAndReturnValue("SELECT g.`id` FROM `tbl_group` AS g, `tbl_employee` AS e 
                WHERE e.`group` = g.`name` AND e.`category` = '" & underTextBox.Text & "' And e.id = '" & empOrGroupIDTextBox.Text & "'", "id")
            End If

            SalarySetupStartTypeFrom.Show()
            Me.Width = Me.MaximumSize.Width
            Me.Height = Me.MaximumSize.Height
        End If
    End Sub

    Private Sub SavesSalaryDetailsButton_Click(sender As Object, e As EventArgs) Handles SavesSalaryDetailsButton.Click

        'Check for validations
        If selectedStartTypeTextBox.Text = "1" Then
            If (EmployeeSalaryDetailsDataGridView.RowCount - 1) < 1 Then
                MsgBox("Employee salary sheet not empty!")
                Exit Sub
            End If

        ElseIf selectedStartTypeTextBox.Text = "2" Then
            If (GrpSalaryDetailsDataGridView.RowCount - 1) < 1 Then
                MsgBox("Salary details sheet not empty!")
                Exit Sub
            End If

        Else
            Exit Sub
        End If

        'Set few params to use
        Dim empOrGroupId As Integer = empOrGroupIDTextBox.Text          'employee or group id from db
        Dim empOrGroupType As String = empOrGroupTypeTextBox.Text       'type of run, thus either employee or group

        If clickedDgvItemTextBox.Text = "" Then
            'Add New Data
            AddNewEmployeeSalaryDetails(empOrGroupId, empOrGroupType)

        Else
            'Update Data
            UpdateEmployeeSalaryDetails(empOrGroupId)

        End If


    End Sub

    Private Sub CancelPayHeadButton_Click(sender As Object, e As EventArgs) Handles CancelSalarySetupButton.Click
        clearData()
    End Sub

    Private Sub EmployeeSalaryDetailsDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles EmployeeSalaryDetailsDataGridView.CellClick
        ' if red column is clicked, remove row at that index
        If e.RowIndex >= 0 And e.RowIndex <= EmployeeSalaryDetailsDataGridView.RowCount - 2 And e.ColumnIndex = 7 Then
            EmployeeSalaryDetailsDataGridView.Rows(e.RowIndex).Selected = True
            EmployeeSalaryDetailsDataGridView.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub GrpSalaryDetailsDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrpSalaryDetailsDataGridView.CellClick

        ' if red column is clicked, remove row
        If e.RowIndex >= 0 And e.RowIndex < GrpSalaryDetailsDataGridView.RowCount - 1 And e.ColumnIndex = 0 Then
            GrpSalaryDetailsDataGridView.Rows(e.RowIndex).Selected = True
            GrpSalaryDetailsDataGridView.Rows.RemoveAt(e.RowIndex)

            'if pay head name column is clicked, show pay head form
        ElseIf e.RowIndex >= 0 And e.RowIndex = GrpSalaryDetailsDataGridView.RowCount - 1 And e.ColumnIndex = 2 Then
            clickedGroupRowIndexTextBox.Text = e.RowIndex
            PayHeadsForm.Show()

        End If

    End Sub

    Private Sub SalaryDetailsSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        EmployeeSalaryDetailsDataGridView.ClearSelection()
    End Sub

    Private Sub SalaryDetailsSetupForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        PayrollForm.Show()
    End Sub

    Private Sub GrpSalaryDetailsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrpSalaryDetailsDataGridView.CellContentClick

    End Sub

    Private Sub empSalariesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles empSalariesComboBox.SelectedIndexChanged
        clickedDgvItemTextBox.Text = empSalariesComboBox.SelectedValue.ToString

        If clickedDgvItemTextBox.Text <> "System.Data.DataRowView" And clickedDgvItemTextBox.Text <> "" Then
            If setSalaryDetailsSetup(CInt(clickedDgvItemTextBox.Text)) = 1 Then
                setSalaryDetailsDgv(empOrGroupTypeTextBox.Text, CInt(clickedDgvItemTextBox.Text))
                SavesSalaryDetailsButton.Text = "Update"
                addPayHeadsButton.Enabled = False
            End If

        Else
            clickedDgvItemTextBox.Text = ""
            empSalariesComboBox.Text = ""
        End If

    End Sub

    Private Sub empSalariesComboBox_Enter(sender As Object, e As EventArgs) Handles empSalariesComboBox.Enter
        FetchComboData(empSalariesComboBox, "SELECT DISTINCT e.`id`, CONCAT(e.`surname`, ' ', e.`first_name`) AS 'name' 
                                                    FROM `tbl_employee` AS e, `tbl_salary_details_setup` AS s 
                                                    WHERE  e.`id` = s.`empOrGrID` AND s.`type` = 'Employee'", "name")
        empSalariesComboBox.Text = "Employees' Salary"
    End Sub

    'Used whiles setting up or adding salary details for an employee
    'Updates the applicables tables and set pay heads assigned to employee to 1
    Private Function updateApplicableTables(ByVal payid As Integer, ByVal empOrGroupId As Integer, ByRef applicable As Integer) As Integer
        Dim u As Integer = 0

        'if employee type dgv is visible (meaning we are going to use that dgv)
        'Change values columns in applicable table related to employee to 1 (meaning it is applicable in processing payroll)
        If EmployeeSalaryDetailsDataGridView.Visible = True Then

            For index = 0 To EmployeeSalaryDetailsDataGridView.RowCount - 2

                'if the pay head type at this position is of type earnings for employees, then update the applicables
                'to that employee, set it to 1
                If EmployeeSalaryDetailsDataGridView.Rows(index).Cells("pay_head_type").Value = "Earnings for Employees" Then
                    If runQuery("UPDATE `tbl_emp_applicable_earnings` SET 
                                `" & EmployeeSalaryDetailsDataGridView.Rows(index).Cells("pay_head").Value & "` = '" & applicable & "' 
                                WHERE `payid` = '" & payid & "' AND `empid` = '" & empOrGroupId & "'") = 1 Then
                        u += 1
                    End If

                    'if the pay head type at this position is of type Deductions from Employees, then update the applicables
                    'to that employee, set it to 1
                ElseIf EmployeeSalaryDetailsDataGridView.Rows(index).Cells("pay_head_type").Value = "Deductions from Employees" Then
                    If runQuery("UPDATE `tbl_emp_applicable_deductions` SET 
                                `" & EmployeeSalaryDetailsDataGridView.Rows(index).Cells("pay_head").Value & "` = '" & applicable & "' 
                                WHERE `payid` = '" & payid & "' AND `empid` = '" & empOrGroupId & "'") = 1 Then
                        u += 1
                    End If

                    'if the pay head type at this position is of type Contributions by Employer, then update the applicables
                    'to that employee, set it to 1
                ElseIf EmployeeSalaryDetailsDataGridView.Rows(index).Cells("pay_head_type").Value = "Contributions by Employer" Then
                    If runQuery("UPDATE `tbl_emp_applicable_contributions` SET 
                                `" & EmployeeSalaryDetailsDataGridView.Rows(index).Cells("pay_head").Value & "` = '" & applicable & "' 
                                WHERE `payid` = '" & payid & "' AND `empid` = '" & empOrGroupId & "'") = 1 Then
                        u += 1
                    End If
                End If
            Next

            'if group type dgv is visible (meaning we are going to use that dgv)
        ElseIf GrpSalaryDetailsDataGridView.Visible = True Then

            'if the pay head type at this position is of type Earnings for Employees, then update the applicables
            'to that employee, set it to 1
            For index = 0 To GrpSalaryDetailsDataGridView.RowCount - 2
                If GrpSalaryDetailsDataGridView.Rows(index).Cells("pay_head_type").Value = "Earnings for Employees" Then
                    If runQuery("UPDATE `tbl_emp_applicable_earnings` SET 
                                `" & GrpSalaryDetailsDataGridView.Rows(index).Cells("name").Value & "` = '" & applicable & "' 
                                WHERE `payid` = '" & payid & "' AND `empid` = '" & empOrGroupId & "'") = 1 Then
                        u += 1
                    End If

                    'if the pay head type at this position is of type Deductions from Employees, then update the applicables
                    'to that employee, set it to 1
                ElseIf GrpSalaryDetailsDataGridView.Rows(index).Cells("pay_head_type").Value = "Deductions from Employees" Then
                    If runQuery("UPDATE `tbl_emp_applicable_deductions` SET 
                                `" & GrpSalaryDetailsDataGridView.Rows(index).Cells("name").Value & "` = '" & applicable & "' 
                                WHERE `payid` = '" & payid & "' AND `empid` = '" & empOrGroupId & "'") = 1 Then
                        u += 1
                    End If

                    'if the pay head type at this position is of type Contributions by Employer, then update the applicables
                    'to that employee, set it to 1
                ElseIf GrpSalaryDetailsDataGridView.Rows(index).Cells("pay_head_type").Value = "Contributions by Employer" Then
                    If runQuery("UPDATE `tbl_emp_applicable_contributions` SET 
                                `" & GrpSalaryDetailsDataGridView.Rows(index).Cells("name").Value & "` = '" & applicable & "' 
                                WHERE `payid` = '" & payid & "' AND `empid` = '" & empOrGroupId & "'") = 1 Then
                        u += 1
                    End If
                End If
            Next

        End If

        Return u
    End Function

    Private Function addEmployeeIdToApplicableTables(ByVal payid As Integer, ByVal empid As Integer) As Integer

        'Add employee id and pay period's id to earnings and it's applicables table in the db
        If runQuery("INSERT INTO `tbl_emp_earnings`(`payid`, `empid`, `added_at`) VALUES('" & payid & "', '" & empid & "', CURRENT_TIMESTAMP)") = 1 Then
            If runQuery("INSERT INTO `tbl_emp_applicable_earnings`(`payid`, `empid`) VALUES('" & payid & "', '" & empid & "')") = 1 Then

                'Add employee id and pay period's id to deductions and it's applicables table in the db
                If runQuery("INSERT INTO `tbl_emp_deductions`(`payid`, `empid`, `added_at`)  VALUES('" & payid & "', '" & empid & "', CURRENT_TIMESTAMP)") > 0 Then
                    If runQuery("INSERT INTO `tbl_emp_applicable_deductions`(`payid`, `empid`)  VALUES('" & payid & "', '" & empid & "')") = 1 Then

                        'Add employee id and pay period's id to contributions and it's applicables table in the db
                        If runQuery("INSERT INTO `tbl_emp_contributions`(`payid`, `empid`, `added_at`)  VALUES('" & payid & "', '" & empid & "', CURRENT_TIMESTAMP)") > 0 Then
                            If runQuery("INSERT INTO `tbl_emp_applicable_contributions`(`payid`, `empid`)  VALUES('" & payid & "', '" & empid & "')") = 1 Then

                                Return 1

                            End If
                        End If

                    End If
                End If

            End If
        End If

        Return 0
    End Function

    Private Sub AddNewEmployeeSalaryDetails(ByVal empOrGroupId As Integer, ByVal empOrGroupType As String)

        Dim x As Integer = 0                                            'to check number of query ran

        If selectedStartTypeTextBox.Text = "1" Then
            'Add to pay head's id and details to salary setup details table in db
            For index = 0 To EmployeeSalaryDetailsDataGridView.RowCount - 2
                If runQuery("INSERT INTO `tbl_salary_details_setup`(`phid`, `empOrGrID`, `type`, `rate`) 
                                VALUES ('" & EmployeeSalaryDetailsDataGridView.Rows(index).Cells("id").Value & "', 
                                        '" & empOrGroupId & "', '" & empOrGroupType & "', 
                                        '" & If(EmployeeSalaryDetailsDataGridView.Rows(index).Cells("rate").Value = "", 0, EmployeeSalaryDetailsDataGridView.Rows(index).Cells("rate").Value) & "')") = 1 Then
                    x += 1
                End If
            Next

        ElseIf selectedStartTypeTextBox.Text = "2" Then
            'Add to pay head's id and details to salary setup details table in db
            For index = 0 To GrpSalaryDetailsDataGridView.RowCount - 2
                Dim int As Integer = runQuery("INSERT INTO `tbl_salary_details_setup`(`phid`, `empOrGrID`, `type`, `rate`) 
                                                VALUES ('" & GrpSalaryDetailsDataGridView.Rows(index).Cells("id").Value & "', 
                                                        '" & empOrGroupId & "', '" & empOrGroupType & "', 
                                                        " & GrpSalaryDetailsDataGridView.Rows(index).Cells("rate").Value & ")")
                If int = 1 Then
                    x += 1
                End If
            Next

        Else
            Exit Sub

        End If

        'if the type of our run , is for employee and not group
        If LCase(empOrGroupType) = "employee" Then

            Dim payid As Integer = payPeriodIDTextBox.Text       'payid/id of pay period to save details for
            If addEmployeeIdToApplicableTables(payid, empOrGroupId) = 1 Then

                Dim u As Integer = updateApplicableTables(payid, empOrGroupId, 1)       'Set employee fields to 1 where it's applicable

                Dim totalAdded As Integer = 0

                If EmployeeSalaryDetailsDataGridView.Visible = True Then
                    totalAdded = EmployeeSalaryDetailsDataGridView.RowCount - 1

                ElseIf GrpSalaryDetailsDataGridView.Visible = True Then
                    totalAdded = GrpSalaryDetailsDataGridView.RowCount - 1
                End If

                If x = totalAdded And u = totalAdded Then
                    If addEmpBasicSalaryToMonthEarningTable(payid, empOrGroupId) = 1 Then
                        MsgBox("Employee salary details successfully created!")
                    End If
                End If

            End If

        Else
            MsgBox("Group salary details successfully created!")

        End If

        clearData()
    End Sub

    Private Function updateEmployeeRateOrAddPayHeadToSetupTable(ByVal payid As Integer, ByVal empOrGroupId As Integer, ByVal empOrGroupType As String) As Integer
        Dim x As Integer = 0            'to check number of query ran

        'For each and every row in the dgv
        For index = 0 To GrpSalaryDetailsDataGridView.RowCount - 2

            'Get the pay head's id from tbl_salary_details_setup table if it exist
            Dim phid_exist As String = runQueryAndReturnValue("SELECT `phid` FROM `tbl_salary_details_setup` 
                                                                    WHERE `phid` = '" & GrpSalaryDetailsDataGridView.Rows(index).Cells("id").Value & "' 
                                                                    AND `empOrGrID` = '" & empOrGroupId & "' AND `type` = 'Employee' LIMIT 1", "phid")
            'if the pay head's id from tbl_salary_details_setup doesn't exit or is empty
            If phid_exist = "" Then

                'Add to pay head's details to salary setup details table in db
                If runQuery("INSERT INTO `tbl_salary_details_setup`(`phid`, `empOrGrID`, `type`, `rate`) 
                                VALUES ('" & GrpSalaryDetailsDataGridView.Rows(index).Cells("id").Value & "', '" & empOrGroupId & "', '" & empOrGroupType & "', 
                                '" & If(GrpSalaryDetailsDataGridView.Rows(index).Cells("rate").Value Is DBNull.Value, 0, GrpSalaryDetailsDataGridView.Rows(index).Cells("rate").Value) & "')") = 1 Then

                    If updateApplicableTables(payid, empOrGroupId, 1) > 0 Then
                        x += 1
                    End If
                End If

            Else
                'Update to pay head's details to salary setup details table in db
                If runQuery("UPDATE `tbl_salary_details_setup` SET 
                            `rate` = " & GrpSalaryDetailsDataGridView.Rows(index).Cells("rate").Value & " 
                            WHERE `phid`= '" & GrpSalaryDetailsDataGridView.Rows(index).Cells("id").Value & "' 
                            AND `empOrGrID` = '" & empOrGroupId & "' AND `type` = 'Employee'") = 1 Then
                    x += 1
                End If

            End If

        Next

        Return x
    End Function

    Private Function deletedOldPayHeadNameAndResetApplicables(ByVal payid As Integer, ByVal empOrGroupId As Integer) As Integer

        Dim deleted As Integer = 0

        'For each row in the previous employee salary details dgv
        For index = 0 To LoadedSalaryDetailsIDDataGridView.RowCount - 2
            Dim a As Integer = 0

            'For each row in the current employee salary details dgv
            For j = 0 To GrpSalaryDetailsDataGridView.RowCount - 2

                'if the pay head's id is the same in previous and 
                If GrpSalaryDetailsDataGridView.Rows(j).Cells("id").Value = LoadedSalaryDetailsIDDataGridView.Rows(index).Cells("id").Value Then
                    a += 1
                    Exit For
                End If
            Next

            If a = 0 Then
                If runQuery("DELETE FROM `tbl_salary_details_setup` 
                            WHERE `phid`= '" & LoadedSalaryDetailsIDDataGridView.Rows(index).Cells("id").Value & "' 
                            AND `empOrGrID` = '" & empOrGroupId & "' AND `type` = 'Employee'") = 1 Then

                    If LoadedSalaryDetailsIDDataGridView.Rows(index).Cells("pay_head_type").Value = "Earnings for Employees" Then
                        If runQuery("UPDATE `tbl_emp_applicable_earnings` SET 
                                `" & LoadedSalaryDetailsIDDataGridView.Rows(index).Cells("name").Value & "` = 0 
                                WHERE `payid` = '" & payid & "' AND `empid` = '" & empOrGroupId & "'") = 1 Then
                            deleted += 1
                        End If

                        'if the pay head type at this position is of type Deductions from Employees, then update the applicables
                        'to that employee, set it to 1
                    ElseIf LoadedSalaryDetailsIDDataGridView.Rows(index).Cells("pay_head_type").Value = "Deductions from Employees" Then
                        If runQuery("UPDATE `tbl_emp_applicable_deductions` SET 
                                `" & LoadedSalaryDetailsIDDataGridView.Rows(index).Cells("name").Value & "` = 0 
                                WHERE `payid` = '" & payid & "' AND `empid` = '" & empOrGroupId & "'") = 1 Then
                            deleted += 1
                        End If

                        'if the pay head type at this position is of type Contributions by Employer, then update the applicables
                        'to that employee, set it to 1
                    ElseIf LoadedSalaryDetailsIDDataGridView.Rows(index).Cells("pay_head_type").Value = "Contributions by Employer" Then
                        If runQuery("UPDATE `tbl_emp_applicable_contributions` SET 
                                `" & LoadedSalaryDetailsIDDataGridView.Rows(index).Cells("name").Value & "` = 0 
                                WHERE `payid` = '" & payid & "' AND `empid` = '" & empOrGroupId & "'") = 1 Then
                            deleted += 1
                        End If
                    End If

                End If
            End If

        Next

        Return deleted
    End Function

    Private Sub UpdateEmployeeSalaryDetails(ByVal empOrGroupId As Integer)
        Dim payid As String = payPeriodIDTextBox.Text
        Dim empOrGroupType As String = empOrGroupTypeTextBox.Text       'type of run, thus either employee or group

        Dim x As Integer = updateEmployeeRateOrAddPayHeadToSetupTable(payid, empOrGroupId, empOrGroupType)

        If x = GrpSalaryDetailsDataGridView.RowCount - 1 Then

            'Delete pay head and reset applicables to 0
            If deletedOldPayHeadNameAndResetApplicables(payid, empOrGroupId) >= 0 Then

                If addEmpBasicSalaryToMonthEarningTable(payid, empOrGroupId) = 1 Then
                    MsgBox("Employee Salary details successfully updated!")
                    setSalaryDetailsDgv(empOrGroupTypeTextBox.Text, clickedDgvItemTextBox.Text)
                End If

            End If

        End If


    End Sub

    Private Function addEmpBasicSalaryToMonthEarningTable(ByVal payid As Integer, ByVal empid As Integer) As Integer

        If EmployeeSalaryDetailsDataGridView.Visible = True Then

            For index = 0 To EmployeeSalaryDetailsDataGridView.RowCount - 2
                If EmployeeSalaryDetailsDataGridView.Rows(index).Cells("pay_type").Value = "Basic Salary" Then

                    If runQuery("UPDATE `tbl_emp_attendance_voucher` SET 
                                    `basic_salary` = '" & EmployeeSalaryDetailsDataGridView.Rows(index).Cells("rate").Value & "' 
                                    WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'") = 1 Then

                        If runQuery("UPDATE `tbl_emp_overtime_voucher` SET 
                                        `basic_salary` = '" & EmployeeSalaryDetailsDataGridView.Rows(index).Cells("rate").Value & "' 
                                        WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'") = 1 Then

                            Return 1

                        End If

                    End If

                End If
            Next

        ElseIf GrpSalaryDetailsDataGridView.Visible = True Then

            For index = 0 To GrpSalaryDetailsDataGridView.RowCount - 2
                If GrpSalaryDetailsDataGridView.Rows(index).Cells("pay_type").Value = "Basic Salary" Then
                    If runQuery("UPDATE `tbl_emp_attendance_voucher` SET 
                                    `basic_salary` = '" & GrpSalaryDetailsDataGridView.Rows(index).Cells("rate").Value & "' 
                                    WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'") = 1 Then

                        If runQuery("UPDATE `tbl_emp_overtime_voucher` SET 
                                        `basic_salary` = '" & GrpSalaryDetailsDataGridView.Rows(index).Cells("rate").Value & "' 
                                        WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'") = 1 Then

                            Return 1

                        End If

                    End If

                End If
            Next

        End If

        Return 0
    End Function

    Public Sub clearData()

        empOrGroupIDTextBox.Text = ""
        empOrGroupTypeTextBox.Text = ""
        empOrGroupNameTextBox.Text = ""
        underTextBox.Text = ""
        selectedStartTypeTextBox.Text = ""
        clickedRowIndexTextBox.Text = "0"
        clickedGroupRowIndexTextBox.Text = ""
        GroupDgvTotalRowsTextBox.Text = ""
        clickedDgvItemTextBox.Text = ""

        If EmployeeSalaryDetailsDataGridView.Visible = True Then
            If (EmployeeSalaryDetailsDataGridView.RowCount - 1) <> 0 Then
                EmployeeSalaryDetailsDataGridView.Rows.Clear()
            End If

        ElseIf GrpSalaryDetailsDataGridView.Visible = True Then
            If (GrpSalaryDetailsDataGridView.RowCount - 1) <> 0 Then
                GrpSalaryDetailsDataGridView.DataSource = DBNull.Value
            End If
        End If

        LoadedSalaryDetailsIDDataGridView.DataSource = DBNull.Value
        addPayHeadsButton.Enabled = True

        GrpSalaryDetailsDataGridView.Visible = False
        EmployeeSalaryDetailsDataGridView.Visible = True
        SavesSalaryDetailsButton.Text = "Save"

    End Sub

    Public Function setSalaryDetailsSetup(ByVal empID As Integer) As Integer
        Try
            Dim query As String = "SELECT e.`id`, CONCAT(e.`surname`, ' ', e.`first_name`) AS 'name', c.`name` AS 'category', g.`id` AS 'groupID'  
                                    FROM `tbl_employee` AS e, `tbl_salary_details_setup` AS s, `tbl_category` AS c, `tbl_group` AS g 
                                    WHERE  e.`id` = s.`empOrGrID` AND s.`empOrGrID` = '" & empID & "' AND s.`type` = 'Employee' 
                                    AND c.`name` = e.`category` AND g.`name` = e.`group` LIMIT 1"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read

                    empOrGroupIDTextBox.Text = If(dr.Item("id") Is DBNull.Value, String.Empty, dr.Item("id"))
                    empOrGroupNameTextBox.Text = If(dr.Item("name") Is DBNull.Value, String.Empty, dr.Item("name"))
                    underTextBox.Text = If(dr.Item("category") Is DBNull.Value, String.Empty, dr.Item("category"))
                    empGroupIDTextBox.Text = If(dr.Item("groupID") Is DBNull.Value, String.Empty, dr.Item("groupID"))
                    empOrGroupTypeTextBox.Text = "Employee"

                End While
            End If

            conn.Close()
            Return 1

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        Finally
            conn.Dispose()
        End Try

        Return 0
    End Function

    Public Sub setSalaryDetailsDgv(ByVal type As String, ByVal empOrGrpID As Integer)

        EmployeeSalaryDetailsDataGridView.Visible = False
        GrpSalaryDetailsDataGridView.Visible = True
        GrpSalaryDetailsDataGridView.Location = New Point(169, 241)

        LoadDataIntoDatagrid(LoadedSalaryDetailsIDDataGridView,
            "SELECT p.`id`, p.`name`, p.`pay_head_type` FROM `tbl_pay_head` AS p, `tbl_salary_details_setup` AS s 
                WHERE p.`id` = s.`phid` AND s.`type` = '" & type & "' AND s.`empOrGrID` = '" & empOrGrpID & "'")

        LoadDataIntoDatagrid(GrpSalaryDetailsDataGridView,
            "SELECT p.`id`, p.`name`, s.`rate`, p.`calculation_period`, 
                p.`pay_head_type`, p.`calculation_type`, p.`compute_on`, p.`specified_formula`, p.`pay_type` 
                FROM `tbl_pay_head` AS p, `tbl_salary_details_setup` AS s 
                WHERE p.`id` = s.`phid` AND s.`type` = '" & type & "' AND s.`empOrGrID` = '" & empOrGrpID & "'")

        GrpSalaryDetailsDataGridView.Columns("id").Visible = False
        GrpSalaryDetailsDataGridView.Columns("name").HeaderText = "PAY HEAD"
        GrpSalaryDetailsDataGridView.Columns("rate").HeaderText = "RATE"
        GrpSalaryDetailsDataGridView.Columns("calculation_period").HeaderText = "PERIOD"
        GrpSalaryDetailsDataGridView.Columns("pay_head_type").HeaderText = "PAY HEAD TYPE"
        GrpSalaryDetailsDataGridView.Columns("calculation_type").HeaderText = "CALCULATION TYPE"
        GrpSalaryDetailsDataGridView.Columns("compute_on").HeaderText = "COMPUTE ON"
        GrpSalaryDetailsDataGridView.Columns("specified_formula").Visible = False
        GrpSalaryDetailsDataGridView.Columns("pay_type").Visible = False

        GrpSalaryDetailsDataGridView.Columns("name").Width = 200
        GrpSalaryDetailsDataGridView.Columns("rate").Width = 100
        GrpSalaryDetailsDataGridView.Columns("calculation_period").Width = 100
        GrpSalaryDetailsDataGridView.Columns("pay_head_type").Width = 185
        GrpSalaryDetailsDataGridView.Columns("calculation_type").Width = 125
        GrpSalaryDetailsDataGridView.Columns("compute_on").Width = 250
        GrpSalaryDetailsDataGridView.Columns("remove_row").DisplayIndex = 7

        For index = 0 To GrpSalaryDetailsDataGridView.RowCount - 1
            If LCase(GrpSalaryDetailsDataGridView.Rows(index).Cells("calculation_type").Value) = "as computed value" Then
                If LCase(GrpSalaryDetailsDataGridView.Rows(index).Cells("compute_on").Value) = "on specified formula" Then
                    GrpSalaryDetailsDataGridView.Rows(index).Cells("compute_on").Value = GrpSalaryDetailsDataGridView.Rows(index).Cells("specified_formula").Value
                End If
            End If
        Next

        selectedStartTypeTextBox.Text = 2
        GroupDgvTotalRowsTextBox.Text = GrpSalaryDetailsDataGridView.RowCount - 1

    End Sub

End Class