using System.Collections.Generic;

namespace BrainFry
{
	public class ThreadContext
	{
		public ThreadContext(int memoryPointer, int commandPointer)
		{
			MemoryPointer = memoryPointer;
			CommandPointer = commandPointer;

			LoopStack = new Stack<int>();
			CallStack = new Stack<int>();
		}

		public int MemoryPointer;
		public int CommandPointer;

		public readonly Stack<int> CallStack;
		public readonly Stack<int> LoopStack;
	}
}
