using System.Linq.Expressions;

namespace Repository.Interfaces
{
	public interface IRepository<T> where T : class
	{
		Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
		Task<List<T>> GetAllAsync();
		Task<T> GetAsync(int id);
		Task<List<T>> SearchAsync(Expression<Func<T, bool>> predicate);
		Task InsertAsync(T entity);
		Task SaveChangesAsync();
		Task UpdateAsync(T entity);
	}
}
