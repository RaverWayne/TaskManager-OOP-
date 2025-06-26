Imports Newtonsoft.Json
<JsonObject(MemberSerialization.OptIn)>
Public MustInherit Class User
    <JsonProperty>
    Public Property Username As String
    <JsonProperty>
    Public Property Password As String
    <JsonProperty>
    Public Property Age As Integer?
    <JsonProperty>
    Public Property Birthday As String
    <JsonProperty>
    Public Property Gender As String
    <JsonProperty>
    Public Property Role As String

    Public Sub New()
        Me.Age = Nothing
    End Sub

    Public Sub New(username As String, password As String, Optional age As Integer? = Nothing, Optional birthday As String = "", Optional gender As String = "")
        Me.Username = username
        Me.Password = password
        Me.Age = age
        Me.Birthday = birthday
        Me.Gender = gender
    End Sub

    Public Overrides Function ToString() As String
        Return $"Username: {Username}, Role: {Role}, Age: {Age}, Gender: {Gender}"
    End Function
End Class