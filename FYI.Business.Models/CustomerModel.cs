using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Business.Models
{
    public class CustomerModel : BaseModel
    {
        public string? CustomerName { get; set; }
        public int CityID { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobileNo { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsMobileVerified { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? BioDetails { get; set; }
        public bool IsBrand { get; set; }
        public string? ProfileImageURL { get; set; }
    }
    public class CustomerPassword : BaseModel
    {
        public int CustomerID { get; set; }
        public string? Password { get; set; }
        public string? PasswordSalt { get; set; }
        public bool LoginProviderID { get; set; }
        public bool IsVerified { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
