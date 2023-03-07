using Model.Entities;

namespace Repository.Interfaces
{
	public interface ICustomerRepository : IRepository<Customer>
	{
		Task<List<Customer>> FilterAsync(string name);
		Task<bool> ExistsIdentificationNumberAsync(int idCustomer, string identificationNumber);
	}
}
