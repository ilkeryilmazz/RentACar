using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Senders.SmtpSender
{
    //appsettings.json içerisinde ki SMTPDEV ile eşleştiriliyor.
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port{ get; set; }
        public string Username{ get; set; }
        public bool Ssl { get; set; }
        public string Password{ get; set; }
    }
}
