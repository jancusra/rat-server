using System.Collections.Generic;
using System.Threading.Tasks;
using Rat.Contracts;

namespace Rat.Services
{
    public partial interface IEntityValidationService
    {
        Task<IList<ValidationEntryResult>> ValidateCommonEntityAsync(
            string entityName, Dictionary<string, object> data, int languageId);
    }
}
