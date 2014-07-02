using System;

namespace BrainFry.Commands
{
	public sealed class DebugOutputCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			Console.WriteLine(" === Debug Information === ");
			Console.WriteLine(" Command Pointer: " + thread.CommandPointer);
			Console.WriteLine(" Memory Pointer: " + thread.MemoryPointer);
			Console.WriteLine(" Current Memory: " + execution.Memory[thread.MemoryPointer]);
			Console.ReadKey(true);
		}
	}
}