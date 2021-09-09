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
        private readonly IPrintService _printService;

        public OrderController(ILogger<OrderController> logger, IPrintService printService)
        {
            _logger = logger;
            _printService = printService;
        }


        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] IEnumerable<OrderItem> orderItems)
        {
            var orders = orderItems.Select(x => new Kedust.Data.Domain.OrderItem()
            {
                Amount = x.Count,
                MenuItem = new MenuItem
                {
                    Description = x.Description,
                    Name = x.Name,
                    Price = x.Price,
                    Category = x.Category
                }
            }).ToList();
            
            Order order = new Order()
            {
                OrderItems = orders,
                Table = new Table
                {
                    Description = "21"
                },
                TimeOrderPlaced = DateTime.Now
            };
            
            _printService.PrintOrderTicket(order);
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