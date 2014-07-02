using System.Threading;

namespace BrainFry
{
	class ExecutionThread
	{
		private readonly Thread _thread;
		private readonly ExecutionContext _executionContext;
		private readonly ThreadContext _threadContext;
		private readonly int _procedureId;

		public ExecutionThread(ExecutionContext execution, int memoryPointer, int commandPointer, int procedureId = -1)
		{
			// Setup thread metadata
			_executionContext = execution;
			_threadContext = new ThreadContext(memoryPointer, commandPointer);
			_procedureId = procedureId;

			_thread = new Thread(Run);

			// Check if we need to add ourselves to the thread list
			if (_procedureId != -1)
				_executionContext.RegisterThread(_procedureId, this);

			// Actually start the thread
			_thread.Start();
		}

		private void Run()
		{
			// Run all the commands
			for (; _threadContext.CommandPointer < _executionContext.Commands.Count; _threadContext.CommandPointer++)
			{
				_executionContext.Commands[_threadContext.CommandPointer].Execute(_executionContext, _threadContext);
			}

			// Check if we need to remove ourselves from the thread list
			if (_procedureId != -1)
				_executionContext.RemoveThread(_procedureId, this);
		}

		public void Join()
		{
			_thread.Join();
		}
	}
}
