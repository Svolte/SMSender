using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SMSender
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly IMessageHandler _message;

        public HomeController(IMessageHandler message)
        {
            _message = message;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var text = @"Hello {{name}}! You have just won {{value}} dollars!";
            var result = await _message.SendMessage(text,
                new Dictionary<string, object> { { "name", "Anton" }, { "value", "5000" } });
            return Json(result);
        }
    }
}