using System;
using System.Linq;

namespace DesignPatterns.SimpleFactory.Additional
{
    public class LogFileStatisticsCollector
    {
        public event EventHandler<LogFileStatisticsEventArgs> OnStatisticsCollected; 

        public void Process(IntPtr fileHandle, FileFormats fileFormat)
        {
            var logFileParser = new LogFileParserSimpleFactory().Create(fileHandle, fileFormat);

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
