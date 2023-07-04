using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Rat.Domain;
using Rat.Domain.Entities;

namespace Rat.Services
{
    public partial class LocalizationService : ILocalizationService
    {
        private readonly IRepository _repository;

        private readonly ILanguageService _languageService;

        public LocalizationService(
            IRepository repository,
            ILanguageService languageService)
        {
            _repository = repository;
            _languageService = languageService;
        }

        public virtual async Task<IList<Localization>> GetByLanguageIdAsync(int languageId)
        {
            if (languageId > default(int))
            {
                return await _repository.Table<Localization>().Where(x => x.LanguageId == languageId).ToListAsync();
            }
            else
            {
                var language = _languageService.GetDefaultLanguageAsync();
                return await _repository.Table<Localization>().Where(x => x.LanguageId == language.Id).ToListAsync();
            }
        }
    }
}
