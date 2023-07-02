using System;
using Rat.Domain.EntityAttributes;
using Rat.Domain.EntityTypes;

namespace Rat.Domain.Entities
{
    [CommonAccess]
    public partial class User : TableEntity, IAuditable//, ISoftDelete
    {
        public User()
        {
            UserGuid = Guid.NewGuid();
        }

        public Guid UserGuid { get; set; }

        [NotNullableString]
        [MaxStringLength(EntityDefaults.MaxEmailLength)]
        public string Email { get; set; }

        [MaxStringLength(EntityDefaults.MaxTypicalStringLength)]
        public string SystemName { get; set; }

        public bool IsVatPayer { get; set; }

        public bool IsActive { get; set; }

        public string AdminNote { get; set; }

        public int InvalidLoginAttempts { get; set; }

        [MaxStringLength(EntityDefaults.MaxIpAddressLength)]
        public string LastIpAddress { get; set; }

        public DateTime? LastLoginUTC { get; set; }

        public DateTime CreatedUTC { get; set; }

        public DateTime? ModifiedUTC { get; set; }

        public bool Deleted { get; set; }
    }
}
