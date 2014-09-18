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
        FileSystemLogger _logger;

        public LogService()
        {
            _logger = new FileSystemLogger();
        }

        public void Log(string message, LogLevel logLevel)
        {
            _logger.Log(message, logLevel);
        }
    }
}
