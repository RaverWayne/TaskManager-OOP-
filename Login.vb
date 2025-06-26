Public Class Login

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If String.IsNullOrWhiteSpace(txtbUserName.Text) OrElse
           String.IsNullOrWhiteSpace(txtbPassword.Text) Then
            MessageBox.Show("Please enter both username and password.",
                            "Login Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If


        Dim dataService As New DataService()
        Dim user = dataService.Authenticate(txtbUserName.Text, txtbPassword.Text)

        If user IsNot Nothing Then

            MessageBox.Show($"Welcome, {user.Username} ({user.Role})!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim dashboard As New MainDashboard()
            Try

                dashboard.CurrentUser = user
                dashboard.Show()
                Me.Hide()
            Catch ex As Exception

                MessageBox.Show($"An error occurred while preparing the dashboard: {ex.Message}", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine($"ERROR: Exception when setting CurrentUser or showing Dashboard: {ex.Message}")
                Console.WriteLine(ex.StackTrace)
            End Try
        Else

            MessageBox.Show("Invalid credentials or no users registered yet. Please check your username and password.",
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


    Private Sub txtbUserName_TextChanged(sender As Object, e As EventArgs) Handles txtbUserName.TextChanged

    End Sub


    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtbUserName.Clear()
        txtbPassword.Clear()
    End Sub

    Private Sub Login_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        txtbUserName.Clear()
        txtbPassword.Clear()
        txtbUserName.Focus()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub lblWelcome_Click(sender As Object, e As EventArgs) Handles lblWelcome.Click

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?",
                                              "Exit Application",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class