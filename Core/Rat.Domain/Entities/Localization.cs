using Rat.Domain.EntityAttributes;

namespace Rat.Domain.Entities
{
    public partial class Localization : TableEntity
    {
        [ForeignKey(nameof(Language))]
        public int LanguageId { get; set; }

        [NotNullableString]
        [MaxStringLength(EntityDefaults.MaxTypicalStringLength)]
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
