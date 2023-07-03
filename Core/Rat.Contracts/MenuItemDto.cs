using System.Collections.Generic;
using Rat.Contracts.Common;

namespace Rat.Contracts
{
    public partial class MenuItemDto : BaseDto
    {
        public MenuItemDto()
        {
            ChildMenuItems = new List<MenuItemDto>();
        }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public List<MenuItemDto> ChildMenuItems { get; set; }
    }
}
