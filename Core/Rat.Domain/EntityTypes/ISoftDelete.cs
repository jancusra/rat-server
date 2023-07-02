namespace Rat.Domain.EntityTypes
{
    public partial interface ISoftDelete
    {
        public bool Deleted { get; set; }
    }
}
