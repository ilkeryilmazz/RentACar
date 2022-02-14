using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Senders.SmtpSender
{
    public interface IEmailSender
    {
        public void SendEmail(string fromAddress, string toAddress, string subject, string message);
    }
}
