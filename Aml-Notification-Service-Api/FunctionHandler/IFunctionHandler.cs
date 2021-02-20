using Aml.Notification.Service.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aml_Notification_Service_Api.FunctionHandler
{
    public interface IFunctionHandler
    {
        Task DeserialiseRequest();
        Task<IActionResult> Execute(Orders orders);
    }
}
