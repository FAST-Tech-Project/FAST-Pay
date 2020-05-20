Imports MySql.Data.MySqlClient

Module ProcessPayrollModule

    Private WORKING_DAYS As Integer = 0

    'For gra tax slab
    Dim AMT_FROM As Decimal = 0
    Dim AMT_TO As Decimal = 0
    Dim CHRG_AMT As Decimal = 0
    Dim PERCENT As Decimal = 0
    Dim AMT_CRH As Decimal = 0
    Dim FREE_AMT As Decimal = 0

    'taxable pay
    Private BASIC_SALARY As Decimal = 0
    Private EMPLOYEE_SSNIT As Decimal = 0
    Private EMPLOYEE_PF As Decimal = 0

    Private Function setupVars(ByVal id As Integer) As Integer

        Try
            Dim query As String = "SELECT * FROM `tbl_gra_refera` WHERE `id` ='" & id & "'"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    AMT_FROM = CType(dr.Item("amt_from"), Decimal)
                    AMT_TO = CType(dr.Item("amt_to"), Decimal)
                    CHRG_AMT = CType(dr.Item("chrg_amt"), Decimal)
                    PERCENT = CType(dr.Item("percentage"), Decimal)
                    AMT_CRH = CType(dr.Item("amt_crh"), Decimal)
                End While
            End If
            conn.Close()
            Return 1
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        Finally
            conn.Close()
        End Try

        Return 0
    End Function

    Public Function setupAdecimalVal(ByVal query As String, ByVal rtrn As String) As Decimal

        Try
            Dim value As Decimal = 0
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    value = CType(dr.Item(rtrn), Decimal)
                End While
            End If
            conn.Close()
            Return value
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        Finally
            conn.Close()
        End Try

        Return 0
    End Function

    Public Function CalcEmpTaxableAllowance(ByVal empId As Integer, ByVal pId As Integer) As Decimal
        'Dim totalTaxableAllowance As Decimal = 0
        'For a = 0 To MainForm.allowancesNamesDataGridView.RowCount - 2
        '    totalTaxableAllowance += CType(runQueryAndReturnValue("SELECT DISTINCT 
        '        p.`" & MainForm.allowancesNamesDataGridView.Rows(a).Cells(0).Value & "` AS 'allow' 
        '        FROM `tbl_payroll` AS p, `tbl_allowance` AS a
        '        WHERE `pid` = '" & pId & "' AND `empid` = '" & empId & "' AND a.`taxable` = 1;", "allow"), Decimal)
        'Next
        'Return totalTaxableAllowance
        Return 0
    End Function

    Public Function CalcEmpDeduction(ByVal empId As Integer, ByVal pId As Integer) As Decimal
        'Dim totalDeduction As Decimal = 0
        'For d = 0 To MainForm.DeductionNamesDataGridView.RowCount - 2
        '    totalDeduction += CType(runQueryAndReturnValue("SELECT  
        '    `" & MainForm.DeductionNamesDataGridView.Rows(d).Cells(0).Value & "` AS 'deduct' 
        '    FROM `tbl_payroll` WHERE `pid` = '" & pId & "' AND `empid` = '" & empId & "';", "deduct"), Decimal)
        'Next
        'Return totalDeduction
        Return 0
    End Function

    Private Function getEmpIncomeTax(ByVal payid As Integer, ByVal empid As Integer) As Decimal

        Dim income_tax As String = runQueryAndReturnValue("SELECT `name` FROM `tbl_pay_head` 
                                         WHERE `pay_head_type` = 'Deductions from Employees' 
                                        AND `pay_type` = 'Income Tax'", "name")

        If Not String.IsNullOrEmpty(income_tax) Then
            Return runQueryAndReturnValue("SELECT `" & income_tax & "` FROM `tbl_emp_deductions` 
                                        WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'", income_tax)

        End If

        Return 0
    End Function

    Private Function getEmployeeSSNIT(ByVal payid As Integer, ByVal empid As Integer) As Decimal

        Dim ssnit_name As String = runQueryAndReturnValue("SELECT `name` FROM `tbl_pay_head` 
                                         WHERE `pay_head_type` = 'Deductions from Employees' 
                                        AND `pay_type` = 'SSNIT Employee'", "name")

        If Not String.IsNullOrEmpty(ssnit_name) Then
            Return runQueryAndReturnValue("SELECT `" & ssnit_name & "` FROM `tbl_emp_deductions` 
                                        WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'", ssnit_name)

        End If

        Return 0
    End Function

    Private Function getEmployeePF(ByVal payid As Integer, ByVal empid As Integer) As Decimal

        Dim pf_name As String = runQueryAndReturnValue("SELECT `name` FROM `tbl_pay_head` 
                                         WHERE `pay_head_type` = 'Deductions from Employees' 
                                        AND `pay_type` = 'PF Employee'", "name")

        If Not String.IsNullOrEmpty(pf_name) Then
            Return runQueryAndReturnValue("SELECT `" & pf_name & "` FROM `tbl_emp_deductions` 
                                        WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'", pf_name)

        End If

        Return 0
    End Function

    Private Function getEmpMonthEarning(ByVal payid As Integer, ByVal empid As Integer) As Decimal

        Return runQueryAndReturnValue("SELECT `month_earning` FROM `tbl_month_earning` 
                                        WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'", "month_earning")

    End Function

    Private Function getEmpTaxableEarnings(ByVal payid As Integer, ByVal empid As Integer) As Decimal

        Return runQueryAndReturnValue("SELECT `total` FROM `tbl_emp_taxable_earnings` 
                                        WHERE `payid` = '" & payid & "' 
                                        AND `empid` = '" & empid & "'", "total")

    End Function

    Private Function getEmpUntaxedEarnings(ByVal payid As Integer, ByVal empid As Integer) As Decimal

        Return runQueryAndReturnValue("SELECT `total` FROM `tbl_emp_untaxed_earnings` 
                                        WHERE `payid` = '" & payid & "' 
                                        AND `empid` = '" & empid & "'", "total")

    End Function

    Private Function getEmpBasicSalary(ByVal payid As Integer, ByVal empid As Integer) As Decimal

        Dim month_earning As String = runQueryAndReturnValue("SELECT `month_earning` 
                                                            FROM `tbl_emp_attendance_voucher` 
                                                            WHERE `payid` = '" & payid & "' 
                                                            AND `empid` = '" & empid & "'", "month_earning")

        Dim pay_head As String = runQueryAndReturnValue("SELECT `name` FROM `tbl_pay_head` 
                                         WHERE `pay_head_type` = 'Earnings for Employees' 
                                        AND `pay_type` = 'Basic Salary'", "name")

        If runQuery("UPDATE `tbl_emp_earnings` SET 
                `" & pay_head & "` = " & month_earning & " 
                WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'") = 1 Then

            Return month_earning

        End If

        Return 0
    End Function

    Private Function getEmpOvertimeEarning(ByVal payid As Integer, ByVal empid As Integer) As Integer

        Dim overtime As String = runQueryAndReturnValue("SELECT `overtime_earning` FROM `tbl_emp_overtime_voucher` 
                                        WHERE `payid` = '" & payid & "' 
                                        AND `empid` = '" & empid & "'", "overtime_earning")

        If Not String.IsNullOrEmpty(overtime) Then
            If runQuery("UPDATE `tbl_payroll` SET `net_overtime` = " & CDec(overtime) & " 
                        WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'") Then
                Return 1
            End If
        End If

        Return 0
    End Function

    Public Function calcEmpTaxablePay(ByVal payid As Integer, ByVal empid As Integer) As Integer

        'Dim month_earning As Decimal = getEmpMonthEarning(payid, empid)         'Employee's monthly earning (if attendance is applicable) or basic salary
        Dim txaable_earnings As Decimal = getEmpTaxableEarnings(payid, empid)    'Employee's total allowances

        Dim ssnit_employee As Decimal = getEmployeeSSNIT(payid, empid)          'SSNIT of the employee
        Dim pf_employee As Decimal = getEmployeePF(payid, empid)                'PF of the employee

        'Taxable pay of the employee
        Dim taxable_pay As Decimal = txaable_earnings - (ssnit_employee + pf_employee)

        'add to db
        If runQuery("UPDATE `tbl_payroll` SET `taxable_pay` = " & taxable_pay & " 
                    WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'") = 1 Then
            Return 1
        End If

        Return 0
    End Function

    Public Function calculateEmpIncomeTax(ByVal payid As Integer, ByVal empid As Integer) As Integer

        setupVars(1)

        Dim taxable_pay As Decimal = calcEmpTaxablePay(payid, empid)

        For i = 1 To runQueryAndReturnValue("SELECT COUNT(*) AS 'total' FROM `tbl_gra_refera`", "total")
            If taxable_pay > AMT_TO Then
                setupVars(i + 1)
            Else
                If i > 1 Then
                    FREE_AMT = CType(runQueryAndReturnValue("SELECT `free_amt` FROM `tbl_gra_refera` WHERE `id` = '" & (i - 1) & "'", "free_amt"), Decimal)
                Else
                    FREE_AMT = CType(runQueryAndReturnValue("SELECT `free_amt` FROM `tbl_gra_refera` WHERE `id` = '" & i & "'", "free_amt"), Decimal)
                End If

                Exit For
            End If
        Next

        Dim income_tax As Decimal = (((taxable_pay - AMT_FROM) * PERCENT) / 100) + FREE_AMT

        If runQuery("UPDATE `tbl_payroll` SET `income_tax` = " & income_tax & " 
                    WHERE `payid` = '" & payid & "' AND `empid` = '" & empid & "'") = 1 Then
            Return 1
        End If
        'Add to db

        Return income_tax
    End Function

    Public Function checkColumn(ByVal table_name As String, ByVal column_name As String) As String
        Dim sql As String = "SELECT IF(count(*) = 1, 'Exist','Not Exist') AS result 
                            FROM information_schema.columns 
                            WHERE table_schema = 'db_fast_pharms' 
                            AND table_name = '" & table_name & "' 
                            AND column_name = '" & column_name & "';"
        MsgBox(runQueryAndReturnValue(sql, "result"))
        Return 0
    End Function

End Module
