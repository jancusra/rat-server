using System.Threading.Tasks;

namespace Rat.Framework.Authentication
{
    public partial interface ITokenManager
    {
        Task CreateTokenAsync(string email, string password);

        Task<bool> IsCurrentTokenActiveAsync();

        Task<bool> IsTokenActiveAsync(string token);

        Task DeactivateCurrentTokenAsync();

        Task DeactivateTokenAsync(string token);
    }
}
