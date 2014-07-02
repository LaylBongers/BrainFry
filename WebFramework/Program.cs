﻿using System.ServiceProcess;

namespace WebFramework
{
	internal static class Program
	{
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		private static void Main()
		{
			var servicesToRun = new ServiceBase[]
			{
				new Service()
			};
			ServiceBase.Run(servicesToRun);
		}
	}
}