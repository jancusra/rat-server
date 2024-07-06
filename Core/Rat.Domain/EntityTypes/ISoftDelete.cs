namespace Rat.Domain.EntityTypes
{
    /// <summary>
    /// Specify if entity should be soft deleted
    /// </summary>
    public partial interface ISoftDelete
    {
        public bool Deleted { get; set; }
    }
}
