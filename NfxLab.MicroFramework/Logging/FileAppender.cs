using System;
using Microsoft.SPOT;
using System.IO;

namespace NfxLab.MicroFramework.Logging
{
    public class FileAppender : Appender
    {
        StreamWriter writer;

        public FileAppender(string path)
        {
            var stream = File.Open(path, FileMode.Append);
            writer = new StreamWriter(stream);
        }

        public override void Write(DateTime time, string name, LogType type, int level, object[] datas)
        {
            try
            {
                writer.WriteLine(Formatter.Format(time, name, type, level, datas));
            }
            catch
            {
            }
        }
    }
}
