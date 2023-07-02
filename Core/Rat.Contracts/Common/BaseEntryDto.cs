using System.Collections.Generic;

namespace Rat.Contracts.Common
{
    public partial class BaseEntryDto
    {
        public BaseEntryDto()
        {
            SelectOptions = new Dictionary<int, string>();
        }

        public string Name { get; set; }

        public string EntryType { get; set; }

        public int Order { get; set; }

        public bool Hidden { get; set; }

        public bool Excluded { get; set; }

        public Dictionary<int, string> SelectOptions { get; set; }
    }
}
