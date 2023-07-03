using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Rat.Contracts;
using Rat.Domain;
using Rat.Domain.Entities;
using Rat.Domain.Types;
using Rat.Mappings;

namespace Rat.Services
{
    public partial class MenuService : IMenuService
    {
        private readonly IRepository _repository;

        public MenuService(
            IRepository repository)
        {
            _repository = repository;
        }

        private async Task<IList<MenuItem>> GetAllMenuItemsByTypeAsync(MenuType menuType)
            => await _repository.Table<MenuItem>().Where(x => x.MenuTypeId == (int)menuType).ToListAsync();

        public virtual async Task<IList<MenuItemDto>> GetAdminMenuItemsAsync()
        {
            var allAdminMenuItems = await GetAllMenuItemsByTypeAsync(MenuType.Admin);
            var result = new List<MenuItemDto>();

            result.AddRange(allAdminMenuItems.Where(x => x.ParentMenuItemId == default(int))
                .OrderBy(x => x.ItemOrder)
                .Select(x => x.ToDtoModel(x.SystemName))
            );

            foreach (var menuItem in result)
            {
                menuItem.ChildMenuItems.AddRange(GetChildMenuItemsByParentId(allAdminMenuItems, menuItem.Id));
            }

            return result;
        }

        private IList<MenuItemDto> GetChildMenuItemsByParentId(
            IList<MenuItem> allMenuItems,
            int parentMenuItemId)
        {
            return allMenuItems.Where(x => x.ParentMenuItemId == parentMenuItemId)
                .OrderBy(x => x.ItemOrder)
                .Select(x => x.ToDtoModel(x.SystemName)).ToList();
        }
    }
}
