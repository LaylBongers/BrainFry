using System.Threading;

namespace BrainFry
{
	class ExecutionThread
	{
		private readonly Thread _thread;
		private readonly ExecutionContext _executionContext;
		private readonly ThreadContext _threadContext;

		public ExecutionThread(ExecutionContext execution, int memoryPointer, int commandPointer)
		{
			_executionContext = execution;
			_threadContext = new ThreadContext(memoryPointer, commandPointer);
			_thread = new Thread(Run);
			_thread.Start();
		}

		private void Run()
		{
			for (; _threadContext.CommandPointer < _executionContext.Commands.Count; _threadContext.CommandPointer++)
			{
				_executionContext.Commands[_threadContext.CommandPointer].Execute(_executionContext, _threadContext);
			}
		}

		public void Join()
		{
			_thread.Join();
		}
	}
}
