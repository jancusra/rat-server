using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rat.Domain
{
    public partial interface IRepository
    {
        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : TableEntity;

        Task InsertAsync<TEntity>(TEntity entity) where TEntity : TableEntity;

        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : TableEntity;

        Task DeleteAsync<TEntity>(int id) where TEntity : TableEntity;

        Task<IList<TEntity>> GetAllAsync<TEntity>() where TEntity : TableEntity;

        IQueryable<TEntity> Table<TEntity>() where TEntity : TableEntity;
    }
}
