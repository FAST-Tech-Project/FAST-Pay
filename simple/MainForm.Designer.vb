<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.toPayrollButton = New System.Windows.Forms.Button()
        Me.toSalariesButton = New System.Windows.Forms.Button()
        Me.toPayHeadsButton = New System.Windows.Forms.Button()
        Me.toEmployeeButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'toPayrollButton
        '
        Me.toPayrollButton.Location = New System.Drawing.Point(145, 133)
        Me.toPayrollButton.Name = "toPayrollButton"
        Me.toPayrollButton.Size = New System.Drawing.Size(75, 23)
        Me.toPayrollButton.TabIndex = 7
        Me.toPayrollButton.Text = "Payroll"
        Me.toPayrollButton.UseVisualStyleBackColor = True
        '
        'toSalariesButton
        '
        Me.toSalariesButton.Location = New System.Drawing.Point(64, 133)
        Me.toSalariesButton.Name = "toSalariesButton"
        Me.toSalariesButton.Size = New System.Drawing.Size(75, 23)
        Me.toSalariesButton.TabIndex = 6
        Me.toSalariesButton.Text = "Salaries"
        Me.toSalariesButton.UseVisualStyleBackColor = True
        '
        'toPayHeadsButton
        '
        Me.toPayHeadsButton.Location = New System.Drawing.Point(145, 104)
        Me.toPayHeadsButton.Name = "toPayHeadsButton"
        Me.toPayHeadsButton.Size = New System.Drawing.Size(75, 23)
        Me.toPayHeadsButton.TabIndex = 5
        Me.toPayHeadsButton.Text = "Pay Heads"
        Me.toPayHeadsButton.UseVisualStyleBackColor = True
        '
        'toEmployeeButton
        '
        Me.toEmployeeButton.Location = New System.Drawing.Point(64, 104)
        Me.toEmployeeButton.Name = "toEmployeeButton"
        Me.toEmployeeButton.Size = New System.Drawing.Size(75, 23)
        Me.toEmployeeButton.TabIndex = 4
        Me.toEmployeeButton.Text = "Employee"
        Me.toEmployeeButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.toPayrollButton)
        Me.Controls.Add(Me.toSalariesButton)
        Me.Controls.Add(Me.toPayHeadsButton)
        Me.Controls.Add(Me.toEmployeeButton)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents toPayrollButton As Button
    Friend WithEvents toSalariesButton As Button
    Friend WithEvents toPayHeadsButton As Button
    Friend WithEvents toEmployeeButton As Button
End Class
