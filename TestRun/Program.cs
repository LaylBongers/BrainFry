using System;
using BrainFry;
using BrainFry.Commands;

namespace TestRun
{
	internal static class Program
	{
		// Complex Hello World that tends to crash interpreters
		private const string InputCode =
			">++++++++[<+++++++++>-]<.>>+>+>++>[-]+<[>[->+<<++++>]<<]>.+++++++..+++.>" +
			">+++++++.<<<[[-]<[-]>]<+++++++++++++++.>>.+++.------.--------.>>+.>++++.";

		private static void Main()
		{
			var compiler = new Compiler(CommandPresets.Default);
			var program = compiler.Compile(InputCode);
			program.Run();

#if DEBUG
			Console.Write("\nFinished executing, press any key to exit...");
			Console.ReadKey();
#endif
		}
	}
}