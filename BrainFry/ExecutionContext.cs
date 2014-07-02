using System;
using System.Collections.Generic;

namespace BrainFry
{
	public sealed class ExecutionContext
	{
		public readonly IList<ICommand> Commands;
		public readonly byte[] Memory;
		public readonly int[] ProcedurePointers;

		private readonly List<ExecutionThread>[] _procedureThreads;

		public ExecutionContext(IList<ICommand> commands)
		{
			Memory = new byte[5000];
			Commands = commands;

			ProcedurePointers = new int[byte.MaxValue];
			_procedureThreads = new List<ExecutionThread>[byte.MaxValue];
			for (var i = 0; i < _procedureThreads.Length; i++)
			{
				_procedureThreads[i] = new List<ExecutionThread>();
			}
		}

		internal void RegisterThread(int procedureId, ExecutionThread thread)
		{
			lock (_procedureThreads[procedureId])
			{
				_procedureThreads[procedureId].Add(thread);
			}
		}

		internal void RemoveThread(int procedureId, ExecutionThread thread)
		{
			lock (_procedureThreads[procedureId])
			{
				_procedureThreads[procedureId].Remove(thread);
			}
		}

		internal void JoinThreads(int procedureId)
		{
			var tempList = new List<ExecutionThread>();
			lock (_procedureThreads[procedureId])
			{
				tempList.AddRange(_procedureThreads[procedureId]);
			}
			
			foreach (var thread in tempList)
			{
				thread.Join();
			}
		}
	}
}