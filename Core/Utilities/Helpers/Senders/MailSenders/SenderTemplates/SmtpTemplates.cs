using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Senders.SenderTemplates
{
    public static class SmtpTemplates
    {
      //Mail body kısmı için istediğimiz template türünü static fonksiyonlar aracılığı ile getirmeye yarayan class.
        public static string GetEmailVerifyTemplate(string verifyToken)
        {
            return
                $"<div style=\"width: 100%;\">\r\n    <div style=\"color: white; text-align: center; background-color: gray; width: 50%; height: 200px;  margin: auto;\">\r\n        <div>\r\n            <h1>\r\n                Rent A Car\r\n            </h1>\r\n        </div>\r\n        <a style=\"text-decoration: none; color: black;\" href=\"https://localhost:44370/api/UserVeryfies/verify?verifyToken={verifyToken}\"\">\r\n            <div style=\"font-size: 24px; position: fixed; top: 12%; left: 50%; transform: translate(-50%,-50%);\">\r\n Please click for account verify.</div>\r\n        </a>\r\n    </div>\r\n</div>";
          
        }

    }
}
