Imports MySql.Data.MySqlClient

Public Class PayHeadCreationForm
    Dim seconds As Integer = 0

    Private Sub PayHeadCreationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PayHeadCreationForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        PayrollForm.Show()
    End Sub

    Private Sub ViewFormulaButton_Click(sender As Object, e As EventArgs) Handles ViewFormulaButton.Click
        FormulaForm.Show()
    End Sub

    Private Sub computeTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles computeTypeComboBox.SelectedIndexChanged
        If computeTypeComboBox.SelectedItem = "On Specified Formula" Then
            specifiedFormulaPanel.Show()
        Else
            specifiedFormulaPanel.Hide()
        End If
    End Sub

    ' When name of pay head is entered, this will cause it to appear in the name to appear on pay slip textbox
    Private Sub payHeadNameTextBox_LostFocus(sender As Object, e As EventArgs) Handles payHeadNameTextBox.LostFocus
        nameToAppearTextBox.Text = payHeadNameTextBox.Text
    End Sub

    Private Sub payHeadTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles payHeadTypeComboBox.SelectedIndexChanged
        selectedPayHeadTypeIDTextBox.Text = payHeadTypeComboBox.SelectedValue.ToString
        If selectedPayHeadTypeIDTextBox.Text <> "System.Data.DataRowView" And selectedPayHeadTypeIDTextBox.Text <> "" Then
            payTypePanel.Visible = True
        End If
    End Sub

    Private Sub payHeadTypeComboBox_Click(sender As Object, e As EventArgs) Handles payHeadTypeComboBox.Click
        FetchComboData(payHeadTypeComboBox, "SELECT * FROM `tbl_pay_head_type`", "name")
        payHeadTypeComboBox.Text = ""
    End Sub

    Private Sub PayTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PayTypeComboBox.SelectedIndexChanged
        If selectedPaytypeIDTextBox.Text = "Income Tax" And computeTypeComboBox.Text = "As Computed Value" Then
            If graTaxSlabDataGridView.DataSource = DBNull.Value Then
                LoadDataIntoDatagrid(graTaxSlabDataGridView, "SELECT `amt_from`, `amt_to`, `chrg_amt`, `percentage`, `amt_crh`,`free_amt` FROM `tbl_gra_refera`")
            End If
            'computationInfoDataGridView.Visible = False
            'computationInfoForUpdateDataGridView2.Visible = False
            graTaxSlabDataGridView.Visible = True
            graTaxSlabDataGridView.Location = New Point(13, 7)
            graTaxSlabDataGridView.Height = 200
        Else
            'If graTaxSlabDataGridView.DataSource = DBNull.Value Then
            LoadDataIntoDatagrid(graTaxSlabDataGridView, "SELECT `amt_from`, `amt_to`, `chrg_amt`, `percentage`, `amt_crh`,`free_amt` FROM `tbl_gra_refera`")
            'End If
        End If
    End Sub

    Private Sub PayTypeComboBox_Click(sender As Object, e As EventArgs) Handles PayTypeComboBox.Click
        If Not String.IsNullOrEmpty(selectedPayHeadTypeIDTextBox.Text) Then
            FetchComboData(PayTypeComboBox, "SELECT * FROM `tbl_pay_type` WHERE `ph_type` = '" & selectedPayHeadTypeIDTextBox.Text & "'", "name")
            PayTypeComboBox.Text = ""
        End If
    End Sub

    Private Sub calculationTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles calculationTypeComboBox.SelectedIndexChanged
        If LCase(calculationTypeComboBox.SelectedItem) = "as computed value" Then

            calcGroupPanel.Visible = True
            whatCalcTypePanel.Visible = False
            calcPeriodPanel.Visible = True
            calcBasisPanel.Visible = False
            periodOfPanel.Visible = False

            'Me.Width = Me.MaximumSize.Width

            If PayTypeComboBox.Text = "Income Tax" Then
                computationInfoDataGridView.Visible = False
                computationInfoForUpdateDataGridView2.Visible = False
                graTaxSlabDataGridView.Visible = True
                graTaxSlabDataGridView.Location = New Point(13, 7)
                graTaxSlabDataGridView.Height = 200

            Else

                If clickedDgvItemTextBox.Text <> "" Then
                    computationInfoDataGridView.Visible = False
                    graTaxSlabDataGridView.Visible = False
                    computationInfoForUpdateDataGridView2.Visible = True
                    computationInfoForUpdateDataGridView2.Location = New Point(13, 7)
                    computationInfoForUpdateDataGridView2.Height = 161

                Else
                    computationInfoForUpdateDataGridView2.Visible = False
                    graTaxSlabDataGridView.Visible = False
                    computationInfoDataGridView.Visible = True

                End If

            End If

            computeOnPanel.Visible = True
            specifiedFormulaPanel.Visible = False
            computeInfoDgvPanel.Visible = True
            CalculationPeriodComboBox.Text = "Months"

        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "as user defined value" Then

            calcGroupPanel.Visible = True
            whatCalcTypePanel.Visible = False
            calcPeriodPanel.Visible = False
            calcBasisPanel.Visible = False
            periodOfPanel.Visible = False

            'Me.Width = Me.MinimumSize.Width

            computeOnPanel.Visible = False
            specifiedFormulaPanel.Visible = False
            computeInfoDgvPanel.Visible = False

        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "flat rate" Then

            calcGroupPanel.Visible = True
            whatCalcTypePanel.Visible = False
            calcPeriodPanel.Visible = True
            calcBasisPanel.Visible = False
            periodOfPanel.Visible = False

            'Me.Width = Me.MinimumSize.Width

            computeOnPanel.Visible = False
            specifiedFormulaPanel.Visible = False
            computeInfoDgvPanel.Visible = False

        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "on attendance" Then

            calcGroupPanel.Visible = True
            whattypeLabel.Text = "Present/Leave With Pay :"
            whatCalcTypePanel.Visible = True
            calcPeriodPanel.Visible = True
            calcBasisPanel.Visible = True
            periodOfPanel.Visible = True

            'Me.Width = Me.MinimumSize.Width

            computeOnPanel.Visible = False
            specifiedFormulaPanel.Visible = False
            computeInfoDgvPanel.Visible = False

        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "on production" Then

            calcGroupPanel.Visible = True
            whattypeLabel.Text = "Production Type :"
            whatCalcTypePanel.Visible = True
            calcPeriodPanel.Visible = False
            calcBasisPanel.Visible = False
            periodOfPanel.Visible = False

            'Me.Width = Me.MinimumSize.Width

            computeOnPanel.Visible = False
            specifiedFormulaPanel.Visible = False
            computeInfoDgvPanel.Visible = False

        End If

        whatTypeComboBox.Text = "Select"
        CalculationPeriodComboBox.Text = "Select"
        calculationBasisComboBox.Text = "Select"
        computeTypeComboBox.Text = "Select"
        effectiveFromDateTimePicker.Text = Date.Now

    End Sub

    Private Sub whatTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles whatTypeComboBox.SelectedIndexChanged

    End Sub

    Private Sub whatTypeComboBox_Click(sender As Object, e As EventArgs) Handles whatTypeComboBox.Click
        whatTypeComboBox.Text = ""
        If LCase(calculationTypeComboBox.Text) = "on attendance" Then
            FetchComboData(whatTypeComboBox, "SELECT * FROM `tbl_attendance_or_production` WHERE `type` LIKE 'Attendance%' AND `name` LIKE 'Present%'", "name")
        ElseIf LCase(calculationTypeComboBox.Text) = "on production" Then
            FetchComboData(whatTypeComboBox, "SELECT * FROM `tbl_attendance_or_production` WHERE `type` = 'Production'", "name")
        End If
        whatTypeComboBox.Text = ""
    End Sub

    Private Sub SavePayHeadButton_Click(sender As Object, e As EventArgs) Handles SavePayHeadButton.Click
        If validatePayHead() = 1 Then
            Exit Sub
        End If

        Me.Enabled = False

        If clickedDgvItemTextBox.Text = "" Then
            addNewPayHead()
        Else
            updatePayHead()
        End If

        Me.Enabled = True

    End Sub

    Private Sub deletePayHeadButton_Click(sender As Object, e As EventArgs) Handles deletePayHeadButton.Click
        If Not String.IsNullOrEmpty(clickedDgvItemTextBox.Text) Then
            Me.Enabled = False
            Dim msg As String = MsgBox("Do you want to delete completely this Pay Head: " & PayHeadOldNameTextBox.Text, +vbYesNo, "Delete Pay Head")
            If msg = vbYes Then
                If deletePayHead(clickedDgvItemTextBox.Text) = 1 Then
                    MsgBox("Pay Head: " & PayHeadOldNameTextBox.Text & " was deleted successfully")
                    clearAll()
                End If
            End If
            Me.Enabled = True
        End If
    End Sub

    Private Sub clearAllDataButton_Click(sender As Object, e As EventArgs) Handles clearAllDataButton.Click
        clearAll()
    End Sub

    Private Sub computationInfoDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles computationInfoDataGridView.CellClick
        If e.RowIndex >= 0 And e.ColumnIndex = 2 Then
            slabTypeRowIndexTextBox.Text = e.RowIndex
            SelectSlabTypeForm.Show()
        End If
    End Sub

    Private Sub computationInfoForUpdateDataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles computationInfoForUpdateDataGridView2.CellClick
        If e.RowIndex >= 0 And e.ColumnIndex = 3 Then
            slabTypeRowIndexTextBox.Text = e.RowIndex
            SelectSlabTypeForm.Show()
        End If
    End Sub

    Private Sub payHeadsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles payHeadsComboBox.SelectedIndexChanged
        clickedDgvItemTextBox.Text = payHeadsComboBox.SelectedValue.ToString

        If clickedDgvItemTextBox.Text <> "System.Data.DataRowView" And clickedDgvItemTextBox.Text <> "" Then
            If setPayHeadDetails(CInt(clickedDgvItemTextBox.Text)) = 1 Then
                setPayHeadDgv(CInt(clickedDgvItemTextBox.Text))
                SavePayHeadButton.Text = "Update"
                deletePayHeadButton.Enabled = True
            End If

        Else
            clickedDgvItemTextBox.Text = ""
            payHeadsComboBox.Text = ""
        End If

    End Sub

    Private Sub payHeadsComboBox_Enter(sender As Object, e As EventArgs) Handles payHeadsComboBox.Enter
        FetchComboData(payHeadsComboBox, "SELECT `id`, `name` FROM  `tbl_pay_head`", "name")
        payHeadsComboBox.Text = "Pay Heads"
    End Sub

    Public Function validatePayHead() As Integer
        If payHeadNameTextBox.Text = "" Then
            MsgBox("This field can't be left empty!")
            payHeadNameTextBox.Focus()
            Return 1
        ElseIf PayTypeComboBox.Text = "Select" Then
            MsgBox("Some fields can't be left empty or unselected!")
            PayTypeComboBox.Focus()
            Return 1
        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "as computed value" Then
            If CalculationPeriodComboBox.Text = "Select" Or (computeTypeComboBox.Text = "on specified formula" And specifiedFormulaTextBox.Text = "") Then
                MsgBox("This field can't be left empty or unselected!")
                specifiedFormulaTextBox.Focus()
                Return 1
            End If
        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "on attendance" Then
            If CalculationPeriodComboBox.Text = "Select" Or whatTypeComboBox.Text = "Select" Or calculationBasisComboBox.Text = "Select" Or periodOfTextBox.Text = "" Then
                MsgBox("You have some unselected field! or unselected")
                Return 1
            End If
        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "on production" Then
            If whatTypeComboBox.Text = "Select" Then
                MsgBox("You have some unselected field! or unselected")
                whatTypeComboBox.Focus()
                Return 1
            End If
        End If
        Return 0
    End Function

    Private Sub clearAll()

        clickedDgvItemTextBox.Text = ""
        PayHeadOldNameTextBox.Text = ""
        OldPayHeadTypeTextBox.Text = ""

        payHeadNameTextBox.Text = ""
        selectedPayHeadTypeIDTextBox.Text = ""
        payHeadTypeComboBox.Text = "Select"
        selectedPaytypeIDTextBox.Text = ""
        PayTypeComboBox.Text = ""
        underComboBox.Text = "Select"
        taxableComboBox.Text = "Yes"
        affectsNetSalComboBox.Text = "Yes"
        nameToAppearTextBox.Text = ""
        calculationTypeComboBox.Text = "Select"
        CalculationPeriodComboBox.Text = "Select"
        whatTypeComboBox.Text = "Select"
        calculationBasisComboBox.Text = "Select"
        periodOfTextBox.Text = ""

        payTypePanel.Visible = False
        calcGroupPanel.Visible = False
        computeOnPanel.Visible = False
        computeInfoDgvPanel.Visible = False
        specifiedFormulaPanel.Visible = False

        payHeadsComboBox.Text = "Pay Heads"
        computeTypeComboBox.Text = "Select"
        specifiedFormulaTextBox.Text = "="
        effectiveFromDateTimePicker.Text = Date.Now
        computationInfoForUpdateDataGridView2.DataSource = DBNull.Value
        graTaxSlabDataGridView.DataSource = DBNull.Value
        computationInfoDataGridView.Rows.Clear()
        computationInfoForUpdateDataGridView2.Visible = False
        graTaxSlabDataGridView.Visible = False
        computationInfoDataGridView.Visible = True

        SavePayHeadButton.Text = "Save"

        FormulaForm.Close()
        payHeadNameTextBox.Focus()
    End Sub

    Private Sub addNewPayHead()
        'Add new pay heads
        Dim addedToTable As Integer = 0

        If LCase(calculationTypeComboBox.SelectedItem) = "as computed value" Then

            Dim x As Integer = runQuery("INSERT INTO `tbl_pay_head` (`name`, `pay_head_type`, `pay_type`, 
                                            `under`, `taxable`, `affect_net_salary`, `name_to_appear`, 
                                            `calculation_type`, `calculation_period`, `compute_on`, 
                                            `specified_formula`, `effective_from`, `added_at`) 
                                        VALUES ('" & payHeadNameTextBox.Text & "', 
                                                '" & payHeadTypeComboBox.Text & "', 
                                                '" & PayTypeComboBox.Text & "', 
                                                '" & underComboBox.Text & "', 
                                                '" & taxableComboBox.Text & "', 
                                                '" & affectsNetSalComboBox.Text & "',
                                                '" & nameToAppearTextBox.Text & "', 
                                                '" & calculationTypeComboBox.Text & "', 
                                                '" & CalculationPeriodComboBox.Text & "', 
                                                '" & computeTypeComboBox.Text & "',
                                                '" & specifiedFormulaTextBox.Text & "', 
                                                '" & effectiveFromDateTimePicker.Text & "', CURRENT_TIMESTAMP)")

            If x = 1 Then
                addedToTable += addComputationInfo()
            End If


        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "as user defined value" Then

            Dim x As Integer = runQuery("INSERT INTO `tbl_pay_head` 
                                        (`name`, `pay_head_type`, `pay_type`, `under`, `taxable`, `affect_net_salary`, 
                                        `name_to_appear`, `calculation_type`, `added_at`) 
                                        VALUES ('" & payHeadNameTextBox.Text & "', 
                                                '" & payHeadTypeComboBox.Text & "', 
                                                '" & PayTypeComboBox.Text & "', 
                                                '" & underComboBox.Text & "', 
                                                '" & taxableComboBox.Text & "', 
                                                '" & affectsNetSalComboBox.Text & "', 
                                                '" & nameToAppearTextBox.Text & "', 
                                                '" & calculationTypeComboBox.Text & "', CURRENT_TIMESTAMP)")

            If x = 1 Then
                addedToTable += 1
            End If

        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "flat rate" Then

            Dim x As Integer = runQuery("INSERT INTO `tbl_pay_head` 
                                        (`name`, `pay_head_type`, `pay_type`, `under`, `taxable`, `affect_net_salary`, 
                                        `name_to_appear`, `calculation_type`, `calculation_period`, `added_at`) 
                                        VALUES ('" & payHeadNameTextBox.Text & "', 
                                                '" & payHeadTypeComboBox.Text & "', 
                                                '" & PayTypeComboBox.Text & "',
                                                '" & underComboBox.Text & "', 
                                                '" & taxableComboBox.Text & "', 
                                                '" & affectsNetSalComboBox.Text & "', 
                                                '" & nameToAppearTextBox.Text & "', 
                                                '" & calculationTypeComboBox.Text & "', 
                                                '" & CalculationPeriodComboBox.Text & "', CURRENT_TIMESTAMP)")

            If x = 1 Then
                addedToTable += 1
            End If

        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "on attendance" Then

            Dim x As Integer = runQuery("INSERT INTO `tbl_pay_head` 
                                        (`name`, `pay_head_type`, `pay_type`, `under`, `taxable`, `affect_net_salary`, 
                                        `name_to_appear`, `calculation_type`, `calculation_period`, `attend_or_prod_type`, 
                                        `calculation_basis`, `period_of`, `added_at`) 
                                        VALUES ('" & payHeadNameTextBox.Text & "', 
                                                '" & payHeadTypeComboBox.Text & "', 
                                                '" & PayTypeComboBox.Text & "',
                                                '" & underComboBox.Text & "', 
                                                '" & taxableComboBox.Text & "', 
                                                '" & affectsNetSalComboBox.Text & "', 
                                                '" & nameToAppearTextBox.Text & "', 
                                                '" & calculationTypeComboBox.Text & "', 
                                                '" & CalculationPeriodComboBox.Text & "', 
                                                '" & whatTypeComboBox.Text & "', 
                                                '" & calculationBasisComboBox.Text & "',
                                                '" & periodOfTextBox.Text & "', CURRENT_TIMESTAMP)")

            If x = 1 Then
                addedToTable += 1
            End If

        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "on production" Then

            Dim x As Integer = runQuery("INSERT INTO `tbl_pay_head` (`name`, `pay_head_type`, `pay_type`, `under`, 
                                        `taxable`, `affect_net_salary`, `name_to_appear`, `calculation_type`, 
                                        `attend_or_prod_type`, `added_at`) 
                                         VALUES ('" & payHeadNameTextBox.Text & "', 
                                                '" & payHeadTypeComboBox.Text & "', 
                                                '" & PayTypeComboBox.Text & "', 
                                                '" & underComboBox.Text & "', 
                                                '" & taxableComboBox.Text & "', 
                                                '" & affectsNetSalComboBox.Text & "', 
                                                '" & nameToAppearTextBox.Text & "', 
                                                '" & calculationTypeComboBox.Text & "', 
                                                '" & whatTypeComboBox.Text & "', CURRENT_TIMESTAMP)")

            If x = 1 Then
                addedToTable += 1
            End If

        End If

        addedToTable += addPayHeadsToTables()

        MsgBox(addedToTable)

        If addedToTable = 2 Then
            MsgBox("Pay Head: " & payHeadNameTextBox.Text & " created successfully")
            addedToTable = 0
        End If

        clearAll()

    End Sub

    Private Sub updatePayHead()
        'Update/Edit pay heads

        Dim addedToTable As Integer = 0

        If LCase(calculationTypeComboBox.Text) = "as computed value" Then

            Dim x As Integer = runQuery("UPDATE `tbl_pay_head` SET 
                                        `name` = '" & payHeadNameTextBox.Text & "', 
                                        `pay_head_type` = '" & payHeadTypeComboBox.Text & "', 
                                        `pay_type` = '" & PayTypeComboBox.Text & "', 
                                        `under` = '" & underComboBox.Text & "', 
                                        `taxable` = '" & taxableComboBox.Text & "', 
                                        `affect_net_salary` = '" & affectsNetSalComboBox.Text & "', 
                                        `name_to_appear`'" & nameToAppearTextBox.Text & "', 
                                        `calculation_type` = '" & calculationTypeComboBox.Text & "', 
                                        `attend_or_prod_type` = '', 
                                        `calculation_period` = '" & CalculationPeriodComboBox.Text & "', 
                                        `calculation_basis` = '', 
                                        `period_of` = 0, 
                                        `compute_on` = '" & computeTypeComboBox.Text & "', 
                                        `specified_formula` = '" & specifiedFormulaTextBox.Text & "', 
                                        `effective_from` = '" & effectiveFromDateTimePicker.Text & "', 
                                        `updated_at` = CURRENT_TIMESTAMP 
                                        WHERE `id` = '" & clickedDgvItemTextBox.Text & "'")

            If x = 1 Then
                addedToTable += updateComputationInfo()
            End If


        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "as user defined value" Then

            Dim x As Integer = runQuery("UPDATE `tbl_pay_head` SET 
                                        `name` = '" & payHeadNameTextBox.Text & "', 
                                        `pay_head_type` = '" & payHeadTypeComboBox.Text & "', 
                                        `pay_type` = '" & PayTypeComboBox.Text & "', 
                                        `under` = '" & underComboBox.Text & "', 
                                        `taxable` = '" & taxableComboBox.Text & "', 
                                        `affect_net_salary` = '" & affectsNetSalComboBox.Text & "', 
                                        `name_to_appear` = '" & nameToAppearTextBox.Text & "', 
                                        `calculation_type` = '" & calculationTypeComboBox.Text & "',
                                        `attend_or_prod_type` = '', 
                                        `calculation_period` = '', 
                                        `calculation_basis` = '', 
                                        `period_of` = 0, 
                                        `compute_on` = '', 
                                        `specified_formula` = '', 
                                        `effective_from` = '',  
                                        `updated_at` = CURRENT_TIMESTAMP 
                                        WHERE `id` = '" & clickedDgvItemTextBox.Text & "'")

            If x = 1 Then
                addedToTable += 1
            End If

        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "flat rate" Then

            Dim x As Integer = runQuery("UPDATE `tbl_pay_head` SET 
                                        `name` = '" & payHeadNameTextBox.Text & "', 
                                        `pay_head_type` = '" & payHeadTypeComboBox.Text & "', 
                                        `pay_type` = '" & PayTypeComboBox.Text & "', 
                                        `under` = '" & underComboBox.Text & "', 
                                        `taxable` = '" & taxableComboBox.Text & "', 
                                        `affect_net_salary` = '" & affectsNetSalComboBox.Text & "', 
                                        `name_to_appear` = '" & nameToAppearTextBox.Text & "', 
                                        `calculation_type` = '" & calculationTypeComboBox.Text & "', 
                                        `attend_or_prod_type` = '', 
                                        `calculation_period` = '" & CalculationPeriodComboBox.Text & "',
                                        `calculation_basis` = '', 
                                        `period_of` = 0, 
                                        `compute_on` = '', 
                                        `specified_formula` = '', 
                                        `effective_from` = '',  
                                        `updated_at` = CURRENT_TIMESTAMP 
                                        WHERE `id` = '" & clickedDgvItemTextBox.Text & "'")

            If x = 1 Then
                addedToTable += 1
            End If

        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "on attendance" Then

            Dim x As Integer = runQuery("UPDATE `tbl_pay_head` SET 
                                        `name` = '" & payHeadNameTextBox.Text & "', 
                                        `pay_head_type` = '" & payHeadTypeComboBox.Text & "', 
                                        `pay_type` = '" & PayTypeComboBox.Text & "', 
                                        `under` = '" & underComboBox.Text & "', 
                                        `taxable` = '" & taxableComboBox.Text & "', 
                                        `affect_net_salary` = '" & affectsNetSalComboBox.Text & "', 
                                        `name_to_appear` = '" & nameToAppearTextBox.Text & "', 
                                        `calculation_type` = '" & calculationTypeComboBox.Text & "', 
                                        `attend_or_prod_type` = '" & whatTypeComboBox.Text & "', 
                                        `calculation_period` = '" & CalculationPeriodComboBox.Text & "',
                                        `calculation_basis` = '" & calculationBasisComboBox.Text & "', 
                                        `period_of` = '" & periodOfTextBox.Text & "', 
                                        `compute_on` = '', 
                                        `specified_formula` = '', 
                                        `effective_from` = '', 
                                        `updated_at` = CURRENT_TIMESTAMP 
                                        WHERE `id` = '" & clickedDgvItemTextBox.Text & "'")

            If x = 1 Then
                addedToTable += 1
            End If

        ElseIf LCase(calculationTypeComboBox.SelectedItem) = "on production" Then

            Dim x As Integer = runQuery("UPDATE `tbl_pay_head` SET 
                                        `name` = '" & payHeadNameTextBox.Text & "', 
                                        `pay_head_type` = '" & payHeadTypeComboBox.Text & "', 
                                        `pay_type` = '" & PayTypeComboBox.Text & "', 
                                        `under` = '" & underComboBox.Text & "', 
                                        `taxable` = '" & taxableComboBox.Text & "', 
                                        `affect_net_salary` = '" & affectsNetSalComboBox.Text & "', 
                                        `name_to_appear` = '" & nameToAppearTextBox.Text & "', 
                                        `calculation_type` = '" & calculationTypeComboBox.Text & "', 
                                        `attend_or_prod_type` = '" & whatTypeComboBox.Text & "', 
                                        `calculation_period` = '',
                                        `calculation_basis` = '', 
                                        `period_of` = 0, 
                                        `compute_on` = '', 
                                        `specified_formula` = '', 
                                        `effective_from` = '', 
                                        `updated_at` = CURRENT_TIMESTAMP 
                                        WHERE `id` = '" & clickedDgvItemTextBox.Text & "'")


            If x = 1 Then
                addedToTable += 1
            End If

        End If


        If OldPayHeadTypeTextBox.Text <> payHeadTypeComboBox.Text Then
            'when pay head old type and new type are different
            If removeOldPayHeadsFromTables() = 1 Then
                'Then Add pay head to their new table and applicable
                addedToTable += addPayHeadsToTables()

            End If

        End If

        If PayHeadOldNameTextBox.Text <> payHeadNameTextBox.Text Then
            'if previous pay head name is different from new one
            'Just change the name of columns where they are
            addedToTable += changePayHeadName()

        End If

        If addedToTable = 1 Or addedToTable = 4 Then
            MsgBox("Pay Head: Successfully updated pay head's details")
        End If


    End Sub

    Private Function addComputationInfo() As Integer

        Dim pay_head_id As Integer = runQueryAndReturnValue("SELECT `id` FROM `tbl_pay_head` 
                                                            WHERE `name` = '" & payHeadNameTextBox.Text & "' 
                                                            AND `name_to_appear` = '" & nameToAppearTextBox.Text & "'", "id")

        If pay_head_id > 0 Then

            Dim amtfrom As Decimal = 0
            Dim amtto As Decimal = 0
            Dim slabtype As String = ""
            Dim value As Decimal = 0
            Dim z As Integer = 0

            If PayTypeComboBox.Text <> "Income Tax" Then

                For index = 0 To computationInfoDataGridView.RowCount - 2

                    amtfrom = If(computationInfoDataGridView.Rows(index).Cells("amount_from").Value = "", 0, computationInfoDataGridView.Rows(index).Cells("amount_from").Value)
                    amtto = If(computationInfoDataGridView.Rows(index).Cells("amount_to").Value = "", 0, computationInfoDataGridView.Rows(index).Cells("amount_to").Value)
                    slabtype = computationInfoDataGridView.Rows(index).Cells("slab_type").Value
                    value = If(computationInfoDataGridView.Rows(index).Cells("value_basis").Value = "", 0, computationInfoDataGridView.Rows(index).Cells("value_basis").Value)

                    If runQuery("INSERT INTO `tbl_computation_info` (`phid`, `amount_from`, `amount_to`, `slab_type`, `value_basis`, `added_at`) 
                                    VALUES ('" & pay_head_id & "', '" & amtfrom & "', '" & amtto & "', '" & slabtype & "', '" & value & "', CURRENT_TIMESTAMP)") = 1 Then
                        z += 1
                    End If

                Next

                If z = computationInfoDataGridView.RowCount - 1 Then
                    If FormulaForm.addSpecifiedFormula(pay_head_id, computeTypeComboBox.Text) = 1 Then
                        Return 1
                    End If
                End If

            Else
                If runQuery("INSERT INTO `tbl_computation_info` (`phid`, `amount_from`, `amount_to`, `slab_type`, `value_basis`, `added_at`)  
                                VALUES ('" & pay_head_id & "', '" & amtfrom & "', '" & amtto & "', 'GRA tax slab', '" & value & "', CURRENT_TIMESTAMP)") = 1 Then
                    If FormulaForm.addSpecifiedFormula(pay_head_id, computeTypeComboBox.Text) = 1 Then
                        Return 1
                    End If
                End If

            End If

        End If

        Return 0

    End Function

    Private Function updateComputationInfo() As Integer

        Dim pay_head_id As Integer = clickedDgvItemTextBox.Text

        If CInt(pay_head_id) > 0 Then

            Dim id As Integer = 0
            Dim amtfrom As Decimal = 0
            Dim amtto As Decimal = 0
            Dim slabtype As String = ""
            Dim value As Decimal = 0
            Dim z As Integer = 0

            If PayTypeComboBox.Text <> "Income Tax" Then

                For index = 0 To computationInfoForUpdateDataGridView2.RowCount - 2

                    id = computationInfoForUpdateDataGridView2.Rows(index).Cells("id").Value
                    amtfrom = If(computationInfoForUpdateDataGridView2.Rows(index).Cells("amount_from").Value = "", 0, computationInfoForUpdateDataGridView2.Rows(index).Cells("amount_from").Value)
                    amtto = If(computationInfoForUpdateDataGridView2.Rows(index).Cells("amount_to").Value = "", 0, computationInfoForUpdateDataGridView2.Rows(index).Cells("amount_to").Value)
                    slabtype = computationInfoForUpdateDataGridView2.Rows(index).Cells("slab_type").Value
                    value = If(computationInfoForUpdateDataGridView2.Rows(index).Cells("value_basis").Value = "", 0, computationInfoForUpdateDataGridView2.Rows(index).Cells("value_basis").Value)


                    Dim phid_exist As String = runQueryAndReturnValue("SELECT `phid` FROM `tbl_computation_info`
                                                   WHERE `id` = '" & id & "'", "phid")
                    If phid_exist = "" Then
                        'Add to pay head's computation info
                        If runQuery("INSERT INTO `tbl_computation_info` (`phid`, `amount_from`, `amount_to`, `slab_type`, `value_basis`, `added_at`) 
                                VALUES ('" & pay_head_id & "', '" & amtfrom & "', '" & amtto & "', '" & slabtype & "', '" & value & "', CURRENT_TIMESTAMP") = 1 Then
                            z += 1
                        End If

                    Else
                        'Update to pay head's computation info
                        If runQuery("UPDATE `tbl_computation_info` SET  
                                    `amount_from` = '" & amtfrom & "', 
                                    `amount_to` = '" & amtto & "', 
                                    `slab_type` = '" & slabtype & "', 
                                    `value_basis` = '" & value & "', 
                                    `updated_at` = CURRENT_TIMESTAMP 
                                    WHERE `phid` = '" & pay_head_id & "' 
                                    AND `id` = '" & id & "'") = 1 Then
                            z += 1
                        End If

                    End If
                Next

            ElseIf PayTypeComboBox.Text = "Income Tax" Then
                z += 1
            End If

            If z = computationInfoDataGridView.RowCount - 1 Then
                If FormulaForm.updateSpecifiedFormula(pay_head_id, computeTypeComboBox.Text) = 1 Then
                    Return 1
                End If
            End If

        End If

        Return 0

    End Function

    Private Function addPayHeadsToTables() As Integer

        If payHeadTypeComboBox.Text = "Earnings for Employees" Then
            If runQuery("ALTER TABLE `tbl_emp_earnings` ADD COLUMN `" & payHeadNameTextBox.Text & "` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `empid`") > 0 Then
                If runQuery("ALTER TABLE `tbl_emp_applicable_earnings` ADD COLUMN `" & payHeadNameTextBox.Text & "` TINYINT NOT NULL DEFAULT 0 AFTER `empid`") > 0 Then
                    Return 1
                End If
            End If

        ElseIf payHeadTypeComboBox.Text = "Deductions from Employees" Then
            If runQuery("ALTER TABLE `tbl_emp_deductions` ADD COLUMN `" & payHeadNameTextBox.Text & "` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `empid`") > 0 Then
                If runQuery("ALTER TABLE `tbl_emp_applicable_deductions` ADD COLUMN `" & payHeadNameTextBox.Text & "` TINYINT NOT NULL DEFAULT 0 AFTER `empid`") > 0 Then
                    Return 1
                End If
            End If

        ElseIf payHeadTypeComboBox.Text = "Contributions by Employer" Then
            If runQuery("ALTER TABLE `tbl_emp_contributions` ADD COLUMN `" & payHeadNameTextBox.Text & "` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `empid`") > 0 Then
                If runQuery("ALTER TABLE `tbl_emp_applicable_contributions` ADD COLUMN `" & payHeadNameTextBox.Text & "` TINYINT NOT NULL DEFAULT 0 AFTER `empid`") > 0 Then
                    Return 1
                End If
            End If

        End If

        Return 0

    End Function

    Private Function removeOldPayHeadsFromTables() As Integer

        'first of all delete the columns from their previous tables
        If OldPayHeadTypeTextBox.Text = "Earnings for Employees" Then
            'Check if pay head exists in the db
            If runQueryAndReturnValue("SELECT IF(count(*) = 1, 'Exist','Not Exist') AS result
                        FROM information_schema.columns 
                        WHERE table_schema = 'db_fast_pharms' AND table_name = 'tbl_emp_earnings' 
                        AND column_name = '" & PayHeadOldNameTextBox.Text & "';", "result") = "Exist" Then

                'Then delete it from the table tbl_emp_earnings
                If runQuery("ALTER TABLE `tbl_emp_earnings` DROP COLUMN `" & PayHeadOldNameTextBox.Text & "`") > 0 Then
                    'Then delete it from the table tbl_emp_applicable_earnings
                    If runQuery("ALTER TABLE `tbl_emp_applicable_earnings` DROP COLUMN `" & PayHeadOldNameTextBox.Text & "`") > 0 Then
                        Return 1
                    End If
                End If

            End If

        ElseIf OldPayHeadTypeTextBox.Text = "Deductions from Employees" Then

            If runQueryAndReturnValue("SELECT IF(count(*) = 1, 'Exist','Not Exist') AS result
                        FROM information_schema.columns 
                        WHERE table_schema = 'db_fast_pharms' AND table_name = 'tbl_emp_deductions' 
                        AND column_name = '" & PayHeadOldNameTextBox.Text & "';", "result") = "Exist" Then

                If runQuery("ALTER TABLE `tbl_emp_deductions` DROP COLUMN `" & PayHeadOldNameTextBox.Text & "`") > 0 Then
                    If runQuery("ALTER TABLE `tbl_emp_applicable_deductions` DROP COLUMN `" & PayHeadOldNameTextBox.Text & "`") > 0 Then
                        Return 1
                    End If
                End If

            End If

        ElseIf OldPayHeadTypeTextBox.Text = "Contributions by Employer" Then

            If runQueryAndReturnValue("SELECT IF(count(*) = 1, 'Exist','Not Exist') AS result
                        FROM information_schema.columns 
                        WHERE table_schema = 'db_fast_pharms' AND table_name = 'tbl_emp_contributions' 
                        AND column_name = '" & PayHeadOldNameTextBox.Text & "';", "result") = "Exist" Then

                If runQuery("ALTER TABLE `tbl_emp_contributions` DROP COLUMN `" & PayHeadOldNameTextBox.Text & "`") > 0 Then
                    If runQuery("ALTER TABLE `tbl_emp_applicable_contributions` DROP COLUMN `" & PayHeadOldNameTextBox.Text & "`") > 0 Then
                        Return 1
                    End If
                End If

            End If

        End If

        Return 0
    End Function

    Private Function changePayHeadName() As Integer

        If payHeadTypeComboBox.Text = "Earnings for Employees" Then

            If runQueryAndReturnValue("SELECT IF(count(*) = 1, 'Exist','Not Exist') AS result
                        FROM information_schema.columns 
                        WHERE table_schema = 'db_fast_pharms' AND table_name = 'tbl_emp_earnings' 
                        AND column_name = '" & PayHeadOldNameTextBox.Text & "';", "result") = "Exist" Then

                If runQuery("ALTER TABLE `tbl_emp_earnings` CHANGE COLUMN `" & PayHeadOldNameTextBox.Text & "` `" & payHeadNameTextBox.Text & "` DECIMAL(10,2) NOT NULL DEFAULT 0") > 0 Then
                    If runQuery("ALTER TABLE `tbl_emp_applicable_earnings` CHANGE COLUMN `" & PayHeadOldNameTextBox.Text & "` `" & payHeadNameTextBox.Text & "` TINYINT NOT NULL DEFAULT 0") > 0 Then
                        Return 1
                    End If
                End If

            End If

        ElseIf payHeadTypeComboBox.Text = "Deductions from Employees" Then

            If runQueryAndReturnValue("SELECT IF(count(*) = 1, 'Exist','Not Exist') AS result
                        FROM information_schema.columns 
                        WHERE table_schema = 'db_fast_pharms' AND table_name = 'tbl_emp_deductions' 
                        AND column_name = '" & PayHeadOldNameTextBox.Text & "';", "result") = "Exist" Then

                If runQuery("ALTER TABLE `tbl_emp_deductions` CHANGE COLUMN `" & PayHeadOldNameTextBox.Text & "` `" & payHeadNameTextBox.Text & "` DECIMAL(10,2) NOT NULL DEFAULT 0") > 0 Then
                    If runQuery("ALTER TABLE `tbl_emp_applicable_deductions` CHANGE COLUMN `" & PayHeadOldNameTextBox.Text & "` `" & payHeadNameTextBox.Text & "` TINYINT NOT NULL DEFAULT 0") > 0 Then
                        Return 1
                    End If
                End If

            End If

        ElseIf payHeadTypeComboBox.Text = "Contributions by Employer" Then

            If runQueryAndReturnValue("SELECT IF(count(*) = 1, 'Exist','Not Exist') AS result
                        FROM information_schema.columns 
                        WHERE table_schema = 'db_fast_pharms' AND table_name = 'tbl_emp_contributions' 
                        AND column_name = '" & PayHeadOldNameTextBox.Text & "';", "result") = "Exist" Then

                If runQuery("ALTER TABLE `tbl_emp_contributions` CHANGE COLUMN `" & PayHeadOldNameTextBox.Text & "` `" & payHeadNameTextBox.Text & "` DECIMAL(10,2) NOT NULL DEFAULT 0") > 0 Then
                    If runQuery("ALTER TABLE `tbl_emp_applicable_contributions` CHANGE COLUMN `" & PayHeadOldNameTextBox.Text & " `" & payHeadNameTextBox.Text & "`` TINYINT NOT NULL DEFAULT 0") > 0 Then
                        Return 1
                    End If
                End If

            End If

        End If

        Return 0
    End Function

    Private Function deletePayHead(ByVal phid As Integer) As Integer

        If runQuery("DELETE FROM `tbl_pay_head` WHERE `id` = '" & phid & "'") = 1 Then
            If removeOldPayHeadsFromTables() = 1 Then
                Return 1
            Else
                Return 1
            End If
        End If

        Return 0
    End Function

    Private Function setPayHeadDetails(ByVal payHeadID As Integer) As Integer
        Try
            Dim query As String = "SELECT * FROM `tbl_pay_head` WHERE `id` = '" & payHeadID & "'"

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd = New MySqlCommand(query, conn)
            da = New MySqlDataAdapter(cmd)
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read

                    PayHeadOldNameTextBox.Text = If(dr.Item("name") Is DBNull.Value, String.Empty, dr.Item("name"))
                    payHeadNameTextBox.Text = If(dr.Item("name") Is DBNull.Value, String.Empty, dr.Item("name"))
                    OldPayHeadTypeTextBox.Text = If(dr.Item("pay_head_type") Is DBNull.Value, String.Empty, dr.Item("pay_head_type"))
                    payHeadTypeComboBox.Text = If(dr.Item("pay_head_type") Is DBNull.Value, String.Empty, dr.Item("pay_head_type"))
                    PayTypeComboBox.Text = If(dr.Item("pay_type") Is DBNull.Value, String.Empty, dr.Item("pay_type"))

                    underComboBox.Text = If(dr.Item("under") Is DBNull.Value, String.Empty, dr.Item("under"))
                    taxableComboBox.Text = If(dr.Item("taxable") Is DBNull.Value, String.Empty, dr.Item("taxable"))
                    affectsNetSalComboBox.Text = If(dr.Item("affect_net_salary") Is DBNull.Value, String.Empty, dr.Item("affect_net_salary"))
                    nameToAppearTextBox.Text = If(dr.Item("name_to_appear") Is DBNull.Value, String.Empty, dr.Item("name_to_appear"))
                    calculationTypeComboBox.Text = If(dr.Item("calculation_type") Is DBNull.Value, String.Empty, dr.Item("calculation_type"))

                    calculationBasisComboBox.Text = If(dr.Item("calculation_basis") Is DBNull.Value, String.Empty, dr.Item("calculation_basis"))
                    periodOfTextBox.Text = If(dr.Item("period_of") Is DBNull.Value, String.Empty, dr.Item("period_of"))
                    whatTypeComboBox.Text = If(dr.Item("attend_or_prod_type") Is DBNull.Value, String.Empty, dr.Item("attend_or_prod_type"))
                    CalculationPeriodComboBox.Text = If(dr.Item("calculation_period") Is DBNull.Value, String.Empty, dr.Item("calculation_period"))

                    computeTypeComboBox.Text = If(dr.Item("compute_on") Is DBNull.Value, String.Empty, dr.Item("compute_on"))
                    specifiedFormulaTextBox.Text = If(dr.Item("specified_formula") Is DBNull.Value, String.Empty, dr.Item("specified_formula"))
                    effectiveFromDateTimePicker.Text = If(dr.Item("effective_from") Is DBNull.Value, Date.Now, CDate(dr.Item("effective_from")))
                End While

                If calculationTypeComboBox.Text = "As Computed Value" Then

                    calcGroupPanel.Visible = True
                    whatCalcTypePanel.Visible = False
                    calcPeriodPanel.Visible = True
                    calcBasisPanel.Visible = False
                    periodOfPanel.Visible = False

                    If PayTypeComboBox.Text = "Income Tax" Then
                        computationInfoDataGridView.Visible = False
                        computationInfoForUpdateDataGridView2.Visible = False
                        graTaxSlabDataGridView.Visible = True
                        graTaxSlabDataGridView.Location = New Point(13, 7)

                    Else
                        computationInfoDataGridView.Visible = False
                        graTaxSlabDataGridView.Visible = False
                        computationInfoForUpdateDataGridView2.Visible = True
                        computationInfoForUpdateDataGridView2.Location = New Point(13, 7)
                        computationInfoForUpdateDataGridView2.Height = 161

                    End If

                    computeOnPanel.Visible = True
                    specifiedFormulaPanel.Visible = False
                    computeInfoDgvPanel.Visible = True

                ElseIf calculationTypeComboBox.Text = "As User Defined Value" Then

                    calcGroupPanel.Visible = True
                    whatCalcTypePanel.Visible = False
                    calcPeriodPanel.Visible = False
                    calcBasisPanel.Visible = False
                    periodOfPanel.Visible = False

                    'Me.Width = Me.MinimumSize.Width

                    computeOnPanel.Visible = False
                    specifiedFormulaPanel.Visible = False
                    computeInfoDgvPanel.Visible = False

                ElseIf calculationTypeComboBox.Text = "Flat Rate" Then

                    calcGroupPanel.Visible = True
                    whatCalcTypePanel.Visible = False
                    calcPeriodPanel.Visible = True
                    calcBasisPanel.Visible = False
                    periodOfPanel.Visible = False

                    'Me.Width = Me.MinimumSize.Width

                    computeOnPanel.Visible = False
                    specifiedFormulaPanel.Visible = False
                    computeInfoDgvPanel.Visible = False

                ElseIf calculationTypeComboBox.Text = "On Production" Then

                    calcGroupPanel.Visible = True
                    whattypeLabel.Text = "Production Type :"
                    whatCalcTypePanel.Visible = True
                    calcPeriodPanel.Visible = False
                    calcBasisPanel.Visible = False
                    periodOfPanel.Visible = False

                    'Me.Width = Me.MinimumSize.Width

                    computeOnPanel.Visible = False
                    specifiedFormulaPanel.Visible = False
                    computeInfoDgvPanel.Visible = False

                ElseIf calculationTypeComboBox.Text = "On Attendance" Then

                    calcGroupPanel.Visible = True
                    whattypeLabel.Text = "Present/Leave With Pay :"
                    whatCalcTypePanel.Visible = True
                    calcPeriodPanel.Visible = True
                    calcBasisPanel.Visible = True
                    periodOfPanel.Visible = True

                    'Me.Width = Me.MinimumSize.Width

                    computeOnPanel.Visible = False
                    specifiedFormulaPanel.Visible = False
                    computeInfoDgvPanel.Visible = False

                End If

                If computeTypeComboBox.Text = "On Specified Formula" Then
                    specifiedFormulaPanel.Visible = True
                Else
                    specifiedFormulaPanel.Visible = False
                End If


            End If

            conn.Close()
            Return 1

        Catch ex As Exception
            conn.Close()
            MsgBox(ex.StackTrace.ToString)
        Finally
            conn.Dispose()
        End Try

        Return 0

    End Function

    Public Sub setPayHeadDgv(ByVal payHeadID As Integer)
        If calculationTypeComboBox.Text = "As Computed Value" Then

            computationInfoDataGridView.Visible = False
            computationInfoForUpdateDataGridView2.Visible = False
            graTaxSlabDataGridView.Visible = True
            computationInfoForUpdateDataGridView2.Location = New Point(13, 7)

            If PayTypeComboBox.Text = "Income Tax" Then
                LoadDataIntoDatagrid(graTaxSlabDataGridView, "SELECT `amt_from`, `amt_to`, `chrg_amt`, 
                            `percentage`, `amt_crh`,`free_amt` FROM `tbl_gra_refera`")

            Else
                computationInfoDataGridView.Visible = False
                graTaxSlabDataGridView.Visible = False
                computationInfoForUpdateDataGridView2.Visible = True
                computationInfoForUpdateDataGridView2.Location = New Point(14, 8)

                LoadDataIntoDatagrid(computationInfoForUpdateDataGridView2, "SELECT `id`, `amount_from`, `amount_to`, 
                            `slab_type`, `value_basis` FROM `tbl_computation_info` WHERE `phid` = '" & payHeadID & "'")

                computationInfoForUpdateDataGridView2.Columns("id").Visible = False
                computationInfoForUpdateDataGridView2.Columns("slab_type").DefaultCellStyle.BackColor = Color.CadetBlue

                computationInfoForUpdateTotalTextBox.Text = computationInfoForUpdateDataGridView2.RowCount - 1

            End If

        End If
    End Sub

    Private Sub computationInfoDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles computationInfoDataGridView.CellContentClick

    End Sub

    Private Sub specifiedFormulaTextBox_TextChanged(sender As Object, e As EventArgs) Handles specifiedFormulaTextBox.TextChanged

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub
End Class