using Aml.Notification.Service.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aml_Notification_Service_Api.FunctionHandler
{

    public abstract class FunctionHandlerBase : IFunctionHandler
    {
        public HttpRequest HttpRequest { get; set; }
#pragma warning disable 1998
        public virtual async Task DeserialiseRequest()
        {
        }
        public abstract Task<IActionResult> Execute(Orders orders);

    }
}
