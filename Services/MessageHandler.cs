using System.Collections.Generic;
using System.Threading.Tasks;
using HandlebarsDotNet;

namespace SMSender.Services
{
    public class MessageHandler : IMessageHandler
    {
        private readonly ISmsApi _api;

        public MessageHandler(ISmsApi api)
        {
            _api = api;
        }

        public async Task<string> SendMessage(string receiver, string text, Dictionary<string, object> values)
        {
            var template = Handlebars.Compile(text);
            var result = template(values);
            await _api.SendMessageAsync(receiver, text);
            return result;
        }
    }
}