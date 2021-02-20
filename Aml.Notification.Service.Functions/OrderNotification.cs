using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Aml.Notification.Service.Functions
{
    public static class OrderNotification
    {
        [FunctionName(nameof(OrderNotification))]
        public static void Run([QueueTrigger("queuemessage")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
