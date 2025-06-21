Imports Newtonsoft.Json
Imports System.IO
Imports System.Linq

Public Class DataService
    Private ReadOnly DataFile As String = "users.json"
    Private _users As New List(Of User)()

    Public Sub New()
        LoadUsers()
    End Sub

    Public Function Authenticate(username As String, password As String) As User
        ' Strict validation - user must exist in registered users list
        If Not _users.Any() Then
            Return Nothing ' No users registered yet
        End If

        ' Exact match required for both username and password
        Dim authenticatedUser = _users.FirstOrDefault(
            Function(u) u.Username = username AndAlso
                       u.Password = password AndAlso
                       Not String.IsNullOrWhiteSpace(u.Username))

        Return authenticatedUser
    End Function

    Public Function RegisterUser(user As User) As Boolean
        ' Validate required fields
        If String.IsNullOrWhiteSpace(user.Username) OrElse
           String.IsNullOrWhiteSpace(user.Password) Then
            Return False
        End If

        ' Check for duplicate username
        If _users.Any(Function(u) u.Username = user.Username) Then
            Return False
        End If

        _users.Add(user)
        SaveUsers()
        Return True
    End Function

    Private Sub LoadUsers()
        If File.Exists(DataFile) Then
            Dim settings = New JsonSerializerSettings With {
                .TypeNameHandling = TypeNameHandling.Auto
            }
            _users = JsonConvert.DeserializeObject(Of List(Of User))(
                File.ReadAllText(DataFile), settings)
        End If
    End Sub

    Public Sub SaveUsers()
        Dim settings As New JsonSerializerSettings With {
            .TypeNameHandling = TypeNameHandling.Auto,
            .Formatting = Formatting.Indented
        }
        File.WriteAllText(DataFile, JsonConvert.SerializeObject(_users, settings))
    End Sub

End Class