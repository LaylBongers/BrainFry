using System;

namespace BrainFry.Commands
{
	public sealed class InputCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			// Enter for some reason gives a \r, which needs to be a \n
			var ch = Console.ReadKey(false).KeyChar;
			thread.CurrentMemory = (byte)(ch == '\r' ? '\n' : ch);
		}
	}

	public sealed class OutputCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			Console.Write((char)thread.CurrentMemory);
		}
	}
}