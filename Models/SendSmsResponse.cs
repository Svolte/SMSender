using System;
using Newtonsoft.Json;

namespace SMSender.Models
{
    public class SendSmsResponse
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("from")] public string From { get; set; }

        [JsonProperty("to")] public string To { get; set; }

        [JsonProperty("parts")] public int Parts { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("created")] public DateTime CreatedAt { get; set; }

        [JsonProperty("cost")] public int Cost { get; set; }

        [JsonProperty("direction")] public string Direction { get; set; }
    }
}