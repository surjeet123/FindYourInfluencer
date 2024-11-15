using FYI.Business.Models.Customer;
using FYI.Data.Models;
using FYI.Data.Services.ManageCustomer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindYourInfluencer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;
        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [HttpPost("SaveCustomer")]
        public ActionResult<Customer> AddCustomer([FromBody] CustomerModel customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is required.");
            }

            // Simple validation: Ensure a customer name is provided
            if (string.IsNullOrWhiteSpace(customer.CustomerName))
            {
                return BadRequest("Customer name is required.");
            }

            // Set the CreatedOn date to the current time
            customer.CreatedOn = DateTime.Now;

            // In a real-world scenario, you'd save this to the database
            _CustomerService.CreateCustomer(customer);

            // Return the newly added customer
            return Ok();
        }
    }
}
