namespace BrainFry.Commands
{
	public sealed class DecrementCommand : ICommand
	{
		public char Char
		{
			get { return '-'; }
		}

		public void Execute(ExecutionContext context)
		{
			context.CurrentMemory--;
		}
	}
}