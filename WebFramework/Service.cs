using System;
using System.Diagnostics;
using System.Net;
using System.ServiceProcess;
using System.Threading;

namespace WebFramework
{
	public partial class Service : ServiceBase
	{
		private HttpListener _listener;
		private Thread _thread;
		private bool _keepListening;
		private Framework _framework;

		public Service()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			Trace.TraceInformation("Initializing BrainFry Web Framework...");

			// Make sure the HttpListener is supported
			if (!HttpListener.IsSupported)
			{
				Trace.TraceError("HttpListener class not supported by the platform.");
				throw new NotSupportedException("HttpListener class not supported by the platform.");
			}

			// Set up the HttpListener's configuration
			_listener = new HttpListener();
			_listener.Prefixes.Add("http://+:80/");

			// Set up the Framework
			_framework = new Framework();

			// Start running the internal listen thread
			_thread = new Thread(ListenThread);
			_thread.Start();

			Trace.TraceInformation("BrainFry Web Framework started!");
		}

		protected override void OnStop()
		{
			Trace.TraceInformation("Attempting to stop BrainFry Web Framework...");

			_keepListening = false;
			_thread.Join();

			Trace.TraceInformation("BrainFry Web Framework stopped!");
		}

		private void ListenThread()
		{
			// Start up the listener
			// If this throws an exception, run as admin
			_listener.Start();

			// Fire off the first get context, the callback will renew itself
			_listener.BeginGetContext(OnContextReceived, _listener);

			_keepListening = true;
			while (_keepListening)
			{
				Thread.Sleep(1);
			}

			_listener.Stop();
		}

		private void OnContextReceived(IAsyncResult ar)
		{
			try
			{
				// Await a web request using GetContext
				var context = _listener.EndGetContext(ar);

				_framework.ProcessRequest(context);

				// Renew the get context request
				_listener.BeginGetContext(OnContextReceived, _listener);
			}
			catch (HttpListenerException e)
			{
				// 995 is an exception that sometimes happens when the thread is stopped
				if (e.ErrorCode != 995)
					throw;
			}
		}
	}
}