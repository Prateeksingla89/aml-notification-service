using Aml.Notification.Service.Services.Notification;
using Aml.Notification.Service.Services.NotificationService;
using Aml.Notification.Service.Services.StorageService.QueueStorage;
using Aml.Notification.Service.Services.StorageService.TableStorage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aml.Notification.Service.Services
{
    public static class DependencyInjectionExtension
    {
        public static void AddServiceRegistrations(this IServiceCollection services)
        {
           
            services.AddScoped<ITableStorageRepository, TableStorageRepository>();
            services.AddScoped<ITableStorageService, TableStorageService>();
            services.AddScoped<ICloudStorageAccountFacade, CloudStorageAccountFacade>();

            services.AddScoped<IQueueStorageRepository, QueueStorageRepository>();
            services.AddScoped<IQueueStorageService, QueueStorageService>();
            services.AddScoped<IQueueStorageAccountFacade, QueueStorageAccountFacade>();

            services.AddScoped<INotificationService, NotificationsService>();
        }
    }
}
