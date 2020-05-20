Imports MySql.Data.MySqlClient

Module EmployeeModule
    Private DAYS_WORKED As Integer = 0
    Private EMPLOYEE_BASIC_SALARY As Double = 0
    Private USER_ID As Integer = 0
    Private USER_TYPE As String = ""
    Private USER_LOGIN As Boolean = False

    Public Sub setEmployeeID(ByVal staff_id As String)
        Try
            Dim query As String = "SELECT `id` FROM `tbl_employee` WHERE `staff_id` ='" & staff_id & "'"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    USER_ID = dr.GetInt32("id")
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub setEmployeeBasicSalary(ByVal staff_id As String)
        Try
            setEmployeeID(staff_id)
            Dim query As String = "SELECT `basic salary` FROM `tbl_payroll` WHERE `empid` ='" & staff_id & "'"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    EMPLOYEE_BASIC_SALARY = dr.GetDouble("basic salary")
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub setEmployeeDaysWorked(ByVal day_worked As Integer)
        DAYS_WORKED = day_worked
    End Sub

    Public Function getEmployeeID() As Integer
        Return USER_ID
    End Function

    Public Function getEmployeeBasicSalary() As Double
        Return EMPLOYEE_BASIC_SALARY
    End Function

    Public Function getEmployeeDaysWorked() As Integer
        Return DAYS_WORKED
    End Function

    Private Function generateUserName(ByVal firstname As String, ByVal lastname As String) As String
        Dim f As String = firstname.Substring(firstname.Length() - 1)
        Dim l As String = lastname.Substring(lastname.Length() - 1)
        Dim user As String = lastname & "." & f & l
        Return Microsoft.VisualBasic.LCase(user)
    End Function

    'Private Function generatePassword() As String
    '    StringBuilder returnValue = New StringBuilder(length)
    '    for int i = 0 i < length i++

    '        returnValue.append(ALPHABET.charAt(Random.nextInt(ALPHABET.length())))

    '        Return returnValue
    'End Function

    Public Sub createEmployeeGroup(ByVal group_name As String)
        Try
            Dim query As String = "INSERT INTO `tbl_employee_group`(`group_name`) VALUES('" & group_name & "')"
            Dim x As Integer = runQuery(query)

            If x > 0 Then
                MsgBox("Group SUCCESSFULLY added!", MessageBoxIcon.Information)
            Else
                MsgBox("Group COULDN'T be added!", MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub updateEmployeeGroup(ByVal group_id As Integer, ByVal group_name As String)
        Try
            Dim query As String = "UPDATE `tbl_employee_group` SET `group_nam`e='" & group_name & "' WHERE `id`='" & group_id & "'"
            Dim x As Integer = runQuery(query)

            If x > 0 Then
                MsgBox("Group SUCCESSFULLY updated!", MessageBoxIcon.Information)
            Else
                MsgBox("Group COULDN'T be updated!", MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub deleteEmployeeGroup(group_id As Integer)
        Try
            Dim query As String = "DELETE FROM `tbl_employee_group` WHERE `id`='" & group_id & "'"
            Dim x As Integer = runQuery(query)

            If x > 0 Then
                MsgBox("Group SUCCESSFULLY deleted!", MessageBoxIcon.Information)
            Else
                MsgBox("Group COULDN'T be deleted!", MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub createEmployeeBranch(branch_name As String)
        Try
            Dim query As String = "INSERT INTO `tbl_employee_branch`(`branch_name`) VALUES('" & branch_name & "')"
            Dim x As Integer = runQuery(query)

            If x > 0 Then
                MsgBox("Branch SUCCESSFULLY added!", MessageBoxIcon.Information)
            Else
                MsgBox("Branch COULDN'T be added!", MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub updateEmployeeBranch(ByVal branch_id As Integer, ByVal branch_name As String)
        Try
            Dim query As String = "UPDATE `tbl_employee_branch` SET `group_name`='" & branch_name & "' WHERE `id`='" & branch_id & "'"
            Dim x As Integer = runQuery(query)

            If x > 0 Then
                MsgBox("Branch SUCCESSFULLY updated!", MessageBoxIcon.Information)
            Else
                MsgBox("Branch COULDN'T be updated!", MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub deleteEmployeeBranch(branch_id As Integer)
        Try
            Dim query As String = "DELETE FROM `tbl_employee_branch` WHERE `id`='" & branch_id & "'"
            Dim x As Integer = runQuery(query)

            If x > 0 Then
                MsgBox("Branch SUCCESSFULLY deleted!", MessageBoxIcon.Information)
            Else
                MsgBox("Branch COULDN'T be deleted!", MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function updateEmployeeDetails(
                        ByVal surname As String, ByVal first_name As String,
                        ByVal staff_id As String, ByVal ssnit_number As String,
                        ByVal tin_number As String) As Integer
        Try

            Dim query As String = "UPDATE `tbl_employee` SET " _
            + "`surname` ='" & surname & "', `first_name` ='" & first_name &
            "', `ssnit_number` ='" & ssnit_number & "', `tin_number` ='" & tin_number &
            "', `updated_at` = CURRENT_TIMESTAMP  WHERE `staff_id` ='" & staff_id & "'"

            Return runQuery(query)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

    Public Function deleteEmployeeDetails(ByVal staff_id As String) As Integer
        Try

            Dim query As String = "DELETE FROM tbl_employee WHERE staff_id = '" & staff_id & "'"

            Return runQuery(query)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

    Public Function updateContactDetails(
                        ByVal address_1 As String, ByVal address_2 As String,
                        ByVal city As String, ByVal state_or_province As String,
                        ByVal zip_or_postal_code As String, ByVal house_number As String,
                        ByVal country As String, ByVal home_telephone As String,
                        ByVal mobile As String, ByVal work_number As String,
                        ByVal work_email As String, ByVal other_email As String) As Integer
        Try
            'setEmployeeID(staff_id)

            Dim query As String = "UPDATE tbl_payroll SET " _
            + "address_1 ='" & address_1 & "', address_2 ='" & address_2 &
            "', city ='" & city & "', state_or_province ='" & state_or_province &
            "', zip_or_postal_code ='" & zip_or_postal_code & "', house_number ='" & house_number &
            "', country ='" & country & "', home_telephone ='" & home_telephone &
            "', mobile ='" & mobile & "', work_number ='" & work_number &
            "', work_email ='" & work_email & "', other_email ='" & other_email &
            "' WHERE e_id ='" & getEmployeeID() & "'"

            Dim x As Integer = runQuery(query)
            Return x
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

    Public Function updateOtherInfo(
                        ByVal number_of_kids As Integer,
                        ByVal higher_qualification As String, ByVal year_of_qualification As String,
                        ByVal institution_of_qualification As String, ByVal religion As String,
                        ByVal date_ofemployment As Date, ByVal date_of_confirmation As Date,
                        ByVal appointment_letter As String, ByVal employment_type As String,
                        ByVal contract_validity As String, ByVal branch As String,
                        ByVal department As String, ByVal position As String,
                        ByVal last_place_of_work As String, ByVal next_of_kin As String,
                        ByVal tel_of_next_of_kin As String
                        ) As Integer
        Try
            'setEmployeeID(staff_id)
            Dim query As String = "UPDATE tbl_payroll SET " _
            + "number_of_kids ='" & number_of_kids & "', higher_qualification ='" & higher_qualification &
            "', year_of_qualification ='" & year_of_qualification & "', institution_of_qualification ='" & institution_of_qualification &
            "', religion ='" & religion & "', date_ofemployment ='" & date_ofemployment &
            "', date_of_confirmation ='" & date_of_confirmation & "', appointment_letter ='" & appointment_letter &
            "', employment_type ='" & employment_type & "', contract_validity ='" & employment_type &
            "', branch ='" & employment_type & "', department ='" & employment_type &
            "', position ='" & employment_type & "', last_place_of_work ='" & employment_type &
            "', next_of_kin ='" & employment_type & "',tel_of_next_of_kin ='" & employment_type &
            "' WHERE e_id ='" & getEmployeeID() & "'"

            Dim x As Integer = runQuery(query)
            Return x
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

    Public Sub setEmployeeDetails(ByVal employeeID As Integer)
        Try
            Dim query As String = "SELECT * FROM `tbl_employee` WHERE `id` = '" & employeeID & "'"
            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read

                    EmployeeForm.TitleComboBox.Text = If(dr.Item("title") Is DBNull.Value, String.Empty, dr.Item("title"))
                    EmployeeForm.SurnameTextBox.Text = If(dr.Item("surname") Is DBNull.Value, String.Empty, dr.Item("surname"))
                    EmployeeForm.MiddleNameTextBox.Text = If(dr.Item("middle_name") Is DBNull.Value, String.Empty, dr.Item("middle_name"))
                    EmployeeForm.FirstNameTextBox.Text = If(dr.Item("first_name") Is DBNull.Value, String.Empty, dr.Item("first_name"))
                    EmployeeForm.NationalityTextBox.Text = If(dr.Item("nationality") Is DBNull.Value, String.Empty, dr.Item("nationality"))
                    EmployeeForm.DateOfBirthDateTimePicker.Text = If(dr.Item("date_of_birth") Is DBNull.Value, Date.Now, CDate(dr.Item("date_of_birth")))
                    EmployeeForm.MaritalStatusComboBox.Text = If(dr.Item("marital_status") Is DBNull.Value, String.Empty, dr.Item("marital_status"))
                    EmployeeForm.BloodGroupComboBox.Text = If(dr.Item("blood_group") Is DBNull.Value, String.Empty, dr.Item("blood_group"))
                    EmployeeForm.GenderComboBox.Text = If(dr.Item("gender") Is DBNull.Value, String.Empty, dr.Item("gender"))
                    EmployeeForm.ReligionComboBox.Text = If(dr.Item("religion") Is DBNull.Value, String.Empty, dr.Item("religion"))
                    EmployeeForm.SurburbTextBox.Text = If(dr.Item("surburb") Is DBNull.Value, String.Empty, dr.Item("surburb"))
                    EmployeeForm.NationalIDTextBox.Text = If(dr.Item("national_id") Is DBNull.Value, String.Empty, dr.Item("national_id"))
                    EmployeeForm.DriversIDTextBox.Text = If(dr.Item("driver_id") Is DBNull.Value, String.Empty, dr.Item("driver_id"))
                    EmployeeForm.NumberOfKidsTextBox.Text = If(dr.Item("number_of_kids") Is DBNull.Value, String.Empty, dr.Item("number_of_kids"))
                    EmployeeForm.NextOfKinTextBox.Text = If(dr.Item("next_of_kin") Is DBNull.Value, String.Empty, dr.Item("next_of_kin"))
                    EmployeeForm.TelNextOfKinTextBox.Text = If(dr.Item("tel_of_next_of_kin") Is DBNull.Value, String.Empty, dr.Item("tel_of_next_of_kin"))

                    EmployeeForm.cityTextBox.Text = If(dr.Item("city") Is DBNull.Value, String.Empty, dr.Item("city"))
                    EmployeeForm.StateProvinceTextBox.Text = If(dr.Item("state_or_province") Is DBNull.Value, String.Empty, dr.Item("state_or_province"))
                    EmployeeForm.ZipCodeTextBox.Text = If(dr.Item("zip_or_postal_code") Is DBNull.Value, String.Empty, dr.Item("zip_or_postal_code"))
                    EmployeeForm.CountryTextBox.Text = If(dr.Item("country") Is DBNull.Value, String.Empty, dr.Item("country"))
                    EmployeeForm.MobileTextBox.Text = If(dr.Item("mobile") Is DBNull.Value, String.Empty, dr.Item("mobile"))
                    EmployeeForm.HomeTelTextBox.Text = If(dr.Item("home_telephone") Is DBNull.Value, String.Empty, dr.Item("home_telephone"))
                    EmployeeForm.Address1TextBox.Text = If(dr.Item("address_1") Is DBNull.Value, String.Empty, dr.Item("address_1"))
                    EmployeeForm.Address2TextBox.Text = If(dr.Item("address_2") Is DBNull.Value, String.Empty, dr.Item("address_2"))
                    EmployeeForm.WorkNumberTextBox.Text = If(dr.Item("work_number") Is DBNull.Value, String.Empty, dr.Item("work_number"))
                    EmployeeForm.WorkEmailTextBox.Text = If(dr.Item("work_email") Is DBNull.Value, String.Empty, dr.Item("work_email"))
                    EmployeeForm.OtherEmailTextBox.Text = If(dr.Item("other_email") Is DBNull.Value, String.Empty, dr.Item("other_email"))
                    EmployeeForm.HouseNumberTextBox.Text = If(dr.Item("house_number") Is DBNull.Value, String.Empty, dr.Item("house_number"))
                    EmployeeForm.LastPlaceOfWorkTextBox.Text = If(dr.Item("last_place_of_work") Is DBNull.Value, String.Empty, dr.Item("last_place_of_work"))

                    EmployeeForm.HighestDegreeComboBox.Text = If(dr.Item("highest_qualification") Is DBNull.Value, String.Empty, dr.Item("highest_qualification"))
                    EmployeeForm.YearOfQualTextBox.Text = If(dr.Item("year_of_qualification") Is DBNull.Value, String.Empty, dr.Item("year_of_qualification"))
                    EmployeeForm.InstitutionTextBox.Text = If(dr.Item("institution_of_qualification") Is DBNull.Value, String.Empty, dr.Item("institution_of_qualification"))

                    EmployeeForm.TINTextBox.Text = If(dr.Item("tin_number") Is DBNull.Value, String.Empty, dr.Item("tin_number"))
                    EmployeeForm.SSNITTextBox.Text = If(dr.Item("ssnit_number") Is DBNull.Value, String.Empty, dr.Item("ssnit_number"))
                    EmployeeForm.IncomeTaxTextBox.Text = If(dr.Item("income_tax_number") Is DBNull.Value, String.Empty, dr.Item("income_tax_number"))

                    EmployeeForm.StaffIDTextBox.Text = If(dr.Item("staff_number") Is DBNull.Value, String.Empty, dr.Item("staff_number"))
                    EmployeeForm.PositionTextBox.Text = If(dr.Item("position") Is DBNull.Value, String.Empty, dr.Item("position"))
                    EmployeeForm.DateEmployedDateTimePicker.Text = If(dr.Item("date_employed") Is DBNull.Value, Date.Now, CDate(dr.Item("date_employed")))
                    EmployeeForm.DateResignedDateTimePicker.Text = If(dr.Item("date_resigned") Is DBNull.Value, Date.Now, CDate(dr.Item("date_resigned")))
                    EmployeeForm.ConfirmDateDateTimePicker.Text = If(dr.Item("date_of_confirmation") Is DBNull.Value, Date.Now, CDate(dr.Item("date_of_confirmation")))
                    EmployeeForm.ContractValidDateTimePicker.Text = If(dr.Item("contract_validity") Is DBNull.Value, Date.Now, CDate(dr.Item("contract_validity")))
                    EmployeeForm.BranchComboBox.Text = If(dr.Item("branch") Is DBNull.Value, String.Empty, dr.Item("branch"))
                    EmployeeForm.DepartmentComboBox.Text = If(dr.Item("department") Is DBNull.Value, String.Empty, dr.Item("department"))
                    EmployeeForm.CategoryComboBox.Text = If(dr.Item("category") Is DBNull.Value, String.Empty, dr.Item("category"))
                    EmployeeForm.GroupComboBox.Text = If(dr.Item("group") Is DBNull.Value, String.Empty, dr.Item("group"))
                    EmployeeForm.EmployTypeComboBox.Text = If(dr.Item("employment_type") Is DBNull.Value, String.Empty, dr.Item("employment_type"))
                    EmployeeForm.AppointmentLetterTextBox.Text = If(dr.Item("appointment_letter") Is DBNull.Value, String.Empty, dr.Item("appointment_letter"))

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

    Private Function addEmployeeSalary(ByVal staff_id As String, ByVal salary As Double)
        Try
            setEmployeeID(staff_id)
            Dim query As String = "UPDATE tbl_payroll SET basic_salary =? WHERE e_id ='" & getEmployeeID() & "'"
            Dim x As Integer = runQuery(query)
            Return x
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

    Private Function addUsernameAndPassword(ByVal user_type As String, ByVal username As String, ByVal password As String)
        Try
            Dim query As String = "INSERT INTO tbl_user_login(usertype,username,passw) VALUES('" & user_type & "','" & username & "','" & password & "')"
            Dim x As Integer = runQuery(query)
            Return x
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

    Public Sub createUserLogin(ByVal user_type As String, ByVal username As String, ByVal password As String)
        Try
            If addUsernameAndPassword(user_type, username, password) > 0 Then
                MsgBox("User SUCCESSFULLY created!")
            Else
                MsgBox("User COULDN'T be created!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub runAddEmployeeDetails(ByVal fname As String, ByVal lname As String, ByVal staff_id As String)
        'Dim w As Integer = addEmployeeDetails(fname, lname, staff_id, "753951741852", "852963741789")
        Dim w As Integer = 0
        If w > 0 Then
            setEmployeeID(staff_id)
            Dim x As Integer = runQuery("INSERT INTO tbl_leave_management(id,e_id) VALUES(NULL,'" & getEmployeeID() & "')")
            If x > 0 Then
                Dim y As Integer = runQuery("INSERT INTO tbl_payroll(id,e_id) VALUES(NULL,'" & getEmployeeID() & "')")
                If y > 0 Then
                    Dim z As Integer = runQuery("INSERT INTO tbl_contributions(id,e_id) VALUES(NULL,'" & getEmployeeID() & "')")
                    If z > 0 Then
                        MsgBox("Data SUCCESSFULLY added!")
                        Dim username As String = generateUserName(fname, lname)
                        'Dim password As String = generatePassword(6)
                        Dim k As Integer = addUsernameAndPassword("user", username, "1234")
                        If k > 0 Then
                            MsgBox("User LOGIN DETAILS Created!")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub userLogin(ByVal username As String, ByVal password As String)
        Try
            If "PHARMS".CompareTo(username) = 0 And "PHARMS".CompareTo(password) = 0 Then
                'redirect to registrator new company
                Exit Sub
            End If

            Dim query As String = "SELECT `user_type`,username FROM tbl_user_login WHERE username='" & username & "' AND passw='" & password & "'"

            conn.Open()
            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                If dr.Read Then
                    USER_LOGIN = True
                    USER_TYPE = dr.GetString("usertype")
                    If "user".CompareTo(USER_TYPE) = 0 Then
                        MsgBox("OLA")
                        Exit Sub
                    ElseIf "admin".CompareTo(USER_TYPE) = 0 Then
                        'redirect to admin page
                        Exit Sub
                    Else
                        MsgBox("Invalid username or password!")
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Invalid username or passowrd!")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
