<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeSetupForm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.branchesSelectedPanel = New System.Windows.Forms.Panel()
        Me.BranchesButton = New System.Windows.Forms.Button()
        Me.groupsSelectedPanel = New System.Windows.Forms.Panel()
        Me.departmentSelectedPanel = New System.Windows.Forms.Panel()
        Me.categoriesSelectedPanel = New System.Windows.Forms.Panel()
        Me.groupsButton = New System.Windows.Forms.Button()
        Me.departmentsButton = New System.Windows.Forms.Button()
        Me.categoriesButton = New System.Windows.Forms.Button()
        Me.displayDataGridView = New System.Windows.Forms.DataGridView()
        Me.displayPanel = New System.Windows.Forms.Panel()
        Me.selectedCategoryIDTextBox = New System.Windows.Forms.TextBox()
        Me.categoryComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.currentNameTextBox = New System.Windows.Forms.TextBox()
        Me.newNameTextBox = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.selectedDatagridIDTextBox = New System.Windows.Forms.TextBox()
        Me.cancelEmpSetupButton = New System.Windows.Forms.Button()
        Me.saveEmpSetupButton = New System.Windows.Forms.Button()
        Me.clickedButtonCheckTextBox = New System.Windows.Forms.TextBox()
        Me.AddNewEmpSetupButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.displayDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.displayPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.branchesSelectedPanel)
        Me.Panel1.Controls.Add(Me.BranchesButton)
        Me.Panel1.Controls.Add(Me.groupsSelectedPanel)
        Me.Panel1.Controls.Add(Me.departmentSelectedPanel)
        Me.Panel1.Controls.Add(Me.categoriesSelectedPanel)
        Me.Panel1.Controls.Add(Me.groupsButton)
        Me.Panel1.Controls.Add(Me.departmentsButton)
        Me.Panel1.Controls.Add(Me.categoriesButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(104, 226)
        Me.Panel1.TabIndex = 3
        '
        'branchesSelectedPanel
        '
        Me.branchesSelectedPanel.Location = New System.Drawing.Point(95, 24)
        Me.branchesSelectedPanel.Name = "branchesSelectedPanel"
        Me.branchesSelectedPanel.Size = New System.Drawing.Size(13, 22)
        Me.branchesSelectedPanel.TabIndex = 8
        '
        'BranchesButton
        '
        Me.BranchesButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranchesButton.Location = New System.Drawing.Point(11, 24)
        Me.BranchesButton.Name = "BranchesButton"
        Me.BranchesButton.Size = New System.Drawing.Size(82, 23)
        Me.BranchesButton.TabIndex = 9
        Me.BranchesButton.Text = "Branches"
        Me.BranchesButton.UseVisualStyleBackColor = True
        '
        'groupsSelectedPanel
        '
        Me.groupsSelectedPanel.Location = New System.Drawing.Point(95, 111)
        Me.groupsSelectedPanel.Name = "groupsSelectedPanel"
        Me.groupsSelectedPanel.Size = New System.Drawing.Size(10, 23)
        Me.groupsSelectedPanel.TabIndex = 6
        '
        'departmentSelectedPanel
        '
        Me.departmentSelectedPanel.Location = New System.Drawing.Point(95, 53)
        Me.departmentSelectedPanel.Name = "departmentSelectedPanel"
        Me.departmentSelectedPanel.Size = New System.Drawing.Size(10, 23)
        Me.departmentSelectedPanel.TabIndex = 6
        '
        'categoriesSelectedPanel
        '
        Me.categoriesSelectedPanel.Location = New System.Drawing.Point(95, 82)
        Me.categoriesSelectedPanel.Name = "categoriesSelectedPanel"
        Me.categoriesSelectedPanel.Size = New System.Drawing.Size(10, 23)
        Me.categoriesSelectedPanel.TabIndex = 5
        '
        'groupsButton
        '
        Me.groupsButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupsButton.Location = New System.Drawing.Point(11, 111)
        Me.groupsButton.Name = "groupsButton"
        Me.groupsButton.Size = New System.Drawing.Size(82, 23)
        Me.groupsButton.TabIndex = 7
        Me.groupsButton.Text = "Groups"
        Me.groupsButton.UseVisualStyleBackColor = True
        '
        'departmentsButton
        '
        Me.departmentsButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.departmentsButton.Location = New System.Drawing.Point(11, 53)
        Me.departmentsButton.Name = "departmentsButton"
        Me.departmentsButton.Size = New System.Drawing.Size(82, 23)
        Me.departmentsButton.TabIndex = 6
        Me.departmentsButton.Text = "Departments"
        Me.departmentsButton.UseVisualStyleBackColor = True
        '
        'categoriesButton
        '
        Me.categoriesButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categoriesButton.Location = New System.Drawing.Point(11, 82)
        Me.categoriesButton.Name = "categoriesButton"
        Me.categoriesButton.Size = New System.Drawing.Size(82, 23)
        Me.categoriesButton.TabIndex = 5
        Me.categoriesButton.Text = "Categories"
        Me.categoriesButton.UseVisualStyleBackColor = True
        '
        'displayDataGridView
        '
        Me.displayDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.displayDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.displayDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.displayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.displayDataGridView.DefaultCellStyle = DataGridViewCellStyle4
        Me.displayDataGridView.Location = New System.Drawing.Point(10, 8)
        Me.displayDataGridView.Name = "displayDataGridView"
        Me.displayDataGridView.RowHeadersVisible = False
        Me.displayDataGridView.Size = New System.Drawing.Size(158, 169)
        Me.displayDataGridView.TabIndex = 4
        '
        'displayPanel
        '
        Me.displayPanel.BackColor = System.Drawing.Color.White
        Me.displayPanel.Controls.Add(Me.selectedCategoryIDTextBox)
        Me.displayPanel.Controls.Add(Me.categoryComboBox)
        Me.displayPanel.Controls.Add(Me.Label2)
        Me.displayPanel.Controls.Add(Me.Label1)
        Me.displayPanel.Controls.Add(Me.currentNameTextBox)
        Me.displayPanel.Controls.Add(Me.newNameTextBox)
        Me.displayPanel.Controls.Add(Me.displayDataGridView)
        Me.displayPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.displayPanel.Location = New System.Drawing.Point(104, 0)
        Me.displayPanel.Name = "displayPanel"
        Me.displayPanel.Size = New System.Drawing.Size(178, 188)
        Me.displayPanel.TabIndex = 6
        '
        'selectedCategoryIDTextBox
        '
        Me.selectedCategoryIDTextBox.Enabled = False
        Me.selectedCategoryIDTextBox.Location = New System.Drawing.Point(196, 67)
        Me.selectedCategoryIDTextBox.Name = "selectedCategoryIDTextBox"
        Me.selectedCategoryIDTextBox.Size = New System.Drawing.Size(21, 20)
        Me.selectedCategoryIDTextBox.TabIndex = 10
        '
        'categoryComboBox
        '
        Me.categoryComboBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categoryComboBox.FormattingEnabled = True
        Me.categoryComboBox.Location = New System.Drawing.Point(223, 63)
        Me.categoryComboBox.Name = "categoryComboBox"
        Me.categoryComboBox.Size = New System.Drawing.Size(138, 23)
        Me.categoryComboBox.TabIndex = 9
        Me.categoryComboBox.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(220, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(220, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'currentNameTextBox
        '
        Me.currentNameTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currentNameTextBox.Location = New System.Drawing.Point(223, 65)
        Me.currentNameTextBox.Name = "currentNameTextBox"
        Me.currentNameTextBox.ReadOnly = True
        Me.currentNameTextBox.Size = New System.Drawing.Size(138, 23)
        Me.currentNameTextBox.TabIndex = 6
        Me.currentNameTextBox.Visible = False
        '
        'newNameTextBox
        '
        Me.newNameTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newNameTextBox.Location = New System.Drawing.Point(223, 109)
        Me.newNameTextBox.Name = "newNameTextBox"
        Me.newNameTextBox.Size = New System.Drawing.Size(138, 23)
        Me.newNameTextBox.TabIndex = 5
        Me.newNameTextBox.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.selectedDatagridIDTextBox)
        Me.Panel2.Controls.Add(Me.cancelEmpSetupButton)
        Me.Panel2.Controls.Add(Me.saveEmpSetupButton)
        Me.Panel2.Controls.Add(Me.clickedButtonCheckTextBox)
        Me.Panel2.Controls.Add(Me.AddNewEmpSetupButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(104, 188)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(178, 38)
        Me.Panel2.TabIndex = 7
        Me.Panel2.Visible = False
        '
        'selectedDatagridIDTextBox
        '
        Me.selectedDatagridIDTextBox.Enabled = False
        Me.selectedDatagridIDTextBox.Location = New System.Drawing.Point(119, 8)
        Me.selectedDatagridIDTextBox.Name = "selectedDatagridIDTextBox"
        Me.selectedDatagridIDTextBox.Size = New System.Drawing.Size(21, 20)
        Me.selectedDatagridIDTextBox.TabIndex = 5
        '
        'cancelEmpSetupButton
        '
        Me.cancelEmpSetupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cancelEmpSetupButton.FlatAppearance.BorderSize = 0
        Me.cancelEmpSetupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelEmpSetupButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelEmpSetupButton.ForeColor = System.Drawing.Color.White
        Me.cancelEmpSetupButton.Location = New System.Drawing.Point(253, 9)
        Me.cancelEmpSetupButton.Name = "cancelEmpSetupButton"
        Me.cancelEmpSetupButton.Size = New System.Drawing.Size(50, 20)
        Me.cancelEmpSetupButton.TabIndex = 4
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
        Me.saveEmpSetupButton.Location = New System.Drawing.Point(309, 9)
        Me.saveEmpSetupButton.Name = "saveEmpSetupButton"
        Me.saveEmpSetupButton.Size = New System.Drawing.Size(52, 20)
        Me.saveEmpSetupButton.TabIndex = 3
        Me.saveEmpSetupButton.Text = "Save"
        Me.saveEmpSetupButton.UseVisualStyleBackColor = False
        Me.saveEmpSetupButton.Visible = False
        '
        'clickedButtonCheckTextBox
        '
        Me.clickedButtonCheckTextBox.Enabled = False
        Me.clickedButtonCheckTextBox.Location = New System.Drawing.Point(92, 8)
        Me.clickedButtonCheckTextBox.Name = "clickedButtonCheckTextBox"
        Me.clickedButtonCheckTextBox.Size = New System.Drawing.Size(21, 20)
        Me.clickedButtonCheckTextBox.TabIndex = 2
        '
        'AddNewEmpSetupButton
        '
        Me.AddNewEmpSetupButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddNewEmpSetupButton.Location = New System.Drawing.Point(10, 8)
        Me.AddNewEmpSetupButton.Name = "AddNewEmpSetupButton"
        Me.AddNewEmpSetupButton.Size = New System.Drawing.Size(67, 20)
        Me.AddNewEmpSetupButton.TabIndex = 1
        Me.AddNewEmpSetupButton.Text = "Add New"
        Me.AddNewEmpSetupButton.UseVisualStyleBackColor = True
        '
        'EmployeeSetupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(282, 226)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.displayPanel)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(494, 265)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(298, 265)
        Me.Name = "EmployeeSetupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EmployeeSetupForm"
        Me.Panel1.ResumeLayout(False)
        CType(Me.displayDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.displayPanel.ResumeLayout(False)
        Me.displayPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents displayDataGridView As DataGridView
    Friend WithEvents groupsSelectedPanel As Panel
    Friend WithEvents departmentSelectedPanel As Panel
    Friend WithEvents categoriesSelectedPanel As Panel
    Friend WithEvents groupsButton As Button
    Friend WithEvents departmentsButton As Button
    Friend WithEvents categoriesButton As Button
    Friend WithEvents displayPanel As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents AddNewEmpSetupButton As Button
    Friend WithEvents clickedButtonCheckTextBox As TextBox
    Friend WithEvents saveEmpSetupButton As Button
    Friend WithEvents cancelEmpSetupButton As Button
    Friend WithEvents currentNameTextBox As TextBox
    Friend WithEvents newNameTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents categoryComboBox As ComboBox
    Friend WithEvents selectedDatagridIDTextBox As TextBox
    Friend WithEvents selectedCategoryIDTextBox As TextBox
    Friend WithEvents branchesSelectedPanel As Panel
    Friend WithEvents BranchesButton As Button
End Class
