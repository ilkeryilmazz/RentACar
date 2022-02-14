using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Senders.SmsSenders
{
   public interface ISmsSender
   {
       public void Send(string message, string toPhone);
   }
}
