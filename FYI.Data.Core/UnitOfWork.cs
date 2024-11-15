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
        public UnitOfWork(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase("FindYourInfluencer");
        }
        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new GenericRepository<Customer>(_database, "customers");
                }
                return _customerRepository;
            }
        }

        public async Task Save()
        {
            // You may not need to do anything here depending on your implementation
            // For some scenarios, MongoDB operations are automatically committed
            // However, if you are using transactions or other advanced features, you might need to implement additional logic.
        }
    }
}
