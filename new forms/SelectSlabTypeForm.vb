Imports System.ComponentModel

Public Class SelectSlabTypeForm

    Private Sub SelectSlabTypeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub SelectSlabTypeForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If PayHeadCreationForm.computationInfoDataGridView.Visible = True Then
            If PayHeadCreationForm.slabTypeRowIndexTextBox.Text <> "" Then
                If ((PayHeadCreationForm.computationInfoDataGridView.RowCount - 2) - CInt(PayHeadCreationForm.slabTypeRowIndexTextBox.Text)) > 0 Then
                    PayHeadCreationForm.computationInfoDataGridView.Rows.RemoveAt(PayHeadCreationForm.computationInfoDataGridView.RowCount - 2)
                End If
            End If

        ElseIf PayHeadCreationForm.computationInfoForUpdateDataGridView2.Visible = True Then

            If PayHeadCreationForm.slabTypeRowIndexTextBox.Text <> "" Then
                If ((PayHeadCreationForm.computationInfoForUpdateDataGridView2.RowCount - 2) - CInt(PayHeadCreationForm.slabTypeRowIndexTextBox.Text)) > 0 Then
                    PayHeadCreationForm.computationInfoForUpdateDataGridView2.Rows.RemoveAt(PayHeadCreationForm.computationInfoForUpdateDataGridView2.RowCount - 2)
                End If
            End If

        End If
    End Sub

    Private Sub slabTypeListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles slabTypeListBox.SelectedIndexChanged
        If slabTypeListBox.SelectedItem <> "" Then
            If PayHeadCreationForm.computationInfoDataGridView.Visible = True Then

                PayHeadCreationForm.computationInfoDataGridView.Rows.Add()
                Dim rowInd As Integer = PayHeadCreationForm.slabTypeRowIndexTextBox.Text

                PayHeadCreationForm.computationInfoDataGridView.Rows(rowInd).Cells("slab_type").Value = slabTypeListBox.SelectedItem
                PayHeadCreationForm.computationInfoDataGridView.Rows(rowInd).Cells("slab_type").Selected = False
                PayHeadCreationForm.computationInfoDataGridView.Rows(rowInd).Cells("value_basis").Selected = True

            ElseIf PayHeadCreationForm.computationInfoForUpdateDataGridView2.Visible = True Then

                Dim MyNewRow As DataRow
                MyNewRow = PayHeadCreationForm.computationInfoForUpdateDataGridView2.DataSource.NewRow
                Dim rowInd As Integer = rowInd

                With MyNewRow
                    .Item("slab_type") = slabTypeListBox.SelectedItem
                End With

                PayHeadCreationForm.computationInfoForUpdateDataGridView2.DataSource.rows.add(MyNewRow)
                PayHeadCreationForm.computationInfoForUpdateDataGridView2.DataSource.acceptchanges

            End If
        End If

        Me.Close()

    End Sub


End Class