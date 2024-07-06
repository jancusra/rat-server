using System.Collections.Generic;

namespace Rat.Contracts.Common
{
    /// <summary>
    /// Represents base DTO entry for a table column
    /// </summary>
    public partial class BaseEntryDto
    {
        public BaseEntryDto()
        {
            SelectOptions = new Dictionary<int, string>();
        }

        /// <summary>
        /// Column name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Column entry type
        /// </summary>
        public string EntryType { get; set; }

        /// <summary>
        /// Column view order
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Should be column hidden in a table
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Should be column excluded from a table
        /// </summary>
        public bool Excluded { get; set; }

        /// <summary>
        /// Select options for a columns with possible options (like enums)
        /// </summary>
        public Dictionary<int, string> SelectOptions { get; set; }
    }
}
