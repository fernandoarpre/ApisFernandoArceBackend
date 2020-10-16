using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Email
{
    public interface IEmailService
    {
        void Send( string to, string subject, string html);
    }
}
