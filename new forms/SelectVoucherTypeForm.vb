Public Class SelectVoucherTypeForm

    Private Sub AttendanceOrProductionVoucherSetupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadDataIntoDatagrid(attend)
    End Sub

    Private Sub empOrGroupComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles empOrGroupComboBox.SelectedIndexChanged
        If LCase(empOrGroupComboBox.SelectedItem) = "employee" Then
            LoadDataIntoDatagrid(EmpOrGroupNameDataGridView, "SELECT `id`, CONCAT(`surname`, ' ', `first_name`) AS 'employee' 
            FROM `tbl_employee` WHERE `category` = '" & AttendaceOrProductionVoucherForm.empCategoryComboBox.Text & "';")
            EmpOrGroupNameDataGridView.Columns(1).HeaderText = "EMPLOYEE"

            EmpOrGroupNameDataGridView.Columns("id").Visible = False
            EmpOrGroupNameDataGridView.Columns(1).Width = 195

        ElseIf LCase(empOrGroupComboBox.SelectedItem) = "group" Then
            LoadDataIntoDatagrid(EmpOrGroupNameDataGridView, "SELECT g.`id`, g.`name` AS 'group' 
            FROM `tbl_group` AS g , `tbl_category` AS c 
            WHERE c.`id` = g.`catId` AND g.`catId` = '" & AttendaceOrProductionVoucherForm.empCatIDTextBox.Text & "'")
            EmpOrGroupNameDataGridView.Columns(1).HeaderText = "GROUP"

            EmpOrGroupNameDataGridView.Columns("id").Visible = False
            EmpOrGroupNameDataGridView.Columns(1).Width = 195

        ElseIf LCase(empOrGroupComboBox.SelectedItem) = "all items" Then
            AttendaceOrProductionVoucherForm.empOrGroupTypeTextBox.Text = empOrGroupComboBox.Text
            AttendaceOrProductionVoucherForm.empOrGroupIDTextBox.Text = "0"
            AttendaceOrProductionVoucherForm.empOrGroupNameTextBox.Text = empOrGroupComboBox.Text
            Me.Close()
        End If
    End Sub

    Private Sub EmpOrGroupNameDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles EmpOrGroupNameDataGridView.CellClick
        If e.RowIndex >= 0 And e.RowIndex <= EmpOrGroupNameDataGridView.RowCount - 2 Then
            If callFromTextBox.Text = "2" Then
                ProcessPayrollForm.empOrGroupTypeTextBox.Text = empOrGroupComboBox.Text
                ProcessPayrollForm.empOrGroupIDTextBox.Text = EmpOrGroupNameDataGridView.Rows(e.RowIndex).Cells("id").Value
                ProcessPayrollForm.empOrGroupNameTextBox.Text = EmpOrGroupNameDataGridView.Rows(e.RowIndex).Cells(1).Value

            Else
                AttendaceOrProductionVoucherForm.empOrGroupTypeTextBox.Text = empOrGroupComboBox.Text
                AttendaceOrProductionVoucherForm.empOrGroupIDTextBox.Text = EmpOrGroupNameDataGridView.Rows(e.RowIndex).Cells("id").Value
                AttendaceOrProductionVoucherForm.empOrGroupNameTextBox.Text = EmpOrGroupNameDataGridView.Rows(e.RowIndex).Cells(1).Value

            End If
            Me.Close()
        End If
    End Sub

End Class