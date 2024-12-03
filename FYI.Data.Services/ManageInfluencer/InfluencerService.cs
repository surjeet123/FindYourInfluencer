using AutoMapper;
using FYI.Business.Models;
using FYI.Data.Core;
using FYI.Data.Models;
using FYI.Data.Services.Utilities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Services.ManageInfluencer
{
    public class InfluencerService : IInfluencerService
	{
		private readonly UnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public InfluencerService(UnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}
		public bool CreateInfluencer(InfluencerRegisterModel Model)
		{
			// Encrypt sensitive information
			Model.EmailAddress = EncryptionUtilities.Encrypt(Model.EmailAddress);
			Model.MobileNo = EncryptionUtilities.Encrypt(Model.MobileNo);

			// Hash the password (using bcrypt for security)
			var hashedPassword = EncryptionUtilities.HashRawText(Model.Password);

			// Map the model to the customer entity
			var newInfluencer = _mapper.Map<Influencer>(Model);

			// Insert customer data and password data into the database
			_unitOfWork.InfluencerRepository.InsertAsync(newInfluencer).Wait();
			// Create a new CustomerPassword record for storing the hashed password
				var influencerPassword = new InfluencerPassword
				{
					InfluencerID = newInfluencer.Id, // Assuming the ID is generated on insert
					Password = hashedPassword.HashedValue,
					PasswordSalt = hashedPassword.Salt
				};
			_unitOfWork.InfluencerPasswordRepository.InsertAsync(influencerPassword).Wait();
			_unitOfWork.Save().Wait();
			GenerateVerificationCode(newInfluencer.Id);
			return true;
		}
		public bool GenerateVerificationCode(string influencerID, bool checkExisting = false)
		{
			if (checkExisting)//Deactivate already issued verification code
			{
				// Define the update operation
				var update = Builders<InfluencerVerificationCode>.Update.Set(x => x.Active, false);
				// Perform the update operation
				_unitOfWork.InfluencerVerificationCodeRepository.UpdateManyAsync((x => x.InfluencerID == influencerID && x.Active == true), update);
			}
			var verificationCode = EncryptionUtilities.Generate4DigitNumber().ToString();
			var hashedCode = EncryptionUtilities.HashRawText(verificationCode);
			var influencerVerificationModel = new InfluencerVerificationCode
			{
				InfluencerID = influencerID,
				VerificationCode = hashedCode.HashedValue,
				Salt = hashedCode.Salt,
				Active = true
			};
			_unitOfWork.InfluencerVerificationCodeRepository.InsertAsync(influencerVerificationModel).Wait();
			_unitOfWork.Save().Wait();
			return true;
		}
		public bool VerifyCode(string influencerID, string code)
		{
			var model = _unitOfWork.InfluencerVerificationCodeRepository.GetFirstAsync(x => x.InfluencerID == influencerID && x.Active == true).Result;
			return EncryptionUtilities.VerifyHashValue(code, model.VerificationCode, model.Salt);
		}
		public string LoginInfluencer(InfluencerLoginModel Model)
		{
			var influencerModel = _unitOfWork.InfluencerRepository.GetFirstAsync(x => x.EmailAddress == EncryptionUtilities.Encrypt(Model.EmailAddress) && x.Active == true).Result;
			if (influencerModel != null)
			{
				var passwordModel = _unitOfWork.InfluencerPasswordRepository.GetFirstAsync(x => x.InfluencerID == influencerModel.Id && x.Active == true).Result;
				var result = EncryptionUtilities.VerifyHashValue(Model.Password, passwordModel.Password, passwordModel.PasswordSalt);
				if (result == true)
					return influencerModel.Id.ToString();
			}
			return null;
		}
		public bool UpdateOrInsertBasicDetailsAsync(InfluencerProfileDetailModel Model)
		{
			// Check if the record exists
			var existingDetails =  _unitOfWork.InfluencerProfileRepository.GetFirstAsync(x => x.InfluencerID == Model.InfluencerID).Result;
			if (existingDetails == null)
			{
				// If no record exists, insert a new record
				var newInfluencerProfile = new InfluencerProfileDetail
				{
					InfluencerID = Model.InfluencerID,
					HeadLine = Model.HeadLine,
					BioDetails = Model.BioDetails,
					Gender = Model.Gender,
					Active = true
				};
				_unitOfWork.InfluencerProfileRepository.InsertAsync(newInfluencerProfile);
				return true;
			}
			// If the record exists, update it
			var update = Builders<InfluencerProfileDetail>.Update
				.Set(x => x.HeadLine, Model.HeadLine)
				.Set(x => x.BioDetails, Model.BioDetails)
				.Set(x => x.Gender, Model.Gender);

			var updateResult = _unitOfWork.InfluencerProfileRepository.UpdateAsync(x => x.InfluencerID == Model.InfluencerID && x.Active == true, update).Result;

			return updateResult;
		}


	}
}
