Public Class LoginForm

    Private Sub MainPageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        repositionMainPanel()
    End Sub

    Private Sub MainPageForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        connectToServer()
        If connectionStateTextBox.Text = 1 Then
            usernameTextBox.Focus()
        End If
    End Sub

    Private Sub MainPageForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        repositionMainPanel()
    End Sub

    Private Sub connectionStatusButton_Click(sender As Object, e As EventArgs) Handles connectionStatusButton.Click
        connectToServer()
    End Sub

    Private Sub usernameTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles usernameTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub passwordTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles passwordTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            loginUser(usernameTextBox.Text, passwordTextBox.Text)
            usernameTextBox.Clear()
            passwordTextBox.Clear()
            usernameTextBox.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub repositionMainPanel()
        Dim formWidth As Integer = Me.Width
        Dim formHeight As Integer = Me.Height

        Dim mmpWidth As Integer = mainMenuPanel.Width
        Dim mmpHeight As Integer = mainMenuPanel.Height

        mainMenuPanel.Location = New Point(((formWidth - mmpWidth) / 2), ((formHeight - mmpHeight) / 2))
    End Sub

    Private Sub connectToServer()

        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                connectionStatusButton.Text = "Connected"
                connectionStatusButton.BackColor = Color.LimeGreen
                conn.Close()
                connectionStateTextBox.Text = 1
                mainMenuPanel.Visible = True
            End If
        Catch ex As Exception
            connectionStateTextBox.Text = 0
            mainMenuPanel.Visible = False
            connectionStatusButton.Text = "Connect!"
            connectionStatusButton.BackColor = Color.Tomato
            MsgBox("The server is currently down. Turn it on and connect.")
        End Try

    End Sub

    Private Sub loginUser(ByVal username As String, ByVal password As String)

        If Not String.IsNullOrEmpty(username) And Not String.IsNullOrEmpty(password) Then

            If connectionStateTextBox.Text = "1" Then
                Dim user_exist As String = runQueryAndReturnValue("SELECT `id` FROM `tbl_users` 
                                                                WHERE `username` = '" & username & "' 
                                                                AND `password` = '" & password & "'", "id")

                If user_exist <> "" Then
                    If CInt(user_exist) = 1 Then
                        PayrollForm.Show()
                        Me.Hide()
                    End If
                End If
            End If
        End If

    End Sub
End Class