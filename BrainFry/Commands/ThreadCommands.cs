namespace BrainFry.Commands
{
	public sealed class ProcedureCallThreadedCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			var exeThread = new ExecutionThread(
				execution,
				thread.MemoryPointer,
				execution.ProcedurePointers[execution.Memory[thread.MemoryPointer]] + 1,
				execution.Memory[thread.MemoryPointer]);
		}
	}

	public sealed class JoinThreadCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			execution.JoinThreads(execution.Memory[thread.MemoryPointer]);
		}
	}
}