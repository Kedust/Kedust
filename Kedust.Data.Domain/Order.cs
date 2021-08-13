using System;
using System.Collections.Generic;

namespace Kedust.Data.Domain
{
    public class Order: IDbLiteEntity<int>
    {
        public int Id { get; set; }
        public DateTime TimeOrderPlaced { get; set; }
        public Table Table { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}