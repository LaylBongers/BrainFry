using System;
using System.Diagnostics;
using System.IO;
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
			var targetDirectory = new DirectoryInfo("." + request.Url.LocalPath);

			Trace.TraceInformation("{0} {1}: {2}", DateTime.Now.ToString("O"), request.HttpMethod, targetDirectory);

			// Construct a response
			var buffer = Encoding.UTF8.GetBytes(string.Format("<html><body>Hello, {0}!</body></html>", targetDirectory.FullName));

			// Get a response stream and write the response to it
			var output = response.OutputStream;

			response.ContentLength64 = buffer.Length;
			output.Write(buffer, 0, buffer.Length);

			output.Close();
		}
	}
}