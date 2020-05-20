Public Class SalarySetupStartTypeFrom
    Private Sub SalarySetupStartTypeFrom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub startTypeListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles startTypeListBox.SelectedIndexChanged
        If startTypeListBox.SelectedItem = "Start Afresh" Then
            SalaryDetailsSetupForm.EmployeeSalaryDetailsDataGridView.Visible = True
            SalaryDetailsSetupForm.GrpSalaryDetailsDataGridView.Visible = False

            SalaryDetailsSetupForm.selectedStartTypeTextBox.Text = 1
            PayHeadsForm.Show()

        ElseIf startTypeListBox.SelectedItem = "Copy From Parent Value" Then
            If LCase(SalaryDetailsSetupForm.empOrGroupTypeTextBox.Text) = "employee" Then
                SalaryDetailsSetupForm.setSalaryDetailsDgv("Group", SalaryDetailsSetupForm.empGroupIDTextBox.Text)
            End If

        End If

        Me.Close()

    End Sub
End Class