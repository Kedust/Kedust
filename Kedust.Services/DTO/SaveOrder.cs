using System.Collections.Generic;

namespace Kedust.Services.DTO
{
    public class OrderForSaving
    {
        public int TableId { get; set; }
        public List<OrderItemForSaving> OrderItems { get; set; }
    }
}