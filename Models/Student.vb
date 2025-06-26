Public Class Student : Inherits User
    Public Sub New()
        MyBase.New()
        Me.Role = "Student"
    End Sub


    Public Sub New(username As String, password As String, Optional age As Integer? = Nothing, Optional birthday As String = "", Optional gender As String = "")
        MyBase.New(username, password, age, birthday, gender)
        Me.Role = "Student"
    End Sub
End Class