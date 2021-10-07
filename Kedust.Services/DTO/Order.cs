using System;
using System.Collections.Generic;

namespace Kedust.Services.DTO
{
    public class Order
    {
        public DateTime TimeOrderPlaced { get; set; }
        public Table Table { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}