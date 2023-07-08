namespace Rat.Contracts.Models.User
{
    public partial class RegisterDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordVerify { get; set; }
    }
}
