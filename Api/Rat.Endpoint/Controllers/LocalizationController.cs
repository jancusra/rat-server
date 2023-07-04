using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rat.Services;

namespace Rat.Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public partial class LocalizationController : ControllerBase
    {
        private readonly ILocalizationService _localizationService;

        public LocalizationController(
            ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Get()
        {
            var locales = (await _localizationService.GetByLanguageIdAsync(1))
                .ToDictionary(k => k.Name, v => v.Value);

            return Ok(locales);
        }
    }
}
