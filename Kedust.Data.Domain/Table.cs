using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kedust.Data.Domain
{
    public class Table : BaseEntity<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        
        public ICollection<Order> Orders { get; set; }
        public Menu Menu { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} Code:{Code} Description:{Description} Menu:{Menu?.Id??'/'} Count:{Orders?.Count??'/'}";
        }
    }
}