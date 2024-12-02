using FYI.Data.Models;
using FYI.Data.Models.Master;
using FYI.Data.Core.Generic;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Core
{
    public class UnitOfWork
    {
        private readonly IMongoDatabase _database;
        private IRepository<Customer> _customerRepository;
        private IRepository<CustomerPassword> _customerPasswordRepository;
        private IRepository<CustomerVerificationCode> _customerVerificationCodeRepository;

		#region Influencer
		private IRepository<Influencer> _influencerRepository;
		private IRepository<InfluencerPassword> _influencerPasswordRepository;
		private IRepository<InfluencerVerificationCode> _influencerVerificationCodeRepository;
		private IRepository<InfluencerProfileDetail> _influencerProfileRepository;
		#endregion

		public UnitOfWork(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase("FindYourInfluencer");
        }
        public IRepository<Customer> CustomerRepository => _customerRepository ??= new GenericRepository<Customer>(_database, "customers");
        public IRepository<CustomerPassword> CustomerPasswordRepository => _customerPasswordRepository ??= new GenericRepository<CustomerPassword>(_database, "customerpasswords");
        public IRepository<CustomerVerificationCode> CustomerVerificationCodeRepository => _customerVerificationCodeRepository ??= new GenericRepository<CustomerVerificationCode>(_database, "customerverificationcodes");

		#region Influencer

		public IRepository<Influencer> InfluencerRepository => _influencerRepository ??= new GenericRepository<Influencer>(_database, "influencers");
		public IRepository<InfluencerPassword> InfluencerPasswordRepository => _influencerPasswordRepository ??= new GenericRepository<InfluencerPassword>(_database, "influencerpasswords");
		public IRepository<InfluencerVerificationCode> InfluencerVerificationCodeRepository => _influencerVerificationCodeRepository ??= new GenericRepository<InfluencerVerificationCode>(_database, "influencerverificationcodes");
		public IRepository<InfluencerProfileDetail> InfluencerProfileRepository => _influencerProfileRepository ??= new GenericRepository<InfluencerProfileDetail>(_database, "influencerprofiledetails");

		#endregion

		public async Task Save()
        {
            // You may not need to do anything here depending on your implementation
            // For some scenarios, MongoDB operations are automatically committed
            // However, if you are using transactions or other advanced features, you might need to implement additional logic.
        }
    }
}
