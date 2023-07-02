using System.Collections.Generic;
using Rat.Contracts.Common;
using Rat.Domain.Types;

namespace Rat.Mappings.CommonTableColumns
{
    public static class UserRole
    {
        public static IList<ColumnMetadata> GetMetadata()
        {
            return new List<ColumnMetadata>()
            {
                new ColumnMetadata()
                {
                    Name = CustomColumnType.EditInViewButton.ToString(),
                    EntryType = CustomColumnType.EditInViewButton.ToString()
                },
                new ColumnMetadata()
                {
                    Name = CustomColumnType.DeleteButton.ToString(),
                    EntryType = CustomColumnType.DeleteButton.ToString()
                }
            };
        }
    }
}
