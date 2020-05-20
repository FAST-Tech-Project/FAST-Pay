Public Class CreatePayPeriodForm
    Private Sub CreatePayPeriodForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim comment As String = ""

        If FromDateDateTimePicker.Value.Year = ToDateDateTimePicker.Value.Year Then

            If FromDateDateTimePicker.Value.Month > ToDateDateTimePicker.Value.Month Then
                MsgBox("'From Date' month can't be greater than 'To Date' month")
                Exit Sub
            End If

            If FromDateDateTimePicker.Value.Month = ToDateDateTimePicker.Value.Month Then
                If FromDateDateTimePicker.Value.Day = ToDateDateTimePicker.Value.Day Then
                    MsgBox("'From Date' day can't be same as 'To Date' day")
                    Exit Sub
                ElseIf FromDateDateTimePicker.Value.Day > ToDateDateTimePicker.Value.Day Then
                    MsgBox("'From Date' day can't be greater than 'To Date' date")
                    Exit Sub
                End If

                comment = "Payroll For " & MonthName(ToDateDateTimePicker.Value.Month) & " " & FromDateDateTimePicker.Value.Day & " - " & ToDateDateTimePicker.Value.Day

            ElseIf FromDateDateTimePicker.Value.Month <> ToDateDateTimePicker.Value.Month Then
                comment = "Payroll For " & MonthName(FromDateDateTimePicker.Value.Month) & " " & FromDateDateTimePicker.Value.Day & " - "
                comment += MonthName(ToDateDateTimePicker.Value.Month) & " " & ToDateDateTimePicker.Value.Day

            End If
            comment += ", " & ToDateDateTimePicker.Value.Year

        ElseIf ToDateDateTimePicker.Value.Year > FromDateDateTimePicker.Value.Year Then

            comment = "Payroll For "
            comment += MonthName(FromDateDateTimePicker.Value.Month) & " " & FromDateDateTimePicker.Value.Day & ", " & FromDateDateTimePicker.Value.Year
            comment += " - "
            comment += MonthName(ToDateDateTimePicker.Value.Month) & " " & ToDateDateTimePicker.Value.Day & ", " & ToDateDateTimePicker.Value.Year

        ElseIf ToDateDateTimePicker.Value.Year < FromDateDateTimePicker.Value.Year Then
            MsgBox("'From Date' year can't be greater than 'To Date' year")
            Exit Sub

        End If

        If CInt(runQueryAndReturnValue("SELECT COUNT(*) AS 'total' FROM `tbl_pay_process` WHERE `processed` = 0", "total")) > 0 Then
            MsgBox("You can only run payroll for a pay period at a time and therefore you can create more than one pay period.")
            Exit Sub

        Else
            If runQuery("INSERT INTO `tbl_pay_process`(`from`, `to`, `comment`, `added_at`)
                    VALUES('" & FromDateDateTimePicker.Text & "', 
                            '" & ToDateDateTimePicker.Text & "', 
                            '" & comment & "', CURRENT_TIMESTAMP)") = 1 Then
                MsgBox("Pay period created!")
            End If

        End If

    End Sub
End Class