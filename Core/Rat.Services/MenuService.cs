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
            var childMenuItems = allAdminMenuItems.Where(x => x.ParentMenuItemId > default(int))
                .OrderByDescending(x => x.ItemOrder).ToList();
            var result = new List<MenuItemDto>();

            result.AddRange(allAdminMenuItems.Where(x => x.ParentMenuItemId == default(int))
                .OrderBy(x => x.ItemOrder)
                .Select(x => x.ToDtoModel(x.SystemName))
            );

            foreach (var menuItem in result)
            {
                for (int i = childMenuItems.Count - 1; i >= 0; i--)
                {
                    if (childMenuItems[i].ParentMenuItemId == menuItem.Id)
                    {
                        menuItem.ChildMenuItems.Add(childMenuItems[i].ToDtoModel(childMenuItems[i].SystemName));

                        childMenuItems.RemoveAt(i);
                    }
                }
            }

            return result;
        }
    }
}
