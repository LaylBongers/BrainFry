using System;

namespace BrainFry.Commands
{
	public sealed class InputCommand : ICommand
	{
		public char Char
		{
			get { return ','; }
		}

		public void Execute(ExecutionContext context)
		{
			context.CurrentMemory = (byte)Console.ReadKey().KeyChar;
		}
	}
}