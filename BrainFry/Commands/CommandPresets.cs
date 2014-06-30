using System.Collections.Generic;

namespace BrainFry.Commands
{
	public static class CommandPresets
	{
		public static IEnumerable<ICommand> Default
		{
			get { return new List<ICommand>
			{
				new DecrementCommand(),
				new IncrementCommand(),

				new InputCommand(),
				new OutputCommand(),
				
				new PointerDecrementCommand(),
				new PointerIncrementCommand(),

				new LoopOpenCommand(),
				new LoopCloseCommand()
			};}
		}
	}
}
