Imports MySql.Data.MySqlClient

Module PayDayModule
    Public Sub setPayDayDetails(ByVal payDayID As String)
        Try
            Dim query As String = "SELECT `from`, `to` FROM `tbl_pay_process` WHERE `id` = '" & payDayID & "'"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    'NewPayDayForm.PayFromDateTimePicker.Text = dr.Item("from")
                    'NewPayDayForm.PayToDateTimePicker.Text = dr.Item("to")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        Finally
            conn.Dispose()
        End Try

    End Sub

    Public Function createPayDay(ByVal _from As String, ByVal _to As String,
                                    ByVal comment As String) As Integer
        Try

            Dim query As String = "INSERT INTO `tbl_pay_process` (`from`, `to`, `comment`, `added_at`)" _
            + " VALUES('" & _from & "', '" & _to & "', '" & comment & "', CURRENT_TIMESTAMP)"

            Return runQuery(query)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function

    Public Function updatePayDay(ByVal _from As Date, ByVal _to As Date,
                                    ByVal comment As String) As Integer
        Try
            Dim query As String = "UPDATE `tbl_pay_process` 
                                       SET `from` = '" & _from & "', 
                                       `to` = '" & _to & "', 
                                       `comment` = '" & comment & "', 
                                       `updated_at` = CURRENT_TIMESTAMP)"

            Return runQuery(query)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function

    Public Function deletePayDay(ByVal id As Integer) As Integer
        Try
            Dim query As String = "DELETE FROM `tbl_pay_process` WHERE `id` = '" & id & "'"

            Return runQuery(query)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function


    'This deals with the processing of payroll

    Public Function addSelectedEmployee(ByVal pID As Integer, ByVal empID As Integer) As Integer
        Try
            Dim output As Integer = -1
            Dim query As String = "CALL proc_add_selected_employee ('" & pID & "', '" & empID & "');"
            Return runQuery(query)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
    End Function

    'check if pay_process has employees added to it
    Public Function checkForEmployee(ByVal pID As Integer) As Integer
        Try
            Dim query As String = "SELECT count(pid) FROM `tbl_payroll` WHERE `pid` = '" & pID & "'"

            Return runQuery(query)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return -1
        End Try
        Return 0
    End Function

End Module
