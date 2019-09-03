using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Moonglade.Notification.Models;

namespace Moonglade.Notification.EmailProcessor
{
    public class Functions
    {
        [Timeout("00:01:01")]
        public static async Task ProcessQueueMessage(
            [QueueTrigger("notification-email-queue")] NotificationRequest model, CancellationToken token, ILogger logger)
        {
            await Task.CompletedTask;
            if (token.IsCancellationRequested)
            {
                logger.LogInformation("Task cancelled.");
            }
            logger.LogInformation(System.Text.Json.JsonSerializer.Serialize(model));
        }
    }
}
