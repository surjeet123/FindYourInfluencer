using FYI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Services.ManageInfluencer
{
	public interface IInfluencerService
	{
		bool CreateInfluencer(InfluencerRegisterModel Model);
		bool GenerateVerificationCode(string influencerID, bool checkExisting = false);
		bool VerifyCode(string influencerID, string code);
		string LoginInfluencer(InfluencerLoginModel Model);
		bool UpdateOrInsertBasicDetailsAsync(InfluencerProfileDetailModel Model);
	}
}
