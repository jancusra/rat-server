using System;

namespace Rat.Domain.EntityTypes
{
    public partial interface IAuditable
    {
        DateTime CreatedUTC { get; set; }

        DateTime? ModifiedUTC { get; set; }
    }
}
