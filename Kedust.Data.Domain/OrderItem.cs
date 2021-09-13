using System.ComponentModel.DataAnnotations;

namespace Kedust.Data.Domain
{
    public class OrderItem: BaseEntity<int>
    {
        public Choice Choice { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{Amount} x {Choice.Name}";
        }
    }
}