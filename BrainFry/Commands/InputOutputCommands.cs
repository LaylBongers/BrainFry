using System;

namespace BrainFry.Commands
{
	public sealed class InputCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			// Enter for some reason gives a \r, which needs to be a \n
			var ch = Console.ReadKey(false).KeyChar;
			context.CurrentMemory = (byte)(ch == '\r' ? '\n' : ch);
		}
	}

	public sealed class OutputCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			Console.Write((char)context.CurrentMemory);
		}
	}
}