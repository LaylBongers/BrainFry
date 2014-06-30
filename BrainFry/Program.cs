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
			var context = new ExecutionContext(_commands);
			var thread = new ExecutionThread(context, 0, 0);
			thread.Join();
		}
	}
}