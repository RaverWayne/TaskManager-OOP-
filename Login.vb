Public Class Login
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Validate inputs aren't empty
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter both username and password",
                          "Login Failed",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
            Return
        End If

        Dim dataService As New DataService()
        Dim user = dataService.Authenticate(txtUsername.Text, txtPassword.Text)

        If user IsNot Nothing Then
            ' Successful login
            Dim dashboard As New MainDashboard()
            dashboard.CurrentUser = user
            dashboard.Show()
            Me.Hide()
        Else
            ' Failed login
            MessageBox.Show("Invalid credentials or no users registered yet",
                          "Login Failed",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim registerForm As New Register()
        registerForm.Show()
        Me.Hide()
    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles txtUsername.Click
    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles txtPassword.Click
    End Sub

    Private Sub Label1_Click_2(sender As Object, e As EventArgs) Handles lblTaskManager.Click
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Label1_Click_3(sender As Object, e As EventArgs) Handles lblWelcome.Click
    End Sub

    Private Sub Label1_Click_4(sender As Object, e As EventArgs)
    End Sub
End Class