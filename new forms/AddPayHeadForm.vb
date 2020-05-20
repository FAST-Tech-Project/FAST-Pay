Public Class AddPayHeadForm
    Private Sub AddPayHeadForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataIntoDatagrid(PayHeadsDataGridView, "SELECT `name` FROM `tbl_pay_head`")
        PayHeadsDataGridView.Columns("name").Width = PayHeadsDataGridView.Width - 1
    End Sub

    Private Sub PayHeadsDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles PayHeadsDataGridView.CellClick
        If e.RowIndex < PayHeadsDataGridView.RowCount - 1 Then

            If PayHeadCreationForm.clickedDgvItemTextBox.Text = "" Then
                FormulaForm.userSpecifiedFunctionDataGridView.Rows(FormulaForm.rowIndexTextBox.Text).Cells(2).Value = PayHeadsDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            Else
                FormulaForm.updateUserSpecifiedFunctionDataGridView.Rows(FormulaForm.rowIndexTextBox.Text).Cells("pay_head").Value = PayHeadsDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            End If
        End If

        Me.Close()
    End Sub

End Class