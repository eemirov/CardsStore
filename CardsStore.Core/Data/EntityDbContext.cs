using System.Collections.Generic;
using System.Data.Entity;
using CardsStore.Core.Entities;

namespace CardsStore.Core.Data
{
	public class EntityDbContext: DbContext, IDbContext
	{
		public IDbSet<Card> Cards { get; set; }
		public IDbSet<Category> Categories { get; set; } 

		static EntityDbContext()
		{
			Database.SetInitializer(new DbInitializer());
		}

		public EntityDbContext(string connectionstring) : base(connectionstring)
		{
			
		}

		public new IDbSet<T> Set<T>() where T : Entity
		{
			return base.Set<T>();
		}
	}
}