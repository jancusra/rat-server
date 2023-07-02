using System.Threading.Tasks;
using LinqToDB;
using Rat.Domain;

namespace Rat.DataStorage
{
    public partial interface IDbDataProvider
    {
        Task<TEntity> InsertEntityAsync<TEntity>(TEntity entity) where TEntity : TableEntity;

        Task UpdateEntityAsync<TEntity>(TEntity entity) where TEntity : TableEntity;

        Task DeleteEntityAsync<TEntity>(TEntity entity) where TEntity : TableEntity;

        ITable<TEntity> GetTable<TEntity>() where TEntity : TableEntity;
    }
}
