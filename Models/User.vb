Imports System.Collections.Generic

Public MustInherit Class User
    Public Property Username As String
    Public Property Password As String
    Public Property Age As Integer?
    Public Property Birthday As String
    Public Property Gender As String
    Public Property Tasks As New List(Of Task)

    Public MustOverride ReadOnly Property Role As String

    Public Sub AddTask(name As String, [date] As String)
        Tasks.Add(New Task With {.Name = name, .Date = [date]})
    End Sub

    Public Sub RemoveTask(task As Task)
        Tasks.Remove(task)
    End Sub
End Class