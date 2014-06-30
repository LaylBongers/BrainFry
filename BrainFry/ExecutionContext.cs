using System.Collections.Generic;

namespace BrainFry
{
	public sealed class ExecutionContext
	{
		public ExecutionContext(IList<ICommand> commands)
		{
			Memory = new byte[5000];

			Commands = commands;
			ProcedurePointers = new int[byte.MaxValue];

			LoopStack = new Stack<int>();
			CallStack = new Stack<int>();
		}

		public byte[] Memory;
		public int MemoryPointer;

		public int CommandPointer;
		public IList<ICommand> Commands;
		public int[] ProcedurePointers;

		public Stack<int> CallStack;
		public Stack<int> LoopStack;

		public byte CurrentMemory
		{
			get { return Memory[MemoryPointer]; }
			set { Memory[MemoryPointer] = value; }
		}

		public ICommand CurrentCommand
		{
			get { return Commands[CommandPointer]; }
		}
	}
}