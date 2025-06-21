' User.vb
' Make sure you have Newtonsoft.Json installed via NuGet Package Manager
Imports Newtonsoft.Json

' JsonObject attribute helps Json.NET know which properties to serialize/deserialize
<JsonObject(MemberSerialization.OptIn)>
Public MustInherit Class User
    <JsonProperty>
    Public Property Username As String
    <JsonProperty>
    Public Property Password As String ' IMPORTANT: In a real-world app, you MUST hash and salt passwords!
    <JsonProperty>
    Public Property Age As Integer? ' Nullable Integer, allows for cases where age might not be provided
    <JsonProperty>
    Public Property Birthday As String ' Storing as string in "yyyy-MM-dd" format for simplicity
    <JsonProperty>
    Public Property Gender As String
    <JsonProperty>
    Public Property Role As String ' Explicitly stores the user's role (e.g., "Student", "Teacher", "Employee")

    ' Parameterless constructor: Essential for Json.NET deserialization
    Public Sub New()
        Me.Age = Nothing ' Explicitly set nullable properties to Nothing (default is usually 0 for Integer)
    End Sub

    ' Optional: Parameterized constructor for convenience when creating new users in code
    Public Sub New(username As String, password As String, Optional age As Integer? = Nothing, Optional birthday As String = "", Optional gender As String = "")
        Me.Username = username
        Me.Password = password
        Me.Age = age
        Me.Birthday = birthday
        Me.Gender = gender
        ' Role will be set by the derived class's constructor
    End Sub

    ' For easier debugging and display in console/messages
    Public Overrides Function ToString() As String
        Return $"Username: {Username}, Role: {Role}, Age: {Age}, Gender: {Gender}"
    End Function
End Class