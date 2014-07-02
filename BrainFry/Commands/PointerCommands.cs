namespace BrainFry.Commands
{
	public sealed class PointerIncrementCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			thread.MemoryPointer++;
		}
	}

	public sealed class PointerDecrementCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			thread.MemoryPointer--;
		}
	}
}