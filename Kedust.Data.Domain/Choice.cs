using System.ComponentModel.DataAnnotations.Schema;

namespace Kedust.Data.Domain
{
    public class Choice : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Image { get; set; }

        public int Sorting { get; set; }

        public Menu Menu { get; set; }
        [ForeignKey("Menu")] public int MenuId { get; set; }
    }
}