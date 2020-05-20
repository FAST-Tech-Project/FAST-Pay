<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewPayDayForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SelectedPayIDTextBox = New System.Windows.Forms.TextBox()
        Me.DelPayDayButton = New System.Windows.Forms.Button()
        Me.SavePayDateButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PayFromDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.PayToDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'SelectedPayIDTextBox
        '
        Me.SelectedPayIDTextBox.Location = New System.Drawing.Point(207, 14)
        Me.SelectedPayIDTextBox.Name = "SelectedPayIDTextBox"
        Me.SelectedPayIDTextBox.ReadOnly = True
        Me.SelectedPayIDTextBox.Size = New System.Drawing.Size(35, 20)
        Me.SelectedPayIDTextBox.TabIndex = 25
        '
        'DelPayDayButton
        '
        Me.DelPayDayButton.Location = New System.Drawing.Point(77, 12)
        Me.DelPayDayButton.Name = "DelPayDayButton"
        Me.DelPayDayButton.Size = New System.Drawing.Size(35, 23)
        Me.DelPayDayButton.TabIndex = 24
        Me.DelPayDayButton.Text = "Del"
        Me.DelPayDayButton.UseVisualStyleBackColor = True
        Me.DelPayDayButton.Visible = False
        '
        'SavePayDateButton
        '
        Me.SavePayDateButton.Location = New System.Drawing.Point(12, 12)
        Me.SavePayDateButton.Name = "SavePayDateButton"
        Me.SavePayDateButton.Size = New System.Drawing.Size(59, 23)
        Me.SavePayDateButton.TabIndex = 23
        Me.SavePayDateButton.Text = "Save"
        Me.SavePayDateButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "From"
        '
        'PayFromDateTimePicker
        '
        Me.PayFromDateTimePicker.CustomFormat = "yyyy-MM-dd"
        Me.PayFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PayFromDateTimePicker.Location = New System.Drawing.Point(45, 60)
        Me.PayFromDateTimePicker.Name = "PayFromDateTimePicker"
        Me.PayFromDateTimePicker.Size = New System.Drawing.Size(197, 20)
        Me.PayFromDateTimePicker.TabIndex = 26
        '
        'PayToDateTimePicker
        '
        Me.PayToDateTimePicker.CustomFormat = "yyyy-MM-dd"
        Me.PayToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PayToDateTimePicker.Location = New System.Drawing.Point(45, 90)
        Me.PayToDateTimePicker.Name = "PayToDateTimePicker"
        Me.PayToDateTimePicker.Size = New System.Drawing.Size(197, 20)
        Me.PayToDateTimePicker.TabIndex = 27
        '
        'NewPayDayForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 130)
        Me.Controls.Add(Me.PayToDateTimePicker)
        Me.Controls.Add(Me.PayFromDateTimePicker)
        Me.Controls.Add(Me.SelectedPayIDTextBox)
        Me.Controls.Add(Me.DelPayDayButton)
        Me.Controls.Add(Me.SavePayDateButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "NewPayDayForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pay Date"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SelectedPayIDTextBox As TextBox
    Friend WithEvents DelPayDayButton As Button
    Friend WithEvents SavePayDateButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PayFromDateTimePicker As DateTimePicker
    Friend WithEvents PayToDateTimePicker As DateTimePicker
End Class
