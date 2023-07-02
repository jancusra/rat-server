using System.Collections.Generic;
using System.Threading.Tasks;
using Rat.Contracts;

namespace Rat.Services.Abstractions
{
    public partial interface IMenuService
    {
        Task<IList<MenuItemDto>> GetAdminMenuItemsAsync();
    }
}
