Public Class Teacher
    Inherits User
    Public Overrides ReadOnly Property Role As String
        Get
            Return "Teacher"
        End Get
    End Property
End Class