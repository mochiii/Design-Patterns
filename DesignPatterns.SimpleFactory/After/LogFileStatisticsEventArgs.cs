using System;

namespace DesignPatterns.SimpleFactory.After
{
    public class LogFileStatisticsEventArgs : EventArgs
    {
        public int WarningCount { get; set; }

        public int ErrorCount { get; set; }
    }
}
