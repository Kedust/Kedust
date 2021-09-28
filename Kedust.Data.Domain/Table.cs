using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kedust.Data.Domain
{
    public class Table : BaseEntity<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<Order> Orders { get; set; }
        public Menu Menu { get; set; }
        [ForeignKey("Menu")] public int MenuId { get; set; }
    }
}