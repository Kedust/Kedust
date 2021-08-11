using System.Collections.Generic;

namespace Kedust.Data.Domain
{
    public class Table
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}