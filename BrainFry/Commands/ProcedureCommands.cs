using System;

namespace BrainFry.Commands
{
	public sealed class ProcedureDefineStartCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			// This only gets encountered if we create a new procedure
			thread.Execution.ProcedurePointers[thread.CurrentMemory] = thread.CommandPointer;

			// Skip till end of procedure definition
			thread.CommandPointer++;
			var depth = 0;
			for (; thread.CommandPointer < thread.Execution.Commands.Count; thread.CommandPointer++)
			{
				var commandType = thread.CurrentCommand.GetType();

				if (commandType == typeof (ProcedureDefineStartCommand))
				{
					depth++; // Nested procedure create open
				}
				else if (commandType == typeof (ProcedureDefineEndCommand))
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
		public void Execute(ThreadContext thread)
		{
			// This only gets encountered if we're in the procedure

			// If the callstack is empty we're in a thread (probably) so let's just halt execution by putting the pointer at the end
			thread.CommandPointer = thread.CallStack.Count == 0
				? thread.Execution.Commands.Count
				: thread.CallStack.Pop();
		}
	}

	public sealed class ProcedureCallCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			thread.CallStack.Push(thread.CommandPointer);
			thread.CommandPointer = thread.Execution.ProcedurePointers[thread.CurrentMemory];
		}
	}
}