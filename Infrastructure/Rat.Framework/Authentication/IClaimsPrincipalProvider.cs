using System.Security.Claims;

namespace Rat.Framework.Authentication
{
    public partial interface IClaimsPrincipalProvider
    {
        ClaimsPrincipal GetClaimsPrincipal();
    }
}
