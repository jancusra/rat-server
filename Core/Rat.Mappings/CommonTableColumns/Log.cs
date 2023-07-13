using System.Collections.Generic;
using Rat.Contracts.Common;
using Rat.Domain.Extensions;
using Rat.Domain.Types;

namespace Rat.Mappings.CommonTableColumns
{
    public static class Log
    {
        public static IList<ColumnMetadata> GetMetadata()
        {
            return new List<ColumnMetadata>()
            {
                new ColumnMetadata()
                {
                    Name = nameof(Domain.Entities.Log.LogLevelTypeId),
                    EntryType = CustomColumnType.EnumIcon.ToString(),
                    SelectOptions = EnumExtensions.GetEnumDictionary<LogLevelType>()
                },
                new ColumnMetadata()
                {
                    Name = nameof(Domain.Entities.Log.FullMessage),
                    Hidden = true
                },
                new ColumnMetadata()
                {
                    Name = nameof(Domain.Entities.Log.UserId),
                    Hidden = true
                },
                new ColumnMetadata()
                {
                    Name = nameof(Domain.Entities.Log.ReferrerUrl),
                    Hidden = true
                },
                new ColumnMetadata()
                {
                    Name = CustomColumnType.ShowDetail.ToString(),
                    EntryType = CustomColumnType.ShowDetail.ToString()
                }
            };
        }
    }
}
