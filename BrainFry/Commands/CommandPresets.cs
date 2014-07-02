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

		public static IDictionary<char, ICommand> TbrainExtension
		{
			get
			{
				return new Dictionary<char, ICommand>
				{
					{';', new ProcedureCallThreadedCommand()},
					{'\\', new JoinThreadCommand()}
				};
			}
		}

		public static IDictionary<char, ICommand> BrainFryExtension
		{
			get
			{
				return new Dictionary<char, ICommand>
				{
					{'$', new DebugOutputCommand()}
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

		public static IDictionary<char, ICommand> BrainFry
		{
			get { return Merge(Brainfuck, PbrainExtension, TbrainExtension, BrainFryExtension); }
		}

		public static IDictionary<char, ICommand> Pbrain
		{
			get { return Merge(Brainfuck, PbrainExtension); }
		}

		public static IDictionary<char, ICommand> Tbrain
		{
			get { return Merge(Brainfuck, PbrainExtension, TbrainExtension); }
		}
	}
}