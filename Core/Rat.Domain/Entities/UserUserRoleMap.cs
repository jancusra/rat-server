using Rat.Domain.EntityAttributes;

namespace Rat.Domain.Entities
{
    public partial class UserUserRoleMap : TableEntity
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserRole))]
        public int UserRoleId { get; set; }
    }
}
