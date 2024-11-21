using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Core.Generic
{
    public interface IRepository<TDocument> where TDocument : class
    {
        Task<TDocument> InsertAsync(TDocument document);
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task<IEnumerable<TDocument>> GetAsync(Expression<Func<TDocument, bool>> filter);
        Task<TDocument> GetFirstAsync(Expression<Func<TDocument, bool>> filter);

        Task<bool> UpdateAsync(Expression<Func<TDocument, bool>> filter, UpdateDefinition<TDocument> update);
        Task<bool> DeleteAsync(Expression<Func<TDocument, bool>> filter);
        Task<bool> UpdateManyAsync(Expression<Func<TDocument, bool>> filter, UpdateDefinition<TDocument> update);
        Task<bool> DeleteMultiAsync(Expression<Func<TDocument, bool>> filter);
    }
}
