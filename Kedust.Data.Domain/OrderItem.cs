using System.ComponentModel.DataAnnotations;

namespace Kedust.Data.Domain
{
    public class OrderItem: BaseEntity<int>
    {
        public MenuItem MenuItem { get; set; }
        public int Amount { get; set; }
    }
}