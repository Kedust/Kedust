using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Kedust.Services;
using Kedust.Services.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kedust.UI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IPrintSignal _printSignal;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IPrintSignal printSignal, IOrderService orderService)
        {
            _logger = logger;
            _printSignal = printSignal;
            _orderService = orderService;
        }

        [HttpPut]
        [Consumes("application/json")]
        public async Task<IActionResult> Put(OrderForSaving order, CancellationToken token)
        {
            var id = await _orderService.Save(order);
            if (id > 0)
            {
                await _printSignal.NotifyNewOrder("azerty", token);
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPatch("/Status/{status}/{newStatus}")]
        public async Task<IEnumerable<OrderForPrinting>> PatchByStatus(OrderStatus status, OrderStatus newStatus)
        {
            return await _orderService.PatchByStatus(status, newStatus);
        }
    }
}