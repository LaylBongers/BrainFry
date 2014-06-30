namespace BrainFry.Commands
{
	public sealed class LoopCloseCommand : ICommand
	{
		public char Char
		{
			get { return ']'; }
		}

		public void Execute(ExecutionContext context)
		{
			// 1 before the target because the command pointer gets incremented at the end
			context.CommandPointer = context.LoopStack.Pop() - 1;
		}
	}
}