using System;
using System.Collections.Generic;
using Kedust.Data.Domain;

namespace Kedust.Services.DTO
{
    public class OrderForPrinting
    {
        public int Id { get; set; }
        public DateTime TimeOrderPlaced { get; set; }
        public OrderStatus Status { get; set; }
        public Table Table { get; set; }
        public List<OrderItemForPrinting> OrderItems { get; set; }
    }
}