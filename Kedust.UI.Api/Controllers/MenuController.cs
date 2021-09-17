﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        
        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
        }

        public struct GetAllResponse
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
    }
}