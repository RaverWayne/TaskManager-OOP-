Public Class Login
    ' Handles the Login button click event
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' --- Input Validation ---
        If String.IsNullOrWhiteSpace(txtbUserName.Text) OrElse
           String.IsNullOrWhiteSpace(txtbPassword.Text) Then
            MessageBox.Show("Please enter both username and password.",
                            "Login Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return ' Stop execution if validation fails
        End If

        ' --- Authentication Logic ---
        Dim dataService As New DataService()
        Dim user = dataService.Authenticate(txtbUserName.Text, txtbPassword.Text)

        If user IsNot Nothing Then
            ' --- Successful Login ---
            MessageBox.Show($"Welcome, {user.Username} ({user.Role})!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim dashboard As New MainDashboard()
            Try
                ' Pass the authenticated user object to the dashboard
                dashboard.CurrentUser = user
                dashboard.Show() ' Show the dashboard form
                Me.Hide()        ' Hide the current login form
            Catch ex As Exception
                ' Catch any errors that occur specifically when opening the dashboard
                MessageBox.Show($"An error occurred while preparing the dashboard: {ex.Message}", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine($"ERROR: Exception when setting CurrentUser or showing Dashboard: {ex.Message}")
                Console.WriteLine(ex.StackTrace)
            End Try
        Else
            ' --- Failed Login ---
            MessageBox.Show("Invalid credentials or no users registered yet. Please check your username and password.",
                            "Login Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End If
    End Sub

    ' Handles the Register button click event
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim registerForm As New Register()
        registerForm.Show() ' Show the registration form
        Me.Hide()           ' Hide the current login form
    End Sub

    ' Optional: This handler was mentioned previously and is now correctly linked.
    Private Sub txtbUserName_TextChanged(sender As Object, e As EventArgs) Handles txtbUserName.TextChanged
        ' This handler is currently empty.
    End Sub

    ' Optional: Clear fields when the form loads/activates for a clean start
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtbUserName.Clear()
        txtbPassword.Clear()
    End Sub

    Private Sub Login_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ' This ensures fields are clear if you return to Login from Register/Dashboard
        txtbUserName.Clear()
        txtbPassword.Clear()
        txtbUserName.Focus() ' Set focus to username for convenience
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