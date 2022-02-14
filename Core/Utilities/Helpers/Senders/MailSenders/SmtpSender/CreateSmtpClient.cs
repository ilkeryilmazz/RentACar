using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.Helpers.Senders.SmtpSender
{
    public static class CreateSmtpClient
    {

        /// <summary>
        ///  SmtpClient oluşturur ve oluşan client'ı return eder.
        /// </summary>
        public static SmtpClient CreateClient(SmtpSettings _settings)
        {
            var smtpClient = new SmtpClient(_settings.Host, _settings.Port)
            {
                EnableSsl = _settings.Ssl,
                Credentials = new NetworkCredential(_settings.Username, _settings.Password)
            };
            
            return smtpClient;
        }
    }
}
