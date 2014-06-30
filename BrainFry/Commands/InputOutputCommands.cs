using System;

namespace BrainFry.Commands
{
	public sealed class InputCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			context.CurrentMemory = (byte)Console.ReadKey().KeyChar;
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