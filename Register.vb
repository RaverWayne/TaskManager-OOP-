Public Class Register
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' --- Input Validation ---
        If String.IsNullOrWhiteSpace(txtbUserName.Text) OrElse ' Using txtbUserName
           String.IsNullOrWhiteSpace(txtbPassword.Text) Then  ' Using txtbPassword
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
        If cbStudent.Checked Then    ' Using cbStudent
            selectedRole = "Student"
        ElseIf cbTeacher.Checked Then ' Using cbTeacher
            selectedRole = "Teacher"
        ElseIf cbEmployee.Checked Then ' Using cbEmployee
            selectedRole = "Employee"
        End If

        If String.IsNullOrEmpty(selectedRole) Then
            MessageBox.Show("Please select a role (Student, Teacher, or Employee).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim selectedGender As String = ""
        If rbMale.Checked Then    ' Using rbMale
            selectedGender = "Male"
        ElseIf rbFemale.Checked Then ' Using rbFemale
            selectedGender = "Female"
        ElseIf rbOther.Checked Then  ' Using rbOther
            selectedGender = "Other"
        Else
            selectedGender = "Not Specified" ' Default if none selected
        End If

        ' --- Create User Object based on Selected Role ---
        Dim newUser As User = Nothing
        Select Case selectedRole
            Case "Student"
                newUser = New Student()
            Case "Teacher"
                newUser = New Teacher()
            Case "Employee"
                newUser = New Employee()
        End Select

        ' --- Populate User Properties ---
        newUser.Username = txtbUserName.Text.Trim() ' Using txtbUserName
        newUser.Password = txtbPassword.Text.Trim() ' Using txtbPassword
        newUser.Age = ageValue
        newUser.Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd") ' Using dtpBirthday
        newUser.Gender = selectedGender
        ' Role is already set by the derived class constructor (e.g., New Student() sets Role = "Student")

        ' --- Attempt Registration via DataService ---
        Try
            Dim dataService As New DataService()
            Dim registrationSuccess As Boolean = dataService.RegisterUser(newUser)

            If registrationSuccess Then
                MessageBox.Show("Registration successful! Please login with your new account.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ClearForm() ' Clear registration form fields
                Dim loginForm As New Login()
                loginForm.Show() ' Go back to the login form
                Me.Close()       ' Close the registration form
            Else
                ' This branch is hit if RegisterUser returns False (e.g., username already exists)
                MessageBox.Show("Registration failed. This username might already exist, or there was an issue saving data. Check console for details.",
                                "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Catch any unexpected errors during the registration process
            MessageBox.Show($"An unexpected error occurred during registration: {ex.Message}", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine($"ERROR: Unexpected exception during registration: {ex.Message}")
            Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    ' Helper method to clear all input fields on the form
    Private Sub ClearForm()
        txtbUserName.Clear() ' Using txtbUserName
        txtbPassword.Clear() ' Using txtbPassword
        txtbAge.Clear()      ' Using txtbAge
        dtpBirthday.Value = DateTime.Now ' Using dtpBirthday
        cbStudent.Checked = False
        cbTeacher.Checked = False
        cbEmployee.Checked = False
        rbMale.Checked = False
        rbFemale.Checked = False
        rbOther.Checked = False ' Using rbOther
        txtbUserName.Focus() ' Set focus back to username field
    End Sub

    ' Handles the Back button click event to return to Login
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click ' Using btnBack
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub

End Class