namespace Rat.Domain.EntityTypes
{
    /// <summary>
    /// Specify system entry (usually system entry can't be deleted)
    /// </summary>
    public partial interface ICanBeSystem
    {
        public bool IsSystemEntry { get; set; }
    }
}
