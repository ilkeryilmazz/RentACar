using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Core.CrossCuttingConcerns.Logging.NLog.Layouts;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Config;
using NLog.Fluent;
using NLog.Targets;

namespace Core.CrossCuttingConcerns.Logging.NLog
{
    public class LoggerServiceBase
    {
        private ILogger _logger;


        public LoggerServiceBase(string logger)
        {
            LogManager.Configuration = new XmlLoggingConfiguration("NLog.config");

            _logger = LogManager.GetLogger(logger);


        }

        public bool IsInfoEnabled => _logger.IsInfoEnabled;
        public bool IsDebugEnabled => _logger.IsDebugEnabled;
        public bool IsWarnEnabled => _logger.IsWarnEnabled;
        public bool IsFatalEnabled => _logger.IsFatalEnabled;
        public bool IsErrorEnabled => _logger.IsErrorEnabled;

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _logger.Info(JsonLayout.Format(logMessage));
            }
        }
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                _logger.Debug(JsonLayout.Format(logMessage));
            }
        }
        public void Warn(object logMessage)
        {

            if (IsWarnEnabled)
            {

                _logger.Warn(JsonLayout.Format(logMessage));
            }
        }
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                _logger.Fatal(JsonLayout.Format(logMessage));
            }
        }
        public void Error( Exception exception)
        {
            if (IsErrorEnabled)
            {
                _logger.Error(exception);
            }
        }
        public void Error(object logMessage, Exception exception)
        {
            if (IsErrorEnabled)
            {
                _logger.Error(exception, JsonLayout.Format(logMessage));  
            }
        }
    }

}

