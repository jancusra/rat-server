using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Rat.Domain.Types;

namespace Rat.Services
{
    public partial class HashingService : IHashingService
    {
        public virtual string GenerateSalt(int size = 128)
        {
            byte[] salt = new byte[size / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetNonZeroBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public virtual string GetHashByType(HashType hashType, string inputString, bool withSalt = false, string salt = null)
        {
            switch (hashType)
            {
                case HashType.Pbkdf2SHA512:
                    return GetPbkdf2Hash(inputString, salt);
                default:
                    return GetHashByAlgorithm(hashType, inputString, withSalt, salt);
            }
        }

        private string GetHashByAlgorithm(HashType hashType, string inputString, bool withSalt = false, string salt = null)
        {
            if (withSalt)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = GenerateSalt();
                }

                inputString = $"{inputString}-{salt}";
            }

            var hashAlgorithm = (HashAlgorithm)CryptoConfig.CreateFromName(hashType.ToString());
            var hashBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            
            return Convert.ToBase64String(hashBytes);
        }

        private string GetPbkdf2Hash(string inputString, string salt = null)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: inputString,
                salt: string.IsNullOrEmpty(salt) ? Encoding.UTF8.GetBytes(GenerateSalt()) : Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));
        }
    }
}
