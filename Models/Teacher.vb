' Teacher.vb
Public Class Teacher : Inherits User
    Public Sub New()
        MyBase.New() ' Call the parameterless constructor of the base User class
        Me.Role = "Teacher" ' Set the specific role for Teacher
    End Sub

    ' Optional: Parameterized constructor for Teacher
    Public Sub New(username As String, password As String, Optional age As Integer? = Nothing, Optional birthday As String = "", Optional gender As String = "")
        MyBase.New(username, password, age, birthday, gender)
        Me.Role = "Teacher"
    End Sub

    ' Add any Teacher-specific properties here (e.g., Department, EmployeeID)
    '<JsonProperty> Public Property Department As String
End Class