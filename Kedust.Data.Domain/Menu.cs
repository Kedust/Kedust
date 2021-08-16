using System.Collections.Generic;

namespace Kedust.Data.Domain
{
    public class Menu
    {
        public int Id { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}