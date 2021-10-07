using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kedust.Data.Domain
{
    public class Order: BaseEntity<int>
    {
        public DateTime TimeOrderPlaced { get; set; }
        
        public Table Table { get; set; }
        [ForeignKey("Table")] public int TableId { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; }
        
        public DateTime? PrintedAt { get; set; }
    }
}