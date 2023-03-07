using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
	public class Customer
	{
		[Key]
		public int IdCustomer { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime Birthdate { get; set; }
		public string IdentificationNumber { get; set; }
		public string Adress { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

	}
}
