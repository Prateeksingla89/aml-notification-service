using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aml.Notification.Service.Model.Response
{
    public class OrderResponse
    {
        [JsonProperty(PropertyName = "messageId")]
        public Guid MessageId { get; set; }
    }
}
