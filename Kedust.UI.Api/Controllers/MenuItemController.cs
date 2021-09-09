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
    public class MenuItemController : ControllerBase
    {
        private readonly ILogger<MenuItemController> _logger;
        private readonly IMenuItemRepo _menuItem;

        public MenuItemController(ILogger<MenuItemController> logger, IMenuItemRepo menuItem)
        {
            _logger = logger;
            _menuItem = menuItem;
        }

        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            return _menuItem.GetAll();
        }
        

    }
}