using System;
using System.Collections.Generic;
using System.Linq;
using Rat.Contracts;
using Rat.Domain;
using Rat.Domain.EntityAttributes;
using Rat.Domain.Extensions;

namespace Rat.Services
{
    public partial class EntityValidationService : IEntityValidationService
    {
        private readonly IEntityService _entityService;

        public EntityValidationService(
            IEntityService entityService)
        {
            _entityService = entityService;
        }

        public virtual IList<ValidationEntryResult> ValidateCommonEntity(string entityName, Dictionary<string, object> data)
        {
            var validationEntries = new List<ValidationEntryResult>();
            var entityType = _entityService.GetTableEntityTypeByName(entityName);

            if (!entityType.HasSpecificAttribute<CommonAccessAttribute>())
            {
                return validationEntries;
            }

            var entityProperties = entityType.GetProperties();

            foreach (var entityEntry in data)
            {
                if (entityEntry.Key != nameof(TableEntity.Id))
                {
                    var propertyInfo = entityProperties.FirstOrDefault(x => x.Name == entityEntry.Key);

                    if (propertyInfo != null && propertyInfo.PropertyType == typeof(String)
                        && propertyInfo.HasSpecificAttribute<NotNullableStringAttribute>()
                        && string.IsNullOrEmpty((string)entityEntry.Value))
                    {
                        validationEntries.Add(new ValidationEntryResult {
                            FieldName = entityEntry.Key,
                            Message = $"Field {entityEntry.Key} is required!"
                        });
                    }
                }
            }

            return validationEntries;
        }
    }
}
