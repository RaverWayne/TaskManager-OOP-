' TaskService.vb
Imports Newtonsoft.Json
Imports System.IO
Imports System.Linq

Public Class TaskService
    Private ReadOnly TaskDataFile As String = "tasks.json"
    Private _tasks As New List(Of Task)()

    Public Sub New()
        Console.WriteLine($"DEBUG: TaskService initialized. Expected TaskDataFile path: {Path.GetFullPath(TaskDataFile)}")
        LoadTasks()
        Console.WriteLine($"DEBUG: After LoadTasks(), current total task count: {_tasks.Count}")
    End Sub

    Private Sub LoadTasks()
        Console.WriteLine($"DEBUG: Entering LoadTasks(). Checking if file exists: {Path.GetFullPath(TaskDataFile)}")
        If File.Exists(TaskDataFile) Then
            Try
                Dim settings = New JsonSerializerSettings With {
                    .TypeNameHandling = TypeNameHandling.Auto,
                    .NullValueHandling = NullValueHandling.Ignore
                }
                _tasks = JsonConvert.DeserializeObject(Of List(Of Task))(
                    File.ReadAllText(TaskDataFile), settings)

                If _tasks Is Nothing Then
                    _tasks = New List(Of Task)()
                    Console.WriteLine("DEBUG: Deserialization resulted in Nothing or empty task list. Initializing empty list.")
                End If
                Console.WriteLine($"DEBUG: Successfully loaded {_tasks.Count} tasks from {Path.GetFullPath(TaskDataFile)}.")
            Catch ex As Exception
                Console.WriteLine($"DEBUG ERROR: Failed to load tasks from {Path.GetFullPath(TaskDataFile)}: {ex.Message}")
                Console.WriteLine($"DEBUG ERROR StackTrace: {ex.StackTrace}")
                _tasks = New List(Of Task)()
            End Try
        Else
            _tasks = New List(Of Task)()
            Console.WriteLine($"DEBUG: {Path.GetFullPath(TaskDataFile)} does not exist. Initializing empty task list.")
        End If
    End Sub

    Private Sub SaveTasks()
        Try
            Dim settings As New JsonSerializerSettings With {
                .TypeNameHandling = TypeNameHandling.Auto,
                .Formatting = Formatting.Indented,
                .NullValueHandling = NullValueHandling.Ignore
            }
            File.WriteAllText(TaskDataFile, JsonConvert.SerializeObject(_tasks, settings))
            Console.WriteLine($"DEBUG: Successfully saved {_tasks.Count} tasks to {Path.GetFullPath(TaskDataFile)}.")
        Catch ex As Exception
            Console.WriteLine($"DEBUG ERROR: Failed to save tasks to {Path.GetFullPath(TaskDataFile)}: {ex.Message}")
            Console.WriteLine($"DEBUG ERROR StackTrace: {ex.StackTrace}")
        End Try
    End Sub

    ' --- Public methods for Task Management ---

    ' Get all tasks for a specific user, optionally filtering by completion status
    Public Function GetTasksByUsername(username As String, Optional isCompletedStatus As Boolean? = Nothing) As List(Of Task)
        Console.WriteLine($"DEBUG: Getting tasks for user '{username}', IsCompletedStatus filter: {If(isCompletedStatus.HasValue, isCompletedStatus.ToString(), "None")}")
        Dim query = _tasks.Where(Function(t) String.Equals(t.AssignedToUsername, username, StringComparison.OrdinalIgnoreCase))

        If isCompletedStatus.HasValue Then
            query = query.Where(Function(t) t.IsCompleted = isCompletedStatus.Value)
        End If

        Return query.ToList()
    End Function

    ' Add a new task
    Public Function AddTask(task As Task) As Boolean
        Console.WriteLine($"DEBUG: Attempting to add task '{task.Description}' for '{task.AssignedToUsername}'.")
        If task Is Nothing Then Return False
        _tasks.Add(task)
        SaveTasks()
        Console.WriteLine($"DEBUG: Task '{task.Description}' added. Total tasks: {_tasks.Count}")
        Return True
    End Function

    ' Update an existing task
    Public Function UpdateTask(updatedTask As Task) As Boolean
        Console.WriteLine($"DEBUG: Attempting to update task '{updatedTask.Description}' (ID: {updatedTask.Id}).")
        Dim existingTask = _tasks.FirstOrDefault(Function(t) t.Id = updatedTask.Id)
        If existingTask IsNot Nothing Then
            existingTask.Description = updatedTask.Description
            existingTask.DueDate = updatedTask.DueDate
            existingTask.AssignedRole = updatedTask.AssignedRole
            existingTask.IsCompleted = updatedTask.IsCompleted ' Allow changing completion status
            SaveTasks()
            Console.WriteLine($"DEBUG: Task '{updatedTask.Description}' (ID: {updatedTask.Id}) updated.")
            Return True
        End If
        Console.WriteLine($"DEBUG: Failed to update task. Task with ID '{updatedTask.Id}' not found.")
        Return False
    End Function

    ' Mark a task as completed (moved to history)
    Public Function MarkTaskAsCompleted(taskId As Guid) As Boolean
        Console.WriteLine($"DEBUG: Attempting to mark task ID '{taskId}' as completed.")
        Dim taskToComplete = _tasks.FirstOrDefault(Function(t) t.Id = taskId)
        If taskToComplete IsNot Nothing Then
            taskToComplete.IsCompleted = True
            SaveTasks()
            Console.WriteLine($"DEBUG: Task ID '{taskId}' marked as completed.")
            Return True
        End If
        Console.WriteLine($"DEBUG: Failed to mark task as completed. Task with ID '{taskId}' not found.")
        Return False
    End Function

    ' Mark a task as active (restored from history)
    Public Function MarkTaskAsActive(taskId As Guid) As Boolean
        Console.WriteLine($"DEBUG: Attempting to mark task ID '{taskId}' as active.")
        Dim taskToActivate = _tasks.FirstOrDefault(Function(t) t.Id = taskId)
        If taskToActivate IsNot Nothing Then
            taskToActivate.IsCompleted = False
            SaveTasks()
            Console.WriteLine($"DEBUG: Task ID '{taskId}' marked as active.")
            Return True
        End If
        Console.WriteLine($"DEBUG: Failed to mark task as active. Task with ID '{taskId}' not found.")
        Return False
    End Function

    ' Permanently delete a task by ID (for history deletion)
    Public Function DeleteTask(taskId As Guid) As Boolean
        Console.WriteLine($"DEBUG: Attempting to permanently delete task ID '{taskId}'.")
        Dim initialCount = _tasks.Count
        _tasks.RemoveAll(Function(t) t.Id = taskId)
        If _tasks.Count < initialCount Then
            SaveTasks()
            Console.WriteLine($"DEBUG: Task ID '{taskId}' permanently deleted.")
            Return True
        End If
        Console.WriteLine($"DEBUG: Failed to permanently delete task. Task with ID '{taskId}' not found.")
        Return False
    End Function

End Class