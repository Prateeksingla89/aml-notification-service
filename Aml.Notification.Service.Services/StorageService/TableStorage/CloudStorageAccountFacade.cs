using Aml.Notification.Service.Settings;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aml.Notification.Service.Services.StorageService.TableStorage
{
    public interface ICloudStorageAccountFacade
    {
        CloudTableClient CreateCloudTableClient();
    }

    public class CloudStorageAccountFacade : ICloudStorageAccountFacade
    {
        private readonly CloudStorageAccount cloudStorageAccount;
        private readonly IOptions<ApplicationSettings> appSettings;
        public CloudStorageAccountFacade(IOptions<ApplicationSettings> appSettings)
        {
            this.appSettings = appSettings;

            if (appSettings == null)
                throw new ArgumentNullException(nameof(appSettings));
            if (string.IsNullOrEmpty(appSettings.Value.TableStorageConnectionString))
                throw new ArgumentNullException(nameof(appSettings.Value.TableStorageConnectionString));
            cloudStorageAccount = CloudStorageAccount.Parse(appSettings.Value.TableStorageConnectionString);
        }

        public CloudTableClient CreateCloudTableClient()
        {
            return cloudStorageAccount.CreateCloudTableClient();
        }
    }
}
