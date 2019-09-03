using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Moonglade.Notification.EmailProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
            }).ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            }).ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
            });
            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
}
