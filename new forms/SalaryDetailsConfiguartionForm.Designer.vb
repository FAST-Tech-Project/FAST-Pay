<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalaryDetailsConfiguartionForm
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SavePayHeadButton = New System.Windows.Forms.Button()
        Me.CancelPayHeadButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.overrideSlabPerComboBox = New System.Windows.Forms.ComboBox()
        Me.showPayHeadTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.showcalculationTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.showComputedOnComboBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.SavePayHeadButton)
        Me.GroupBox3.Controls.Add(Me.CancelPayHeadButton)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(331, 42)
        Me.GroupBox3.TabIndex = 89
        Me.GroupBox3.TabStop = False
        '
        'SavePayHeadButton
        '
        Me.SavePayHeadButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavePayHeadButton.Location = New System.Drawing.Point(12, 13)
        Me.SavePayHeadButton.Name = "SavePayHeadButton"
        Me.SavePayHeadButton.Size = New System.Drawing.Size(72, 23)
        Me.SavePayHeadButton.TabIndex = 85
        Me.SavePayHeadButton.Text = "Save"
        Me.SavePayHeadButton.UseVisualStyleBackColor = True
        '
        'CancelPayHeadButton
        '
        Me.CancelPayHeadButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelPayHeadButton.Location = New System.Drawing.Point(90, 13)
        Me.CancelPayHeadButton.Name = "CancelPayHeadButton"
        Me.CancelPayHeadButton.Size = New System.Drawing.Size(49, 23)
        Me.CancelPayHeadButton.TabIndex = 86
        Me.CancelPayHeadButton.Text = "Cancel"
        Me.CancelPayHeadButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 68)
        Me.Label1.MaximumSize = New System.Drawing.Size(171, 17)
        Me.Label1.MinimumSize = New System.Drawing.Size(171, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 17)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Salary Setup Configuration"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 17)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Allow to override slab percentage :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 17)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "Show Pay Head Type :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 17)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "Show Calculation Type :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 17)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Show Computed On :"
        '
        'overrideSlabPerComboBox
        '
        Me.overrideSlabPerComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.overrideSlabPerComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.overrideSlabPerComboBox.FormattingEnabled = True
        Me.overrideSlabPerComboBox.Items.AddRange(New Object() {"Yes", "No"})
        Me.overrideSlabPerComboBox.Location = New System.Drawing.Point(275, 112)
        Me.overrideSlabPerComboBox.Name = "overrideSlabPerComboBox"
        Me.overrideSlabPerComboBox.Size = New System.Drawing.Size(44, 25)
        Me.overrideSlabPerComboBox.TabIndex = 97
        Me.overrideSlabPerComboBox.Text = "Yes"
        '
        'showPayHeadTypeComboBox
        '
        Me.showPayHeadTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.showPayHeadTypeComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.showPayHeadTypeComboBox.FormattingEnabled = True
        Me.showPayHeadTypeComboBox.Items.AddRange(New Object() {"Yes", "No"})
        Me.showPayHeadTypeComboBox.Location = New System.Drawing.Point(275, 141)
        Me.showPayHeadTypeComboBox.Name = "showPayHeadTypeComboBox"
        Me.showPayHeadTypeComboBox.Size = New System.Drawing.Size(44, 25)
        Me.showPayHeadTypeComboBox.TabIndex = 98
        Me.showPayHeadTypeComboBox.Text = "Yes"
        '
        'showcalculationTypeComboBox
        '
        Me.showcalculationTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.showcalculationTypeComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.showcalculationTypeComboBox.FormattingEnabled = True
        Me.showcalculationTypeComboBox.Items.AddRange(New Object() {"Yes", "No"})
        Me.showcalculationTypeComboBox.Location = New System.Drawing.Point(275, 170)
        Me.showcalculationTypeComboBox.Name = "showcalculationTypeComboBox"
        Me.showcalculationTypeComboBox.Size = New System.Drawing.Size(44, 25)
        Me.showcalculationTypeComboBox.TabIndex = 99
        Me.showcalculationTypeComboBox.Text = "Yes"
        '
        'showComputedOnComboBox
        '
        Me.showComputedOnComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.showComputedOnComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.showComputedOnComboBox.FormattingEnabled = True
        Me.showComputedOnComboBox.Items.AddRange(New Object() {"Yes", "No"})
        Me.showComputedOnComboBox.Location = New System.Drawing.Point(275, 199)
        Me.showComputedOnComboBox.Name = "showComputedOnComboBox"
        Me.showComputedOnComboBox.Size = New System.Drawing.Size(44, 25)
        Me.showComputedOnComboBox.TabIndex = 100
        Me.showComputedOnComboBox.Text = "Yes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(255, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 17)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "?"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(255, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 17)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "?"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(255, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 17)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "?"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(255, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 17)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "?"
        '
        'SalaryDetailsConfiguartionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 243)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.showComputedOnComboBox)
        Me.Controls.Add(Me.showcalculationTypeComboBox)
        Me.Controls.Add(Me.showPayHeadTypeComboBox)
        Me.Controls.Add(Me.overrideSlabPerComboBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(347, 282)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(347, 282)
        Me.Name = "SalaryDetailsConfiguartionForm"
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents SavePayHeadButton As Button
    Friend WithEvents CancelPayHeadButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents overrideSlabPerComboBox As ComboBox
    Friend WithEvents showPayHeadTypeComboBox As ComboBox
    Friend WithEvents showcalculationTypeComboBox As ComboBox
    Friend WithEvents showComputedOnComboBox As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
End Class
