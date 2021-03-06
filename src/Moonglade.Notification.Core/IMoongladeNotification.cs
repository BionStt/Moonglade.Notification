﻿using System.Threading.Tasks;
using Moonglade.Notification.Models;

namespace Moonglade.Notification.Core
{
    public interface IMoongladeNotification
    {
        string EmailDisplayName { get; set; }

        string AdminEmail { get; set; }

        Task SendTestNotificationAsync();

        Task SendNewCommentNotificationAsync(NewCommentPayload model);

        Task SendCommentReplyNotificationAsync(CommentReplyPayload model);

        Task SendPingNotificationAsync(PingPayload model);
    }
}
