using System.Collections.Generic;

namespace Kedust.Data.Domain
{
    public class Menu
    {
        public ICollection<MenuItemGroup> MenuItemGroups { get; set; }
        public string Valuta { get; set; }
    }
}