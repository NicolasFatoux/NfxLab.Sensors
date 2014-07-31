using System;
using Microsoft.SPOT;
using System.Collections;
using System.Diagnostics;

namespace NfxLab.MicroFramework.Logging
{
    public class Log
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Appender[] Appenders { get; set; }

        public Log(params Appender[] appenders)
        {
            this.Appenders = appenders;
        }

        public void Error(params object[] datas)
        {
            Write(LogType.Error, datas);
        }

        public void Warning(params object[] datas)
        {
            Write(LogType.Warning, datas);
        }

        public void Info(params object[] datas)
        {
            Write(LogType.Info, datas);
        }

        [Conditional("DEBUG")]
        public void Debug(params object[] datas)
        {
            Write(LogType.Debug, datas);
        }

        [Conditional("PROFILE")]
        public void Profile(params object[] datas)
        {
            Write(LogType.Profile, datas);
        }

        
        public Block ErrorBlock(params object[] datas)
        {
            return new Block(this,LogType.Error, datas);
        }

        public Block WarningBlock(params object[] datas)
        {
            return new Block(this, LogType.Warning, datas);
        }

        public Block InfoBlock(params object[] datas)
        {
            return new Block(this, LogType.Info, datas);
        }

        public Block DebugBlock(params object[] datas)
        {
            return new Block(this, LogType.Debug, datas);
        }

        public ProfileBlock ProfileBlock(params object[] datas)
        {
            return new ProfileBlock(this, LogType.Profile, datas);
        }


        internal void Write(LogType type, object[] datas)
        {
            if (Appenders == null || datas == null)
                return;

            var time = DateTime.Now;
            int level = Level;

            foreach (Appender appender in Appenders)
                appender.Write(time, Name, type, level, datas);
        }

    }
}
