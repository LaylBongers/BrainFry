using System;
using System.IO;
using System.Linq;
using BrainFry;
using BrainFry.Commands;

namespace CommandLineTool
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			if (args.Length < 2 || (args[0] != "-f" && args[0] != "-c"))
			{
				Console.WriteLine("BrainFry Interpreter - Command Line");
				Console.WriteLine();
				Console.WriteLine(" bfi -f <file name>    Interprets a specified brainfuck source file.");
				Console.WriteLine(" bfi -c <code>         Interprets specified brainfuck code.");
				return;
			}

			// Set up the compiler
			var compiler = new Compiler(CommandPresets.Default);

			// Parse the rest of the parameters
			var restArg = string.Join(" ", args.Skip(1));
			var code = args[0] == "-f" ? File.ReadAllText(restArg) : restArg;

			// Run it
			var program = compiler.Compile(code);
			program.Run();

#if DEBUG
			Console.Write("\nFinished executing, press any key to exit...");
			Console.ReadKey();
#endif
		}
	}
}