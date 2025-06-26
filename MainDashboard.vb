Public Class MainDashboard
    Public Property CurrentUser As User
    Private taskService As TaskService
    Private currentSelectedTask As Task
    Private currentSelectedHistoryTask As Task

    Private Sub MainDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Console.WriteLine("DEBUG: MainDashboard loading...")

        taskService = New TaskService()

        If CurrentUser IsNot Nothing Then
            Console.WriteLine($"DEBUG: Dashboard loaded for user: {CurrentUser.Username} ({CurrentUser.Role})")


            Dim welcomeLabelControls = Me.Controls.Find("lblWelcomeMessage", True)
            If welcomeLabelControls.Length > 0 Then
                Dim welcomeLabel As Label = DirectCast(welcomeLabelControls(0), Label)
                welcomeLabel.Text = $"Welcome, {CurrentUser.Username} ({CurrentUser.Role})!"
            Else
                Console.WriteLine("WARNING: Label 'lblWelcomeMessage' not found on MainDashboard. Cannot display welcome message in dedicated label.")
                Me.Text = $"Dashboard - {CurrentUser.Username}"
            End If

            dtpTaskDate.Value = Date.Today


            RefreshTaskLists()

        Else
            Console.WriteLine("ERROR: MainDashboard loaded without a CurrentUser object. Redirecting to Login.")
            MessageBox.Show("User session expired or not found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim loginForm As New Login()
            loginForm.Show()
            Me.Close()
        End If
    End Sub


    Private Sub RefreshTaskLists()
        Console.WriteLine("DEBUG: Refreshing task lists...")
        ltbTaskList.Items.Clear()
        ltbTaskHistory.Items.Clear()

        If CurrentUser Is Nothing Then Return


        Dim activeTasks = taskService.GetTasksByUsername(CurrentUser.Username, False)
        For Each task In activeTasks
            ltbTaskList.Items.Add(task)
        Next


        Dim completedTasks = taskService.GetTasksByUsername(CurrentUser.Username, True)
        For Each task In completedTasks
            ltbTaskHistory.Items.Add(task)
        Next

        ClearAddTaskFields()
    End Sub


    Private Sub ClearAddTaskFields()
        TextBox2.Clear()
        dtpTaskDate.Value = Date.Today
        cbStudent.Checked = False
        cbTeacher.Checked = False
        cbEmployee.Checked = False
        currentSelectedTask = Nothing
    End Sub



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
            RefreshTaskLists()
            Return
        End If

        ltbTaskList.Items.Clear()
        Dim allActiveUserTasks = taskService.GetTasksByUsername(CurrentUser.Username, False)
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

                If taskService.MarkTaskAsCompleted(taskToRemove.Id) Then
                    MessageBox.Show($"Task '{taskToRemove.Description}' removed and moved to history.", "Task Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefreshTaskLists()
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
            currentSelectedTask = DirectCast(ltbTaskList.SelectedItem, Task)


            TextBox2.Text = currentSelectedTask.Description
            dtpTaskDate.Value = currentSelectedTask.DueDate


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
        Dim taskName As String = TextBox2.Text.Trim()
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

            Dim newTask As New Task(taskName, CurrentUser.Username, selectedRole, taskDate)
            If taskService.AddTask(newTask) Then
                MessageBox.Show($"Task '{taskName}' added!", "Task Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to add task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else

            currentSelectedTask.Description = taskName
            currentSelectedTask.DueDate = taskDate
            currentSelectedTask.AssignedRole = selectedRole

            If taskService.UpdateTask(currentSelectedTask) Then
                MessageBox.Show($"Task '{taskName}' updated!", "Task Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to update task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        RefreshTaskLists()
        ClearAddTaskFields()
    End Sub

    Private Sub btnDeleteHistory_Click(sender As Object, e As EventArgs) Handles btnDeleteHistory.Click
        Console.WriteLine("DEBUG: Delete History button clicked.")
        If ltbTaskHistory.SelectedIndex <> -1 Then
            currentSelectedHistoryTask = DirectCast(ltbTaskHistory.SelectedItem, Task)

            If MessageBox.Show($"Are you sure you want to permanently delete '{currentSelectedHistoryTask.Description}' from history?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If taskService.DeleteTask(currentSelectedHistoryTask.Id) Then
                    MessageBox.Show($"History item '{currentSelectedHistoryTask.Description}' permanently deleted.", "History Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefreshTaskLists()
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

                If taskService.MarkTaskAsActive(currentSelectedHistoryTask.Id) Then
                    MessageBox.Show($"Task '{currentSelectedHistoryTask.Description}' restored to Your Tasks.", "Task Restored", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefreshTaskLists()
                Else
                    MessageBox.Show("Failed to restore task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select a history item to restore.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub ltbTaskList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ltbTaskList.SelectedIndexChanged

        If ltbTaskList.SelectedIndex <> -1 Then
            ltbTaskHistory.ClearSelected()
            currentSelectedHistoryTask = Nothing
        End If
    End Sub


    Private Sub ltbTaskHistory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ltbTaskHistory.SelectedIndexChanged

        If ltbTaskHistory.SelectedIndex <> -1 Then
            ltbTaskList.ClearSelected()
            currentSelectedTask = Nothing
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub txtTaskName_Click(sender As Object, e As EventArgs) Handles txtTaskName.Click

    End Sub

    Private Sub lblSelectRole_Click(sender As Object, e As EventArgs) Handles lblSelectRole.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub cbStudent_CheckedChanged(sender As Object, e As EventArgs) Handles cbStudent.CheckedChanged

    End Sub
End Class