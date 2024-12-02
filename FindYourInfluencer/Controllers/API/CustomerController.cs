using FindYourInfluencer.Helper;
using FindYourInfluencer.Utilities;
using FYI.Business.Models;
using FYI.Data.Services.ManageCustomer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;

namespace FindYourInfluencer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;
        private readonly JWTTokenUtilities _jwtTokenUtilities;
        public CustomerController(ICustomerService CustomerService, JWTTokenUtilities jwtTokenUtilities)
        {
            _CustomerService = CustomerService;
            _jwtTokenUtilities = jwtTokenUtilities;
        }

        [HttpPost("RegisterCustomer")]
        public ActionResult CustomerRegistration([FromBody] CustomerRegisterModel customer)
        {
            // Set the CreatedOn date to the current time

            // In a real-world scenario, you'd save this to the database
            _CustomerService.CreateCustomer(customer);

            // Return the newly added customer
            return Ok();
        }

        [HttpPost("ResendVerificationCode")]
        public ActionResult ResendVerificationCode([FromBody] string customerID)
        {
            // Set the CreatedOn date to the current time

            // In a real-world scenario, you'd save this to the database
            _CustomerService.GenerateVerificationCode(customerID, true);

            // Return the newly added customer
            return Ok(true);
        }

        [HttpPost("VerifyCustomerVerificationCode")]
        public ActionResult VerifyCustomerVerificationCode([FromBody] string customerID, string code)
        {
            // Set the CreatedOn date to the current time

            // In a real-world scenario, you'd save this to the database
            var result = _CustomerService.VerifyCode(customerID, code);

            // Return the newly added customer
            return Ok(result);
        }
        [HttpPost("LoginCustomer")]
        public ActionResult LoginCustomer([FromBody] CustomerLoginModel Model)
        {
            var result = _CustomerService.LoginCustomer(Model);
            if (result != null)
            {        // Generate the JWT token
                var token = _jwtTokenUtilities.GenerateToken(result, "Customer");
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid username or password." });
            }
        }
        [HttpPost("CustomerDetails")]
        [Authorize(Roles = "Customer")]
        public ActionResult GetCustomerDetails(string customerID)
        {
            return Ok();
        }


    }
}
