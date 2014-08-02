using System;
using Microsoft.SPOT;
using System.Collections;
using System.Diagnostics;

namespace NfxLab.MicroFramework.Logging
{
    public class Log
    {
        TextFormatter formatter = new TextFormatter();

        public string Name { get; set; }
        public int Level { get; set; }
        public IAppender[] Appenders { get; set; }

        public Log(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public void Info(params object[] data)
        {
            Write(data);
        }

        [Conditional("DEBUG")]
        public void Debug(params object[] data)
        {
            Write(data);
        }

        private void Write(params object[] data)
        {
            string message = formatter.Format(data);

            foreach (IAppender appender in Appenders)
                appender.Write(message);
        }        
    }
}
