﻿using System.Collections.Generic;
using Moonglade.Notification.Models;

namespace Moonglade.Notification.Core
{
    public class AppSettings
    {
        public bool EnableEmailSending { get; set; }
        public bool EnableSsl { get; set; }
        public int SmtpServerPort { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpUserName { get; set; }
        public IReadOnlyCollection<ApiKey> ApiKeys { get; set; }
    }
}
