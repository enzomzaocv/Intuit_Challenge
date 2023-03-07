using Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model.DataTransferObjects
{
	public class DtoCustomer
	{
		public int? IdCustomer { get; set; }

		[Required(AllowEmptyStrings =false)]
		[MaxLength(70)]
		public string Name { get; set; }

		[Required(AllowEmptyStrings = false)]
		[MaxLength(70)]
		public string Surname { get; set; }

		[JsonPropertyName("cuit")]
		[Required(AllowEmptyStrings = false)]
		[MaxLength(13)]
		[MinLength(13)]
		public string IdentificationNumber { get; set; }

		[MaxLength(100)]
		public string Address { get; set; }

		[Required(AllowEmptyStrings = false)]
		[MaxLength(13)]
		[Phone]
		public string Phone { get; set; }

		[Required(AllowEmptyStrings = false)]
		[EmailAddress]
		[MaxLength(70)]
		public string Email { get; set; }

		[MaxLength(10)]
		public string Birthdate { get; set; }

		public DtoCustomer(Customer customer)
		{
			this.Surname = customer.Surname;
			this.IdentificationNumber = customer.IdentificationNumber;
			this.Address = customer.Adress;
			this.Phone = customer.Phone;
			this.Email = customer.Email;
			this.Birthdate = customer.Birthdate.ToString("dd/MM/yyyy");
			this.IdCustomer = customer.IdCustomer;
			this.Name = customer.Name;
		}

		public DtoCustomer()
		{
		}

		public Customer ToCustumerEntity()
		{
			return new Customer
			{
				Phone = this.Phone,
				Surname = this.Surname,
				Name = this.Name,
				Adress = this.Address,
				IdentificationNumber = this.IdentificationNumber,
				Email = this.Email
			};
		}
	}
}
