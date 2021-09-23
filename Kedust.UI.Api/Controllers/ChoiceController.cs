using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Dal;
using Kedust.Data.Domain;
using Kedust.Services;
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
        private readonly IMenuService _menuService;

        public ChoiceController(ILogger<ChoiceController> logger, IChoiceRepo choice, IMenuService menuService)
        {
            _logger = logger;
            _choice = choice;
            _menuService = menuService;
        }

        [HttpGet("GetByTableCode")]
        public async Task<IEnumerable<Choice>> GetByTableCode(string code)
        {
            _logger.LogInformation($"GET /Choice?code={code}");
            return await _choice.GetByTableCode(code);
        }
        
        [HttpGet("GetByMenu")]
        public async Task<IEnumerable<Choice>> GetByMenu(int id)
        {
            var data = await _choice.GetByMenuId(id);


            return await _choice.GetByMenuId(id);
        }

        [HttpPost("SaveByMenu")]
        public async Task<int> SaveByMenu(SaveByMenuRequest request)
        {
            return await _menuService.Save(request.Menu, request.Choices);
        }

        public class SaveByMenuRequest
        {
            public Menu Menu { get; set; }
            public IEnumerable<Choice> Choices { get; set; }
        }
    }
}