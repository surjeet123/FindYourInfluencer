using FYI.Business.Models;
using FYI.Data.Services.ManageInfluencer;
using Microsoft.AspNetCore.Mvc;

namespace FindYourInfluencer.Controllers.API.Influencer
{
    [Route("api/[controller]")]
	[ApiController]
	public class InfluencerController : ControllerBase
	{
		private readonly IInfluencerService _InfluencerService;
		public InfluencerController(IInfluencerService InfluencerService)
		{
			_InfluencerService = InfluencerService;
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

		[HttpPost("UpdateBasicDetail")]
		public ActionResult UpdateInfluencerBasicDetail([FromBody] InfluencerProfileDetailModel Model)
		{
			_InfluencerService.UpdateOrInsertBasicDetailsAsync(Model);
			return Ok();
		}
	}
}
