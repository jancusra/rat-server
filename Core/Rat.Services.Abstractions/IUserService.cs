﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Rat.Domain.Entities;

namespace Rat.Services.Abstractions
{
    public partial interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IList<User>> GetAllAsync();

        Task<bool> IsUserAdminAsync(int userId);

        Task<User> LoginUserValidationAsync(string email, string password);

        Task<bool> RegisterNewUserAsync(string email, string password, string passwordVerify);
    }
}