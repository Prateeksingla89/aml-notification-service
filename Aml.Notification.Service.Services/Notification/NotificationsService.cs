using Aml.Notification.Service.Model;
using Aml.Notification.Service.Model.Response;
using Aml.Notification.Service.Services.NotificationService;
using Aml.Notification.Service.Services.StorageService.QueueStorage;
using Aml.Notification.Service.Services.StorageService.TableStorage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aml.Notification.Service.Services.Notification
{
    public class NotificationsService : INotificationService
    {
        private const string TableName = "TableMessage";
        private const string QueueName = "QueueMessage";
        private readonly ITableStorageService tableStorageService;
        private readonly IQueueStorageService queueStorageService;
        public NotificationsService(ITableStorageService tableStorageService, IQueueStorageService queueStorageService)
        {
            this.tableStorageService = tableStorageService;
            this.queueStorageService = queueStorageService;
        }
        public async Task<OrderResponse> AddOrder(Orders orderRequest)
        {

            //to insert in to table storage
           var tableResult= await tableStorageService.AddAsync(TableName, new OrderInformationEntity
            (orderRequest.MessageId,
            orderRequest.Message)
            );
            var message = JsonConvert.SerializeObject(orderRequest);
            ////to insert in to queue storage
            var queueResult = await queueStorageService.AddAsync(QueueName, new CloudQueueMessage(message));

            return new OrderResponse
            {
                MessageId = orderRequest.MessageId
            };
        }
    }
}
