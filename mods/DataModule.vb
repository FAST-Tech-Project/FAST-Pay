Imports MySql.Data.MySqlClient

Module DataModule

    Public Sub FetchComboData(combo, sql, disp)
        Try

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd = New MySqlCommand(sql, conn)
            da = New MySqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            combo.DataSource = dt
            combo.DisplayMember = disp
            combo.ValueMember = "id"
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox(ex.StackTrace.ToString)
            conn.Close()
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Dispose()
        End Try
    End Sub

    Public Sub LoadDataIntoDatagrid(datagrid, query)
        Try

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            datagrid.DataSource = dt
            datagrid.Enabled = True
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox(ex.StackTrace.ToString)
            conn.Close()
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Dispose()
        End Try
    End Sub

End Module
