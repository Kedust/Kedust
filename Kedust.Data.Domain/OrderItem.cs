using System.ComponentModel.DataAnnotations.Schema;

namespace Kedust.Data.Domain
{
    public class OrderItem : BaseEntity<int>
    {
        public Order Order { get; set; }
        [ForeignKey("Order")] public int OrderId { get; set; }

        public Choice Choice { get; set; }
        [ForeignKey("Choice")] public int ChoiceId { get; set; }

        
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{Amount} x {Choice.Name}";
        }
    }
}