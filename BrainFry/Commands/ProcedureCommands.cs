using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFry.Commands
{
	public sealed class ProcedureDefineStartCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			// This only gets encountered if we create a new procedure
			context.ProcedurePointers[context.CurrentMemory] = context.CommandPointer;

			// Skip till end of procedure definition
			context.CommandPointer++;
			var depth = 0;
			for (; context.CommandPointer < context.Commands.Count; context.CommandPointer++)
			{
				var commandType = context.CurrentCommand.GetType();

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

			throw new InvalidOperationException("Loop open command lacks close command!");
		}
	}

	public sealed class ProcedureDefineEndCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			// This only gets encountered if we're in the procedure
			context.CommandPointer = context.CallStack.Pop();
		}
	}

	public sealed class ProcedureCallCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			context.CallStack.Push(context.CommandPointer);
			context.CommandPointer = context.ProcedurePointers[context.CurrentMemory];
		}
	}
}
