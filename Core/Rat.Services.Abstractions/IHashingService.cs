using Rat.Domain.Types;

namespace Rat.Services.Abstractions
{
    public partial interface IHashingService
    {
        string GenerateSalt(int size = 128);

        string GetHashByType(HashType hashType, string inputString, bool withSalt = false, string salt = null);
    }
}
