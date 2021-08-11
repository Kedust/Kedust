using System.Collections.Generic;

namespace Kedust.Data.Domain
{
    public class MenuItemGroup
    {
        public string Name { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}