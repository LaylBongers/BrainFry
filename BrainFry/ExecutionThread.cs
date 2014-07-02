using System.Threading;

namespace BrainFry
{
	class ExecutionThread
	{
		private readonly Thread _thread;
		private readonly ThreadContext _context;
		private readonly int _procedureId;

		public ExecutionThread(ExecutionContext execution, int memoryPointer, int commandPointer, int procedureId = -1)
		{
			// Setup thread metadata
			_context = new ThreadContext(execution, memoryPointer, commandPointer);
			_procedureId = procedureId;

			_thread = new Thread(Run);

			// Check if we need to add ourselves to the thread list
			if (_procedureId != -1)
				_context.Execution.RegisterThread(_procedureId, this);

			// Actually start the thread
			_thread.Start();
		}

		private void Run()
		{
			// Run all the commands
			for (; _context.CommandPointer < _context.Execution.Commands.Count; _context.CommandPointer++)
			{
				_context.CurrentCommand.Execute(_context);
			}

			// Check if we need to remove ourselves from the thread list
			if (_procedureId != -1)
				_context.Execution.RemoveThread(_procedureId, this);
		}

		public void Join()
		{
			_thread.Join();
		}
	}
}
