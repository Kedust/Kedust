using System.Collections.Generic;
using System.Threading.Tasks;
using Kedust.Services;
using Kedust.Services.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kedust.UI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ILogger<TableController> _logger;
        private readonly ITableService _tableService;

        public TableController(ILogger<TableController> logger, ITableService tableService)
        {
            _logger = logger;
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IEnumerable<Table>> GetAll() => await _tableService.GetAll();

        [HttpGet("{id:int}")]
        public Task<Table> GetById(int id) => _tableService.GetById(id);

        [HttpGet("Code/{tableCode}")]
        public Task<Table> GetByCode(string tableCode) => _tableService.GetByCode(tableCode);
        
        [HttpPut]
        public async Task<int> Put(Table request) => await _tableService.Save(request);

        [HttpDelete("{id:int}")]
        public async Task<bool> Delete(int id) => await _tableService.Delete(id);
    }
}