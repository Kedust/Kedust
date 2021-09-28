using System.Collections.Generic;
using System.Threading.Tasks;
using Kedust.Data.Dal;
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
        private readonly ITableRepo _tableRepo;
        private readonly ITableService _tableService;

        public TableController(ILogger<TableController> logger, ITableRepo tableRepo, ITableService tableService)
        {
            _logger = logger;
            _tableRepo = tableRepo;
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IEnumerable<Table>> GetAll() => await _tableService.GetAll();

        [HttpGet("{id:int}")]
        public Task<Table> GetById(int id) => _tableService.GetById(id);

        [HttpPut]
        public async Task<int> Put(Table request) => await _tableService.Save(request);

        [HttpDelete("{id:int}")]
        public async Task<bool> Delete(int id) => await _tableService.Delete(id);

        [HttpGet("Generate")]
        public async Task<string> GenerateCode() => await _tableService.GenerateCode();

        [HttpGet("Check/{tableCode}")]
        public async Task<bool> CheckCode(string tableCode)
        {
            return await _tableRepo.CodeExists(tableCode);
        }
    }
}