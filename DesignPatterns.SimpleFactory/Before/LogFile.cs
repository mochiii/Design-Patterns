using System.Collections.Generic;

namespace DesignPatterns.SimpleFactory.Before
{
    public class LogFile
    {
        public IEnumerable<string> Warnings { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
