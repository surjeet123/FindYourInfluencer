using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Core.Generic
{
    public class GenericRepository<TDocument> : IRepository<TDocument> where TDocument : class
    {
        private readonly IMongoCollection<TDocument> _collection;

        public GenericRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<TDocument>(collectionName);
        }

        public async Task<TDocument> InsertAsync(TDocument document)
        {
            await _collection.InsertOneAsync(document);
            return document;
        }

        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            var documents = await _collection.Find(new BsonDocument()).ToListAsync();
            return documents;
        }

        public async Task<IEnumerable<TDocument>> GetAsync(Expression<Func<TDocument, bool>> filter)
        {
            var documents = await _collection.Find(filter).ToListAsync();
            return documents;
        }
        public async Task<TDocument> GetFirstAsync(Expression<Func<TDocument, bool>> filter)
        {
            var documents = await _collection.Find(filter).FirstOrDefaultAsync();
            return documents;
        }

        public async Task<bool> UpdateAsync(Expression<Func<TDocument, bool>> filter, UpdateDefinition<TDocument> update)
        {
            var result = await _collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(Expression<Func<TDocument, bool>> filter)
        {
            var result = await _collection.DeleteOneAsync(filter);

            return result.DeletedCount > 0;
        }

        public async Task<bool> DeleteMultiAsync(Expression<Func<TDocument, bool>> filter)
        {
            var result = await _collection.DeleteManyAsync(filter);

            return result.DeletedCount > 0;
        }
    }
}
