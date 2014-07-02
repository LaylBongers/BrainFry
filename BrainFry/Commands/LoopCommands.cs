using System;

namespace BrainFry.Commands
{
	public sealed class LoopOpenCommand : ICommand
	{
		public void Execute(ThreadContext thread)
		{
			if (thread.CurrentMemory != 0) // If current memory true (!=0) => execute block
			{
				thread.LoopStack.Push(thread.CommandPointer);
			}
			else // If current memory false (0) => skip block
			{
				thread.CommandPointer++;
				var depth = 0;
				for (; thread.CommandPointer < thread.Execution.Commands.Count; thread.CommandPointer++)
				{
					var commandType = thread.CurrentCommand.GetType();

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
		public void Execute(ThreadContext thread)
		{
			// 1 before the target because the command pointer gets incremented at the end
			thread.CommandPointer = thread.LoopStack.Pop() - 1;
		}
	}
}