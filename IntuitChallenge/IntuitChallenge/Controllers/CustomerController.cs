using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DataTransferObjects;

namespace IntuitChallenge.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerBusiness customerBusiness;

		public CustomerController(ICustomerBusiness customerBusiness)
		{
			this.customerBusiness = customerBusiness;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] string? name)
		{
			var customers = await customerBusiness.GetAllAsync(name);

			return Ok(customers);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute]int id)
		{
			var customer = await customerBusiness.GetAsync(id);

			return Ok(customer);
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrUpdate([FromBody] DtoCustomer requestData)
		{
			if (!ModelState.IsValid) return BadRequest();

			await customerBusiness.CreateOrUpdateAsync(requestData);

			return Ok();
		}
	}
}
