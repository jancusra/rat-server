namespace Rat.Domain.Types
{
    /// <summary>
    /// Define hash algorithm types
    /// </summary>
    public enum HashType
    {
        /// <summary>
        /// SHA256
        /// </summary>
        SHA256 = 10,

        /// <summary>
        /// SHA512
        /// </summary>
        SHA512 = 20,

        /// <summary>
        /// Pbkdf2SHA512
        /// </summary>
        Pbkdf2SHA512 = 50
    }
}
