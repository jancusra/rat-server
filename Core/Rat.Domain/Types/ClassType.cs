﻿namespace Rat.Domain.Types
{
    /// <summary>
    /// Define type of class for a search by reflection
    /// </summary>
    public enum ClassType
    {
        /// <summary>
        /// Standard class
        /// </summary>
        Class,

        /// <summary>
        /// Table entity class
        /// </summary>
        Entities,

        /// <summary>
        /// Common entity entries (with entity editing properties)
        /// </summary>
        CommonEntityEntries,

        /// <summary>
        /// Common table columns (with properties for displaying entities in the table)
        /// </summary>
        CommonTableColumns
    }
}
