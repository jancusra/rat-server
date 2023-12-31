﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Rat.Contracts.Models;

namespace Rat.Services
{
    public partial interface IMenuService
    {
        Task<IList<MenuItemDto>> GetAdminMenuItemsAsync();
    }
}
