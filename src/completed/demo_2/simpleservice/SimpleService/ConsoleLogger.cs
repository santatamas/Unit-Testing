using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService
{
    public class ConsoleLogger : ILogger
    {
        public bool SupportsLogLevel(LogLevel logLevel)
        {
 	        return logLevel == LogLevel.Error;
        }

        public void LogMessage(string message, LogLevel level)
        {
            if (level != LogLevel.Error)
                throw new ArgumentException("LogLevel not supported!");

            Console.WriteLine(message);
        }
    }
}
