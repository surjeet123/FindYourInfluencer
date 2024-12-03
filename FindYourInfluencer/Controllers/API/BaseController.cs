using FindYourInfluencer.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FindYourInfluencer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult GenerateApiResponse<T>(bool isSuccess, string message, T data = default, string token = "", HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var responseModel = new APIResponseModel<T>(isSuccess, message, token, data);

            // Return appropriate status code based on the passed statusCode
            return statusCode switch
            {
                HttpStatusCode.Unauthorized => Unauthorized(responseModel),
                HttpStatusCode.BadRequest => BadRequest(responseModel),
                HttpStatusCode.OK => Ok(responseModel),
                _ => StatusCode((int)statusCode, responseModel)
            };
        }
    }
}
