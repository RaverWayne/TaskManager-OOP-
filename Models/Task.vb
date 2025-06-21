' Task.vb
Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)>
Public Class Task
    <JsonProperty>
    Public Property Id As Guid
    <JsonProperty>
    Public Property Description As String
    <JsonProperty>
    Public Property IsCompleted As Boolean ' True if in history (completed/removed), False if active
    <JsonProperty>
    Public Property AssignedToUsername As String ' To link tasks to a specific user
    <JsonProperty>
    Public Property AssignedRole As String ' e.g., "Student", "Teacher", "Employee"
    <JsonProperty>
    Public Property DueDate As DateTime ' Storing as DateTime

    Public Sub New()
        Me.Id = Guid.NewGuid() ' Assign a unique ID by default
        Me.IsCompleted = False
        Me.DueDate = Date.Today ' Default to today
    End Sub

    ' Parameterized constructor for convenience
    Public Sub New(description As String, assignedToUsername As String, assignedRole As String, dueDate As DateTime)
        Me.Id = Guid.NewGuid()
        Me.Description = description
        Me.IsCompleted = False ' New tasks are not completed
        Me.AssignedToUsername = assignedToUsername
        Me.AssignedRole = assignedRole
        Me.DueDate = dueDate
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Description} ({AssignedRole}) - Due: {DueDate.ToShortDateString()} {(If(IsCompleted, "(Archived)", ""))}"
    End Function
End Class