using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Helpers.Senders.SmsSenders.TwilioSender;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Core.Utilities.Helpers.Senders.SmsSenders.Twilio
{
   public class TwilioSender:ISmsSender
   {
       private IConfiguration _configuration;
       private TwilioSettings _twilioSettings;
        public TwilioSender(IConfiguration configuration)
        {
            _configuration = configuration;
            _twilioSettings = _configuration.GetSection("Twilio").Get<TwilioSettings>();

            TwilioClient.Init(_twilioSettings.AccountSid,_twilioSettings.AuthToken);
        }
        public void Send(string message, string toPhone)
        {
            var sendedMessage = MessageResource.Create(
                body: message,
                from:_twilioSettings.Number,
                to: new PhoneNumber(toPhone)

            );
        }
    }
}
