using System.Threading;
using System.Threading.Tasks;
using Kedust.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kedust.UI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingController : ControllerBase
    {
        private readonly ILogger<SettingController> _logger;
        private readonly ISettingService _settingService;
        private readonly IPrintSignal _printSignal;

        public SettingController(ILogger<SettingController> logger, ISettingService settingService, IPrintSignal printSignal)
        {
            _logger = logger;
            _settingService = settingService;
            _printSignal = printSignal;
        }

        [HttpGet("Key/{key}")]
        public async Task<ActionResult<string>> GetByKey(string key)
        {
            (bool succes, string value) setting = await _settingService.TryGetByKey(key);
            if (setting.succes) return setting.value;
            return NoContent();
        }

        [HttpPost("Key/{key}")]
        public async Task SetByKey(string key, string value, CancellationToken token)
        {
            await _settingService.SetByKey(key, value);
            await _printSignal.UpdatedCanOrder(token);
        }
    }
}