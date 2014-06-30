using System;

namespace BrainFry.Commands
{
	public sealed class InputCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			// Enter for some reason gives a \r, which needs to be a \n
			var ch = Console.ReadKey(false).KeyChar;
			execution.Memory[thread.MemoryPointer] = (byte)(ch == '\r' ? '\n' : ch);
		}
	}

	public sealed class OutputCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			Console.Write((char)execution.Memory[thread.MemoryPointer]);
		}
	}
}