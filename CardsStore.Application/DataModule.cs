using Autofac;
using CardsStore.Application.Services;
using CardsStore.Core.Data;

namespace CardsStore.Application
{
	public class DataModule: Module
	{
		private readonly string _connectionString;
		public DataModule(string connectionString)
		{
			_connectionString = connectionString;
		}

		protected override void Load(ContainerBuilder builder)
		{
			builder.Register<IDbContext>(c => new EntityDbContext(_connectionString));
			builder.RegisterGeneric(typeof (EntityRepository<>)).As(typeof (IRepository<>)).InstancePerLifetimeScope();

			builder.RegisterType<CardAppService>().As<ICardAppService>();

			base.Load(builder);
		}
	}
}
