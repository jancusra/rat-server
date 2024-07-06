namespace Rat.Domain.EntityTypes
{
    /// <summary>
    /// Specify entity with some name (usually required)
    /// </summary>
    public partial interface INamed
    {
        public string Name { get; set; }
    }
}
