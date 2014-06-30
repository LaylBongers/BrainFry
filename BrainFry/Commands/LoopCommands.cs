using System;

namespace BrainFry.Commands
{
	public sealed class LoopOpenCommand : ICommand
	{
		public void Execute(ExecutionContext context)
		{
			if (context.CurrentMemory != 0) // If current memory true (!=0) => execute block
			{
				context.LoopStack.Push(context.CommandPointer);
			}
			else // If current memory false (0) => skip block
			{
				// Since we start at ourselves, this will increment to 1 immediately
				var depth = 0;
				for (; context.CommandPointer < context.Commands.Count; context.CommandPointer++)
				{
					var commandType = context.CurrentCommand.GetType();

					if (commandType == typeof(LoopOpenCommand))
					{
						depth++; // Nested loop open
					}
					else if (commandType == typeof(LoopCloseCommand))
					{
						if (depth == 1) // This is our stop!
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
		public void Execute(ExecutionContext context)
		{
			// 1 before the target because the command pointer gets incremented at the end
			context.CommandPointer = context.LoopStack.Pop() - 1;
		}
	}
}