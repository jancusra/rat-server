using System;
using Rat.Domain.EntityAttributes;
using Rat.Domain.EntityTypes;

namespace Rat.Domain.Entities
{
    [CommonAccess]
    public partial class UserRole : TableEntity, IAuditable, ICanBeSystem, INamed
    {
        [NotNullableString]
        [MaxStringLength(EntityDefaults.MaxTypicalStringLength)]
        public string Name { get; set; }

        public int DefaultAccessTypeId { get; set; }

        public bool IsActive { get; set; }

        public bool IsSystemEntry { get; set; }

        public DateTime CreatedUTC { get; set; }

        public DateTime? ModifiedUTC { get; set; }
    }
}
