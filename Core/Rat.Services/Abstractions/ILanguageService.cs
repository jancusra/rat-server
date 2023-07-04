using System.Collections.Generic;
using System.Threading.Tasks;
using Rat.Domain.Entities;

namespace Rat.Services
{
    public partial interface ILanguageService
    {
        Task<Language> GetDefaultLanguageAsync();

        Task<IList<Language>> GetAllAsync();
    }
}
