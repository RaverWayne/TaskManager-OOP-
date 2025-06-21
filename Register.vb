Public Class Register
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' Validate inputs
        If String.IsNullOrEmpty(txtUsername.Text) OrElse
           String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Username and password are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Create user based on role
        Dim newUser As User = Nothing

        If cbStudent.Checked Then
            newUser = New Student()
        ElseIf cbTeacher.Checked Then
            newUser = New Teacher()
        ElseIf cbEmployee.Checked Then
            newUser = New Employee()
        Else
            MessageBox.Show("Please select a role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Set user properties
        newUser.Username = txtUsername.Text
        newUser.Password = txtPassword.Text
        newUser.Age = If(Integer.TryParse(txtAge.Text, New Integer), Integer.Parse(txtAge.Text), Nothing)
        newUser.Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd")
        newUser.Gender = If(rbMale.Checked, "Male", If(rbFemale.Checked, "Female", "Other"))

        ' Save user
        Try
            Dim dataService As New DataService()
            dataService.RegisterUser(newUser)

            MessageBox.Show("Registration successful! Please login with your new account.",
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear form and return to login
            ClearForm()
            Dim loginForm As New Login()
            loginForm.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Registration failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearForm()
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtAge.Text = ""
        dtpBirthday.Value = DateTime.Now
        cbStudent.Checked = False
        cbTeacher.Checked = False
        cbEmployee.Checked = False
        rbMale.Checked = False
        rbFemale.Checked = False
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub

    Private Sub dtpBirthday_Click(sender As Object, e As EventArgs) Handles Picturebox2.Click

    End Sub

    Private Sub txtAge_Click(sender As Object, e As EventArgs) Handles txtAge.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblBirthday.Click

    End Sub

    Private Sub dtpBirthday_ValueChanged(sender As Object, e As EventArgs) Handles dtpBirthday.ValueChanged

    End Sub

    Private Sub lblTaskManager_Click(sender As Object, e As EventArgs) Handles lblTaskManager.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub


End Class