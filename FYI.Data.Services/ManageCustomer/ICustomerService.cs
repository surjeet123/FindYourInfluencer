using FYI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Services.ManageCustomer
{
    public  interface ICustomerService
    {
        bool CreateCustomer(CustomerRegisterModel Model);
    }
}
