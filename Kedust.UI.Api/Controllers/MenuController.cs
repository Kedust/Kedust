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
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IMenuService _menuService;

        public MenuController(ILogger<MenuController> logger, IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }

        [HttpGet]
        public Task<IEnumerable<Menu>> GetAll() => _menuService.GetAll();

        [HttpGet("{id:int}")]
        public Task<Menu> GetById(int id) => _menuService.GetById(id);

        [HttpPut]
        public async Task<int> Put(Menu request) => await _menuService.Save(request);

        [HttpDelete("{id:int}")]
        public async Task<bool> Delete(int id) => await _menuService.Delete(id);

        [HttpGet("Table/{tableCode}")]
        public async Task<IEnumerable<Choice>> GetByTableCode(string tableCode)
        {
            return await _menuService.GetByTableCode(tableCode);
        }    }
}