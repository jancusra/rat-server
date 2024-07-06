namespace Rat.Contracts.Models.Entity
{
    /// <summary>
    /// Represents model to get specific common entity
    /// </summary>
    public partial class GetEntityDto
    {
        /// <summary>
        /// Not required entity ID
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Entity name
        /// </summary>
        public string EntityName { get; set; }
    }
}
