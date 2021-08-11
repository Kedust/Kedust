using System;
using System.Collections.Generic;

namespace Kedust.Data.Domain
{
    public class Order
    {
        public DateTime TimeOrderPlaced { get; set; }
        public Table Table { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}