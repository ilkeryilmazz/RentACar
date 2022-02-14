using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.NLog.Loggers
{
   public class FileLogger:LoggerServiceBase
    {
        public FileLogger() : base("FileLogger")
        {
        }
    }
}
