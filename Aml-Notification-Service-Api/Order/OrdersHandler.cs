using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aml.Notification.Service.Model;
using Aml.Notification.Service.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Aml.Notification.Service.Exceptions;
using Aml.Notification.Service.Services.NotificationService;

namespace Aml_Notification_Service_Api.Order
{

    public interface IOrdersHandler
    {
        Task<IActionResult> Execute(Orders orders);
    }
    public class OrdersHandler :  IOrdersHandler
    {
        private readonly INotificationService notificationService;
        public OrdersHandler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }


        public async Task<IActionResult> Execute(Orders order)
        {
            if (order == null)
                throw new ValidationException("Empty order request supplied.");

            var response = await notificationService.AddOrder(order);
            return new OkObjectResult(response);
        }
    }
}
