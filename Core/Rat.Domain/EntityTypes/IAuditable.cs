using System;

namespace Rat.Domain.EntityTypes
{
    /// <summary>
    /// Auditable entity has created and modified date
    /// </summary>
    public partial interface IAuditable
    {
        DateTime CreatedUTC { get; set; }

        DateTime? ModifiedUTC { get; set; }
    }
}
