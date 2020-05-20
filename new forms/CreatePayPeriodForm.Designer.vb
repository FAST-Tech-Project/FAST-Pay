<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreatePayPeriodForm
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
        Me.FromDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.ToDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'FromDateDateTimePicker
        '
        Me.FromDateDateTimePicker.CustomFormat = "yyyy-MM-dd"
        Me.FromDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FromDateDateTimePicker.Location = New System.Drawing.Point(71, 25)
        Me.FromDateDateTimePicker.Name = "FromDateDateTimePicker"
        Me.FromDateDateTimePicker.Size = New System.Drawing.Size(111, 23)
        Me.FromDateDateTimePicker.TabIndex = 0
        '
        'ToDateDateTimePicker
        '
        Me.ToDateDateTimePicker.CustomFormat = "yyyy-MM-dd"
        Me.ToDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ToDateDateTimePicker.Location = New System.Drawing.Point(71, 65)
        Me.ToDateDateTimePicker.Name = "ToDateDateTimePicker"
        Me.ToDateDateTimePicker.Size = New System.Drawing.Size(111, 23)
        Me.ToDateDateTimePicker.TabIndex = 1
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(71, 103)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(111, 27)
        Me.SaveButton.TabIndex = 2
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "To :"
        '
        'CreatePayPeriodForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(203, 148)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.ToDateDateTimePicker)
        Me.Controls.Add(Me.FromDateDateTimePicker)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(219, 187)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(219, 187)
        Me.Name = "CreatePayPeriodForm"
        Me.Text = "Add Pay Period"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FromDateDateTimePicker As DateTimePicker
    Friend WithEvents ToDateDateTimePicker As DateTimePicker
    Friend WithEvents SaveButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
