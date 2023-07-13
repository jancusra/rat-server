using System;
using Rat.Domain.EntityAttributes;

namespace Rat.Domain.Entities
{
    [CommonAccess]
    public partial class Log : TableEntity
    {
        public int LogLevelTypeId { get; set; }

        public string ShortMessage { get; set; }

        public string FullMessage { get; set; }

        public int? UserId { get; set; }

        [MaxStringLength(EntityDefaults.MaxUrlLength)]
        public string PathUrl { get; set; }

        [MaxStringLength(EntityDefaults.MaxUrlLength)]
        public string ReferrerUrl { get; set; }

        public DateTime CreatedUTC { get; set; }
    }
}
