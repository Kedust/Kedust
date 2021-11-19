using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

        [HttpGet]
        public Task<List<OrderForPrinting>> GetAll(DateTime from, DateTime till, CancellationToken token) =>
            _orderService.GetAll(from, till, token);
        
        [HttpPut]
        public async Task<IActionResult> Put(OrderForSaving order, CancellationToken token)
        {
            var id = await _orderService.Save(order);
            if (id > 0)
            {
                await _printSignal.NotifyNewOrder(id, token);
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpGet("Print/{id:int}")]
        public Task<OrderForPrinting> PrintingGetById(int id, CancellationToken token) =>
            _orderService.GetByIdForPrinting(id, token);


        [HttpGet("Print")]
        public Task<List<OrderForPrinting>> PrintingGetAll(CancellationToken token) =>
            _orderService.GetAllForPrinting(token);


        [HttpPost("Printed")]
        public Task SetPrinted([FromForm] int id, CancellationToken token) =>
            _orderService.MarkPrinted(id, token);
    }
}