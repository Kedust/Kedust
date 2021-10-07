using System.Collections.Generic;

namespace Kedust.Services.DTO
{
    public class SaveOrder
    {
        public int TableId { get; set; }
        public List<SaveOrderItem> OrderItems { get; set; }
    }
}