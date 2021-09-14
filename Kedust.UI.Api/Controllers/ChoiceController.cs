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
    public class ChoiceController : ControllerBase
    {
        private readonly ILogger<ChoiceController> _logger;
        private readonly IChoiceRepo _choice;

        public ChoiceController(ILogger<ChoiceController> logger, IChoiceRepo choice)
        {
            _logger = logger;
            _choice = choice;
        }

        [HttpGet]
        public async Task<IEnumerable<Choice>> Get(string code)
        {
            _logger.LogInformation($"GET /Choice?code={code}");
            return await _choice.GetByTableCode(code);
        }

        public class GetRequest
        {
            public string Code { get; set; }
        }
    }
}