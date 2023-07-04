using System.Collections.Generic;
using System.Threading.Tasks;
using Rat.Domain;
using Rat.Domain.Entities;

namespace Rat.Services
{
    public partial class LanguageService : ILanguageService
    {
        private readonly IRepository _repository;

        public LanguageService(
            IRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<IList<Language>> GetAllAsync()
            => await _repository.GetAllAsync<Language>();
    }
}
