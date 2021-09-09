using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kedust.Data.Domain
{
    public class Menu:BaseEntity<int>
    {
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}