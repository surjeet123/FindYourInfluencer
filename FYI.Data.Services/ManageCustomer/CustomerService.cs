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
using System.Security.Cryptography;
using MongoDB.Driver;

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
            GenerateVerificationCode(newCustomer.Id);
            return true;
        }
        public bool GenerateVerificationCode(string customerID, bool checkExisting = false)
        {
            if (checkExisting)//Deactivate already issued verification code
            {
                // Define the update operation
                var update = Builders<CustomerVerificationCode>.Update.Set(x => x.Active, false);
                // Perform the update operation
                _unitOfWork.CustomerVerificationCodeRepository.UpdateManyAsync((x => x.CustomerID == customerID && x.Active == true), update);
            }
            var verificationCode = EncryptionUtilities.Generate4DigitNumber().ToString();
            var hashedCode = EncryptionUtilities.HashRawText(verificationCode);
            var customerVerificationModel = new CustomerVerificationCode
            {
                CustomerID = customerID,
                VerificationCode = hashedCode.HashedValue,
                Salt = hashedCode.Salt,
                Active = true
            };
            _unitOfWork.CustomerVerificationCodeRepository.InsertAsync(customerVerificationModel).Wait();
            _unitOfWork.Save().Wait();
            return true;
        }
        public bool VerifyCode(string customerID, string code)
        {
            var model = _unitOfWork.CustomerVerificationCodeRepository.GetFirstAsync(x => x.CustomerID == customerID && x.Active == true).Result;
            return EncryptionUtilities.VerifyHashValue(code, model.VerificationCode, model.Salt);
        }
        public string LoginCustomer(CustomerLoginModel Model)
        {
            var customerModel = _unitOfWork.CustomerRepository.GetFirstAsync(x => x.EmailAddress == EncryptionUtilities.Encrypt(Model.EmailAddress) && x.Active == true).Result;
            if (customerModel != null)
            {
                var passwordModel = _unitOfWork.CustomerPasswordRepository.GetFirstAsync(x => x.CustomerID == customerModel.Id && x.Active == true).Result;
                var result = EncryptionUtilities.VerifyHashValue(Model.Password, passwordModel.Password, passwordModel.PasswordSalt);
                if (result == true)
                    return customerModel.Id.ToString();
            }
            return null;
        }

    }
}
