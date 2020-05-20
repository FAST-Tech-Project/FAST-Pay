<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.mainMenuPanel = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.passwordTextBox = New System.Windows.Forms.TextBox()
        Me.usernameTextBox = New System.Windows.Forms.TextBox()
        Me.connectionStatusButton = New System.Windows.Forms.Button()
        Me.connectionStateTextBox = New System.Windows.Forms.TextBox()
        Me.mainMenuPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenuPanel
        '
        Me.mainMenuPanel.BackColor = System.Drawing.Color.GhostWhite
        Me.mainMenuPanel.Controls.Add(Me.Label3)
        Me.mainMenuPanel.Controls.Add(Me.Label2)
        Me.mainMenuPanel.Controls.Add(Me.Label1)
        Me.mainMenuPanel.Controls.Add(Me.passwordTextBox)
        Me.mainMenuPanel.Controls.Add(Me.usernameTextBox)
        Me.mainMenuPanel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainMenuPanel.Location = New System.Drawing.Point(263, 139)
        Me.mainMenuPanel.Name = "mainMenuPanel"
        Me.mainMenuPanel.Size = New System.Drawing.Size(306, 233)
        Me.mainMenuPanel.TabIndex = 19
        Me.mainMenuPanel.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(116, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 32)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Login"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Password:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Username:"
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordTextBox.Location = New System.Drawing.Point(54, 160)
        Me.passwordTextBox.Name = "passwordTextBox"
        Me.passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.passwordTextBox.Size = New System.Drawing.Size(199, 25)
        Me.passwordTextBox.TabIndex = 13
        '
        'usernameTextBox
        '
        Me.usernameTextBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usernameTextBox.Location = New System.Drawing.Point(54, 99)
        Me.usernameTextBox.Name = "usernameTextBox"
        Me.usernameTextBox.Size = New System.Drawing.Size(199, 25)
        Me.usernameTextBox.TabIndex = 12
        '
        'connectionStatusButton
        '
        Me.connectionStatusButton.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.connectionStatusButton.FlatAppearance.BorderSize = 0
        Me.connectionStatusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.connectionStatusButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.connectionStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.connectionStatusButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.connectionStatusButton.ForeColor = System.Drawing.Color.White
        Me.connectionStatusButton.Location = New System.Drawing.Point(12, 12)
        Me.connectionStatusButton.Name = "connectionStatusButton"
        Me.connectionStatusButton.Size = New System.Drawing.Size(76, 24)
        Me.connectionStatusButton.TabIndex = 20
        Me.connectionStatusButton.UseVisualStyleBackColor = True
        '
        'connectionStateTextBox
        '
        Me.connectionStateTextBox.Location = New System.Drawing.Point(94, 12)
        Me.connectionStateTextBox.Name = "connectionStateTextBox"
        Me.connectionStateTextBox.ReadOnly = True
        Me.connectionStateTextBox.Size = New System.Drawing.Size(23, 22)
        Me.connectionStateTextBox.TabIndex = 21
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(835, 493)
        Me.Controls.Add(Me.connectionStateTextBox)
        Me.Controls.Add(Me.connectionStatusButton)
        Me.Controls.Add(Me.mainMenuPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mainMenuPanel.ResumeLayout(False)
        Me.mainMenuPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mainMenuPanel As Panel
    Friend WithEvents connectionStatusButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents passwordTextBox As TextBox
    Friend WithEvents usernameTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents connectionStateTextBox As TextBox
End Class
