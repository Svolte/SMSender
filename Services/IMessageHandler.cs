using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMSender.Services
{
    public interface IMessageHandler
    {
        Task<string> SendMessage(string template, Dictionary<string, object> values);
    }
}