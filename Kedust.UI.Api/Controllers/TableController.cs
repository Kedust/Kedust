using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Dal;
using Kedust.Services;
using Kedust.Services.Menu;
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
        public async Task<IEnumerable<Table>> GetAll()
        {
            var data = await _tableService.GetAll();
            return data;
        }
        
        [HttpGet("{id:int}")]
        public Task<Table> GetById(int id) => _tableService.GetById(id);

        [HttpGet("CheckCode/{tableCode}")]
        public async Task<bool> CheckCode(string tableCode)
        {
            return await _tableRepo.CodeExists(tableCode);
        }
    }
}