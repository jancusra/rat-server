using System.Collections.Generic;
using System.Threading.Tasks;
using Rat.Domain.Entities;

namespace Rat.Services
{
    public partial interface ILocalizationService
    {
        Task<IList<Localization>> GetByLanguageIdAsync(int languageId);
    }
}
