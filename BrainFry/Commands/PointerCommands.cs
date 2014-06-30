namespace BrainFry.Commands
{
	public sealed class PointerIncrementCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			context.MemoryPointer++;
		}
	}

	public sealed class PointerDecrementCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			context.MemoryPointer--;
		}
	}
}