using FYI.Business.Models;
using FindYourInfluencer.Utilities;
using FYI.Data.Services.ManageInfluencer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FindYourInfluencer.Controllers.API.Influencer
{
    [Route("api/[controller]")]
	[ApiController]
	public class InfluencerController : ControllerBase
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
			_InfluencerService.CreateInfluencer(model);
			return Ok();
		}

		[HttpPost("ResendInfluencerVerificationCode")]
		public ActionResult ResendInfluencerVerificationCode([FromBody] string influencerID)
		{
			_InfluencerService.GenerateVerificationCode(influencerID, true);
			return Ok(true);
		}

		[HttpPost("VerifyInfluencerVerificationCode")]
		public ActionResult VerifyInfluencerVerificationCode([FromBody] string influencerID, string code)
		{
			var result = _InfluencerService.VerifyCode(influencerID, code);
			return Ok(result);
		}

		[HttpPost("LoginInfluencer")]
		public ActionResult LoginInfluencer([FromBody] InfluencerLoginModel Model)
		{
			var result = _InfluencerService.LoginInfluencer(Model);
			if (result != null)
			{        // Generate the JWT token
				var token = _jwtTokenUtilities.GenerateToken(result, "Influencer");
				return Ok(new { Token = token });
			}
			else
			{
				return Unauthorized(new { Message = "Invalid username or password." });
			}
		}

		[HttpPost("UpdateBasicDetail")]
		[Authorize(Roles = "Influencer")]
		public ActionResult UpdateInfluencerBasicDetail([FromBody] InfluencerProfileDetailModel Model)
		{
			_InfluencerService.UpdateOrInsertBasicDetailsAsync(Model);
			return Ok();
		}
	}
}
