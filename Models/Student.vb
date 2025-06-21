' Student.vb
Public Class Student : Inherits User
    Public Sub New()
        MyBase.New() ' Call the parameterless constructor of the base User class
        Me.Role = "Student" ' Set the specific role for Student
    End Sub

    ' Optional: Parameterized constructor for Student
    Public Sub New(username As String, password As String, Optional age As Integer? = Nothing, Optional birthday As String = "", Optional gender As String = "")
        MyBase.New(username, password, age, birthday, gender)
        Me.Role = "Student"
    End Sub

    ' Add any Student-specific properties here (e.g., StudentID, Grade)
    '<JsonProperty> Public Property StudentId As String
End Class