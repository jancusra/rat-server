using Rat.Domain.EntityAttributes;

namespace Rat.Domain.Entities
{
    public partial class MenuItem : TableEntity
    {
        public int MenuTypeId { get; set; }

        [NotNullableString]
        [MaxStringLength(EntityDefaults.MaxTypicalStringLength)]
        public string SystemName { get; set; }

        [MaxStringLength(EntityDefaults.MaxTypicalStringLength)]
        public string Url { get; set; }

        [MaxStringLength(EntityDefaults.MaxTypicalStringLength)]
        public string Icon { get; set; }

        public int ItemOrder { get; set; }

        public int ParentMenuItemId { get; set; }
    }
}
