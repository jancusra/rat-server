using Rat.Domain.EntityAttributes;

namespace Rat.Domain.Entities
{
    public partial class Language : TableEntity
    {
        [NotNullableString]
        [MaxStringLength(EntityDefaults.MaxTypicalStringLength)]
        public string Name { get; set; }

        [NotNullableString]
        [MaxStringLength(EntityDefaults.MaxLanguageCultureCodeLength)]
        public string LanguageCulture { get; set; }

        [NotNullableString]
        [MaxStringLength(EntityDefaults.MaxTwoLetterLength)]
        public string TwoLetterCode { get; set; }

        public bool IsActive { get; set; }

        public int ItemOrder { get; set; }
    }
}
