using System;

namespace BrainFry.Commands
{
	public sealed class LoopOpenCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			if (execution.Memory[thread.MemoryPointer] != 0) // If current memory true (!=0) => execute block
			{
				thread.LoopStack.Push(thread.CommandPointer);
			}
			else // If current memory false (0) => skip block
			{
				thread.CommandPointer++;
				var depth = 0;
				for (; thread.CommandPointer < execution.Commands.Count; thread.CommandPointer++)
				{
					var commandType = execution.Commands[thread.CommandPointer].GetType();

					if (commandType == typeof(LoopOpenCommand))
					{
						depth++; // Nested loop open
					}
					else if (commandType == typeof(LoopCloseCommand))
					{
						if (depth == 0) // This is our stop!
							return;

						depth--; // Nested loop close
					}
				}

				throw new InvalidOperationException("Loop open command lacks close command!");
			}
		}
	}

	public sealed class LoopCloseCommand : ICommand
	{
		public void Execute(ExecutionContext execution, ThreadContext thread)
		{
			// 1 before the target because the command pointer gets incremented at the end
			thread.CommandPointer = thread.LoopStack.Pop() - 1;
		}
	}
}