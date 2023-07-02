using Rat.Domain.EntityAttributes;

namespace Rat.Domain.Entities
{
    public partial class UserRoleException : TableEntity
    {
        [ForeignKey(nameof(UserRole))]
        public int UserRoleId { get; set; }

        [ForeignKey(nameof(MenuItem))]
        public int MenuItemId { get; set; }

        public int AccessTypeId { get; set; }
    }
}
