using Microsoft.EntityFrameworkCore;
using Model.Context;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository.Implementations
{
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		private readonly CoreDbContext dbContext;

		public Repository(CoreDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
		{
			return await dbContext.Set<T>().AnyAsync(predicate);
		}

		public async Task<T> GetAsync(int id)
		{
			return await dbContext.Set<T>().FindAsync(id);
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await dbContext.Set<T>().ToListAsync();
		}

		public async Task InsertAsync(T entity)
		{
			await dbContext.Set<T>().AddAsync(entity);
		}

		public async Task<List<T>> SearchAsync(Expression<Func<T,bool>> predicate)
		{
			return await dbContext.Set<T>().Where(predicate).ToListAsync();
		}

		public async Task SaveChangesAsync()
		{
			await dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			dbContext.Set<T>().Update(entity);

			await dbContext.SaveChangesAsync();
		}
	}
}
