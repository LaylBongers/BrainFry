namespace BrainFry.Commands
{
	public sealed class IncrementCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			thread.CurrentMemory++;
		}
	}

	public sealed class DecrementCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			thread.CurrentMemory--;
		}
	}
}