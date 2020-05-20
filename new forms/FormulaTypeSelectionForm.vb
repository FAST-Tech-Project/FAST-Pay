Public Class FormulaTypeSelectionForm
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        If PayHeadCreationForm.clickedDgvItemTextBox.Text = "" Then
            FormulaForm.userSpecifiedFunctionDataGridView.Rows(FormulaForm.rowIndexTextBox.Text).Cells("thefunction").Value = ListBox1.SelectedItem.ToString
        Else
            FormulaForm.updateUserSpecifiedFunctionDataGridView.Rows(FormulaForm.rowIndexTextBox.Text).Cells("function").Value = ListBox1.SelectedItem.ToString
        End If

        Me.Close()
    End Sub
End Class