Imports System.ComponentModel

Public Class PayHeadsForm
    Private Sub PayHeadsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDataIntoDatagrid(payHeadsDataGridView, "SELECT * FROM `tbl_pay_head`;")
        payHeadsDataGridView.Columns(0).Visible = False
        payHeadsDataGridView.Columns(2).Visible = False
        payHeadsDataGridView.Columns(3).Visible = False
        payHeadsDataGridView.Columns(4).Visible = False
        payHeadsDataGridView.Columns(5).Visible = False
        payHeadsDataGridView.Columns(6).Visible = False
        payHeadsDataGridView.Columns(7).Visible = False
        payHeadsDataGridView.Columns(8).Visible = False
        payHeadsDataGridView.Columns(9).Visible = False
        payHeadsDataGridView.Columns(10).Visible = False
        payHeadsDataGridView.Columns(11).Visible = False
        payHeadsDataGridView.Columns(12).Visible = False
        payHeadsDataGridView.Columns(13).Visible = False
        payHeadsDataGridView.Columns(14).Visible = False
        payHeadsDataGridView.Columns(15).Visible = False
        payHeadsDataGridView.Columns(16).Visible = False
        payHeadsDataGridView.Columns(17).Visible = False
        payHeadsDataGridView.Columns(1).Width = 184
        payHeadsDataGridView.Columns(1).HeaderText = "PAY HEADS"

    End Sub

    Private Sub payHeadsDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles payHeadsDataGridView.CellClick

        If e.RowIndex >= 0 And e.RowIndex <= payHeadsDataGridView.RowCount - 2 Then

            If SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Visible = True Then

                SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows.Add()
                Dim rowInd As Integer = SalaryDetailsSetupForm.clickedRowIndexTextBox.Text

                SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows(rowInd).Cells("id").Value = payHeadsDataGridView.Rows(e.RowIndex).Cells("id").Value
                SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows(rowInd).Cells("pay_head").Value = payHeadsDataGridView.Rows(e.RowIndex).Cells("name").Value
                SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows(rowInd).Cells("pay_head_type").Value = payHeadsDataGridView.Rows(e.RowIndex).Cells("pay_head_type").Value
                SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows(rowInd).Cells("calculation_type").Value = payHeadsDataGridView.Rows(e.RowIndex).Cells("calculation_type").Value
                SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows(rowInd).Cells("pay_type").Value = payHeadsDataGridView.Rows(e.RowIndex).Cells("pay_type").Value

                If LCase(payHeadsDataGridView.Rows(e.RowIndex).Cells("calculation_type").Value) = "as computed value" Then
                    If LCase(payHeadsDataGridView.Rows(e.RowIndex).Cells("compute_on").Value) = "on specified formula" Then
                        SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows(rowInd).Cells("compute_on").Value = payHeadsDataGridView.Rows(e.RowIndex).Cells("specified_formula").Value
                    Else
                        SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows(rowInd).Cells("compute_on").Value = payHeadsDataGridView.Rows(e.RowIndex).Cells("compute_on").Value
                    End If

                ElseIf LCase(payHeadsDataGridView.Rows(e.RowIndex).Cells("calculation_type").Value) = "on production" Then
                    SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows(rowInd).Cells("period").Value = runQueryAndReturnValue("SELECT a.`unit` FROM `tbl_pay_head` AS p, `tbl_attendance_or_production` AS a WHERE p.`attend_or_prod_type` = a.`name` AND p.`id` = '" & payHeadsDataGridView.Rows(e.RowIndex).Cells("id").Value & "';", "unit")

                ElseIf LCase(payHeadsDataGridView.Rows(e.RowIndex).Cells("calculation_period").Value) <> "" Then
                    SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows(rowInd).Cells("period").Value = payHeadsDataGridView.Rows(e.RowIndex).Cells("calculation_period").Value
                End If

                SalaryDetailsSetupForm.clickedRowIndexTextBox.Text = rowInd + 1

            ElseIf SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.Visible = True Then

                'Create a new datarow instance to add a new row to the dgv
                Dim MyNewRow As DataRow
                MyNewRow = SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.DataSource.NewRow

                With MyNewRow
                    .Item("id") = payHeadsDataGridView.Rows(e.RowIndex).Cells("id").Value
                    .Item("name") = payHeadsDataGridView.Rows(e.RowIndex).Cells("name").Value
                    .Item("pay_head_type") = payHeadsDataGridView.Rows(e.RowIndex).Cells("pay_head_type").Value
                    .Item("calculation_type") = payHeadsDataGridView.Rows(e.RowIndex).Cells("calculation_type").Value
                    .Item("pay_type") = payHeadsDataGridView.Rows(e.RowIndex).Cells("pay_type").Value

                    If LCase(payHeadsDataGridView.Rows(e.RowIndex).Cells("calculation_type").Value) = "as computed value" Then
                        If LCase(payHeadsDataGridView.Rows(e.RowIndex).Cells("compute_on").Value) = "on specified formula" Then
                            .Item("compute_on") = payHeadsDataGridView.Rows(e.RowIndex).Cells("specified_formula").Value
                        Else
                            .Item("compute_on") = payHeadsDataGridView.Rows(e.RowIndex).Cells("compute_on").Value
                        End If

                    ElseIf LCase(payHeadsDataGridView.Rows(e.RowIndex).Cells("calculation_type").Value) = "on production" Then
                        .Item("calculation_period") = runQueryAndReturnValue("SELECT a.`unit` FROM `tbl_pay_head` AS p, `tbl_attendance_or_production` AS a WHERE p.`attend_or_prod_type` = a.`name` AND p.`id` = '" & payHeadsDataGridView.Rows(e.RowIndex).Cells("id").Value & "'", "unit")

                    ElseIf LCase(payHeadsDataGridView.Rows(e.RowIndex).Cells("calculation_period").Value) <> "" Then
                        .Item("calculation_period") = payHeadsDataGridView.Rows(e.RowIndex).Cells("calculation_period").Value
                    End If
                End With

                SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.DataSource.rows.add(MyNewRow)
                SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.DataSource.acceptchanges
            End If

            payHeadsDataGridView.Rows(e.RowIndex).Selected = True
            payHeadsDataGridView.Rows.RemoveAt(e.RowIndex)

            payHeadsDataGridView.ClearSelection()

        End If

    End Sub

    Private Sub PayHeadsForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'When form is closing check to see if the group dgv has been modified (new row added), then remove addition row by system
        If SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.Visible = True Then
            If SalaryDetailsSetupForm.clickedGroupRowIndexTextBox.Text <> "" And SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.RowCount > CInt(SalaryDetailsSetupForm.GroupDgvTotalRowsTextBox.Text) Then
                SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.Rows.RemoveAt(SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.RowCount - 2)
            End If
        End If
    End Sub

    Private Sub PayHeadsForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        payHeadsDataGridView.ClearSelection()

        'Check and remove from payHeads which are already in DataGridViews
        If SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Visible = True And SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.RowCount - 1 > 0 Then

            For j = 0 To SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.RowCount - 2
                For index = 0 To payHeadsDataGridView.RowCount - 2
                    If payHeadsDataGridView.Rows(index).Cells("id").Value = SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Rows(j).Cells("id").Value Then
                        payHeadsDataGridView.Rows(index).Selected = True
                        payHeadsDataGridView.Rows.RemoveAt(index)
                    End If

                Next
            Next

        ElseIf SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.Visible = True And SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.RowCount - 1 > 0 Then

            For j = 0 To SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.RowCount - 2
                For index = 0 To payHeadsDataGridView.RowCount - 2

                    If payHeadsDataGridView.Rows(index).Cells("id").Value = SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.Rows(j).Cells("id").Value Then
                        payHeadsDataGridView.Rows(index).Selected = True
                        payHeadsDataGridView.Rows.RemoveAt(index)
                    End If

                Next
            Next

        End If

    End Sub

End Class