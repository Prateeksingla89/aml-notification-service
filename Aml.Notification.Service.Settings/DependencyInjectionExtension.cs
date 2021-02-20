using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aml.Notification.Service.Settings
{
    public static class DependencyInjectionExtension
    {
        public static void AddSettingsRegistrations(this IServiceCollection services)
        {
           // services.AddSingleton<IApplicationSettings, ApplicationSettings>();
        }
    }
}
