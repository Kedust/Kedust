using System;
using System.Collections;
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
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IMenuRepo _menuRepo;

        public MenuController(ILogger<MenuController> logger, IMenuRepo menuRepo)
        {
            _logger = logger;
            _menuRepo = menuRepo;
        }

        [HttpGet("GetAll")]
        public Task<IEnumerable<Menu>> GetAll() => Task.FromResult(_menuRepo.GetAll());

        [HttpGet(Name = "GetById")]
        public Task<Menu> GetById(int id) => _menuRepo.GetById(id);
        
        [HttpDelete]
        public async Task Delete(int id) => await _menuRepo.Delete(await _menuRepo.GetById(id));

    }
}