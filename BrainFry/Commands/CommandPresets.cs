using System.Collections.Generic;

namespace BrainFry.Commands
{
	public static class CommandPresets
	{
		public static IDictionary<char, ICommand> Default
		{
			get { return new Dictionary<char, ICommand>
			{
				{'+', new IncrementCommand()},
				{'-', new DecrementCommand()},

				{',', new InputCommand()},
				{'.', new OutputCommand()},
				
				{'>', new PointerIncrementCommand()},
				{'<', new PointerDecrementCommand()},
				
				{'[', new LoopOpenCommand()},
				{']', new LoopCloseCommand()}
			};}
		}
	}
}
