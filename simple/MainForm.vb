Imports MySql.Data.MySqlClient

Public Class MainForm

    Private Sub MainForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        LoginForm.Show()
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub toEmployeeButton_Click(sender As Object, e As EventArgs) Handles toEmployeeButton.Click
        EmployeeDetailsForm.Show()
        Me.Close()
    End Sub

    Private Sub toPayHeadsButton_Click(sender As Object, e As EventArgs) Handles toPayHeadsButton.Click
        PayHeadsDetailsForm.Show()
        Me.Close()
    End Sub

    Private Sub toSalariesButton_Click(sender As Object, e As EventArgs) Handles toSalariesButton.Click
        SalaryDetailsForm.Show()
        Me.Close()
    End Sub

    Private Sub toPayrollButton_Click(sender As Object, e As EventArgs) Handles toPayrollButton.Click
        PayrollDetailsForm.Show()
        Me.Close()
    End Sub
End Class