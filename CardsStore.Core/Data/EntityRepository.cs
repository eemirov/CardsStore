using System;
using System.Data.Entity;
using System.Linq;
using CardsStore.Core.Entities;

namespace CardsStore.Core.Data
{
	public class EntityRepository<T>: IRepository<T> where T:Entity
	{
		private readonly IDbContext _dbContext;
		private IDbSet<T> _entities;

		protected IDbSet<T> Entities
		{
			get
			{
				if (_entities == null)
					_entities = _dbContext.Set<T>();
				return _entities;
			}
		}

		public IQueryable<T> GetAll()
		{
			return this.Entities;
		} 

		public EntityRepository(IDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public T GetById(int id)
		{
			return this.Entities.Find(id);
		}

		public void Insert(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			this.Entities.Add(entity);

			this._dbContext.SaveChanges();
		}

		public void Update(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			this._dbContext.SaveChanges();
		}

		public void Delete(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			this.Entities.Remove(entity);
			this._dbContext.SaveChanges();
		}
	}
}