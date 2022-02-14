using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Core.CrossCuttingConcerns.Logging.NLog.Layouts
{
  public static class JsonLayout
    {
        public static string Format(object message)
        {
            return JsonConvert.SerializeObject(message, Formatting.Indented);
        }
    }

}
