using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kedust.Data.Domain
{
    public class Menu:BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Choice> MenuItems { get; set; }
    }
}