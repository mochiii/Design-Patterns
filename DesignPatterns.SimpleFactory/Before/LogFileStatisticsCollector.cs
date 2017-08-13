using System;
using System.IO;
using System.Linq;
using Microsoft.Win32.SafeHandles;

namespace DesignPatterns.SimpleFactory.Before
{
    public class LogFileStatisticsCollector
    {
        public event EventHandler<LogFileStatisticsEventArgs> OnStatisticsCollected; 

        public void Process(IntPtr fileHandle)
        {
            var safeFileHandle = new SafeFileHandle(fileHandle, false);
            var fileStream = new FileStream(safeFileHandle, FileAccess.Read);
            var streamReader = new StreamReader(fileStream);
            var logFileParser = new LogFileParser(streamReader);

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
