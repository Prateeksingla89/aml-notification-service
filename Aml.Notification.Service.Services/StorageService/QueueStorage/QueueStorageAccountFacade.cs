
using Aml.Notification.Service.Settings;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aml.Notification.Service.Services.StorageService.QueueStorage
{
    public interface IQueueStorageAccountFacade
    {
        CloudQueueClient CreateQueueClient();
    }
    public class QueueStorageAccountFacade : IQueueStorageAccountFacade
    {
        private readonly IOptions<ApplicationSettings> appSettings;
        private readonly CloudStorageAccount cloudStorageAccount;
        public QueueStorageAccountFacade(IOptions<ApplicationSettings> appSettings)
        {
            this.appSettings = appSettings;

            if (appSettings == null)
                throw new ArgumentNullException(nameof(appSettings));
            if (string.IsNullOrEmpty(appSettings.Value.QueueStorageConnectionString))
                throw new ArgumentNullException(nameof(appSettings.Value.QueueStorageConnectionString));
            cloudStorageAccount = CloudStorageAccount.Parse(appSettings.Value.QueueStorageConnectionString);
        }
        public CloudQueueClient CreateQueueClient()
        {
            return cloudStorageAccount.CreateCloudQueueClient();
        }
    }
}
