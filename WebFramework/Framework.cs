using System;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace WebFramework
{
	internal class Framework
	{
		public void ProcessRequest(HttpListenerContext context)
		{
			// Get the request metadata
			var request = context.Request;
			var response = context.Response;

			Trace.TraceInformation("{0} {1} {2}", request.HttpMethod, DateTime.Now.ToString("O"), request.Url.LocalPath);

			// Construct a response
			var buffer = Encoding.UTF8.GetBytes("<html><body>Hello world!</body></html>");

			// Get a response stream and write the response to it
			var output = response.OutputStream;

			response.ContentLength64 = buffer.Length;
			output.Write(buffer, 0, buffer.Length);

			output.Close();
		}
	}
}