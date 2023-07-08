using Rat.Contracts.Models;
using Rat.Domain.Entities;

namespace Rat.Mappings
{
    public static class MenuItemMap
    {
        public static MenuItemDto ToDtoModel(this MenuItem menuItem, string translatedTitle = "")
        {
            return new MenuItemDto
            {
                Id = menuItem.Id,
                Title = translatedTitle,
                Url = menuItem.Url,
                Icon = menuItem.Icon
            };
        }
    }
}
