using Model.DataTransferObjects;

namespace Business.Interfaces
{
	public interface ICustomerBusiness
	{
		Task<List<DtoCustomer>> GetAllAsync(string name);
		Task<DtoCustomer> GetAsync(int id);
		Task CreateOrUpdateAsync(DtoCustomer entity);
		//Task UpdateAsync(DtoCustomer entity);
	}
}
