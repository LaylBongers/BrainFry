namespace BrainFry.Commands
{
	public sealed class IncrementCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			context.CurrentMemory++;
		}
	}

	public sealed class DecrementCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			context.CurrentMemory--;
		}
	}
}