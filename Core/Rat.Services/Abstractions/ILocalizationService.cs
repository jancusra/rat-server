using System.Collections.Generic;
using System.Threading.Tasks;
using Rat.Domain.Entities;

namespace Rat.Services
{
    public partial interface ILocalizationService
    {
        Task<string> GetLocaleAsync(int languageId, string localName);

        Task<IList<Localization>> GetByLanguageIdAsync(int languageId);
    }
}
