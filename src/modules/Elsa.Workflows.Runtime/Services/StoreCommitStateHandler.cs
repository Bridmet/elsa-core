using Elsa.Workflows.Management;
using Elsa.Workflows.State;

namespace Elsa.Workflows.Runtime;

public class StoreCommitStateHandler(IWorkflowInstanceManager workflowInstanceManager) : ICommitStateHandler
{
    public async Task CommitAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken = default)
    {
        var workflowState = workflowInstanceManager.ExtractWorkflowState(workflowExecutionContext);
        await CommitAsync(workflowExecutionContext, workflowState, cancellationToken);
    }

    public async Task CommitAsync(WorkflowExecutionContext workflowExecutionContext, WorkflowState workflowState, CancellationToken cancellationToken = default)
    {
        await workflowInstanceManager.SaveAsync(workflowState, cancellationToken);
        await workflowExecutionContext.ExecuteDeferredTasksAsync();
    }
}