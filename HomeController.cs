using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SMSender.Services;

namespace SMSender
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly IMessageHandler _message;
        private readonly IConfiguration _config;

        public HomeController(IMessageHandler message, IConfiguration config)
        {
            _message = message;
            _config = config;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var text = @"Hello {{name}}! You have just won {{value}} dollars!";
            var result = _message.FillTemplate(text,
                new Dictionary<string, object> { { "name", "Anton" }, { "value", "5000" } });
            return Json(result);
        }
    }
}