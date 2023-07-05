using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rat.Services;
using Rat.Endpoint.Converters;

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
        public virtual async Task<IActionResult> GetEntity([FromBody]GetEntityModel model)
        {
            var data = await _entityService.GetEntityAsync(model.EntityName, model.Id);
            return Ok(data);
        }

        [HttpPost]
        public virtual async Task<IActionResult> SaveEntity([FromBody]SaveEntityModel model)
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
        public virtual async Task<IActionResult> DeleteEntity([FromBody]DeleteEntityModel model)
        {
            await _entityService.DeleteEntityAsync(model.EntityName, model.Id);
            return Ok(true);
        }

        [HttpPost]
        public virtual async Task<IActionResult> GetAllToTable([FromBody]GetAllModel model)
        {
            var data = await _entityService.GetAllToTableAsync(model.EntityName);
            return Ok(data);
        }

        public class GetEntityModel
        {
            public int? Id { get; set; }
            public string EntityName { get; set; }
        }

        public class SaveEntityModel
        {
            public SaveEntityModel()
            {
                Data = new Dictionary<string, object>();
            }

            public string EntityName { get; set; }
            public int LanguageId { get; set; }

            [JsonConverter(typeof(DictionaryStringObjectJsonConverter))]
            public Dictionary<string, object> Data { get; set; }
        }

        public class DeleteEntityModel
        {
            public int Id { get; set; }
            public string EntityName { get; set; }
        }

        public class GetAllModel
        {
            public string EntityName { get; set; }
        }
    }
}
