using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kedust.UI.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public bool Post(IEnumerable<OrderItem> orderItems)
        {
            foreach (var orderItem in orderItems)
            {
                Console.WriteLine(orderItem.Count + "\t" + orderItem.Name);
            }

            return true;
        }

        public class OrderItem
        {
            public int Id { get; set; }
            public string Category { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int Count { get; set; }
        }
    }
}