using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMSender.Services
{
    public interface IMessageHandler
    {
        Task<string> SendMessage(string receiver, string text, Dictionary<string, object> values);
    }
}