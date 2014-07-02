namespace BrainFry.Commands
{
	public sealed class PointerIncrementCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			thread.MemoryPointer++;
		}
	}

	public sealed class PointerDecrementCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			thread.MemoryPointer--;
		}
	}
}