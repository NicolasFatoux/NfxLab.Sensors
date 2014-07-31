using System;
using Microsoft.SPOT;
using System.Diagnostics;

namespace NfxLab.MicroFramework.Logging
{
    public class DebugAppender : Appender
    {
        public override void Write(DateTime time, string name, LogType type, int level, object[] data)
        {
            string line = (string)Formatter.Format(time, name, type, level, data);
            Debug.Print(line);
        }

    }
}
