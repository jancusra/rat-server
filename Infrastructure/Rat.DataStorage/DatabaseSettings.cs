using FluentMigrator.Runner.Initialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rat.DataStorage
{
    public partial class DatabaseSettings : IConnectionStringAccessor
    {
        [JsonProperty(PropertyName = "DataConnectionString")]
        public string ConnectionString { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DatabaseType DataProvider { get; set; }
    }
}
