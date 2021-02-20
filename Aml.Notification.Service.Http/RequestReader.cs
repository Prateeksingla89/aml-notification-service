using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Aml.Notification.Service.Http
{
    public interface IRequestReader
    {
        Task<string> ReadBody(HttpRequest request);

    }
    public class RequestReader : IRequestReader
    {
        public async Task<string> ReadBody(HttpRequest request)
        {
            return await new StreamReader(request.Body).ReadToEndAsync();
        }

        
    }
}
