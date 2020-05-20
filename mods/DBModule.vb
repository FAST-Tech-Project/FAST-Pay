Imports MySql.Data.MySqlClient

Module DBModule
    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public ds As DataSet
    Public dr As MySqlDataReader
    Public NewData As Boolean
    Public i, o As Integer

    'Public servername As String = readfile("serverName.txt")
    Public servername As String = "local"

    Public Function connect() As Integer
        Try
            If String.IsNullOrEmpty(servername) Or servername = "no" Then
                Return 0
            Else
                conn.ConnectionString = "server=localhost;userid=root;password=fast;database=db_fast_pharms"
                If conn.ConnectionString.Any = True Then
                    Return 1
                Else
                    Return 0
                End If
            End If
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace.ToString)
            Return -1
        End Try
    End Function

    Function runQuery(query As String) As Integer
        Try

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            i = cmd.ExecuteNonQuery
            conn.Close()
            Return 1
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
            MsgBox(ex.StackTrace.ToString)
            Return -1
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Dispose()
        End Try
    End Function

    Public Function runQueryAndReturnValue(ByVal query As String, ByVal value As String) As String
        Try
            Dim returnValue As String = ""

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    returnValue = dr.Item(value)
                End While
            End If
            conn.Close()
            Return returnValue
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            MsgBox(ex.StackTrace.ToString)
            Return -1
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Dispose()
        End Try

    End Function

    Public Function runQueryAndReturnArray(ByVal query As String) As List(Of Integer)

        Dim list As New List(Of Integer)

        Try

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                While dr.Read
                    list.Add(dr.GetInt32(dr.GetOrdinal("id")))
                End While
            End If

            conn.Close()
            Return list

        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
            MsgBox(ex.StackTrace.ToString)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Dispose()
        End Try

        Return list
    End Function

End Module
