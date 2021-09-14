using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kedust.Data.Domain
{
    public class Order: BaseEntity<int>
    {
        public DateTime TimeOrderPlaced { get; set; }
        public Table Table { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}