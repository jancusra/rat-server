using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Rat.Domain;
using Rat.Domain.Entities;
using Rat.Domain.Options;
using Rat.Domain.Types;

namespace Rat.Services
{
    public partial class UserService : IUserService
    {
        private readonly IHashingService _hashingService;
        private readonly IRepository _repository;
        private readonly IOptions<UserOptions> _userOptions;

        public UserService(
            IHashingService hashingService,
            IRepository repository,
            IOptions<UserOptions> userOptions)
        {
            _hashingService = hashingService;
            _repository = repository;
            _userOptions = userOptions;
        }

        private async Task<UserPassword> GetUserPasswordByUserIdAsync(int userId)
            => await _repository.Table<UserPassword>().FirstOrDefaultAsync(x => x.UserId == userId);

        public virtual async Task<User> GetUserByEmailAsync(string email)
            => await _repository.Table<User>().FirstOrDefaultAsync(x => x.Email == email);

        public virtual async Task<IList<User>> GetAllAsync()
            => await _repository.GetAllAsync<User>();

        public virtual async Task<bool> IsUserAdminAsync(int userId)
            => await _repository.Table<UserUserRoleMap>().FirstOrDefaultAsync(x => x.UserId == userId && x.UserRoleId == (int)RoleType.Administrators) != null;

        public virtual async Task<User> LoginUserValidationAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);

            if (user != null)
            {
                var userPassword = await GetUserPasswordByUserIdAsync(user.Id);

                if (userPassword != null)
                {
                    var hashToValidate = _hashingService.GetHashByType((HashType)userPassword.HashTypeId, 
                        password, true, userPassword.PasswordSalt);

                    if (hashToValidate == userPassword.PasswordHash)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        public virtual async Task<bool> RegisterNewUserAsync(string email, string password, string passwordVerify)
        {
            if (password != passwordVerify)
                return false;

            var newUser = new User 
            {
                UserGuid = Guid.NewGuid(),
                Email = email,
                IsActive = true,
                CreatedUTC = DateTime.UtcNow
            };

            await _repository.InsertAsync(newUser);

            var passwordSalt = _hashingService.GenerateSalt();
            var passwordHash = _hashingService.GetHashByType(_userOptions.Value.PasswordHashing, password, true, passwordSalt);

            await _repository.InsertAsync(new UserPassword 
            {
                UserId = newUser.Id,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                HashTypeId = (int)_userOptions.Value.PasswordHashing,
                CreatedUTC = DateTime.UtcNow
            });

            return true;
        }
    }
}
