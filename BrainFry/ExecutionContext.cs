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
		}

		public byte[] Memory;
		public IList<ICommand> Commands;
		public int[] ProcedurePointers;
	}
}