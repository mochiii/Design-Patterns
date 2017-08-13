using System;

namespace DesignPatterns.SimpleFactory.Before
{
    public class LogFileStatisticsEventArgs : EventArgs
    {
        public int WarningCount { get; set; }

        public int ErrorCount { get; set; }
    }
}
