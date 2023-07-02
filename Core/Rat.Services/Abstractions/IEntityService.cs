using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rat.Contracts.Common;

namespace Rat.Services
{
    public partial interface IEntityService
    {
        Task<IList<EntityEntryDto>> GetEntityAsync(string entityName, int? entityId);

        Task SaveEntityAsync(string entityName, Dictionary<string, object> data);

        Task DeleteEntityAsync(string entityName, int entityId, bool skipCommonAccessAttribute = false);

        Task<dynamic> GetAllToTableAsync(string entityName);

        Type GetTableEntityTypeByName(string entityName);
    }
}
