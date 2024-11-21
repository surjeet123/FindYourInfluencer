using FindYourInfluencer.Helper;
using FYI.Business.Models;
using FYI.Data.Models;
using FYI.Data.Services.ManageCustomer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpPost("RegisterCustomer")]
        public ActionResult<Customer> CustomerRegistration([FromBody] CustomerRegisterModel customer)
        {
            // Set the CreatedOn date to the current time

            // In a real-world scenario, you'd save this to the database
            _CustomerService.CreateCustomer(customer);

            // Return the newly added customer
            return Ok();
        }
        [HttpPost("ResendVerificationCode")]
        public ActionResult<Customer> ResendVerificationCode([FromBody] string customerID)
        {
            // Set the CreatedOn date to the current time

            // In a real-world scenario, you'd save this to the database
            _CustomerService.GenerateVerificationCode(customerID, true);

            // Return the newly added customer
            return Ok(true);
        }
        [HttpPost("VerifyCustomerVerificationCode")]
        public ActionResult<Customer> VerifyCustomerVerificationCode([FromBody] string customerID, string code)
        {
            // Set the CreatedOn date to the current time

            // In a real-world scenario, you'd save this to the database
            var result = _CustomerService.VerifyCode(customerID, code);

            // Return the newly added customer
            return Ok(result);
        }

    }
}
