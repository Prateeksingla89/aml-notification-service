using System;

namespace Aml.Notification.Service.Settings
{
    //public interface IApplicationSettings 
    //{
    //    string TableStorageConnectionString { get; set; }
    //}
    public class ApplicationSettings 
    {
        public string TableStorageConnectionString { get; set; }

        public string QueueStorageConnectionString { get; set; }

        //public ApplicationSettings()
        //{
        //    this.TableStorageConnectionString = this.GetSetting("TableStorageConnectionString");
        //}
        //public string GetSetting(string key)
        //{
        //    return Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.);
        //}
    }
}
