using Elsa.Mediator.Contracts;
using Elsa.Workflows.Runtime.Contracts;
using Elsa.Workflows.Runtime.Models;

namespace Elsa.Workflows.Runtime.Notifications;

/// <summary>
/// A notification that is sent when a workflow inbox message is received.
/// </summary>
/// <param name="InboxMessage">The inbox message that was received.</param>
/// <param name="WorkflowExecutionResults">Contains workflow execution results</param>
public record WorkflowInboxMessageReceived(WorkflowInboxMessage InboxMessage, ICollection<WorkflowExecutionResult> WorkflowExecutionResults) : INotification;