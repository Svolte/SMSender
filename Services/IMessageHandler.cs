using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMSender.Services
{
    public interface IMessageHandler
    {
        string FillTemplate(string text, Dictionary<string, object> values);
    }
}