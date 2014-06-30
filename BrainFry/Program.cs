using System.Collections.Generic;

namespace BrainFry
{
	public sealed class Program
	{
		private readonly IList<ICommand> _commands;

		public Program(IList<ICommand> commands)
		{
			_commands = commands;
		}

		public void Run()
		{
			for (var context = new ExecutionContext(_commands);
				context.CommandPointer < _commands.Count;
				context.CommandPointer++)
			{
				_commands[context.CommandPointer].Execute(context);
			}
		}
	}
}