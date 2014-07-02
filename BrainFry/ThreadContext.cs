using System.Collections.Generic;

namespace BrainFry
{
	public class ThreadContext
	{
		public ThreadContext(ExecutionContext execution, int memoryPointer, int commandPointer)
		{
			Execution = execution;

			MemoryPointer = memoryPointer;
			CommandPointer = commandPointer;

			LoopStack = new Stack<int>();
			CallStack = new Stack<int>();
		}

		public readonly ExecutionContext Execution;

		public int MemoryPointer;
		public int CommandPointer;

		public readonly Stack<int> CallStack;
		public readonly Stack<int> LoopStack;

		public byte CurrentMemory
		{
			get { return Execution.Memory[MemoryPointer]; }
			set { Execution.Memory[MemoryPointer] = value; }
		}

		public ICommand CurrentCommand
		{
			get { return Execution.Commands[CommandPointer]; }
		}
	}
}
