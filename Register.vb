Public Class Register
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

        If String.IsNullOrWhiteSpace(txtbUserName.Text) OrElse
           String.IsNullOrWhiteSpace(txtbPassword.Text) Then
            MessageBox.Show("Username and password are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim ageValue As Integer
        Console.WriteLine($"DEBUG: Attempting to parse age. txtbAge.Text raw: '{txtbAge.Text}' (Length: {txtbAge.Text.Length})") ' Using txtbAge
        Dim parseSuccess As Boolean = Integer.TryParse(txtbAge.Text.Trim(), ageValue) ' Using txtbAge
        Console.WriteLine($"DEBUG: Integer.TryParse result: {parseSuccess}, ageValue: {ageValue}")

        If Not parseSuccess OrElse ageValue < 0 Then
            MessageBox.Show("Please enter a valid numeric age (must be 0 or greater).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim selectedRole As String = ""
        If cbStudent.Checked Then
            selectedRole = "Student"
        ElseIf cbTeacher.Checked Then
            selectedRole = "Teacher"
        ElseIf cbEmployee.Checked Then
            selectedRole = "Employee"
        End If

        If String.IsNullOrEmpty(selectedRole) Then
            MessageBox.Show("Please select a role (Student, Teacher, or Employee).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim selectedGender As String = ""
        If rbMale.Checked Then
            selectedGender = "Male"
        ElseIf rbFemale.Checked Then
            selectedGender = "Female"
        ElseIf rbOther.Checked Then
            selectedGender = "Other"
        Else
            selectedGender = "Not Specified"
        End If


        Dim newUser As User = Nothing
        Select Case selectedRole
            Case "Student"
                newUser = New Student()
            Case "Teacher"
                newUser = New Teacher()
            Case "Employee"
                newUser = New Employee()
        End Select


        newUser.Username = txtbUserName.Text.Trim()
        newUser.Password = txtbPassword.Text.Trim()
        newUser.Age = ageValue
        newUser.Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd")
        newUser.Gender = selectedGender



        Try
            Dim dataService As New DataService()
            Dim registrationSuccess As Boolean = dataService.RegisterUser(newUser)

            If registrationSuccess Then
                MessageBox.Show("Registration successful! Please login with your new account.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ClearForm()
                Dim loginForm As New Login()
                loginForm.Show()
                Me.Close()
            Else

                MessageBox.Show("Registration failed. This username might already exist, or there was an issue saving data. Check console for details.",
                                "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

            MessageBox.Show($"An unexpected error occurred during registration: {ex.Message}", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine($"ERROR: Unexpected exception during registration: {ex.Message}")
            Console.WriteLine(ex.StackTrace)
        End Try
    End Sub


    Private Sub ClearForm()
        txtbUserName.Clear()
        txtbPassword.Clear()
        txtbAge.Clear()
        dtpBirthday.Value = DateTime.Now
        cbStudent.Checked = False
        cbTeacher.Checked = False
        cbEmployee.Checked = False
        rbMale.Checked = False
        rbFemale.Checked = False
        rbOther.Checked = False
        txtbUserName.Focus()
    End Sub


    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub

    Private Sub txtAge_Click(sender As Object, e As EventArgs) Handles txtAge.Click

    End Sub

    Private Sub Picturebox2_Click(sender As Object, e As EventArgs) Handles Picturebox2.Click

    End Sub

    Private Sub lblWelcome_Click(sender As Object, e As EventArgs) Handles lblWelcome.Click

    End Sub

    Private Sub txtUsername_Click(sender As Object, e As EventArgs) Handles txtUsername.Click

    End Sub

    Private Sub txtPassword_Click(sender As Object, e As EventArgs) Handles txtPassword.Click

    End Sub

    Private Sub txtbUserName_TextChanged(sender As Object, e As EventArgs) Handles txtbUserName.TextChanged

    End Sub

    Private Sub txtbPassword_TextChanged(sender As Object, e As EventArgs) Handles txtbPassword.TextChanged

    End Sub

    Private Sub lblRoles_Click(sender As Object, e As EventArgs) Handles lblRoles.Click

    End Sub

    Private Sub txtbAge_TextChanged(sender As Object, e As EventArgs) Handles txtbAge.TextChanged

    End Sub

    Private Sub lblGender_Click(sender As Object, e As EventArgs) Handles lblGender.Click

    End Sub

    Private Sub rbMale_CheckedChanged(sender As Object, e As EventArgs) Handles rbMale.CheckedChanged

    End Sub

    Private Sub rbFemale_CheckedChanged(sender As Object, e As EventArgs) Handles rbFemale.CheckedChanged

    End Sub

    Private Sub rbOther_CheckedChanged(sender As Object, e As EventArgs) Handles rbOther.CheckedChanged

    End Sub

    Private Sub cbStudent_CheckedChanged(sender As Object, e As EventArgs) Handles cbStudent.CheckedChanged

    End Sub

    Private Sub cbTeacher_CheckedChanged(sender As Object, e As EventArgs) Handles cbTeacher.CheckedChanged

    End Sub

    Private Sub cbEmployee_CheckedChanged(sender As Object, e As EventArgs) Handles cbEmployee.CheckedChanged

    End Sub

    Private Sub lblTaskManager_Click(sender As Object, e As EventArgs) Handles lblTaskManager.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub dtpBirthday_ValueChanged(sender As Object, e As EventArgs) Handles dtpBirthday.ValueChanged

    End Sub

    Private Sub lblBirthday_Click(sender As Object, e As EventArgs) Handles lblBirthday.Click

    End Sub
End Class