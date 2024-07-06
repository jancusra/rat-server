namespace Rat.Contracts.Models.Entity
{
    /// <summary>
    /// Represents model to delete common entity
    /// </summary>
    public partial class DeleteEntityDto
    {
        /// <summary>
        /// Entity ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Entity name
        /// </summary>
        public string EntityName { get; set; }
    }
}
