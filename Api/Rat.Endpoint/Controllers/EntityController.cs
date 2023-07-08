using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rat.Contracts.Models.Entity;
using Rat.Services;

namespace Rat.Endpoint.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public partial class EntityController : ControllerBase
    {
        private readonly IEntityService _entityService;

        private readonly IEntityValidationService _entityValidationService;

        public EntityController(
            IEntityService entityService,
            IEntityValidationService entityValidationService)
        {
            _entityService = entityService;
            _entityValidationService = entityValidationService;
        }

        [HttpPost]
        public virtual async Task<IActionResult> GetEntity([FromBody]GetEntityDto model)
        {
            var data = await _entityService.GetEntityAsync(model.EntityName, model.Id);
            return Ok(data);
        }

        [HttpPost]
        public virtual async Task<IActionResult> SaveEntity([FromBody]SaveEntityDto model)
        {
            var validationResult = await _entityValidationService.ValidateCommonEntityAsync(
                model.EntityName, model.Data, model.LanguageId);

            if (validationResult.Count > default(int))
            {
                return Ok(new { errors = validationResult });
            }
            else
            {
                await _entityService.SaveEntityAsync(model.EntityName, model.Data);
                return Ok(true);
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> DeleteEntity([FromBody]DeleteEntityDto model)
        {
            await _entityService.DeleteEntityAsync(model.EntityName, model.Id);
            return Ok(true);
        }

        [HttpPost]
        public virtual async Task<IActionResult> GetAllToTable([FromBody]GetAllDto model)
        {
            var data = await _entityService.GetAllToTableAsync(model.EntityName);
            return Ok(data);
        }
    }
}
