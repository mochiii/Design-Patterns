using System;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace DesignPatterns.SimpleFactory.After
{
    public class LogFileParserSimpleFactory
    {
        public LogFileParser Create(IntPtr fileHandle)
        {
            var safeFileHandle = new SafeFileHandle(fileHandle, false);
            var fileStream = new FileStream(safeFileHandle, FileAccess.Read);
            var streamReader = new StreamReader(fileStream);

            var logFileParser = new LogFileParser(streamReader);
            return logFileParser;
        }
    }
}
