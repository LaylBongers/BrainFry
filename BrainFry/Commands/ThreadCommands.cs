namespace BrainFry.Commands
{
	public sealed class ProcedureCallThreadedCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			var exeThread = new ExecutionThread(
				thread.Execution,
				thread.MemoryPointer,
				thread.Execution.ProcedurePointers[thread.CurrentMemory] + 1,
				thread.CurrentMemory);
		}
	}

	public sealed class JoinThreadCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			thread.Execution.JoinThreads(thread.CurrentMemory);
		}
	}
}