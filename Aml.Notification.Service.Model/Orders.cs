using Newtonsoft.Json;
using System;

namespace Aml.Notification.Service.Model
{
    public class Orders
    {
        [JsonProperty(PropertyName = "messageId")]
        public Guid MessageId { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
