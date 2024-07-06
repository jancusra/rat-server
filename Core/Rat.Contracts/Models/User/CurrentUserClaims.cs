namespace Rat.Contracts.Models.User
{
    /// <summary>
    /// Represents data about currently logged user
    /// </summary>
    public partial class CurrentUserClaims
    {
        /// <summary>
        /// User DB ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Has current user admin rights
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
