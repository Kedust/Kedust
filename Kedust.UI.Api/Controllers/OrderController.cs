using System;
using System.Collections.Generic;
using System.Linq;
using Kedust.Data.Domain;
using Kedust.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kedust.UI.Api.Controllers
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

        public class PostRequest
        {
            public IEnumerable<OrderItem> Items { get; set; }
            public string Table { get; set; }
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] PostRequest request)
        {
            
            var orders = request.Items.Select(x => new Kedust.Data.Domain.OrderItem()
            {
                Amount = x.Count,
                Choice = new Choice
                {
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                    Category = x.Category
                }
            }).ToList();
            
            _logger.LogInformation($"POST /Order \n {string.Join('\n', orders.Select(o => o.ToString()))}");
            
            Order order = new Order()
            {
                OrderItems = orders,
                Table = new Table
                {
                    Description = request.Table
                },
                TimeOrderPlaced = DateTime.Now
            };
            
            // _printService.PrintOrderTicket(order);
            return Ok(true);
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