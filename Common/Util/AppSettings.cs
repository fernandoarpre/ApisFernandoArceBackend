using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Util
{
    public class AppSettings
    {
        public string SecretKey { get;set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
    }
}
