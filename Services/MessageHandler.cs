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

        public string FillTemplate(string text, Dictionary<string, object> values)
        {
            var template = Handlebars.Compile(text);
            var result = template(values);
            return result;
        }

        public async Task SendMessage(string receiver, string message)
        {
        }
    }
}