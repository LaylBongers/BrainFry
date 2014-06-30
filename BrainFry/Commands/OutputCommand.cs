using System;

namespace BrainFry.Commands
{
	public sealed class OutputCommand : ICommand
	{
		public char Char
		{
			get { return '.'; }
		}

		public void Execute(ExecutionContext context)
		{
			Console.Write((char)context.CurrentMemory);
		}
	}
}