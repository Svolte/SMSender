using System.Collections.Generic;
using System.Threading.Tasks;
using HandlebarsDotNet;

namespace SMSender
{
    public class MessageHandler : IMessageHandler
    {
        public async Task<string> SendMessage(string text, Dictionary<string, object> values)
        {
            var template = Handlebars.Compile(text);
            var result = template(values);
            return result;
        }
    }
}