Public Class MainDashboard
    Public Property CurrentUser As User
    Private taskService As TaskService
    Private currentSelectedTask As Task ' To hold the task object when editing/removing
    Private currentSelectedHistoryTask As Task ' To hold the task object when deleting/restoring history

    Private Sub MainDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Console.WriteLine("DEBUG: MainDashboard loading...")

        taskService = New TaskService() ' Initialize TaskService here

        If CurrentUser IsNot Nothing Then
            Console.WriteLine($"DEBUG: Dashboard loaded for user: {CurrentUser.Username} ({CurrentUser.Role})")

            ' --- Display Welcome Message ---
            Dim welcomeLabelControls = Me.Controls.Find("lblWelcomeMessage", True)
            If welcomeLabelControls.Length > 0 Then
                Dim welcomeLabel As Label = DirectCast(welcomeLabelControls(0), Label)
                welcomeLabel.Text = $"Welcome, {CurrentUser.Username} ({CurrentUser.Role})!"
            Else
                Console.WriteLine("WARNING: Label 'lblWelcomeMessage' not found on MainDashboard. Cannot display welcome message in dedicated label.")
                Me.Text = $"Dashboard - {CurrentUser.Username}"
            End If

            dtpTaskDate.Value = Date.Today ' Initialize the task date picker

            ' Load and display tasks
            RefreshTaskLists()

        Else
            Console.WriteLine("ERROR: MainDashboard loaded without a CurrentUser object. Redirecting to Login.")
            MessageBox.Show("User session expired or not found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim loginForm As New Login()
            loginForm.Show()
            Me.Close()
        End If
    End Sub

    ' --- Helper Method to Refresh Both Task Lists ---
    Private Sub RefreshTaskLists()
        Console.WriteLine("DEBUG: Refreshing task lists...")
        ltbTaskList.Items.Clear()
        ltbTaskHistory.Items.Clear()

        If CurrentUser Is Nothing Then Return

        ' Get active tasks (IsCompleted = False)
        Dim activeTasks = taskService.GetTasksByUsername(CurrentUser.Username, False)
        For Each task In activeTasks
            ltbTaskList.Items.Add(task) ' Add Task objects directly
        Next

        ' Get historical/completed tasks (IsCompleted = True)
        Dim completedTasks = taskService.GetTasksByUsername(CurrentUser.Username, True)
        For Each task In completedTasks
            ltbTaskHistory.Items.Add(task) ' Add Task objects directly
        Next

        ClearAddTaskFields() ' Clear add task section after refresh
    End Sub

    ' --- Helper Method to Clear Add Task Fields ---
    Private Sub ClearAddTaskFields()
        TextBox2.Clear() ' Task Name input
        dtpTaskDate.Value = Date.Today
        cbStudent.Checked = False
        cbTeacher.Checked = False
        cbEmployee.Checked = False
        currentSelectedTask = Nothing ' Clear the selected task for editing
    End Sub

    ' --- Event Handlers for Buttons ---

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Console.WriteLine("DEBUG: User logging out.")
        Me.CurrentUser = Nothing
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchText As String = TextBox1.Text.Trim()
        Console.WriteLine($"DEBUG: Search button clicked. Search text: '{searchText}'")

        If String.IsNullOrWhiteSpace(searchText) Then
            MessageBox.Show("Please enter text to search for a task.", "Search Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshTaskLists() ' Show all active tasks if search is empty
            Return
        End If

        ltbTaskList.Items.Clear()
        Dim allActiveUserTasks = taskService.GetTasksByUsername(CurrentUser.Username, False) ' Search only active tasks
        Dim foundTasks = allActiveUserTasks.Where(Function(t) t.Description.ToLower().Contains(searchText.ToLower())).ToList()

        If foundTasks.Any() Then
            For Each task In foundTasks
                ltbTaskList.Items.Add(task)
            Next
            MessageBox.Show($"{foundTasks.Count} task(s) found matching '{searchText}'.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No tasks found matching your search.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Console.WriteLine("DEBUG: Remove Task button clicked.")
        If ltbTaskList.SelectedIndex <> -1 Then
            Dim taskToRemove As Task = DirectCast(ltbTaskList.SelectedItem, Task)

            If MessageBox.Show($"Are you sure you want to remove '{taskToRemove.Description}'?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' Mark the task as completed (moves to history conceptually)
                If taskService.MarkTaskAsCompleted(taskToRemove.Id) Then
                    MessageBox.Show($"Task '{taskToRemove.Description}' removed and moved to history.", "Task Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefreshTaskLists() ' Update both lists
                Else
                    MessageBox.Show("Failed to remove task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select a task to remove from 'Your Task'.", "No Task Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Console.WriteLine("DEBUG: Edit Task button clicked.")
        If ltbTaskList.SelectedIndex <> -1 Then
            currentSelectedTask = DirectCast(ltbTaskList.SelectedItem, Task) ' Store the selected task

            ' Populate the "Add Task" section with selected task details
            TextBox2.Text = currentSelectedTask.Description
            dtpTaskDate.Value = currentSelectedTask.DueDate

            ' Set role checkboxes based on the task's assigned role
            cbStudent.Checked = (currentSelectedTask.AssignedRole = "Student")
            cbTeacher.Checked = (currentSelectedTask.AssignedRole = "Teacher")
            cbEmployee.Checked = (currentSelectedTask.AssignedRole = "Employee")

            MessageBox.Show($"Task '{currentSelectedTask.Description}' loaded for editing. Click 'Add Task' to save changes.", "Edit Task", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select a task to edit from 'Your Task'.", "No Task Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAddTask_Click(sender As Object, e As EventArgs) Handles btnAddTask.Click
        Console.WriteLine("DEBUG: Add Task button clicked.")
        Dim taskName As String = TextBox2.Text.Trim() ' Task Name input
        Dim taskDate As DateTime = dtpTaskDate.Value

        Dim selectedRole As String = ""
        If cbStudent.Checked Then
            selectedRole = "Student"
        ElseIf cbTeacher.Checked Then
            selectedRole = "Teacher"
        ElseIf cbEmployee.Checked Then
            selectedRole = "Employee"
        End If

        If String.IsNullOrWhiteSpace(taskName) Then
            MessageBox.Show("Please enter a task name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrWhiteSpace(selectedRole) Then
            MessageBox.Show("Please select a role for the task.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If currentSelectedTask Is Nothing Then
            ' --- Add New Task ---
            Dim newTask As New Task(taskName, CurrentUser.Username, selectedRole, taskDate)
            If taskService.AddTask(newTask) Then
                MessageBox.Show($"Task '{taskName}' added!", "Task Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to add task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            ' --- Update Existing Task ---
            currentSelectedTask.Description = taskName
            currentSelectedTask.DueDate = taskDate
            currentSelectedTask.AssignedRole = selectedRole
            ' Ensure IsCompleted status is retained during update unless specifically changed
            If taskService.UpdateTask(currentSelectedTask) Then
                MessageBox.Show($"Task '{taskName}' updated!", "Task Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to update task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        RefreshTaskLists() ' Reload tasks to show changes
        ClearAddTaskFields() ' Clear fields after add/edit
    End Sub

    Private Sub btnDeleteHistory_Click(sender As Object, e As EventArgs) Handles btnDeleteHistory.Click
        Console.WriteLine("DEBUG: Delete History button clicked.")
        If ltbTaskHistory.SelectedIndex <> -1 Then
            currentSelectedHistoryTask = DirectCast(ltbTaskHistory.SelectedItem, Task)

            If MessageBox.Show($"Are you sure you want to permanently delete '{currentSelectedHistoryTask.Description}' from history?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If taskService.DeleteTask(currentSelectedHistoryTask.Id) Then
                    MessageBox.Show($"History item '{currentSelectedHistoryTask.Description}' permanently deleted.", "History Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefreshTaskLists() ' Update lists
                Else
                    MessageBox.Show("Failed to permanently delete history item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select a history item to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnRestoreTask_Click(sender As Object, e As EventArgs) Handles btnRestoreTask.Click
        Console.WriteLine("DEBUG: Restore Task button clicked.")
        If ltbTaskHistory.SelectedIndex <> -1 Then
            currentSelectedHistoryTask = DirectCast(ltbTaskHistory.SelectedItem, Task)

            If MessageBox.Show($"Are you sure you want to restore '{currentSelectedHistoryTask.Description}' to Your Tasks?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' Mark the task as not completed (moves to active list conceptually)
                If taskService.MarkTaskAsActive(currentSelectedHistoryTask.Id) Then
                    MessageBox.Show($"Task '{currentSelectedHistoryTask.Description}' restored to Your Tasks.", "Task Restored", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefreshTaskLists() ' Update lists
                Else
                    MessageBox.Show("Failed to restore task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select a history item to restore.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Handle single selection in task listbox
    Private Sub ltbTaskList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ltbTaskList.SelectedIndexChanged
        ' Clear history selection when an active task is selected
        If ltbTaskList.SelectedIndex <> -1 Then
            ltbTaskHistory.ClearSelected()
            currentSelectedHistoryTask = Nothing
        End If
    End Sub

    ' Handle single selection in history listbox
    Private Sub ltbTaskHistory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ltbTaskHistory.SelectedIndexChanged
        ' Clear active task selection when a history item is selected
        If ltbTaskHistory.SelectedIndex <> -1 Then
            ltbTaskList.ClearSelected()
            currentSelectedTask = Nothing
        End If
    End Sub

End Class