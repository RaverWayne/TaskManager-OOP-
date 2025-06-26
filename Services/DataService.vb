Imports Newtonsoft.Json
Imports System.IO
Imports System.Linq

Public Class DataService
    Private ReadOnly DataFile As String = "users.json"
    Private _users As New List(Of User)()

    Public Sub New()

        Console.WriteLine($"DEBUG: DataService initialized. Expected DataFile path: {Path.GetFullPath(DataFile)}")
        LoadUsers()
        Console.WriteLine($"DEBUG: After LoadUsers(), current user count: {_users.Count}")
    End Sub

    Public Function Authenticate(username As String, password As String) As User
        Console.WriteLine($"DEBUG: Authenticating user '{username}' with password '{password}'. Current _users count: {_users.Count}")

        If Not _users.Any() Then
            Console.WriteLine("DEBUG: _users list is empty. Authentication will return Nothing.")
            Return Nothing
        End If

        Dim authenticatedUser = _users.FirstOrDefault(
            Function(u) String.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase) AndAlso
                        u.Password = password)

        If authenticatedUser IsNot Nothing Then
            Console.WriteLine($"DEBUG: Authentication SUCCESS for user '{authenticatedUser.Username}'. Role: {authenticatedUser.Role}")
        Else
            Console.WriteLine($"DEBUG: Authentication FAILED for '{username}'. No matching user or incorrect password.")
        End If

        Return authenticatedUser
    End Function

    Public Function RegisterUser(user As User) As Boolean
        Console.WriteLine($"DEBUG: Attempting to register user '{user.Username}'.")

        If user Is Nothing Then
            Console.WriteLine("DEBUG: Registration failed - User object is Nothing.")
            Return False
        End If

        If String.IsNullOrWhiteSpace(user.Username) OrElse
           String.IsNullOrWhiteSpace(user.Password) Then
            Console.WriteLine("DEBUG: Registration failed - Username or password is empty.")
            Return False
        End If


        If _users.Any(Function(u) String.Equals(u.Username, user.Username, StringComparison.OrdinalIgnoreCase)) Then
            Console.WriteLine($"DEBUG: Registration failed - Username '{user.Username}' already exists.")
            Return False
        ElseIf _users Is Nothing Then

            _users = New List(Of User)()
        End If

        _users.Add(user)
        SaveUsers()
        Console.WriteLine($"DEBUG: User '{user.Username}' successfully registered. New user count: {_users.Count}")
        Return True
    End Function

    Private Sub LoadUsers()
        Console.WriteLine($"DEBUG: Entering LoadUsers(). Checking if file exists: {Path.GetFullPath(DataFile)}")
        If File.Exists(DataFile) Then
            Try
                Dim settings = New JsonSerializerSettings With {
                    .TypeNameHandling = TypeNameHandling.Auto,
                    .NullValueHandling = NullValueHandling.Ignore
                }

                _users = JsonConvert.DeserializeObject(Of List(Of User))(
                    File.ReadAllText(DataFile), settings)

                If _users Is Nothing Then
                    _users = New List(Of User)()
                    Console.WriteLine("DEBUG: Deserialization resulted in Nothing or empty list. Initializing empty list.")
                End If
                Console.WriteLine($"DEBUG: Successfully loaded {_users.Count} users from {Path.GetFullPath(DataFile)}.")
            Catch ex As Exception

                Console.WriteLine($"DEBUG ERROR: Failed to load users from {Path.GetFullPath(DataFile)}: {ex.Message}")
                Console.WriteLine($"DEBUG ERROR StackTrace: {ex.StackTrace}")
                _users = New List(Of User)()
            End Try
        Else
            _users = New List(Of User)()
            Console.WriteLine($"DEBUG: {Path.GetFullPath(DataFile)} does not exist. Initializing empty user list.")
        End If
    End Sub

    Public Sub SaveUsers()
        Try
            Dim settings As New JsonSerializerSettings With {
                .TypeNameHandling = TypeNameHandling.Auto,
                .Formatting = Formatting.Indented,
                .NullValueHandling = NullValueHandling.Ignore
            }
            File.WriteAllText(DataFile, JsonConvert.SerializeObject(_users, settings))
            Console.WriteLine($"DEBUG: Successfully saved {_users.Count} users to {Path.GetFullPath(DataFile)}.")
        Catch ex As Exception

            Console.WriteLine($"DEBUG ERROR: Failed to save users to {Path.GetFullPath(DataFile)}: {ex.Message}")
            Console.WriteLine($"DEBUG ERROR StackTrace: {ex.StackTrace}")
        End Try
    End Sub

End Class