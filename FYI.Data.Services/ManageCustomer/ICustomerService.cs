using FYI.Business.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Services.ManageCustomer
{
    public  interface ICustomerService
    {
        bool CreateCustomer(CustomerModel Model);
    }
}
