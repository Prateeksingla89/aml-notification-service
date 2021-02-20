using Aml.Notification.Service.Model.TableStorageEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aml.Notification.Service.Model
{
    public class OrderInformationEntity : TableStorageEntity
    {
        public Guid MessageId { get; set; }
        public string Message { get; set; }

        public OrderInformationEntity()
        {
        }

        public OrderInformationEntity(Guid MessageId, string Message)
        {
            PartitionKey = MessageId.ToString();
            RowKey = MessageId.ToString();
            this.MessageId = MessageId;
            this.Message = Message;
        }
    }
}
