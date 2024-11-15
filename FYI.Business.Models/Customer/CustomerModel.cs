using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Business.Models.Customer
{
    public class CustomerModel
    {
        public string? CustomerName { get; set; }
        public int CityID { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobileNo { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsMobileVerified { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? BioDetails { get; set; }
        public bool IsBrand { get; set; }
        public string? ProfileImageURL { get; set; }
    }
}
