' Employee.vb
Public Class Employee : Inherits User
    Public Sub New()
        MyBase.New() ' Call the parameterless constructor of the base User class
        Me.Role = "Employee" ' Set the specific role for Employee
    End Sub

    ' Optional: Parameterized constructor for Employee
    Public Sub New(username As String, password As String, Optional age As Integer? = Nothing, Optional birthday As String = "", Optional gender As String = "")
        MyBase.New(username, password, age, birthday, gender)
        Me.Role = "Employee"
    End Sub

    ' Add any Employee-specific properties here (e.g., Position, EmployeeID)
    '<JsonProperty> Public Property Position As String
End Class