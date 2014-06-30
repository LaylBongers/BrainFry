namespace BrainFry.Commands
{
	public sealed class PointerIncrementCommand : ICommand
	{
		public char Char
		{
			get { return '>'; }
		}

		public void Execute(ExecutionContext context)
		{
			context.MemoryPointer++;
		}
	}
}