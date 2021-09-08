using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
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
        [Consumes("application/json")]
        public IActionResult Post([FromBody] IEnumerable<OrderItem> orderItems)
        {
            var orders = orderItems.ToList();
            
            foreach (var orderItem in orders)
            {
                Console.WriteLine(orderItem.Count + "\t" + orderItem.Name);
            }

            if (orders.Any(oi => oi.Id == 1)) return Ok(true);
            return Problem();
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