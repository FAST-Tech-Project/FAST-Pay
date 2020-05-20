Public Class EmployeeSetupForm
    Private Sub EmployeeSetupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub departmentsButton_Click(sender As Object, e As EventArgs) Handles departmentsButton.Click
        departmentsButton.FlatStyle = FlatStyle.Flat
        departmentSelectedPanel.BackColor = Control.DefaultBackColor
        displayPanel.BackColor = Control.DefaultBackColor

        categoriesButton.FlatStyle = FlatStyle.Standard
        categoriesSelectedPanel.BackColor = Color.White

        groupsButton.FlatStyle = FlatStyle.Standard
        groupsSelectedPanel.BackColor = Color.White

        BranchesButton.FlatStyle = FlatStyle.Standard
        branchesSelectedPanel.BackColor = Color.White

        LoadDataIntoDatagrid(displayDataGridView, "SELECT * FROM `tbl_department`")
        displayDataGridView.Columns(0).Visible = False
        displayDataGridView.Columns(1).HeaderText = "DEPARTMENTS"
        displayDataGridView.Columns(1).Width = 157

        clickedButtonCheckTextBox.Text = 1
        Panel2.Visible = True

    End Sub

    Private Sub categoriesButton_Click(sender As Object, e As EventArgs) Handles categoriesButton.Click
        categoriesButton.FlatStyle = FlatStyle.Flat
        categoriesSelectedPanel.BackColor = Control.DefaultBackColor
        displayPanel.BackColor = Control.DefaultBackColor

        departmentsButton.FlatStyle = FlatStyle.Standard
        departmentSelectedPanel.BackColor = Color.White

        groupsButton.FlatStyle = FlatStyle.Standard
        groupsSelectedPanel.BackColor = Color.White

        BranchesButton.FlatStyle = FlatStyle.Standard
        branchesSelectedPanel.BackColor = Color.White

        LoadDataIntoDatagrid(displayDataGridView, "SELECT * FROM `tbl_category`")
        displayDataGridView.Columns(0).Visible = False
        displayDataGridView.Columns(1).HeaderText = "CATEGORIES"
        displayDataGridView.Columns(1).Width = 157

        clickedButtonCheckTextBox.Text = 2
        Panel2.Visible = True

    End Sub

    Private Sub groupsButton_Click(sender As Object, e As EventArgs) Handles groupsButton.Click
        groupsButton.FlatStyle = FlatStyle.Flat
        groupsSelectedPanel.BackColor = Control.DefaultBackColor
        displayPanel.BackColor = Control.DefaultBackColor

        categoriesButton.FlatStyle = FlatStyle.Standard
        categoriesSelectedPanel.BackColor = Color.White

        departmentsButton.FlatStyle = FlatStyle.Standard
        departmentSelectedPanel.BackColor = Color.White

        BranchesButton.FlatStyle = FlatStyle.Standard
        branchesSelectedPanel.BackColor = Color.White

        LoadDataIntoDatagrid(displayDataGridView, "SELECT `id`, `name` FROM `tbl_group`")
        displayDataGridView.Columns(0).Visible = False
        displayDataGridView.Columns(1).HeaderText = "GROUPS"
        displayDataGridView.Columns(1).Width = 157

        clickedButtonCheckTextBox.Text = 3
        Panel2.Visible = True

    End Sub

    Private Sub BranchesButton_Click(sender As Object, e As EventArgs) Handles BranchesButton.Click
        BranchesButton.FlatStyle = FlatStyle.Flat
        branchesSelectedPanel.BackColor = Control.DefaultBackColor
        displayPanel.BackColor = Control.DefaultBackColor

        categoriesButton.FlatStyle = FlatStyle.Standard
        categoriesSelectedPanel.BackColor = Color.White

        departmentsButton.FlatStyle = FlatStyle.Standard
        departmentSelectedPanel.BackColor = Color.White

        groupsButton.FlatStyle = FlatStyle.Standard
        groupsSelectedPanel.BackColor = Color.White

        LoadDataIntoDatagrid(displayDataGridView, "SELECT `id`, `name` FROM `tbl_branch`")
        displayDataGridView.Columns(0).Visible = False
        displayDataGridView.Columns(1).HeaderText = "BRANCHES"
        displayDataGridView.Columns(1).Width = 157

        clickedButtonCheckTextBox.Text = 4
        Panel2.Visible = True
    End Sub

    Private Sub displayDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles displayDataGridView.CellContentClick

    End Sub

    Private Sub displayDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles displayDataGridView.CellClick
        If e.RowIndex >= 0 And e.RowIndex < displayDataGridView.RowCount - 1 Then
            selectedDatagridIDTextBox.Text = e.RowIndex
            currentNameTextBox.Text = displayDataGridView.Rows(e.RowIndex).Cells(1).Value

            If clickedButtonCheckTextBox.Text = "1" Then
                categoriesButton.Enabled = False
                groupsButton.Enabled = False
                BranchesButton.Enabled = False
                Label1.Text = "Current Name :"
                Label2.Text = "New Name :"

            ElseIf clickedButtonCheckTextBox.Text = "2" Then
                departmentsButton.Enabled = False
                groupsButton.Enabled = False
                BranchesButton.Enabled = False
                Label1.Text = "Current Name :"
                Label2.Text = "New Name :"

            ElseIf clickedButtonCheckTextBox.Text = "3" Then
                categoriesButton.Enabled = False
                departmentsButton.Enabled = False
                BranchesButton.Enabled = False
                Label1.Text = "Current Name :"
                Label2.Text = "New Name :"
                Label1.Visible = True
                categoryComboBox.Visible = True
                categoryComboBox.Location = New Point(223, 21)
                categoryComboBox.Text = runQueryAndReturnValue("SELECT c.`name` FROM `tbl_category` AS c, `tbl_group` AS g 
                                                                WHERE g.`catId` = c.`id` AND g.`name` = '" & currentNameTextBox.Text & "'", "name")

            ElseIf clickedButtonCheckTextBox.Text = "4" Then
                departmentsButton.Enabled = False
                groupsButton.Enabled = False
                categoriesButton.Enabled = False
                Label1.Text = "Current Name :"
                Label2.Text = "New Name :"
            End If

            cancelEmpSetupButton.Visible = True
            saveEmpSetupButton.Visible = True
            Label1.Visible = True
            Label2.Visible = True
            currentNameTextBox.Visible = True
            newNameTextBox.Visible = True
            AddNewEmpSetupButton.Visible = True
            Me.Width = Me.MaximumSize.Width
        End If
    End Sub

    Private Sub AddNewEmpSetupButton_Click(sender As Object, e As EventArgs) Handles AddNewEmpSetupButton.Click

        If clickedButtonCheckTextBox.Text = "1" Then
            categoriesButton.Enabled = False
            groupsButton.Enabled = False
            BranchesButton.Enabled = False
            Label2.Text = "Department Name :"

        ElseIf clickedButtonCheckTextBox.Text = "2" Then
            departmentsButton.Enabled = False
            groupsButton.Enabled = False
            BranchesButton.Enabled = False
            Label2.Text = "Category Name :"

        ElseIf clickedButtonCheckTextBox.Text = "3" Then
            categoriesButton.Enabled = False
            departmentsButton.Enabled = False
            BranchesButton.Enabled = False
            Label1.Text = "Under :"
            Label2.Text = "Group Name :"
            Label1.Visible = True
            categoryComboBox.Location = New Point(223, 63)
            categoryComboBox.Visible = True

        ElseIf clickedButtonCheckTextBox.Text = "4" Then
            departmentsButton.Enabled = False
            groupsButton.Enabled = False
            categoriesButton.Enabled = False
            Label2.Text = "Branch Name :"
        End If

        cancelEmpSetupButton.Visible = True
        saveEmpSetupButton.Visible = True
        Label2.Visible = True
        newNameTextBox.Visible = True
        AddNewEmpSetupButton.Visible = False
        Me.Width = Me.MaximumSize.Width
    End Sub

    Private Sub cancelEmpSetupButton_Click(sender As Object, e As EventArgs) Handles cancelEmpSetupButton.Click
        Me.Width = Me.MinimumSize.Width
        cancelEmpSetupButton.Visible = False
        saveEmpSetupButton.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        currentNameTextBox.Visible = False
        newNameTextBox.Visible = False
        categoryComboBox.Visible = False
        selectedDatagridIDTextBox.Text = ""
        selectedCategoryIDTextBox.Text = ""
        AddNewEmpSetupButton.Visible = True
        departmentsButton.Enabled = True
        categoriesButton.Enabled = True
        groupsButton.Enabled = True
        BranchesButton.Enabled = True
    End Sub

    Private Sub saveEmpSetupButton_Click(sender As Object, e As EventArgs) Handles saveEmpSetupButton.Click

        If selectedDatagridIDTextBox.Text = "" And Not String.IsNullOrEmpty(newNameTextBox.Text) Then
            If clickedButtonCheckTextBox.Text = "1" Then
                If runQuery("INSERT INTO `tbl_department`(`name`) VALUES('" & newNameTextBox.Text & "')") = 1 Then
                    MsgBox("New department added successfully.")
                    LoadDataIntoDatagrid(displayDataGridView, "SELECT * FROM `tbl_department`")
                    displayDataGridView.Columns(0).Visible = False
                    displayDataGridView.Columns(1).HeaderText = "DEPARTMENTS"
                    displayDataGridView.Columns(1).Width = 157
                End If

            ElseIf clickedButtonCheckTextBox.Text = "2" Then
                If runQuery("INSERT INTO `tbl_category`(`name`) VALUES('" & newNameTextBox.Text & "')") = 1 Then
                    MsgBox("New category added successfully.")
                    LoadDataIntoDatagrid(displayDataGridView, "SELECT * FROM `tbl_category`")
                    displayDataGridView.Columns(0).Visible = False
                    displayDataGridView.Columns(1).HeaderText = "CATEGORIES"
                    displayDataGridView.Columns(1).Width = 157
                End If

            ElseIf clickedButtonCheckTextBox.Text = "3" Then
                If Not String.IsNullOrEmpty(selectedCategoryIDTextBox.Text) Then
                    If runQuery("INSERT INTO `tbl_group`(`catId`,`name`) VALUES('" & selectedCategoryIDTextBox.Text & "','" & newNameTextBox.Text & "')") = 1 Then
                        MsgBox("New group added successfully.")
                        LoadDataIntoDatagrid(displayDataGridView, "SELECT `id`, `name` FROM `tbl_group`")
                        displayDataGridView.Columns(0).Visible = False
                        displayDataGridView.Columns(1).HeaderText = "GROUPS"
                        displayDataGridView.Columns(1).Width = 157
                    End If
                End If

            ElseIf clickedButtonCheckTextBox.Text = "4" Then
                If runQuery("INSERT INTO `tbl_branch`(`name`) VALUES('" & newNameTextBox.Text & "')") = 1 Then
                    MsgBox("New branch added successfully.")
                    LoadDataIntoDatagrid(displayDataGridView, "SELECT * FROM `tbl_branch`")
                    displayDataGridView.Columns(0).Visible = False
                    displayDataGridView.Columns(1).HeaderText = "BRANCHES"
                    displayDataGridView.Columns(1).Width = 157
                End If
            End If
        End If
    End Sub

    Private Sub categoryComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles categoryComboBox.SelectedIndexChanged
        selectedCategoryIDTextBox.Text = categoryComboBox.SelectedValue.ToString
    End Sub

    Private Sub categoryComboBox_Click(sender As Object, e As EventArgs) Handles categoryComboBox.Click
        FetchComboData(categoryComboBox, "SELECT * FROM `tbl_category`", "name")
    End Sub
End Class