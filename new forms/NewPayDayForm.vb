Public Class NewPayDayForm

    Private Sub NewPayDayForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SavePayDateButton_Click(sender As Object, e As EventArgs) Handles SavePayDateButton.Click
        If verifyInput() = 1 Then
            Dim x As Integer = 0
            Dim y As Integer = 0
            Dim comment As String = ""

            Dim dateFrom As String = PayFromDateTimePicker.Text
            Dim dateTo As String = PayToDateTimePicker.Text

            If PayFromDateTimePicker.Value.Month = PayToDateTimePicker.Value.Month Then
                comment = "PAYROLL FOR " &
                            UCase(MonthName(PayFromDateTimePicker.Value.Month)) & ", " &
                            PayFromDateTimePicker.Value.Day.ToString & " - " &
                            PayToDateTimePicker.Value.Day.ToString & " " &
                            PayToDateTimePicker.Value.Year

            ElseIf PayFromDateTimePicker.Value.Month < PayToDateTimePicker.Value.Month Then
                comment = "PAYROLL FOR " &
                            UCase(MonthName(PayFromDateTimePicker.Value.Month)) & ", " &
                            PayFromDateTimePicker.Value.Day.ToString & " " &
                            PayFromDateTimePicker.Value.Year & " - " &
                            UCase(MonthName(PayToDateTimePicker.Value.Month)) & ", " &
                            PayToDateTimePicker.Value.Day.ToString & " " &
                            PayToDateTimePicker.Value.Year
            End If

            If SelectedPayIDTextBox.Enabled = False Then
                x = updatePayDay(dateFrom, dateTo, comment)
            Else
                y = createPayDay(dateFrom, dateTo, comment)
            End If
            If x = 1 Then
                MsgBox("Data Saved!")
                Me.Close()
            ElseIf y = 1 Then
                MsgBox("Data Saved!")
                clearText()
            End If
            LoadDataIntoDatagrid(MainPage.AddedPayrollDataGridView,
                             "SELECT `id`, `comment` AS 'PAYROLL PERIOD' FROM `tbl_pay_process`")
            MainPage.AddedPayrollDataGridView.Columns(0).Visible = False
            Me.Close()
        Else
            MsgBox("All fields are required!")
        End If
    End Sub

    Private Sub DelPayDayButton_Click(sender As Object, e As EventArgs) Handles DelPayDayButton.Click
        Dim msg As String = MsgBox("Are you sure you want to delete this?", vbYesNo, "Delete Details")
        If msg = vbYes Then
            deletePayDay(SelectedPayIDTextBox.Text)
            Me.Close()
            LoadDataIntoDatagrid(MainPage.AddedPayrollDataGridView,
                                 "SELECT `id`, `comment` AS 'PAYROLL PERIOD' FROM `tbl_pay_process`")
            MainPage.AddedPayrollDataGridView.Columns(0).Visible = False
        End If
    End Sub

    Private Function verifyInput() As Integer
        If PayFromDateTimePicker.Value.Date < PayToDateTimePicker.Value.Date Then
            Return 1
        End If
        Return 0
    End Function

    Private Sub clearText()
        PayFromDateTimePicker.Value = Date.Now
        PayToDateTimePicker.Value = Date.Now
    End Sub

    Private Sub NewPayDayForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Not String.IsNullOrEmpty(SelectedPayIDTextBox.Text) Then
            setPayDayDetails(SelectedPayIDTextBox.Text)
            SelectedPayIDTextBox.Enabled = False
            DelPayDayButton.Show()
        End If
    End Sub
End Class