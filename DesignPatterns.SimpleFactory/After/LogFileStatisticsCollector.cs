using System;
using System.Linq;

namespace DesignPatterns.SimpleFactory.After
{
    public class LogFileStatisticsCollector
    {
        public event EventHandler<LogFileStatisticsEventArgs> OnStatisticsCollected; 

        public void Process(IntPtr fileHandle)
        {
            var logFileParser = new LogFileParserSimpleFactory().Create(fileHandle);

            var logFile = logFileParser.Parse();

            var statistics = new LogFileStatisticsEventArgs
            {
                WarningCount = logFile.Warnings.Count(),
                ErrorCount = logFile.Errors.Count()
            };

            OnStatisticsCollected?.Invoke(this, statistics);
        }
    }
}
