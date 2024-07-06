
namespace Rat.Contracts
{
    /// <summary>
    /// Represents model for a validation result
    /// </summary>
    public partial class ValidationEntryResult
    {
        /// <summary>
        /// Field name identifier
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Validation result message
        /// </summary>
        public string Message { get; set; }
    }
}
