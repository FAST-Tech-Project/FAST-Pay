<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditSetupForm
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
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cancelEmpSetupButton = New System.Windows.Forms.Button()
        Me.saveEmpSetupButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 12)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(138, 20)
        Me.TextBox2.TabIndex = 8
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(138, 20)
        Me.TextBox1.TabIndex = 7
        '
        'cancelEmpSetupButton
        '
        Me.cancelEmpSetupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cancelEmpSetupButton.FlatAppearance.BorderSize = 0
        Me.cancelEmpSetupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelEmpSetupButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelEmpSetupButton.ForeColor = System.Drawing.Color.White
        Me.cancelEmpSetupButton.Location = New System.Drawing.Point(42, 123)
        Me.cancelEmpSetupButton.Name = "cancelEmpSetupButton"
        Me.cancelEmpSetupButton.Size = New System.Drawing.Size(50, 20)
        Me.cancelEmpSetupButton.TabIndex = 10
        Me.cancelEmpSetupButton.Text = "Cancel"
        Me.cancelEmpSetupButton.UseVisualStyleBackColor = False
        Me.cancelEmpSetupButton.Visible = False
        '
        'saveEmpSetupButton
        '
        Me.saveEmpSetupButton.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.saveEmpSetupButton.FlatAppearance.BorderSize = 0
        Me.saveEmpSetupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveEmpSetupButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveEmpSetupButton.ForeColor = System.Drawing.Color.White
        Me.saveEmpSetupButton.Location = New System.Drawing.Point(98, 123)
        Me.saveEmpSetupButton.Name = "saveEmpSetupButton"
        Me.saveEmpSetupButton.Size = New System.Drawing.Size(52, 20)
        Me.saveEmpSetupButton.TabIndex = 9
        Me.saveEmpSetupButton.Text = "Save"
        Me.saveEmpSetupButton.UseVisualStyleBackColor = False
        Me.saveEmpSetupButton.Visible = False
        '
        'EditSetupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(162, 155)
        Me.Controls.Add(Me.cancelEmpSetupButton)
        Me.Controls.Add(Me.saveEmpSetupButton)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "EditSetupForm"
        Me.Text = "EditSetupForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cancelEmpSetupButton As Button
    Friend WithEvents saveEmpSetupButton As Button
End Class
