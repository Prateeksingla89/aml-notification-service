using Aml.Notification.Service.Model;
using Aml_Notification_Service_Api.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Aml_Notification_Service_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersHandler ordersHandler;

        public OrderController(IOrdersHandler ordersHandler)
        {
            this.ordersHandler = ordersHandler;
        }
        [HttpPost]
        public async Task<IActionResult> GetOrder(Orders order)
        {
            return await ordersHandler.Execute(order);
        }
    }
}
