using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Business.Models
{
    public class CategoryModel : BaseModel
    {
        public string? CategoryName { get; set; }
    }
    public class PlatformModel : BaseModel
    {
        public string? PlatformName { get; set; }
    }
    public class ServiceTypeModel : BaseModel
    {
        public string? ServiceTypeName { get; set; }
    }
    public class OrderStatusModel : BaseModel
    {
        public string? OrderStatusName { get; set; }
    }
    public class PaymentStatusModel : BaseModel
    {
        public string? PaymentStatusName { get; set; }
    }
    public class LoginProviderModel : BaseModel
    {
        public string? LoginProviderName { get; set; }
    }
    public class CountryModel : BaseModel
    {
        public string? CountryName { get; set; }
    }
    public class StateModel : BaseModel
    {
        public string? StateName { get; set; }
    }
    public class CityModel : BaseModel
    {
        public string? CityName { get; set; }
    }
}
