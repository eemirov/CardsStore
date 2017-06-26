using System.Data.Entity;
using CardsStore.Core.Entities;

namespace CardsStore.Core.Data
{
	public interface IDbContext
	{
		IDbSet<T> Set<T>() where T : Entity;
		int SaveChanges();
	}
}