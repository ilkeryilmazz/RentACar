using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Helpers.Senders.SenderTemplates;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.Helpers.Senders.SmtpSender
{
  public  class SmtpEmailSender:IEmailSender
  {
      private IConfiguration _configuration;
      private static SmtpSettings _smtpSettings;

      public SmtpEmailSender(IConfiguration configuration)
      {
          _configuration = configuration;
          _smtpSettings = _configuration.GetSection("SMTPDEV").Get<SmtpSettings>();
        }
       /// <summary>
       /// Kullanıcıya mail gönderir.
       /// </summary>
       /// <param name="fromAddress">Hangi adresten mail gönderilecek</param>
       /// <param name="toAddress">Hangi adrese mail gönderilecek</param>
       /// <param name="subject">Mailin konu başlığı</param>
       /// <param name="message">Mailde gönderilecek olan mesaj</param>
        public void SendEmail(string fromAddress, string toAddress, string subject, string message)
      {
          var mailMessage = new MailMessage(fromAddress,toAddress,subject,message)
          {
              Body = SmtpTemplates.GetEmailVerifyTemplate(message),
              IsBodyHtml = true,
          };
         
          var smtpClient = CreateSmtpClient.CreateClient(_smtpSettings);
          smtpClient.Send(mailMessage);
      }
      
  }
}
