using System;
using System.Data.Common;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using LinqToDB.DataProvider;
using Rat.DataStorage.Mapping;
using Rat.Domain;
using Rat.Domain.Infrastructure;

namespace Rat.DataStorage.DataProviders
{
    public abstract class BaseDataProvider
    {
        protected abstract IDataProvider LinqToDbDataProvider { get; }

        protected abstract DbConnection GetInternalDbConnection(string connectionString);

        private MappingSchema GetMappingSchema()
        {
            if (Singleton<MappingSchema>.Instance is null)
            {
                Singleton<MappingSchema>.Instance = new MappingSchema(LinqToDbDataProvider.Name)
                {
                    MetadataReader = new FluentMigratorMetadataProvider()
                };
            }
            
            return Singleton<MappingSchema>.Instance;
        }

        protected virtual DataConnection CreateDataConnection()
        {
            return CreateDataConnection(LinqToDbDataProvider);
        }

        protected virtual DataConnection CreateDataConnection(IDataProvider dataProvider)
        {
            if (dataProvider is null)
                throw new ArgumentNullException(nameof(dataProvider));

            var dataConnection = new DataConnection(dataProvider, CreateDbConnection(), GetMappingSchema())
            {
                CommandTimeout = 60 //DataSettingsManager.GetSqlCommandTimeout()
            };

            return dataConnection;
        }

        protected virtual DbConnection CreateDbConnection(string connectionString = null)
        {
            return GetInternalDbConnection(!string.IsNullOrEmpty(connectionString) ? connectionString : GetCurrentConnectionString());
        }

        public virtual async Task<TEntity> InsertEntityAsync<TEntity>(TEntity entity) where TEntity : TableEntity
        {
            using var dataContext = CreateDataConnection();
            entity.Id = await dataContext.InsertWithInt32IdentityAsync(entity);

            return entity;
        }

        public virtual async Task UpdateEntityAsync<TEntity>(TEntity entity) where TEntity : TableEntity
        {
            using var dataContext = CreateDataConnection();
            await dataContext.UpdateAsync(entity);
        }

        public virtual async Task DeleteEntityAsync<TEntity>(TEntity entity) where TEntity : TableEntity
        {
            using var dataContext = CreateDataConnection();
            await dataContext.DeleteAsync(entity);
        }

        public virtual ITable<TEntity> GetTable<TEntity>() where TEntity : TableEntity
        {
            return new DataContext(LinqToDbDataProvider, GetCurrentConnectionString()) { MappingSchema = GetMappingSchema() }
                .GetTable<TEntity>();
        }

        protected string GetCurrentConnectionString()
        {
            return DatabaseSettingsManager.GetSettings().ConnectionString;
        }
    }
}
