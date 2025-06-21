Public Class Employee
    Inherits User
    Public Overrides ReadOnly Property Role As String
        Get
            Return "Employee"
        End Get
    End Property
End Class