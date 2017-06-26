using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CardsStore.Application;

namespace CardsStore.Web
{
	public class AutofacConfig
	{
		public static void ConfigureContainer(string connectionString)
		{
			var builder = new ContainerBuilder();

			builder.RegisterControllers(typeof (MvcApplication).Assembly);
			builder.RegisterModule(new DataModule(connectionString));

			var container = builder.Build();

			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}