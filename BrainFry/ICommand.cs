namespace BrainFry
{
	public interface ICommand
	{
		void Execute(ExecutionContext execution, ThreadContext thread);
	}
}