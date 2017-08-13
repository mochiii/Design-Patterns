using System;
using System.IO;
using DesignPatterns.SimpleFactory.Additional.Parsers;
using Microsoft.Win32.SafeHandles;

namespace DesignPatterns.SimpleFactory.Additional
{
    public class LogFileParserSimpleFactory
    {
        public ILogFileParser Create(IntPtr fileHandle, FileFormats fileFormat)
        {
            var safeFileHandle = new SafeFileHandle(fileHandle, false);
            var fileStream = new FileStream(safeFileHandle, FileAccess.Read);
            var streamReader = new StreamReader(fileStream);

            ILogFileParser logFileParser;

            if (fileFormat == FileFormats.Json)
            {
                logFileParser = new JsonLogFileParser(streamReader);
            }
            else
            {
                logFileParser = new XmlLogFileParser(streamReader);
            }

            return logFileParser;
        }
    }
}
