using System.Collections.Generic;
using System.Linq;

namespace BrainFry
{
	public sealed class Compiler
	{
		private readonly IDictionary<char, ICommand> _commands;

		public Compiler(IDictionary<char, ICommand> commands)
		{
			_commands = commands;
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