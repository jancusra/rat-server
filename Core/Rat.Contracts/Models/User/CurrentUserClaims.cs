namespace Rat.Contracts.Models.User
{
    public partial class CurrentUserClaims
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}
