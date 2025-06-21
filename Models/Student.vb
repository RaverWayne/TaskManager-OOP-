Public Class Student
    Inherits User
    Public Overrides ReadOnly Property Role As String
        Get
            Return "Student"
        End Get
    End Property
End Class