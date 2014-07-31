using System;
using Microsoft.SPOT;

namespace NfxLab.MicroFramework.Logging
{
    public class TraceAppender : Appender
    {
        public override void Write(DateTime time, string name, LogType type, int level, object[] datas)
        {
            string line = (string)Formatter.Format(time, name, type, level, datas);
            Trace.Print(line);
        }
    }
}
