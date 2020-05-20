Public Class FormulaForm
    Private Sub FormulaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SaveFunctionButton_Click(sender As Object, e As EventArgs) Handles SaveFunctionButton.Click

        PayHeadCreationForm.specifiedFormulaTextBox.Text = "="
        For i = 0 To userSpecifiedFunctionDataGridView.RowCount - 1

            If userSpecifiedFunctionDataGridView.Rows(i).Cells("symbol").Value = "(" Or userSpecifiedFunctionDataGridView.Rows(i).Cells("symbol").Value = ")" Then
                PayHeadCreationForm.specifiedFormulaTextBox.Text += userSpecifiedFunctionDataGridView.Rows(i).Cells("symbol").Value
            End If

            If PayHeadCreationForm.specifiedFormulaTextBox.Text <> "=" Then

                If userSpecifiedFunctionDataGridView.Rows(i).Cells("thefunction").Value = "Add Pay Head" Then
                    PayHeadCreationForm.specifiedFormulaTextBox.Text += " + "
                ElseIf userSpecifiedFunctionDataGridView.Rows(i).Cells("thefunction").Value = "Substract Pay Head" Then
                    PayHeadCreationForm.specifiedFormulaTextBox.Text += " - "
                ElseIf userSpecifiedFunctionDataGridView.Rows(i).Cells("thefunction").Value = "Divide by Attendance" Then
                    PayHeadCreationForm.specifiedFormulaTextBox.Text += " / "
                ElseIf userSpecifiedFunctionDataGridView.Rows(i).Cells("thefunction").Value = "Multiply by Attendance" Then
                    PayHeadCreationForm.specifiedFormulaTextBox.Text += " * "
                End If

            End If

            If userSpecifiedFunctionDataGridView.Rows(i).Cells("thefunction").Value <> "Divide by Attendance" And
                userSpecifiedFunctionDataGridView.Rows(i).Cells("thefunction").Value <> "Multiply by Attendance" Then
                PayHeadCreationForm.specifiedFormulaTextBox.Text += userSpecifiedFunctionDataGridView.Rows(i).Cells("pay_head").Value
            Else
                PayHeadCreationForm.specifiedFormulaTextBox.Text += "attendance"
            End If

        Next

        Me.Hide()

    End Sub

    Private Sub userSpecifiedFunctionDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles userSpecifiedFunctionDataGridView.CellClick
        If e.ColumnIndex = 1 Then
            rowIndexTextBox.Text = e.RowIndex
            FormulaTypeSelectionForm.Show()
        ElseIf e.ColumnIndex = 2 Then
            If userSpecifiedFunctionDataGridView.Rows(e.RowIndex).Cells("thefunction").Value <> "" Then
                If userSpecifiedFunctionDataGridView.Rows(e.RowIndex).Cells("thefunction").Value = "Divide by Attendance" Then
                    userSpecifiedFunctionDataGridView.Rows(e.RowIndex).Cells("pay_head").Value =
                    runQueryAndReturnValue("SELECT `name` FROM `tbl_attendance_or_production` 
                    WHERE `type` LIKE 'Attendance%' AND `name` LIKE 'Present%'", "name")
                ElseIf userSpecifiedFunctionDataGridView.Rows(e.RowIndex).Cells("thefunction").Value = "Multiply by Attendance" Then
                    userSpecifiedFunctionDataGridView.Rows(e.RowIndex).Cells("pay_head").Value =
                    runQueryAndReturnValue("SELECT `name` FROM `tbl_attendance_or_production` 
                    WHERE `type` LIKE 'Attendance%' AND `name` LIKE 'Present%'", "name")
                Else
                    AddPayHeadForm.Show()
                End If
            Else
                rowIndexTextBox.Text = e.RowIndex
                FormulaTypeSelectionForm.Show()
            End If
        End If
    End Sub

    Private Sub HideFormButton_Click(sender As Object, e As EventArgs) Handles HideFormButton.Click
        Me.Hide()
    End Sub

    Private Sub CancelPayHeadButton_Click(sender As Object, e As EventArgs) Handles CancelPayHeadButton.Click
        userSpecifiedFunctionDataGridView.Rows.Clear()
    End Sub

    Private Sub FormulaForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If PayHeadCreationForm.clickedDgvItemTextBox.Text <> "" Then
            LoadDataIntoDatagrid(updateUserSpecifiedFunctionDataGridView,
                                 "SELECT `id`, `phid`, `symbol`, `function`, `pay_head` 
                                 FROM `tbl_specified_formula` 
                                 WHERE `phid` = '" & PayHeadCreationForm.clickedDgvItemTextBox.Text & "'")
            updateUserSpecifiedFunctionDataGridView.Columns("id").Visible = False
            updateUserSpecifiedFunctionDataGridView.Columns("phid").Visible = False
            updateUserSpecifiedFunctionDataGridView.Columns("symbol").Width = 50
            updateUserSpecifiedFunctionDataGridView.Columns("function").Width = 150
            updateUserSpecifiedFunctionDataGridView.Columns("pay_head").Width = 200
            updateUserSpecifiedFunctionDataGridView.ClearSelection()
            addPanel.Visible = False
            updatePanel.Visible = True

        Else
            addPanel.Visible = True
            updatePanel.Visible = False

        End If

    End Sub

    Private Sub updateUserSpecifiedFunctionDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles updateUserSpecifiedFunctionDataGridView.CellContentClick

    End Sub

    Private Sub updateUserSpecifiedFunctionDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles updateUserSpecifiedFunctionDataGridView.CellClick
        If e.ColumnIndex = 3 Then
            rowIndexTextBox.Text = e.RowIndex
            FormulaTypeSelectionForm.Show()
        ElseIf e.ColumnIndex = 4 Then
            If updateUserSpecifiedFunctionDataGridView.Rows(e.RowIndex).Cells("function").Value IsNot DBNull.Value Then
                If updateUserSpecifiedFunctionDataGridView.Rows(e.RowIndex).Cells("function").Value = "Divide by Attendance" Then
                    updateUserSpecifiedFunctionDataGridView.Rows(e.RowIndex).Cells("pay_head").Value =
                    runQueryAndReturnValue("SELECT `name` FROM `tbl_attendance_or_production` 
                    WHERE `type` LIKE 'Attendance%' AND `name` LIKE 'Present%'", "name")
                ElseIf updateUserSpecifiedFunctionDataGridView.Rows(e.RowIndex).Cells("function").Value = "Multiply by Attendance" Then
                    updateUserSpecifiedFunctionDataGridView.Rows(e.RowIndex).Cells("pay_head").Value =
                    runQueryAndReturnValue("SELECT `name` FROM `tbl_attendance_or_production` 
                    WHERE `type` LIKE 'Attendance%' AND `name` LIKE 'Present%'", "name")
                Else
                    AddPayHeadForm.Show()
                End If
            Else
                rowIndexTextBox.Text = e.RowIndex
                FormulaTypeSelectionForm.Show()
            End If
        End If
    End Sub

    Public Function addSpecifiedFormula(ByVal pay_head_id As Integer, ByVal computeOnType As String) As Integer

        If LCase(computeOnType) = "on specified formula" Then
            Dim y As Integer = 0

            For index = 0 To userSpecifiedFunctionDataGridView.RowCount - 1

                If userSpecifiedFunctionDataGridView.Rows(index).Cells("thefunction").Value <> "" And
                    userSpecifiedFunctionDataGridView.Rows(index).Cells("pay_head").Value <> "" Then

                    If userSpecifiedFunctionDataGridView.Rows(index).Cells("symbol").Value = "" Or
                        userSpecifiedFunctionDataGridView.Rows(index).Cells("symbol").Value = "new row" Then

                        If runQuery("INSERT INTO `tbl_specified_formula` (`phid`, `symbol`, `function`, `pay_head`) 
                                    VALUES ('" & pay_head_id & "', '',
                                    '" & userSpecifiedFunctionDataGridView.Rows(index).Cells("thefunction").Value & "',
                                    '" & userSpecifiedFunctionDataGridView.Rows(index).Cells("pay_head").Value & "')") = 1 Then
                            y += 1
                        End If

                    Else

                        If runQuery("INSERT INTO `tbl_specified_formula` (`phid`, `symbol`, `function`, `pay_head`) 
                                    VALUES ('" & pay_head_id & "', 
                                    '" & userSpecifiedFunctionDataGridView.Rows(index).Cells("symbol").Value & "',
                                    '" & userSpecifiedFunctionDataGridView.Rows(index).Cells("thefunction").Value & "',
                                    '" & userSpecifiedFunctionDataGridView.Rows(index).Cells("pay_head").Value & "')") = 1 Then
                            y += 1
                        End If

                    End If

                End If

            Next

            If y = userSpecifiedFunctionDataGridView.RowCount Then
                Return 1
            End If

        Else
            Return 1
        End If

        Return 0
    End Function

    Public Function updateSpecifiedFormula(ByVal pay_head_id As Integer, ByVal computeOnType As String) As Integer

        If LCase(computeOnType) = "on specified formula" Then
            Dim y As Integer = 0

            For index = 0 To updateUserSpecifiedFunctionDataGridView.RowCount - 1

                Dim ph_exit As Integer = runQueryAndReturnValue("SELECT `id` FROM tbl_specified_formula 
                                                                    WHERE phid = '" & pay_head_id & "'", "id")

                If ph_exit <> "" Then

                    If updateUserSpecifiedFunctionDataGridView.Rows(index).Cells("function").Value <> "" And
                        updateUserSpecifiedFunctionDataGridView.Rows(index).Cells("pay_head").Value <> "" Then

                        If updateUserSpecifiedFunctionDataGridView.Rows(index).Cells("symbol").Value = "" Or
                            updateUserSpecifiedFunctionDataGridView.Rows(index).Cells("symbol").Value = "new row" Then

                            If runQuery("UPDATE `tbl_specified_formula` SET `phid` = '" & pay_head_id & "', `symbol` = '', 
                                    `function` = '" & updateUserSpecifiedFunctionDataGridView.Rows(index).Cells("function").Value & "', 
                                    `pay_head` = '" & updateUserSpecifiedFunctionDataGridView.Rows(index).Cells("pay_head").Value & "', 
                                    `updated_at` = CURRENT_TIMESTAMP 
                                    WHERE `id` = '" & pay_head_id & "'") = 1 Then
                                y += 1
                            End If

                        Else
                            If runQuery("UPDATE `tbl_specified_formula` SET `phid` = '" & pay_head_id & "', 
                                    `symbol` = '" & updateUserSpecifiedFunctionDataGridView.Rows(index).Cells("symbol").Value & "', 
                                    `function` = '" & updateUserSpecifiedFunctionDataGridView.Rows(index).Cells("function").Value & "', 
                                    `pay_head` = '" & updateUserSpecifiedFunctionDataGridView.Rows(index).Cells("pay_head").Value & "', 
                                    `updated_at` = CURRENT_TIMESTAMP 
                                    WHERE `id` = '" & pay_head_id & "'") = 1 Then
                                y += 1
                            End If

                        End If

                    End If

                Else
                    If userSpecifiedFunctionDataGridView.Rows(index).Cells("function").Value <> "" And
                    userSpecifiedFunctionDataGridView.Rows(index).Cells("pay_head").Value <> "" Then

                        If userSpecifiedFunctionDataGridView.Rows(index).Cells("symbol").Value = "" Or
                            userSpecifiedFunctionDataGridView.Rows(index).Cells("symbol").Value = "new row" Then

                            If runQuery("INSERT INTO `tbl_specified_formula` (`phid`, `symbol`, `function`, `pay_head`) 
                                    VALUES ('" & pay_head_id & "', '',
                                    '" & userSpecifiedFunctionDataGridView.Rows(index).Cells("function").Value & "',
                                    '" & userSpecifiedFunctionDataGridView.Rows(index).Cells("pay_head").Value & "')") = 1 Then
                                y += 1
                            End If

                        Else

                            If runQuery("INSERT INTO `tbl_specified_formula` (`phid`, `symbol`, `function`, `pay_head`) 
                                    VALUES ('" & pay_head_id & "', 
                                    '" & userSpecifiedFunctionDataGridView.Rows(index).Cells("symbol").Value & "',
                                    '" & userSpecifiedFunctionDataGridView.Rows(index).Cells("function").Value & "',
                                    '" & userSpecifiedFunctionDataGridView.Rows(index).Cells("pay_head").Value & "')") = 1 Then
                                y += 1
                            End If

                        End If

                    End If

                End If

            Next

            If y = updateUserSpecifiedFunctionDataGridView.RowCount Then
                Return 1
            End If

        Else
            Return 1
        End If

        Return 0
    End Function

End Class