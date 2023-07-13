using System.Collections.Generic;
using Rat.Contracts.Common;
using Rat.Domain.Extensions;
using Rat.Domain.Types;

namespace Rat.Mappings.CommonEntityEntries
{
    public static class Log
    {
        public static IList<EntityEntryDto> GetMetadata()
        {
            return new List<EntityEntryDto>()
            {
                new EntityEntryDto()
                {
                    Name = nameof(Domain.Entities.Log.LogLevelTypeId),
                    EntryType = CustomEntityEntryType.Enum.ToString(),
                    SelectOptions = EnumExtensions.GetEnumDictionary<LogLevelType>()
                }
            };
        }
    }
}
