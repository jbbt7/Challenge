using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

//
// Used code from https://stackoverflow.com/questions/25631970/how-to-post-plain-text-to-asp-net-web-api-endpoint
//
namespace DemoAPI.Utilities
{
	/// <summary>
	/// Serialize data in http body with "text/plain" format to string type
	/// </summary>
	public class TextMediaTypeFormatter : MediaTypeFormatter
	{
		public TextMediaTypeFormatter()
		{
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
		}

		public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
		{
			var taskCompletionSource = new TaskCompletionSource<object>();
			try
			{
				var memoryStream = new MemoryStream();
				readStream.CopyTo(memoryStream);
				string s = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());

				taskCompletionSource.SetResult(s);
			}
			catch (Exception e)
			{
				taskCompletionSource.SetException(e);
			}
			return taskCompletionSource.Task;
		}

		public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext, CancellationToken cancellationToken)
		{
			var buff = System.Text.Encoding.UTF8.GetBytes(value.ToString());
			return writeStream.WriteAsync(buff, 0, buff.Length, cancellationToken);
		}
		public override bool CanReadType(Type type)
		{
			return type == typeof(string);
		}

		public override bool CanWriteType(Type type)
		{
			return type == typeof(string);
		}
	}
}