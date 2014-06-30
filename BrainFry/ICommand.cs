namespace BrainFry
{
	public interface ICommand
	{
		char Char { get; }
		void Execute(ExecutionContext context);
	}
}