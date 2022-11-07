using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

//using example from https://www.c-sharpcorner.com/article/using-autofac-with-web-api/
namespace DemoAPI.Utilities
{
	public class AutofacWebapiConfig
	{
		public static IContainer Container;
		public static void Initialize(HttpConfiguration config)
		{
			Initialize(config, RegisterServices(new ContainerBuilder()));
		}

		public static void Initialize(HttpConfiguration config, IContainer Container)
		{
			config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
		}

		private static IContainer RegisterServices(ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			containerBuilder.RegisterType<SimplePatientFormatter>().As<IPatientFormatter>();
			Container = containerBuilder.Build();
			return Container;
		}
	}
}