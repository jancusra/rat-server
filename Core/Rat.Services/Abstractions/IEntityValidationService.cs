using System.Collections.Generic;
using Rat.Contracts;

namespace Rat.Services
{
    public partial interface IEntityValidationService
    {
        IList<ValidationEntryResult> ValidateCommonEntity(string entityName, Dictionary<string, object> data);
    }
}
