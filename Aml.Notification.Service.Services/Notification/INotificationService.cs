using Aml.Notification.Service.Model;
using Aml.Notification.Service.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aml.Notification.Service.Services.NotificationService
{
    public interface INotificationService
    {
        Task<OrderResponse> AddOrder(Orders order);
    }
}
