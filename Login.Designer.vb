<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.txtUsername = New System.Windows.Forms.Label()
        Me.txtbUserName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.Label()
        Me.txtbPassword = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.lblTaskManager = New System.Windows.Forms.Label()
        Me.txtUsernames = New System.Windows.Forms.PictureBox()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        CType(Me.txtUsernames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUsername
        '
        Me.txtUsername.AccessibleName = ""
        Me.txtUsername.AutoSize = True
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.txtUsername.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.Black
        Me.txtUsername.Location = New System.Drawing.Point(878, 240)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(98, 24)
        Me.txtUsername.TabIndex = 0
        Me.txtUsername.Text = "Username:"
        '
        'txtbUserName
        '
        Me.txtbUserName.Location = New System.Drawing.Point(980, 242)
        Me.txtbUserName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtbUserName.Name = "txtbUserName"
        Me.txtbUserName.Size = New System.Drawing.Size(205, 22)
        Me.txtbUserName.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.AutoSize = True
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.txtPassword.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.Location = New System.Drawing.Point(882, 278)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(94, 24)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.Text = "Password:"
        '
        'txtbPassword
        '
        Me.txtbPassword.Location = New System.Drawing.Point(980, 280)
        Me.txtbPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtbPassword.Name = "txtbPassword"
        Me.txtbPassword.Size = New System.Drawing.Size(205, 22)
        Me.txtbPassword.TabIndex = 3
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.Transparent
        Me.btnLogin.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.Black
        Me.btnLogin.Location = New System.Drawing.Point(882, 339)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(127, 33)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'btnRegister
        '
        Me.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRegister.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegister.ForeColor = System.Drawing.Color.Black
        Me.btnRegister.Location = New System.Drawing.Point(1058, 339)
        Me.btnRegister.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(127, 33)
        Me.btnRegister.TabIndex = 5
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'lblTaskManager
        '
        Me.lblTaskManager.AutoSize = True
        Me.lblTaskManager.Font = New System.Drawing.Font("Bell MT", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaskManager.ForeColor = System.Drawing.Color.White
        Me.lblTaskManager.Location = New System.Drawing.Point(149, 81)
        Me.lblTaskManager.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTaskManager.Name = "lblTaskManager"
        Me.lblTaskManager.Size = New System.Drawing.Size(496, 49)
        Me.lblTaskManager.TabIndex = 6
        Me.lblTaskManager.Text = "Role-Base Task Manager"
        '
        'txtUsernames
        '
        Me.txtUsernames.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.txtUsernames.Location = New System.Drawing.Point(807, -1)
        Me.txtUsernames.Name = "txtUsernames"
        Me.txtUsernames.Size = New System.Drawing.Size(440, 697)
        Me.txtUsernames.TabIndex = 8
        Me.txtUsernames.TabStop = False
        '
        'lblWelcome
        '
        Me.lblWelcome.AccessibleName = ""
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Bell MT", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.ForeColor = System.Drawing.Color.White
        Me.lblWelcome.Location = New System.Drawing.Point(904, 153)
        Me.lblWelcome.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(257, 42)
        Me.lblWelcome.TabIndex = 9
        Me.lblWelcome.Text = "Welcome User"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(68, 220)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(658, 419)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.ErrorImage = Nothing
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.ImageLocation = ""
        Me.PictureBox2.InitialImage = Nothing
        Me.PictureBox2.Location = New System.Drawing.Point(980, 26)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(109, 104)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExit.Font = New System.Drawing.Font("Bell MT", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.Location = New System.Drawing.Point(1058, 606)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(127, 33)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1245, 695)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblTaskManager)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtbPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtbUserName)
        Me.Controls.Add(Me.txtUsernames)
        Me.ForeColor = System.Drawing.Color.Maroon
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Login"
        Me.Text = "Form1"
        CType(Me.txtUsernames, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUsername As Label
    Friend WithEvents txtbUserName As TextBox
    Friend WithEvents txtPassword As Label
    Friend WithEvents txtbPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnRegister As Button
    Friend WithEvents lblTaskManager As Label
    Friend WithEvents txtUsernames As PictureBox
    Friend WithEvents lblWelcome As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnExit As Button
End Class
