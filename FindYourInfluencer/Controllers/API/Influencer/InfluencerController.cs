using FYI.Business.Models;
using FindYourInfluencer.Utilities;
using FYI.Data.Services.ManageInfluencer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FindYourInfluencer.Helper;
using NuGet.Common;
using System.Net;

namespace FindYourInfluencer.Controllers.API.Influencer
{
    [Route("api/[controller]")]
	[ApiController]
	public class InfluencerController : BaseController
    {
		private readonly IInfluencerService _InfluencerService;
		private readonly JWTTokenUtilities _jwtTokenUtilities;
		public InfluencerController(IInfluencerService InfluencerService, JWTTokenUtilities jwtTokenUtilities)
		{
			_InfluencerService = InfluencerService;
			_jwtTokenUtilities = jwtTokenUtilities;
		}

		[HttpPost("RegisterInfluencer")]
		public ActionResult InfluencerRegistration([FromBody] InfluencerRegisterModel model)
		{
			var result = _InfluencerService.CreateInfluencer(model);
            if (result)
            {
                return GenerateApiResponse<InfluencerModel>(true, "Influencer registered successfully");
            }
            else
            {
                return GenerateApiResponse<InfluencerModel>(false, "Registration failed.");
            }
        }

		[HttpPost("ResendInfluencerVerificationCode")]
		public ActionResult ResendInfluencerVerificationCode([FromBody] string influencerID)
		{
			var result = _InfluencerService.GenerateVerificationCode(influencerID, true);
            return GenerateApiResponse<InfluencerModel>(result, "Verification code sent successfully");
        }

		[HttpPost("VerifyInfluencerVerificationCode")]
		public ActionResult VerifyInfluencerVerificationCode([FromBody] string influencerID, string code)
		{
			var result = _InfluencerService.VerifyCode(influencerID, code);
            return GenerateApiResponse<InfluencerModel>(result, "Influencer number successfully verified");
        }

		[HttpPost("LoginInfluencer")]
		public ActionResult LoginInfluencer([FromBody] InfluencerLoginModel Model)
		{
			var result = _InfluencerService.LoginInfluencer(Model);
			if (result != null)
			{        
				// Generate the JWT token
				var token = _jwtTokenUtilities.GenerateToken(result, "Influencer");
				return GenerateApiResponse<InfluencerModel>(true, "Logged in successfully", token: token);
            }
			else
			{
				return GenerateApiResponse<InfluencerModel>(false, "Invalid username or password.", statusCode: HttpStatusCode.BadRequest);
            }
		}

		[HttpPost("UpdateBasicDetail")]
		[Authorize(Roles = "Influencer")]
		public ActionResult UpdateInfluencerBasicDetail([FromBody] InfluencerProfileDetailModel Model)
		{
			var result = _InfluencerService.UpdateOrInsertBasicDetailsAsync(Model);
            return GenerateApiResponse<InfluencerModel>(true, "Influencer details updated successfully");
        }
	}
}
