namespace BrainFry.Commands
{
	public sealed class IncrementCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			execution.Memory[thread.MemoryPointer]++;
		}
	}

	public sealed class DecrementCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			execution.Memory[thread.MemoryPointer]--;
		}
	}
}