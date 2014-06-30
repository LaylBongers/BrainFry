using System.Collections.Generic;
using System.Linq;

namespace BrainFry
{
	public sealed class Compiler
	{
		private readonly Dictionary<char, ICommand> _commands = new Dictionary<char, ICommand>();

		public Compiler(IEnumerable<ICommand> commands)
		{
			foreach (var command in commands)
			{
				_commands.Add(command.Char, command);
			}
		}

		public Program Compile(string code)
		{
			ICommand command = null;
			var compiled = (
				from c in code
				where _commands.TryGetValue(c, out command)
				select command).ToList();

			return new Program(compiled.ToList());
		}
	}
}