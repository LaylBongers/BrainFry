using System.Collections.Generic;
using System.Linq;

namespace BrainFry.Commands
{
	public static class CommandPresets
	{
		private static IDictionary<char, ICommand> Merge(params IDictionary<char, ICommand>[] dictionaries)
		{
			return dictionaries.SelectMany(d => d).ToDictionary(d => d.Key, d => d.Value);
		}

		public static IDictionary<char, ICommand> PbrainExtension
		{
			get
			{
				return new Dictionary<char, ICommand>
				{
					{'(', new ProcedureDefineStartCommand()},
					{')', new ProcedureDefineEndCommand()},
					{':', new ProcedureCallCommand()}
				};
			}
		}

		public static IDictionary<char, ICommand> Brainfuck
		{
			get
			{
				return new Dictionary<char, ICommand>
				{
					{'+', new IncrementCommand()},
					{'-', new DecrementCommand()},

					{',', new InputCommand()},
					{'.', new OutputCommand()},
				
					{'>', new PointerIncrementCommand()},
					{'<', new PointerDecrementCommand()},
				
					{'[', new LoopOpenCommand()},
					{']', new LoopCloseCommand()}
				};
			}
		}

		public static IDictionary<char, ICommand> Default
		{
			get { return Merge(Brainfuck, PbrainExtension); }
		}

		public static IDictionary<char, ICommand> Pbrain
		{
			get { return Merge(Brainfuck, PbrainExtension); }
		}
	}
}