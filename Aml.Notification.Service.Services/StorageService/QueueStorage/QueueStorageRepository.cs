using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aml.Notification.Service.Services.StorageService.QueueStorage
{
    public class QueueStorageRepository:IQueueStorageRepository
    {
        private readonly CloudQueueClient client;
        public QueueStorageRepository(IQueueStorageAccountFacade accountParameter)
        {
            IQueueStorageAccountFacade account = accountParameter ?? throw new ArgumentNullException(nameof(account));
            client = account.CreateQueueClient();
        }

        private async Task<CloudQueue> GetQueue(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName));
            var queue = client.GetQueueReference(tableName);
            await queue.CreateIfNotExistsAsync().ConfigureAwait(false);
            return queue;
        }

        public async Task<object> AddAsync(string tableName, CloudQueueMessage entity)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName));
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var queue = await GetQueue(tableName).ConfigureAwait(false);
            var result =  queue.AddMessageAsync(entity).ConfigureAwait(false);//.ExecuteAsync(TableOperation.Insert(entity)).ConfigureAwait(false);
            return result;
        }

    }
}
