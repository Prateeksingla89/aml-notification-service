using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aml.Notification.Service.Services.StorageService.QueueStorage
{
    public interface IQueueStorageService
    {
        public Task<object> AddAsync(string tableName, CloudQueueMessage entity);

    }
    public class QueueStorageService : IQueueStorageService
    {
        private readonly IQueueStorageRepository queueStorageRepository;
        public QueueStorageService(IQueueStorageRepository queueStorageRepository)
        {
            this.queueStorageRepository = queueStorageRepository;
        }
        public async Task<object> AddAsync(string tableName, CloudQueueMessage entity)
        {
            return await queueStorageRepository.AddAsync(tableName.ToLower(), entity);
        }
    }
}
