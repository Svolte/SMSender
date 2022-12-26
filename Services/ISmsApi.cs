using System.Threading.Tasks;

namespace SMSender.Services
{
    public interface ISmsApi
    {
        Task SendMessageAsync(string receiver, string message, string dryrun = "yes");
    }
}