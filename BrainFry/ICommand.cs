namespace BrainFry
{
	public interface ICommand
	{
		void Execute(ExecutionContext context);
	}
}