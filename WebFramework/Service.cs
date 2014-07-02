using System.Diagnostics;
using System.ServiceProcess;

namespace WebFramework
{
	public partial class Service : ServiceBase
	{
		public Service()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			Trace.TraceInformation("BrainFry Web Framework started!");
		}

		protected override void OnStop()
		{
			Trace.TraceInformation("BrainFry Web Framework stopped!");
		}
	}
}