namespace BrainFry
{
	public interface ICommand
	{
		void Execute(ThreadContext thread);
	}
}