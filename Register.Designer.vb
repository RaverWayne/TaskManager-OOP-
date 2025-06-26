<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register
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
        Me.Picturebox2 = New System.Windows.Forms.PictureBox()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.Label()
        Me.txtbUserName = New System.Windows.Forms.TextBox()
        Me.txtbPassword = New System.Windows.Forms.TextBox()
        Me.txtAge = New System.Windows.Forms.Label()
        Me.lblRoles = New System.Windows.Forms.Label()
        Me.txtbAge = New System.Windows.Forms.TextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.rbMale = New System.Windows.Forms.RadioButton()
        Me.rbFemale = New System.Windows.Forms.RadioButton()
        Me.rbOther = New System.Windows.Forms.RadioButton()
        Me.cbStudent = New System.Windows.Forms.CheckBox()
        Me.cbTeacher = New System.Windows.Forms.CheckBox()
        Me.cbEmployee = New System.Windows.Forms.CheckBox()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblTaskManager = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dtpBirthday = New System.Windows.Forms.DateTimePicker()
        Me.lblBirthday = New System.Windows.Forms.Label()
        CType(Me.Picturebox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Picturebox2
        '
        Me.Picturebox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Picturebox2.Location = New System.Drawing.Point(811, 1)
        Me.Picturebox2.Name = "Picturebox2"
        Me.Picturebox2.Size = New System.Drawing.Size(440, 697)
        Me.Picturebox2.TabIndex = 9
        Me.Picturebox2.TabStop = False
        '
        'lblWelcome
        '
        Me.lblWelcome.AccessibleName = ""
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.lblWelcome.Font = New System.Drawing.Font("Bell MT", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.ForeColor = System.Drawing.Color.White
        Me.lblWelcome.Location = New System.Drawing.Point(862, 108)
        Me.lblWelcome.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(257, 42)
        Me.lblWelcome.TabIndex = 10
        Me.lblWelcome.Text = "Welcome User"
        '
        'txtUsername
        '
        Me.txtUsername.AccessibleName = ""
        Me.txtUsername.AutoSize = True
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.txtUsername.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.Black
        Me.txtUsername.Location = New System.Drawing.Point(869, 199)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(98, 24)
        Me.txtUsername.TabIndex = 11
        Me.txtUsername.Text = "Username:"
        '
        'txtPassword
        '
        Me.txtPassword.AutoSize = True
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.txtPassword.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.Location = New System.Drawing.Point(869, 238)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(94, 24)
        Me.txtPassword.TabIndex = 12
        Me.txtPassword.Text = "Password:"
        '
        'txtbUserName
        '
        Me.txtbUserName.Location = New System.Drawing.Point(985, 201)
        Me.txtbUserName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtbUserName.Name = "txtbUserName"
        Me.txtbUserName.Size = New System.Drawing.Size(205, 22)
        Me.txtbUserName.TabIndex = 13
        '
        'txtbPassword
        '
        Me.txtbPassword.Location = New System.Drawing.Point(985, 240)
        Me.txtbPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtbPassword.Name = "txtbPassword"
        Me.txtbPassword.Size = New System.Drawing.Size(205, 22)
        Me.txtbPassword.TabIndex = 14
        '
        'txtAge
        '
        Me.txtAge.AutoSize = True
        Me.txtAge.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.txtAge.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAge.ForeColor = System.Drawing.Color.Black
        Me.txtAge.Location = New System.Drawing.Point(919, 274)
        Me.txtAge.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(48, 24)
        Me.txtAge.TabIndex = 15
        Me.txtAge.Text = "Age:"
        '
        'lblRoles
        '
        Me.lblRoles.AutoSize = True
        Me.lblRoles.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.lblRoles.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoles.ForeColor = System.Drawing.Color.Black
        Me.lblRoles.Location = New System.Drawing.Point(865, 456)
        Me.lblRoles.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRoles.Name = "lblRoles"
        Me.lblRoles.Size = New System.Drawing.Size(108, 24)
        Me.lblRoles.TabIndex = 16
        Me.lblRoles.Text = "Select Role:"
        '
        'txtbAge
        '
        Me.txtbAge.Location = New System.Drawing.Point(985, 276)
        Me.txtbAge.Margin = New System.Windows.Forms.Padding(4)
        Me.txtbAge.Name = "txtbAge"
        Me.txtbAge.Size = New System.Drawing.Size(205, 22)
        Me.txtbAge.TabIndex = 17
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.lblGender.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.ForeColor = System.Drawing.Color.Black
        Me.lblGender.Location = New System.Drawing.Point(891, 362)
        Me.lblGender.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(76, 24)
        Me.lblGender.TabIndex = 20
        Me.lblGender.Text = "Gender:"
        '
        'rbMale
        '
        Me.rbMale.AutoSize = True
        Me.rbMale.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.rbMale.ForeColor = System.Drawing.Color.Black
        Me.rbMale.Location = New System.Drawing.Point(985, 366)
        Me.rbMale.Name = "rbMale"
        Me.rbMale.Size = New System.Drawing.Size(58, 20)
        Me.rbMale.TabIndex = 21
        Me.rbMale.TabStop = True
        Me.rbMale.Text = "Male"
        Me.rbMale.UseVisualStyleBackColor = False
        '
        'rbFemale
        '
        Me.rbFemale.AutoSize = True
        Me.rbFemale.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.rbFemale.Location = New System.Drawing.Point(985, 392)
        Me.rbFemale.Name = "rbFemale"
        Me.rbFemale.Size = New System.Drawing.Size(74, 20)
        Me.rbFemale.TabIndex = 22
        Me.rbFemale.TabStop = True
        Me.rbFemale.Text = "Female"
        Me.rbFemale.UseVisualStyleBackColor = False
        '
        'rbOther
        '
        Me.rbOther.AutoSize = True
        Me.rbOther.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.rbOther.Location = New System.Drawing.Point(985, 418)
        Me.rbOther.Name = "rbOther"
        Me.rbOther.Size = New System.Drawing.Size(60, 20)
        Me.rbOther.TabIndex = 23
        Me.rbOther.TabStop = True
        Me.rbOther.Text = "Other"
        Me.rbOther.UseVisualStyleBackColor = False
        '
        'cbStudent
        '
        Me.cbStudent.AutoSize = True
        Me.cbStudent.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.cbStudent.Location = New System.Drawing.Point(985, 456)
        Me.cbStudent.Name = "cbStudent"
        Me.cbStudent.Size = New System.Drawing.Size(74, 20)
        Me.cbStudent.TabIndex = 24
        Me.cbStudent.Text = "Student"
        Me.cbStudent.UseVisualStyleBackColor = False
        '
        'cbTeacher
        '
        Me.cbTeacher.AutoSize = True
        Me.cbTeacher.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.cbTeacher.Location = New System.Drawing.Point(985, 482)
        Me.cbTeacher.Name = "cbTeacher"
        Me.cbTeacher.Size = New System.Drawing.Size(80, 20)
        Me.cbTeacher.TabIndex = 25
        Me.cbTeacher.Text = "Teacher"
        Me.cbTeacher.UseVisualStyleBackColor = False
        '
        'cbEmployee
        '
        Me.cbEmployee.AutoSize = True
        Me.cbEmployee.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.cbEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cbEmployee.Location = New System.Drawing.Point(985, 508)
        Me.cbEmployee.Name = "cbEmployee"
        Me.cbEmployee.Size = New System.Drawing.Size(91, 20)
        Me.cbEmployee.TabIndex = 26
        Me.cbEmployee.Text = "Employee"
        Me.cbEmployee.UseVisualStyleBackColor = False
        '
        'btnRegister
        '
        Me.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRegister.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegister.ForeColor = System.Drawing.Color.Black
        Me.btnRegister.Location = New System.Drawing.Point(895, 566)
        Me.btnRegister.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(127, 33)
        Me.btnRegister.TabIndex = 27
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.Black
        Me.btnBack.Location = New System.Drawing.Point(1040, 566)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(150, 33)
        Me.btnBack.TabIndex = 28
        Me.btnBack.Text = "Back to Login"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'lblTaskManager
        '
        Me.lblTaskManager.AutoSize = True
        Me.lblTaskManager.Font = New System.Drawing.Font("Bell MT", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaskManager.ForeColor = System.Drawing.Color.White
        Me.lblTaskManager.Location = New System.Drawing.Point(146, 72)
        Me.lblTaskManager.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTaskManager.Name = "lblTaskManager"
        Me.lblTaskManager.Size = New System.Drawing.Size(496, 49)
        Me.lblTaskManager.TabIndex = 29
        Me.lblTaskManager.Text = "Role-Base Task Manager"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(71, 207)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(658, 419)
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'dtpBirthday
        '
        Me.dtpBirthday.CustomFormat = "yyyy-MM-dd"
        Me.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBirthday.Location = New System.Drawing.Point(985, 316)
        Me.dtpBirthday.Name = "dtpBirthday"
        Me.dtpBirthday.Size = New System.Drawing.Size(205, 22)
        Me.dtpBirthday.TabIndex = 31
        '
        'lblBirthday
        '
        Me.lblBirthday.AutoSize = True
        Me.lblBirthday.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.lblBirthday.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBirthday.ForeColor = System.Drawing.Color.Black
        Me.lblBirthday.Location = New System.Drawing.Point(880, 314)
        Me.lblBirthday.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBirthday.Name = "lblBirthday"
        Me.lblBirthday.Size = New System.Drawing.Size(87, 24)
        Me.lblBirthday.TabIndex = 32
        Me.lblBirthday.Text = "Birthday:"
        '
        'Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1247, 694)
        Me.Controls.Add(Me.lblBirthday)
        Me.Controls.Add(Me.dtpBirthday)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTaskManager)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.cbEmployee)
        Me.Controls.Add(Me.cbTeacher)
        Me.Controls.Add(Me.cbStudent)
        Me.Controls.Add(Me.rbOther)
        Me.Controls.Add(Me.rbFemale)
        Me.Controls.Add(Me.rbMale)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.txtbAge)
        Me.Controls.Add(Me.lblRoles)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.txtbPassword)
        Me.Controls.Add(Me.txtbUserName)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.Picturebox2)
        Me.Name = "Register"
        Me.Text = "Register"
        CType(Me.Picturebox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Picturebox2 As PictureBox
    Friend WithEvents lblWelcome As Label
    Friend WithEvents txtUsername As Label
    Friend WithEvents txtPassword As Label
    Friend WithEvents txtbUserName As TextBox
    Friend WithEvents txtbPassword As TextBox
    Friend WithEvents txtAge As Label
    Friend WithEvents lblRoles As Label
    Friend WithEvents txtbAge As TextBox
    Friend WithEvents lblGender As Label
    Friend WithEvents rbMale As RadioButton
    Friend WithEvents rbFemale As RadioButton
    Friend WithEvents rbOther As RadioButton
    Friend WithEvents cbStudent As CheckBox
    Friend WithEvents cbTeacher As CheckBox
    Friend WithEvents cbEmployee As CheckBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents lblTaskManager As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dtpBirthday As DateTimePicker
    Friend WithEvents lblBirthday As Label
End Class
