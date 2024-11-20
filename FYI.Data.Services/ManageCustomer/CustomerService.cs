using AutoMapper;
using FYI.Business.Models;
using FYI.Data.Core;
using FYI.Data.Models;
using FYI.Data.Services.Utilities;
using FYI.Data.Services.Infrastructure;
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
        public bool CreateCustomer(CustomerRegisterModel Model)
        {
            // Encrypt sensitive information
            Model.EmailAddress = EncryptionUtilities.Encrypt(Model.EmailAddress);
            Model.MobileNo = EncryptionUtilities.Encrypt(Model.MobileNo);

            // Hash the password (using bcrypt for security)
            var hashedPassword = EncryptionUtilities.HashRawText(Model.Password);

            // Map the model to the customer entity
            var newCustomer = _mapper.Map<Customer>(Model);

            // Insert customer data and password data into the database
            _unitOfWork.CustomerRepository.InsertAsync(newCustomer).Wait();
            // Create a new CustomerPassword record for storing the hashed password
            var customerPassword = new CustomerPassword
            {
                CustomerID = newCustomer.Id, // Assuming the ID is generated on insert
                Password = hashedPassword.HashedValue,
                PasswordSalt = hashedPassword.Salt
            };
            _unitOfWork.CustomerPasswordRepository.InsertAsync(customerPassword).Wait();
            _unitOfWork.Save().Wait();

            return true;
        }
    }
}
