using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Moonglade.Notification.EmailProcessor
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices()
                 .AddAzureStorage();
            }).ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            })
            .UseConsoleLifetime();

            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
