namespace BrainFry.Commands
{
	public sealed class ProcedureCallThreadedCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			//execution.CallStack.Push(execution.CommandPointer);
			//execution.CommandPointer = execution.ProcedurePointers[execution.CurrentMemory];
		}
	}
}