Public Class AttendaceOrProductionVoucherForm
    Dim period As Decimal = 0

    Private Sub AttendaceOrProductionVoucherForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        payPeriodIDTextBox.Text = runQueryAndReturnValue("SELECT `id` FROM `tbl_pay_process` WHERE `processed` = 0", "id")
        payrollPeriodComboBox.Text = runQueryAndReturnValue("SELECT `comment` FROM `tbl_pay_process` WHERE `processed` = 0", "comment")
    End Sub

    Private Sub SaveVoucherDetailsButton_Click(sender As Object, e As EventArgs) Handles SaveVoucherDetailsButton.Click
        If AttendOrProductComboBox.Text = "" Then
            Exit Sub
        End If

        If attendOrProdIDTextBox.Text <> "3" Then
            attendOrProductUnitTextBox.Text = runQueryAndReturnValue("SELECT `unit` FROM `tbl_attendance_or_production` 
            WHERE `id` = '" & attendOrProdIDTextBox.Text & "'", "unit")

        End If

        If LCase(empOrGroupTypeTextBox.Text) = "employee" Then
            LoadDataIntoDatagrid(attendOrProductVoucherDataGridView,
                                 "SELECT DISTINCT e.`id`, CONCAT(e.`surname`, ' ', e.`first_name`) AS 'NAME' FROM `tbl_employee` AS e, 
                                 `tbl_salary_details_setup` AS s WHERE e.`id` = '" & empOrGroupIDTextBox.Text & "' 
                                 AND e.`id` = s.`empOrGrID` AND s.`type` = 'Employee'")

        ElseIf LCase(empOrGroupTypeTextBox.Text) = "group" Then
            LoadDataIntoDatagrid(attendOrProductVoucherDataGridView,
                                 "SELECT DISTINCT e.`id`, CONCAT(e.`surname`, ' ', e.`first_name`) AS 'NAME' FROM `tbl_employee` AS e, 
                                 `tbl_salary_details_setup` AS s WHERE e.`category` = '" & empCategoryComboBox.Text & "' 
                                 AND e.`group` = '" & empOrGroupNameTextBox.Text & "' AND e.`id` = s.`empOrGrID` AND s.`type` = 'Employee'")

        ElseIf LCase(empOrGroupTypeTextBox.Text) = "all items" Then
            LoadDataIntoDatagrid(attendOrProductVoucherDataGridView,
                                 "SELECT DISTINCT e.`id`, CONCAT(e.`surname`, ' ', e.`first_name`) AS 'NAME' FROM `tbl_employee` AS e, 
                                 `tbl_salary_details_setup` AS s WHERE  e.`id` = s.`empOrGrID` AND s.`type` = 'Employee'")

        End If

        attendOrProductVoucherSetupPanel.Hide()
        Me.Width = Me.MaximumSize.Width
        Me.Height = Me.MaximumSize.Height
        attendOrProductVoucherDataGridView.Show()
        saveAttendOrProductVoucherButton.Show()

        For index = 0 To attendOrProductVoucherDataGridView.RowCount - 2
            attendOrProductVoucherDataGridView.Rows(index).Cells("type").Value = AttendOrProductComboBox.Text.ToString

            If attendOrProdIDTextBox.Text <> "3" Then
                attendOrProductVoucherDataGridView.Rows(index).Cells("value").Value = defaultValueTextBox.Text.ToString
                attendOrProductVoucherDataGridView.Rows(index).Cells("unit").Value = attendOrProductUnitTextBox.Text.ToString

            Else
                attendOrProductVoucherDataGridView.Rows(index).Cells("value").Value = 0
                attendOrProductVoucherDataGridView.Rows(index).Cells("unit").Value = prodValueTypeComboBox.Text.ToString

            End If

        Next

        attendOrProductVoucherDataGridView.Columns("id").DisplayIndex = 0
        attendOrProductVoucherDataGridView.Columns("NAME").DisplayIndex = 1
        attendOrProductVoucherDataGridView.Columns("id").Visible = False
        attendOrProductVoucherDataGridView.Columns("NAME").Width = 232
        attendOrProductVoucherDataGridView.Columns("NAME").ReadOnly = True

        If attendOrProdIDTextBox.Text = "3" Then
            attendOrProductVoucherDataGridView.Columns("value").HeaderText = "HOURS WORKED"
        End If

    End Sub

    Private Sub CancelVoucherDetailsButton_Click(sender As Object, e As EventArgs) Handles CancelVoucherDetailsButton.Click
        empCategoryComboBox.Text = "Primary Cost Category"
        empCatIDTextBox.Text = "1"
        empOrGroupNameTextBox.Text = "All Items"
        empOrGroupTypeTextBox.Text = "All Items"
        empOrGroupIDTextBox.Text = "0"
        AttendOrProductComboBox.Text = ""
        attendOrProdIDTextBox.Text = ""
        defaultValueTextBox.Text = "0"
        Label14.Visible = False
        prodValueTypeComboBox.Visible = False
    End Sub

    Private Sub payrollPeriodComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles payrollPeriodComboBox.SelectedIndexChanged
        payPeriodIDTextBox.Text = payrollPeriodComboBox.SelectedValue.ToString
    End Sub

    Private Sub payrollPeriodComboBox_Click(sender As Object, e As EventArgs) Handles payrollPeriodComboBox.Click
        FetchComboData(payrollPeriodComboBox, "SELECT `id`, `comment` FROM `tbl_pay_process` WHERE `processed` = 0", "comment")
        payrollPeriodComboBox.Text = ""
        payPeriodIDTextBox.Text = ""
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
    End Sub

    Private Sub AttendOrProductComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AttendOrProductComboBox.SelectedIndexChanged
        attendOrProdIDTextBox.Text = AttendOrProductComboBox.SelectedValue.ToString
        Dim selectedItem As String = AttendOrProductComboBox.SelectedText.ToString

        If attendOrProdIDTextBox.Text = "1" Then
            period = If(runQueryAndReturnValue("SELECT `period_of` AS 'period' FROM `tbl_pay_head` WHERE `period_of` != '' AND `pay_type` = 'Basic Salary' LIMIT 1", "period") = "", 0, runQueryAndReturnValue("SELECT `period_of` AS 'period' FROM `tbl_pay_head` WHERE `period_of` != '' AND `pay_type` = 'Basic Salary' LIMIT 1", "period"))
            defaultValueTextBox.Text = period
            Label7.Text = "Default Value to Fill"
            prodValueTypeComboBox.Visible = False
            Label14.Visible = False

        ElseIf attendOrProdIDTextBox.Text = "3" Then
            Label7.Text = "Hourly Rate"
            Label14.Visible = True
            prodValueTypeComboBox.Visible = True

        Else
            Panel2.Visible = True

        End If

    End Sub

    Private Sub AttendOrProductComboBox_Click(sender As Object, e As EventArgs) Handles AttendOrProductComboBox.Click
        FetchComboData(AttendOrProductComboBox, "SELECT * FROM `tbl_attendance_or_production`", "name")
        AttendOrProductComboBox.Text = ""
        attendOrProdIDTextBox.Text = ""
    End Sub

    Private Sub setupAOrPVoucherButton_Click(sender As Object, e As EventArgs) Handles setupAOrPVoucherButton.Click
        attendOrProductVoucherDataGridView.Hide()
        attendOrProductVoucherSetupPanel.Show()
        Me.Width = Me.MinimumSize.Width
        Me.Height = Me.MinimumSize.Height
        attendOrProductVoucherDataGridView.DataSource = DBNull.Value
    End Sub

    Private Sub attendOrProductVoucherDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles attendOrProductVoucherDataGridView.CellEndEdit
        If CInt(attendOrProductVoucherDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) > period Then
            MsgBox("Value can't be greater than " & period)
            attendOrProductVoucherDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = defaultValueTextBox.Text
        End If
    End Sub

    Private Sub saveAttendOrProductVoucherButton_Click(sender As Object, e As EventArgs) Handles saveAttendOrProductVoucherButton.Click
        Dim pay_id As Integer = payPeriodIDTextBox.Text
        Dim x As Integer = 0
        Dim already As Integer = 0

        Dim working_days As Integer = defaultValueTextBox.Text

        If AttendOrProductComboBox.Text = "Present" Or AttendOrProductComboBox.Text = "Absent" Then

            For index = 0 To attendOrProductVoucherDataGridView.RowCount - 2

                Dim emp_basic_salary As String = runQueryAndReturnValue("SELECT s.`rate` 
                                    FROM `tbl_salary_details_setup` AS s, `tbl_pay_head` AS p 
                                    WHERE p.`pay_type` = 'Basic Salary' AND p.`id` = s.`phid` 
                                    AND s.`type` = 'Employee' 
                                    AND s.`empOrGrID` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "'", "rate")

                Dim exists As Integer = runQueryAndReturnValue("SELECT COUNT(`empid`) AS 'total' FROM `tbl_emp_attendance_voucher` 
                                    WHERE `empid` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "' 
                                    AND `type` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("type").Value & "' 
                                    AND `payid` = '" & pay_id & "'", "total")

                If exists > 0 Then
                    If runQuery("UPDATE `tbl_emp_attendance_voucher` 
                                    SET `basic_salary` = " & CDec(emp_basic_salary) & ", 
                                     `working_days` = " & working_days & ", 
                                    `days_worked` = " & attendOrProductVoucherDataGridView.Rows(index).Cells("value").Value & ",
                                    `updated_at` = CURRENT_TIMESTAMP 
                                    WHERE `payid` = '" & pay_id & "' 
                                    AND `type` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("type").Value & "' 
                                    AND `empid` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "'") = 1 Then
                        x += 1
                    End If
                    already += 1

                ElseIf runQuery("INSERT INTO `tbl_emp_attendance_voucher`(`payid`,`empid`,`type`, 
                                    `basic_salary`, `working_days`,`days_worked`, `unit`, `added_at`) 
                                    VALUES('" & pay_id & "', 
                                    '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "', 
                                    '" & attendOrProductVoucherDataGridView.Rows(index).Cells("type").Value & "', 
                                    " & CDec(emp_basic_salary) & ", 
                                    " & working_days & ", 
                                    '" & attendOrProductVoucherDataGridView.Rows(index).Cells("value").Value & "', 
                                    '" & attendOrProductVoucherDataGridView.Rows(index).Cells("unit").Value & "', 
                                    CURRENT_TIMESTAMP)") = 1 Then
                    x += 1

                End If

            Next

        ElseIf AttendOrProductComboBox.Text = "Overtime" Then

            For index = 0 To attendOrProductVoucherDataGridView.RowCount - 2

                Dim emp_basic_salary As String = runQueryAndReturnValue("SELECT s.`rate` 
                                FROM `tbl_salary_details_setup` AS s, `tbl_pay_head` AS p 
                                WHERE p.`pay_type` = 'Basic Salary' AND p.`id` = s.`phid` 
                                AND s.`type` = 'Employee' 
                                AND s.`empOrGrID` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "'", "rate")

                Dim exists As Integer = runQueryAndReturnValue("SELECT COUNT(`empid`) AS 'total' FROM `tbl_emp_overtime_voucher` 
                                    WHERE `empid` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "'  
                                    AND `payid` = '" & pay_id & "'", "total")

                If exists > 0 Then
                    If runQuery("UPDATE `tbl_emp_overtime_voucher` 
                                SET `basic_salary` = " & CDec(emp_basic_salary) & ", 
                                `hours_worked` = " & attendOrProductVoucherDataGridView.Rows(index).Cells("value").Value & ",
                                `rate` = " & period & ", 
                                `updated_at` = CURRENT_TIMESTAMP 
                                WHERE `payid` = '" & pay_id & "' 
                                AND `empid` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "'") = 1 Then
                        x += 1
                    End If
                    already += 1

                ElseIf runQuery("INSERT INTO `tbl_emp_overtime_voucher`(`payid`, `empid`,
                                `basic_salary`, `rate`, `hours_worked`, `unit`, `added_at`) 
                                VALUES('" & pay_id & "', 
                                '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "', 
                                " & CDec(emp_basic_salary) & ", 
                                " & CDec(period) & ", 
                                '" & attendOrProductVoucherDataGridView.Rows(index).Cells("value").Value & "', 
                                '" & attendOrProductVoucherDataGridView.Rows(index).Cells("unit").Value & "', 
                                CURRENT_TIMESTAMP)") = 1 Then
                    x += 1
                End If

            Next

        ElseIf AttendOrProductComboBox.Text = "Others" Then

            For index = 0 To attendOrProductVoucherDataGridView.RowCount - 2
                Dim exists As Integer = runQueryAndReturnValue("SELECT COUNT(`empid`) AS 'total' FROM `tbl_emp_attend_or_product_voucher` 
                                    WHERE `empid` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "' 
                                    AND `type` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("type").Value & "' 
                                    AND `payid` = '" & pay_id & "'", "total")

                If exists > 0 Then
                    If runQuery("UPDATE `tbl_emp_attend_or_product_voucher` 
                            SET `value` = " & attendOrProductVoucherDataGridView.Rows(index).Cells("value").Value & ", 
                            `updated_at` = CURRENT_TIMESTAMP 
                            WHERE `payid` = '" & pay_id & "' 
                            AND `type` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("type").Value & "' 
                            AND `empid` = '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "'") = 1 Then
                        x += 1
                    End If
                    already += 1

                ElseIf runQuery("INSERT INTO `tbl_emp_attend_or_product_voucher`(`payid`,`empid`,`type`,`value`, `unit`, `added_at`) 
                        VALUES('" & pay_id & "', 
                        '" & attendOrProductVoucherDataGridView.Rows(index).Cells("id").Value & "', 
                        '" & attendOrProductVoucherDataGridView.Rows(index).Cells("type").Value & "', 
                        '" & attendOrProductVoucherDataGridView.Rows(index).Cells("value").Value & "', 
                        '" & attendOrProductVoucherDataGridView.Rows(index).Cells("unit").Value & "', 
                        CURRENT_TIMESTAMP)") = 1 Then
                    x += 1
                End If

            Next

        End If

        If x = attendOrProductVoucherDataGridView.RowCount - 1 Then
            If already > 0 Then
                MsgBox("Encountered " & already & " employees already entered for " & payrollPeriodComboBox.Text)
            End If
            MsgBox("Data saved successfully!")
            already = 0
        End If

    End Sub

    Private Sub defaultValueTextBox_TextChanged(sender As Object, e As EventArgs) Handles defaultValueTextBox.TextChanged
        If defaultValueTextBox.Text = "" Then
            defaultValueTextBox.Text = 0
            Exit Sub
        End If

        If attendOrProdIDTextBox.Text = "3" Then
            period = defaultValueTextBox.Text

        Else

            Dim defaultVal As Decimal = defaultValueTextBox.Text

            If CInt(defaultVal) > period Then
                MsgBox("Value can't be greater than " & period)
                defaultValueTextBox.Text = 0
            End If

        End If

    End Sub

End Class