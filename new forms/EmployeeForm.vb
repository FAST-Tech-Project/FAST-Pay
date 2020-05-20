Public Class EmployeeForm
    Private Sub EmployeeForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        PayrollForm.Show()
    End Sub

    Private Sub EmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        LoadDataIntoDatagrid(EmpDataGridView, "SELECT `id`, `staff_number` AS 'STAFF NUMBER', CONCAT(`surname`, ' ', `first_name`) AS 'NAME' FROM `tbl_employee`")

        EmpDataGridView.Columns(0).Visible = False
        EmpDataGridView.Columns(1).Width = 70
        EmpDataGridView.Columns(2).Width = 148
    End Sub

    Private Sub EmpDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles EmpDataGridView.CellClick

        If e.RowIndex >= 0 And e.RowIndex < EmpDataGridView.RowCount - 1 Then
            empIDTextBox.Text = EmpDataGridView.Rows(e.RowIndex).Cells("id").Value
            setEmployeeDetails(EmpDataGridView.Rows(e.RowIndex).Cells("id").Value)
        End If

    End Sub

    Private Sub addEmployeeButton_Click(sender As Object, e As EventArgs) Handles addEmployeeButton.Click
        listOfEmployeesPanel.Hide()
        employeesDetailsPanel.Show()
    End Sub

    Private Sub saveEmployeeDetailsButton_Click(sender As Object, e As EventArgs) Handles saveEmployeeDetailsButton.Click
        If empIDTextBox.Text <> "" Then
            'update employee details
            Dim query As String = "UPDATE `tbl_employee` Set " _
            + " `title` ='" & TitleComboBox.Text & "', `surname` ='" & SurnameTextBox.Text &
            "', `first_name` ='" & FirstNameTextBox.Text & "', `middle_name` ='" & MiddleNameTextBox.Text &
            "', `date_of_birth` ='" & DateOfBirthDateTimePicker.Text & "', `nationality` ='" & NationalityTextBox.Text &
            "', `marital_status` ='" & MaritalStatusComboBox.Text & "', `blood_group` ='" & BloodGroupComboBox.Text &
            "', `gender` ='" & GenderComboBox.Text & "', `religion` ='" & ReligionComboBox.Text &
            "', `surburb` ='" & SurburbTextBox.Text & "', `national_id` ='" & NationalIDTextBox.Text &
            "', `driver_id` ='" & DriversIDTextBox.Text & "', `number_of_kids` ='" & NumberOfKidsTextBox.Text &
            "', `next_of_kin` ='" & NextOfKinTextBox.Text & "', `tel_of_next_of_kin` ='" & TelNextOfKinTextBox.Text &
            "', `city` ='" & cityTextBox.Text & "', `state_or_province` ='" & StateProvinceTextBox.Text &
            "', `zip_or_postal_code` ='" & ZipCodeTextBox.Text & "', `house_number` ='" & HouseNumberTextBox.Text &
            "', `country` ='" & CountryTextBox.Text & "', `home_telephone` ='" & HomeTelTextBox.Text &
            "', `mobile` ='" & MobileTextBox.Text & "', `work_number` ='" & WorkNumberTextBox.Text &
            "', `work_email` ='" & WorkEmailTextBox.Text & "', `other_email` ='" & OtherEmailTextBox.Text &
            "', `address_1` ='" & Address1TextBox.Text & "', `address_2` ='" & Address2TextBox.Text &
            "', `highest_qualification` ='" & HighestDegreeComboBox.Text & "', `year_of_qualification` ='" & YearOfQualTextBox.Text &
            "', `institution_of_qualification` ='" & InstitutionTextBox.Text & "', `ssnit_number` ='" & SSNITTextBox.Text &
            "', `tin_number` ='" & TINTextBox.Text & "', `income_tax_number` ='" & IncomeTaxTextBox.Text &
            "', `staff_number` ='" & StaffIDTextBox.Text & "', `position` ='" & PositionTextBox.Text &
            "', `branch` ='" & BranchComboBox.Text & "', `department` ='" & DepartmentComboBox.Text &
            "', `category` ='" & CategoryComboBox.Text & "', `group` ='" & GroupComboBox.Text &
            "', `employment_type` ='" & EmployTypeComboBox.Text & "', `appointment_letter` ='" & AppointmentLetterTextBox.Text &
            "', `last_place_of_work` ='" & LastPlaceOfWorkTextBox.Text & "', `date_employed` ='" & DateEmployedDateTimePicker.Text &
            "', `date_resigned` ='" & DateResignedDateTimePicker.Text & "', `date_of_confirmation` ='" & ConfirmDateDateTimePicker.Text &
            "', `contract_validity` ='" & ContractValidDateTimePicker.Text & "', `updated_at` = CURRENT_TIMESTAMP 
            WHERE `id` ='" & empIDTextBox.Text & "'"

            If runQuery(query) = 1 Then
                MsgBox("Information updated successfully!")
                LoadDataIntoDatagrid(EmpDataGridView, "SELECT `id`, `staff_number` AS 'STAFF NUMBER', CONCAT(`surname`, ' ', `first_name`) AS 'NAME' FROM `tbl_employee`")

                EmpDataGridView.Columns(0).Visible = False
                EmpDataGridView.Columns(1).Width = 70
                EmpDataGridView.Columns(2).Width = 148
            End If
        Else
            'save new employee details
            Dim query As String = "INSERT INTO `tbl_employee` (`title`, `surname`, `first_name`, `middle_name`, 
                                    `date_of_birth`, `nationality`, `marital_status`, `blood_group`, `gender`, `religion`, 
                                    `surburb`, `national_id`, `driver_id`, `number_of_kids`, `next_of_kin`, `tel_of_next_of_kin`, 
                                    `city`, `state_or_province`, `zip_or_postal_code`, `house_number`, `country`, `home_telephone`, 
                                    `mobile`, `work_number`, `work_email`, `other_email`, `address_1`, `address_2`, 
                                    `highest_qualification`, `year_of_qualification`, `institution_of_qualification`, 
                                    `ssnit_number`, `tin_number`, `income_tax_number`, `staff_number`, `position`, `branch`, `department`, 
                                    `category`, `group`, `employment_type`, `appointment_letter`, `last_place_of_work`, 
                                    `date_employed`, `date_resigned`, `date_of_confirmation`, `contract_validity`, `added_at`) 
                                    VALUES ('" & TitleComboBox.Text & "', '" & SurnameTextBox.Text & "', '" & FirstNameTextBox.Text &
                                            "', '" & MiddleNameTextBox.Text & "', '" & DateOfBirthDateTimePicker.Text & "', 
                                            '" & NationalityTextBox.Text & "', '" & MaritalStatusComboBox.Text & "', 
                                            '" & BloodGroupComboBox.Text & "', '" & GenderComboBox.Text & "', 
                                            '" & ReligionComboBox.Text & "', '" & SurburbTextBox.Text & "', 
                                            '" & NationalIDTextBox.Text & "', '" & DriversIDTextBox.Text & "', 
                                            '" & NumberOfKidsTextBox.Text & "', '" & NextOfKinTextBox.Text & "', 
                                            '" & TelNextOfKinTextBox.Text & "', '" & cityTextBox.Text & "', 
                                            '" & StateProvinceTextBox.Text & "', '" & ZipCodeTextBox.Text & "', 
                                            '" & HouseNumberTextBox.Text & "', '" & CountryTextBox.Text & "', 
                                            '" & HomeTelTextBox.Text & "', '" & MobileTextBox.Text & "', 
                                            '" & WorkNumberTextBox.Text & "', '" & WorkEmailTextBox.Text & "', 
                                            '" & OtherEmailTextBox.Text & "', '" & Address1TextBox.Text & "', 
                                            '" & Address2TextBox.Text & "', '" & HighestDegreeComboBox.Text & "', 
                                            '" & YearOfQualTextBox.Text & "', '" & InstitutionTextBox.Text & "', 
                                            '" & SSNITTextBox.Text & "', '" & TINTextBox.Text & "', 
                                            '" & IncomeTaxTextBox.Text & "', '" & StaffIDTextBox.Text & "', 
                                            '" & PositionTextBox.Text & "', '" & BranchComboBox.Text & "', 
                                            '" & DepartmentComboBox.Text & "', '" & CategoryComboBox.Text & "', 
                                            '" & GroupComboBox.Text & "', '" & EmployTypeComboBox.Text & "', 
                                            '" & AppointmentLetterTextBox.Text & "', '" & LastPlaceOfWorkTextBox.Text & "', 
                                            '" & DateEmployedDateTimePicker.Text & "', '" & DateResignedDateTimePicker.Text & "', 
                                            '" & ConfirmDateDateTimePicker.Text & "', '" & ContractValidDateTimePicker.Text & "', CURRENT_TIMESTAMP)"

            If runQuery(query) = 1 Then
                MsgBox("Information added successfully!")
                clearData()
                LoadDataIntoDatagrid(EmpDataGridView, "SELECT `id`, `staff_number` AS 'STAFF NUMBER', CONCAT(`surname`, ' ', `first_name`) AS 'NAME' FROM `tbl_employee`")

                EmpDataGridView.Columns(0).Visible = False
                EmpDataGridView.Columns(1).Width = 70
                EmpDataGridView.Columns(2).Width = 148
            End If
        End If
    End Sub

    Private Sub cancelEditEmployeeDetailsButton_Click(sender As Object, e As EventArgs) Handles cancelEditEmployeeDetailsButton.Click
        clearData()
    End Sub

    Private Sub employeeSetupButton_Click(sender As Object, e As EventArgs) Handles employeeSetupButton.Click
        EmployeeSetupForm.Show()
    End Sub

    Private Sub BranchComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BranchComboBox.SelectedIndexChanged
        branchIDTextBox.Text = BranchComboBox.SelectedValue.ToString
    End Sub

    Private Sub BranchComboBox_Click(sender As Object, e As EventArgs) Handles BranchComboBox.Click
        FetchComboData(BranchComboBox, "SELECT * FROM `tbl_branch`", "name")
        BranchComboBox.Text = ""
    End Sub

    Private Sub DepartmentComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DepartmentComboBox.SelectedIndexChanged
        departIDTextBox.Text = DepartmentComboBox.SelectedValue.ToString
    End Sub

    Private Sub DepartmentComboBox_Click(sender As Object, e As EventArgs) Handles DepartmentComboBox.Click
        FetchComboData(DepartmentComboBox, "SELECT * FROM `tbl_department`", "name")
        DepartmentComboBox.Text = ""
    End Sub

    Private Sub CategoryComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CategoryComboBox.SelectedIndexChanged
        catIDTextBox.Text = CategoryComboBox.SelectedValue.ToString
    End Sub

    Private Sub CategoryComboBox_Click(sender As Object, e As EventArgs) Handles CategoryComboBox.Click
        FetchComboData(CategoryComboBox, "SELECT * FROM `tbl_category`", "name")
        CategoryComboBox.Text = ""
    End Sub

    Private Sub GroupComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GroupComboBox.SelectedIndexChanged
        groupIDTextBox.Text = GroupComboBox.SelectedValue.ToString
    End Sub

    Private Sub GroupComboBox_Click(sender As Object, e As EventArgs) Handles GroupComboBox.Click
        FetchComboData(GroupComboBox, "SELECT * FROM `tbl_group` WHERE `catId` = '" & catIDTextBox.Text & "'", "name")
        GroupComboBox.Text = ""
    End Sub

    Private Sub clearData()
        empIDTextBox.Text = ""
        TitleComboBox.Text = ""
        SurnameTextBox.Text = ""
        FirstNameTextBox.Text = ""
        MiddleNameTextBox.Text = ""
        DateOfBirthDateTimePicker.Text = Date.MaxValue
        NationalityTextBox.Text = ""
        MaritalStatusComboBox.Text = ""
        BloodGroupComboBox.Text = ""
        GenderComboBox.Text = ""
        ReligionComboBox.Text = ""
        SurburbTextBox.Text = ""
        NationalIDTextBox.Text = ""
        DriversIDTextBox.Text = ""
        NumberOfKidsTextBox.Text = "0"
        NextOfKinTextBox.Text = ""
        TelNextOfKinTextBox.Text = ""
        cityTextBox.Text = ""
        StateProvinceTextBox.Text = ""
        ZipCodeTextBox.Text = ""
        HouseNumberTextBox.Text = ""
        CountryTextBox.Text = ""
        HomeTelTextBox.Text = ""
        MobileTextBox.Text = ""
        WorkNumberTextBox.Text = ""
        WorkEmailTextBox.Text = ""
        OtherEmailTextBox.Text = ""
        Address1TextBox.Text = ""
        Address2TextBox.Text = ""
        HighestDegreeComboBox.Text = ""
        YearOfQualTextBox.Text = "0"
        InstitutionTextBox.Text = ""
        SSNITTextBox.Text = ""
        TINTextBox.Text = ""
        IncomeTaxTextBox.Text = ""
        StaffIDTextBox.Text = ""
        PositionTextBox.Text = ""
        BranchComboBox.Text = ""
        DepartmentComboBox.Text = ""
        CategoryComboBox.Text = ""
        GroupComboBox.Text = ""
        EmployTypeComboBox.Text = ""
        AppointmentLetterTextBox.Text = ""
        LastPlaceOfWorkTextBox.Text = ""
        DateEmployedDateTimePicker.Text = Date.Now
        DateResignedDateTimePicker.Text = Date.Now
        ConfirmDateDateTimePicker.Text = Date.Now
        ContractValidDateTimePicker.Text = Date.Now
    End Sub

End Class