using System;

namespace Rat.DataStorage.DataProviders
{
    public partial class DataProviderManager : IDataProviderManager
    {
        public static IDbDataProvider GetDataProvider()
        {
            var databaseType = DatabaseSettingsManager.GetSettings().DataProvider;

            return databaseType switch
            {
                DatabaseType.SqlServer => new MsSqlDataProvider(),
                DatabaseType.MySql => new MySqlDataProvider(),
                //DataProviderType.PostgreSQL => new PostgreSqlDataProvider(),
                _ => throw new Exception($"Not supported data provider name: '{databaseType}'")
            };
        }

        public IDbDataProvider DataProvider
        {
            get
            {
                return GetDataProvider();
            }
        }
    }
}
