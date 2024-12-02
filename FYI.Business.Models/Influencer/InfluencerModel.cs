using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Business.Models
{
	public class InfluencerModel : BaseModel
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? EmailAddress { get; set; }
		public string? MobileNo { get; set; }
		public bool IsEmailVerified { get; set; }
		public bool IsMobileVerified { get; set; }
		public bool? IsProfileVerified { get; set; }
		
	}
	public class InfluencerRegisterModel
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? EmailAddress { get; set; }
		public string? MobileNo { get; set; }
		public string? Password { get; set; }
	}
	public class InfluencerPasswordModel : BaseModel
	{
		public string InfluencerID { get; set; }
		public string? Password { get; set; }
		public string? PasswordSalt { get; set; }
	}
	public class InfluencerProfileDetailModel :  BaseModel
	{
		public string InfluencerID { get; set; }
		public string? HeadLine { get; set; }
		public string? BioDetails { get; set; }
		public string? Gender { get; set; }
	}
}
