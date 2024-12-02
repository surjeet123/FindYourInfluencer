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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public bool IsEmailVerified { get; set; }
        public string? MobileNo { get; set; }
        public bool IsMobileVerified { get; set; }
        public int LoginProviderID { get; set; }//1 for self registration, 2 for google, 3 for facebook
        public bool IsVerified { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
    public class CustomerRegisterModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobileNo { get; set; }
        public int LoginProviderID { get; set; }//1 for self registration, 2 for google, 3 for facebook
        public string? Password { get; set; }
    }
    public class CustomerPasswordModel : BaseModel
    {
        public string CustomerID { get; set; }
        public string? Password { get; set; }
        public string? PasswordSalt { get; set; }
    }
    public class CustomerLoginModel
    {
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
    }
}
