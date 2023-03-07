using Business.Interfaces;
using Model.DataTransferObjects;
using Model.Entities;
using Repository.Interfaces;
using System.Text.RegularExpressions;

namespace Business.Implemetations
{
	public class CustomerBusiness : ICustomerBusiness
	{
		private readonly ICustomerRepository customerRepository;

		public CustomerBusiness(ICustomerRepository customerRepository)
		{
			this.customerRepository = customerRepository;
		}

		public async Task<List<DtoCustomer>> GetAllAsync(string name)
		{
			var customers = await customerRepository.FilterAsync(name);

			return customers.Select(x => new DtoCustomer(x)).ToList();
		}

		public async Task<DtoCustomer> GetAsync(int id)
		{
			var customer = await customerRepository.GetAsync(id);

			if (customer == null) return null; 

			return new DtoCustomer(customer);
		}

		public async Task CreateOrUpdateAsync(DtoCustomer requestData)
		{
			if (!validateIdentificationNumber(requestData.IdentificationNumber)) throw new Exception("CUIT invalido.");

			var birthdate = !string.IsNullOrWhiteSpace(requestData.Birthdate) 
				? ParseBirthDate(requestData.Birthdate) 
				: null;

			var customer = new Customer();

			if (requestData.IdCustomer.HasValue && requestData.IdCustomer > default(int))
			{
				customer = await customerRepository.GetAsync(requestData.IdCustomer.Value);

				if (customer == null) throw new Exception("Cliente no encontrado.");
			}
			else
			{
				await customerRepository.InsertAsync(customer);
			}

			if (await customerRepository.ExistsIdentificationNumberAsync(requestData.IdCustomer ?? default, requestData.IdentificationNumber))
				throw new Exception("CUIT ya existe.");

			customer.Birthdate = birthdate.Value;
			customer.Phone = requestData.Phone;
			customer.Surname = requestData.Surname;
			customer.Name = requestData.Name;
			customer.Adress = requestData.Address;
			customer.IdentificationNumber = requestData.IdentificationNumber;
			customer.Email = requestData.Email;


			await customerRepository.SaveChangesAsync();
		}

		private DateTime? ParseBirthDate(string birthDate)
		{
			DateTime date;

			if (!DateTime.TryParseExact(birthDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
			{
				throw new Exception("Fecha de Nacimiento invalida.");
			}

			return date;
		}

		public bool validateIdentificationNumber(string identificationNumber)
		{
			var regex = new Regex(@"(20|2[3-7]|30|3[3-4])\-(\d{8})\-(\d)");

			return regex.IsMatch(identificationNumber);
		}
	}
}
