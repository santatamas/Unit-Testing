using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService
{
    public interface ILogger
    {
        bool SupportsLogLevel(LogLevel logLevel);
        void LogMessage(string message, LogLevel level);
    }
}
