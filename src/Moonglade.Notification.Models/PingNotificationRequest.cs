﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Moonglade.Notification.Models
{
    public class PingNotificationRequest : NotificationRequest
    {
        [Required]
        public string TargetPostTitle { get; set; }

        [Required]
        public DateTime PingTimeUtc { get; set; }

        [Required]
        public string Domain { get; set; }

        [Required]
        public string SourceIp { get; set; }

        [Required]
        public string SourceUrl { get; set; }

        [Required]
        public string SourceTitle { get; set; }
    }
}