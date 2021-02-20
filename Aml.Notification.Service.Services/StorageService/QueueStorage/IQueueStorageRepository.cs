using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aml.Notification.Service.Services.StorageService.QueueStorage
{
   public interface IQueueStorageRepository
    {
        Task<object> AddAsync(string tableName, CloudQueueMessage entity);
    }
}
