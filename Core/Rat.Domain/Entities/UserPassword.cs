using System;
using Rat.Domain.EntityAttributes;

namespace Rat.Domain.Entities
{
    public partial class UserPassword : TableEntity
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [NotNullableString]
        public string PasswordHash { get; set; }

        [NotNullableString]
        public string PasswordSalt { get; set; }

        public int HashTypeId { get; set; }

        public DateTime CreatedUTC { get; set; }
    }
}
