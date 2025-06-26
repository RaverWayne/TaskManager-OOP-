Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptIn)>
Public Class Task
    <JsonProperty>
    Public Property Id As Guid
    <JsonProperty>
    Public Property Description As String
    <JsonProperty>
    Public Property IsCompleted As Boolean
    <JsonProperty>
    Public Property AssignedToUsername As String
    <JsonProperty>
    Public Property AssignedRole As String
    <JsonProperty>
    Public Property DueDate As DateTime

    Public Sub New()
        Me.Id = Guid.NewGuid()
        Me.IsCompleted = False
        Me.DueDate = Date.Today
    End Sub


    Public Sub New(description As String, assignedToUsername As String, assignedRole As String, dueDate As DateTime)
        Me.Id = Guid.NewGuid()
        Me.Description = description
        Me.IsCompleted = False
        Me.AssignedToUsername = assignedToUsername
        Me.AssignedRole = assignedRole
        Me.DueDate = dueDate
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Description} ({AssignedRole}) - Due: {DueDate.ToShortDateString()} {(If(IsCompleted, "(Archived)", ""))}"
    End Function
End Class