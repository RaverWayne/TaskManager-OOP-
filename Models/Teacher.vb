Public Class Teacher : Inherits User
    Public Sub New()
        MyBase.New()
        Me.Role = "Teacher"
    End Sub


    Public Sub New(username As String, password As String, Optional age As Integer? = Nothing, Optional birthday As String = "", Optional gender As String = "")
        MyBase.New(username, password, age, birthday, gender)
        Me.Role = "Teacher"
    End Sub
End Class
