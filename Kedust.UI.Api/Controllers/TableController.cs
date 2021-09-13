using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Dal;
using Kedust.Data.Domain;
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

        public TableController(ILogger<TableController> logger, ITableRepo tableRepo)
        {
            _logger = logger;
            _tableRepo = tableRepo;
        }

        [HttpGet("CheckCode")]
        public async Task<IActionResult> CheckCode(string code)
        {
            _logger.LogInformation($"GET /Table/CheckCode?code={code}");
            bool codeExists = await _tableRepo.CodeExists(code);
            return Ok(new CheckCodeResponse
            {
                Success = codeExists
            });
        }
        
        public class CheckCodeRequest
        {
            public string Code { get; set; }
        }
        public class CheckCodeResponse
        {
            public bool Success { get; set; }
        }
    }
}