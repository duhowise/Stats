using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Stats.Controllers;
using Stats.DataAccess;

namespace Stats
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);

			var builder = new ContainerBuilder();
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			builder.RegisterType<StatsService>().As<IStatsService>();
			var container=	builder.Build();


			var resolver =new AutofacWebApiDependencyResolver(container);

			GlobalConfiguration.Configuration.DependencyResolver = resolver;
		}
	}
}
