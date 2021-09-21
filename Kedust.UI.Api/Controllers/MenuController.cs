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
    }
}