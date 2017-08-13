using System;

namespace DesignPatterns.SimpleFactory.Additional
{
    public class LogFileStatisticsEventArgs : EventArgs
    {
        public int WarningCount { get; set; }

        public int ErrorCount { get; set; }
    }
}
