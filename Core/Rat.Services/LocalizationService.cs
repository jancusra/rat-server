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

        public LocalizationService(
            IRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<IList<Localization>> GetByLanguageIdAsync(int languageId)
            => await _repository.Table<Localization>().Where(x => x.LanguageId == languageId).ToListAsync();
    }
}
