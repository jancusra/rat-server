namespace Rat.Domain.Types
{
    /// <summary>
    /// Define type of access for a user role
    /// </summary>
    public enum AccessType
    {
        /// <summary>
        /// Full access to modify and read all settings
        /// </summary>
        FullAccess = 10,

        /// <summary>
        /// Access only to read all settings
        /// </summary>
        ReadOnly = 20,

        /// <summary>
        /// No administration access
        /// </summary>
        NoAccess = 30
    }
}
