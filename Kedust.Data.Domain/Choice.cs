using System.ComponentModel.DataAnnotations;

namespace Kedust.Data.Domain
{
    public class Choice: BaseEntity<int>
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        
        public Menu Menu { get; set; }
    }
}