using System.Collections.Generic;

namespace BrainFry
{
	public sealed class ExecutionContext
	{
		public ExecutionContext(IList<ICommand> commands)
		{
			Commands = commands;
			Memory = new byte[5000];
			LoopStack = new Stack<int>();
		}

		public byte[] Memory { get; set; }
		public int MemoryPointer { get; set; }
		public int CommandPointer { get; set; }
		public Stack<int> LoopStack { get; set; }
		public IList<ICommand> Commands { get; set; } 
		
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