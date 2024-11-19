using AutoMapper;
using FYI.Business.Models;
using FYI.Data.Core;
using FYI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Services.ManageCustomer
{
    public class CustomerService : ICustomerService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public bool CreateCustomer(CustomerModel Model)
        {
            var newCustomer = _mapper.Map<Customer>(Model);
             _unitOfWork.CustomerRepository.InsertAsync(newCustomer).Wait();
            _unitOfWork.Save().Wait();
            return true;
        }
    }
}
