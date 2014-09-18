using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService
{
    [Flags]
    public enum LogLevel
    { 
        Info = 1, 
        Error = 2,
        Debug = 4
    }

    public class LogService
    {
        List<ILogger> _loggers = new List<ILogger>();

        public List<ILogger> Loggers
        {
            get { return _loggers; }
        }

        public void Log(string message, LogLevel logLevel)
        {
            foreach (var logger in _loggers.Where(l => l.SupportsLogLevel(logLevel)))
            {
                logger.LogMessage(message, logLevel);
            }
        }

        public void RegisterLogger(ILogger logger)
        {
            _loggers.Add(logger);
        }
    }
}
