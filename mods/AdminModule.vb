Imports MySql.Data.MySqlClient
Imports System.IO
Module AdminModule

    Private COMPANY_NAME As String
    Private COMPANY_ADDR As String
    Private COMPANY_LOGO As String
    Private SSNIT_EMPLOYEE As Decimal
    Private SSNIT_EMPLOYER As Decimal
    Private PF_EMPLOYEE As Decimal
    Private PF_EMPLOYER As Decimal
    Private TIER_1 As Decimal
    Private TIER_2 As Decimal
    Private ALLOWANCE_1 As Decimal
    Private ALLOWANCE_2 As Decimal
    Private ALLOWANCE_3 As Decimal
    Private WORKING_DAYS As Integer

    Public Function wrt_ser_name(tf As String, sn As String) As Boolean
        Try
            Dim wrtr As New System.IO.StreamWriter(tf)
            wrtr.Flush()
            wrtr.WriteLine(sn)
            wrtr.Close()
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function readfile(tf As String) As String
        Try
            Dim file As New System.IO.StreamReader(tf)
            Dim output = file.ReadToEnd
            file.Close()
            Return output
        Catch ex As Exception
            Return "no"
        End Try
        Return vbNullString
    End Function

    Public Sub createCompany(ByVal cn As String, ByVal ad As String, ByVal lg As String, ByVal see As Double, ByVal ser As Double, ByVal pfe As Double, ByVal pfr As Double, ByVal t1 As Double, ByVal t2 As Double, ByVal all1 As Double, ByVal all2 As Double, ByVal all3 As Double, ByVal wd As Integer)
        Try
            Dim ssnit_employee As Double = see / 100
            Dim ssnit_employer As Double = ser / 100
            Dim pf_employee As Double = pfe / 100
            Dim pf_employer As Double = pfr / 100
            Dim tier1 As Double = t1 / 100
            Dim tier2 As Double = t2 / 100

            Dim query As String = "INSERT INTO tbl_setup (name,address,logo, ssnit_employee,ssnit_employer,pf_employee,pf_employer, tier_1,tier_2,allowance_1,allowance_2,allowance_3,working_days) " _
                            + " VALUES ('" & cn & "','" & ad & "','" & lg & "','" & ssnit_employee &
                            "','" & ssnit_employer & "','" & pf_employee & "','" & pf_employer &
                            "','" & tier1 & "','" & tier2 & "','" & all1 & "','" & all2 & "','" & all3 &
                            "','" & wd & "')"
            Dim x As Integer = runQuery(query)

            If x > 0 Then
                MsgBox("Data SUCCESSFULLY added!", MessageBoxIcon.Information)
            Else
                MsgBox("Data COULDN'T be added!", MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub updateCompany(ByVal cn As String, ByVal ad As String, ByVal lg As String, ByVal see As Decimal, ByVal ser As Decimal, ByVal pfe As Decimal, ByVal pfr As Decimal, ByVal t1 As Decimal, ByVal t2 As Decimal, ByVal all1 As Decimal, ByVal all2 As Decimal, ByVal all3 As Decimal, ByVal wd As Integer)
        Try
            Dim ssnit_employee As Decimal = see / 100
            Dim ssnit_employer As Decimal = ser / 100
            Dim pf_employee As Decimal = pfe / 100
            Dim pf_employer As Decimal = pfr / 100
            Dim tier1 As Decimal = t1 / 100
            Dim tier2 As Decimal = t2 / 100

            Dim query As String = "UPDATE tbl_setup SET name ='" & cn &
                "',address ='" & ad & "', logo ='" & lg & "', ssnit_employee ='" & ssnit_employee &
                "',ssnit_employer ='" & ssnit_employer & "', pf_employee ='" & pf_employee &
                "',pf_employer ='" & pf_employer & "', tier_1 ='" & tier1 & "',tier_2 ='" & tier2 &
                "', allowance_1 ='" & all1 & "', allowance_2 ='" & all2 &
                "',allowance_3 ='" & all3 & "', working_days ='" & wd &
                "' WHERE id =1"
            Dim x As Integer = runQuery(query)

            If x > 0 Then
                MsgBox("Data SUCCESSFULLY updated!", MessageBoxIcon.Information)
            Else
                MsgBox("Data COULDN'T be updated!", MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub updateAdminUserPass(ByVal admin_id As Integer, ByVal username As String, ByVal password As String)
        Try
            Dim query As String = "UPDATE tbl_user_login SET username='" & username & "', passw='" & password & "' WHERE id='" & admin_id & "'"
            Dim x As Integer = runQuery(query)

            If x > 0 Then
                MsgBox("Data SUCCESSFULLY updated!", MessageBoxIcon.Information)
            Else
                MsgBox("Data COULDN'T be updated!", MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub setAll()
        Try
            Dim query As String = "SELECT * FROM tbl_setup WHERE id = 1"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    COMPANY_NAME = dr.Item("name")
                    COMPANY_LOGO = dr.Item("logo")
                    COMPANY_ADDR = dr.Item("address")
                    SSNIT_EMPLOYEE = dr.Item("ssnit_employee")
                    SSNIT_EMPLOYER = dr.Item("ssnit_employer")
                    PF_EMPLOYEE = dr.Item("pf_employee")
                    PF_EMPLOYER = dr.Item("pf_employer")
                    TIER_1 = dr.Item("tier_1")
                    TIER_2 = dr.Item("tier_2")
                    ALLOWANCE_1 = dr.Item("allowance_1")
                    ALLOWANCE_2 = dr.Item("allowance_2")
                    ALLOWANCE_3 = dr.Item("allowance_3")
                    WORKING_DAYS = dr.Item("working_days")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Public Sub setCompanyName()
        Try
            Dim query As String = "SELECT company_name FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    COMPANY_NAME = dr.GetString("company_name")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setCompnayLogo()
        Try
            Dim query As String = "SELECT logo FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    COMPANY_LOGO = dr.GetString("logo")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setCompnayAddress()
        Try
            Dim query As String = "SELECT address FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    COMPANY_ADDR = dr.GetString("address")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setSSNITEmployee()
        Try
            Dim query As String = "SELECT ssnit_employee FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    SSNIT_EMPLOYEE = dr.GetDouble("ssnit_employee")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setSSNITEmployer()
        Try
            Dim query As String = "SELECT ssnit_employer FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    SSNIT_EMPLOYER = dr.GetDouble("ssnit_employer")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setPFEmployee()
        Try
            Dim query As String = "SELECT pf_employee FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    PF_EMPLOYEE = dr.GetDouble("pf_employee")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setPFEmployer()
        Try
            Dim query As String = "SELECT pf_employer FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    PF_EMPLOYER = dr.GetDouble("pf_employer")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setTierOne()
        Try
            Dim query As String = "SELECT tier_1 FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    TIER_1 = dr.GetDouble("tier_1")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setTierTwo()
        Try
            Dim query As String = "SELECT tier_2 FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    TIER_1 = dr.GetDouble("tier_2")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setAllowanceOne()
        Try
            Dim query As String = "SELECT allowance_1 FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    ALLOWANCE_1 = dr.GetDouble("allowance_1")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setAllowanceTwo()
        Try
            Dim query As String = "SELECT allowance_2 FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    ALLOWANCE_2 = dr.GetDouble("allowance_2")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setAllowanceThree()
        Try
            Dim query As String = "SELECT allowance_3 FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    ALLOWANCE_3 = dr.GetDouble("allowance_3")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Sub setWorkingDays()
        Try
            Dim query As String = "SELECT working_days FROM tbl_setup"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    WORKING_DAYS = dr.GetDouble("working_days")
                End While
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Function getSSNITEmployee() As Double
        Return SSNIT_EMPLOYEE
    End Function

    Public Function getSSNITEmployer() As Double
        Return SSNIT_EMPLOYER
    End Function

    Public Function getPFEmployee() As Double
        Return PF_EMPLOYEE
    End Function

    Public Function getPFEmployer() As Double
        Return PF_EMPLOYER
    End Function

    Public Function getTierOne() As Double
        Return TIER_1
    End Function

    Public Function getTierTwo() As Double
        Return TIER_2
    End Function

    Public Function getWorkingDays()
        Return WORKING_DAYS
    End Function

    Public Function getCompanyName() As String
        Return COMPANY_NAME
    End Function

    Public Function getCompanyLogo() As String
        Return COMPANY_LOGO
    End Function

    Public Function getCompanyAddress() As String
        Return COMPANY_ADDR
    End Function

    Public Sub createFolder(path As String)
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
    End Sub
End Module
