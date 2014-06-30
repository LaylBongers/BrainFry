using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFry.Commands
{
	public sealed class ProcedureDefineStartCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			// This only gets encountered if we create a new procedure
			execution.ProcedurePointers[execution.Memory[thread.MemoryPointer]] = thread.CommandPointer;

			// Skip till end of procedure definition
			thread.CommandPointer++;
			var depth = 0;
			for (; thread.CommandPointer < execution.Commands.Count; thread.CommandPointer++)
			{
				var commandType = execution.Commands[thread.CommandPointer].GetType();

				if (commandType == typeof(ProcedureDefineStartCommand))
				{
					depth++; // Nested loop open
				}
				else if (commandType == typeof(ProcedureDefineEndCommand))
				{
					if (depth == 0) // This is our stop!
						return;

					depth--; // Nested loop close
				}
			}

			throw new InvalidOperationException("Procedure starts command lacks end command!");
		}
	}

	public sealed class ProcedureDefineEndCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			// This only gets encountered if we're in the procedure
			thread.CommandPointer = thread.CallStack.Pop();
		}
	}

	public sealed class ProcedureCallCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			thread.CallStack.Push(thread.CommandPointer);
			thread.CommandPointer = execution.ProcedurePointers[execution.Memory[thread.MemoryPointer]];
		}
	}
}
