using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Moonglade.Notification.EmailProcessor
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("notification-email-queue")] string message, ILogger logger)
        {
            logger.LogInformation(message);
        }
    }
}
