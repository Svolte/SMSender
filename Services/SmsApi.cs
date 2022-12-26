using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Util;
using Microsoft.Extensions.Configuration;
using SMSender.Models;

namespace SMSender.Services
{
    public class SmsApi : ISmsApi
    {
        private readonly IConfiguration _config;

        public SmsApi(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendMessageAsync(string receiver, string message, string dryrun = "yes")
            => await "https://api.46elks.com/a1/SMS"
                .WithBasicAuth(_config["SmsUsername"], _config["SmsSecret"]).PostUrlEncodedAsync(
                    new
                    {
                        from = "SMSender",
                        to = receiver,
                        message,
                        dryrun
                    }.ToKeyValuePairs()).ReceiveJson<SendSmsResponse>();
    }
}