namespace Rat.Contracts.Common
{
    /// <summary>
    /// Represents extended base DTO entry for an entity
    /// </summary>
    public partial class EntityEntryDto : BaseEntryDto
    {
        /// <summary>
        /// entity specific value
        /// </summary>
        public dynamic Value { get; set; }
    }
}
