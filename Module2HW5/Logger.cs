using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module2HW1
{
    public class Logger
    {
        private static readonly Logger _instance = new Logger();
        private StringBuilder _logHistoryBuilder;
        static Logger()
        {
        }

        private Logger()
        {
            _logHistoryBuilder = new StringBuilder();
        }

        public string LogHistory => _logHistoryBuilder.ToString();

        public static Logger Instance => _instance;

        public void Log(TypeLog typeLog, string message)
        {
            var consoleMessage = $"{DateTime.UtcNow}: {typeLog}: {message}";
            Console.WriteLine(consoleMessage);
            _logHistoryBuilder.AppendLine(consoleMessage);
        }
    }
}
