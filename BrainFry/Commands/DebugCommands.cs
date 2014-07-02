using System;

namespace BrainFry.Commands
{
	public sealed class DebugOutputCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			Console.WriteLine(" === Debug Information === ");
			Console.WriteLine(" Command Pointer: " + thread.CommandPointer);
			Console.WriteLine(" Memory Pointer: " + thread.MemoryPointer);
			Console.WriteLine(" Current Memory: " + thread.CurrentMemory);
			Console.ReadKey(true);
		}
	}
}