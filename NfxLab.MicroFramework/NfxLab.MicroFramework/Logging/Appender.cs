using System;

namespace NfxLab.MicroFramework.Logging
{
    public abstract class Appender
    {
        public ILogFormatter Formatter { get; set; }

        public Appender()
        {
            Formatter = new TextFormatter();
        }

        public abstract void Write(DateTime time, string name, LogType type, int level, object[] datas);
    }
}
