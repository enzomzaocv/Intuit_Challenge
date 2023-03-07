using Microsoft.EntityFrameworkCore;
using Model.Context;
using Model.Entities;
using Repository.Interfaces;

namespace Repository.Implementations
{
	public class CustomerRepository : Repository<Customer>, ICustomerRepository
	{
		public CustomerRepository(CoreDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<bool> ExistsIdentificationNumberAsync(int idCustomer, string identificationNumber)
		{
			return await AnyAsync(x => 
				x.IdentificationNumber == identificationNumber && x.IdCustomer != idCustomer 
				|| x.IdentificationNumber == identificationNumber && idCustomer <= default(int));
		}

		public async Task<List<Customer>> FilterAsync(string name)
		{
			return await SearchAsync(x => string.IsNullOrWhiteSpace(name) || x.Name.Contains(name) || x.Surname.Contains(name));
		}
	}
}
