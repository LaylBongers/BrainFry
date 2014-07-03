using System;
using System.Reflection;
using WebFramework;

namespace WebFrameworkConsole
{
	internal static class Program
	{
		private static void Main()
		{
			// Set up the service and object metadata
			var service = new Service();
			var serviceType = typeof (Service);

			// Call start on the service through reflection
			var onStart = serviceType.GetMethod("OnStart", BindingFlags.NonPublic | BindingFlags.Instance);
			onStart.Invoke(service, new object[] {null});

			// Wait for the user to press any key in the console window
			Console.Write("Press any key to stop the service...");
			Console.ReadKey(true);

			// Call stop on the service through reflection
			var onStop = serviceType.GetMethod("OnStop", BindingFlags.NonPublic | BindingFlags.Instance);
			onStop.Invoke(service, null);
		}
	}
}