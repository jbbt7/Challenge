using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DemoAPI.Utilities;

namespace DemoAPI.Utilities
{
	public class BootStrapper
	{
		public static void Run()
		{
			AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);	
		}
	}
}