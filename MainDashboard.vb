Public Class MainDashboard
    Public Property CurrentUser As User
    Private ReadOnly _dataService As New DataService()

    Private Sub MainDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = $"Welcome {CurrentUser.Username} ({CurrentUser.Role})!"
        RefreshTaskList()
    End Sub

    Private Sub RefreshTaskList()
        ltbTaskList.Items.Clear()
        ltbTaskHistory.Items.Clear()

        For Each task As Task In CurrentUser.Tasks
            ltbTaskList.Items.Add($"{task.Name} (Due: {task.Date})")
            ltbTaskHistory.Items.Add($"{task.Name} - Added on {task.CreatedAt.ToString("yyyy-MM-dd")}")
        Next
    End Sub

    Private Sub btnAddTask_Click(sender As Object, e As EventArgs) Handles btnAddTask.Click
        If String.IsNullOrEmpty(txtTaskName.Text) Then
            MessageBox.Show("Please enter a task name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim newTask As New Task With {
            .Name = txtTaskName.Text,
            .Date = dtpTaskDate.Value.ToString("yyyy-MM-dd"),
            .CreatedAt = DateTime.Now
        }

        CurrentUser.Tasks.Add(newTask)
        _dataService.SaveUsers() ' Now properly accessible
        RefreshTaskList()
        txtTaskName.Text = ""
        txtTaskName.Focus()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If ltbTaskList.SelectedIndex = -1 Then
            MessageBox.Show("Please select a task to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        CurrentUser.Tasks.RemoveAt(ltbTaskList.SelectedIndex)
        _dataService.SaveUsers()
        RefreshTaskList()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        _dataService.SaveUsers()
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ltbTaskHistory.SelectedIndexChanged

    End Sub

    Private Sub ltbTaskList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ltbTaskList.SelectedIndexChanged

    End Sub

    Private Sub lblTaskDate_Click(sender As Object, e As EventArgs) Handles lblTaskDate.Click

    End Sub
End Class