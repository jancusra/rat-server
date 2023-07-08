using System.Collections.Generic;
using System.Text.Json.Serialization;
using Rat.Contracts.Converters;

namespace Rat.Contracts.Models.Entity
{
    public partial class SaveEntityDto
    {
        public SaveEntityDto()
        {
            Data = new Dictionary<string, object>();
        }

        public string EntityName { get; set; }

        public int LanguageId { get; set; }

        [JsonConverter(typeof(DictionaryStringObjectJsonConverter))]
        public Dictionary<string, object> Data { get; set; }
    }
}
