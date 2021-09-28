using System.Collections.Generic;

namespace Kedust.Data.Domain
{
    public class Menu : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Choice> Choices { get; set; }
        
        public ICollection<Table> Tables { get; set; }
    }
}