using System;
using Microsoft.SPOT;

namespace NfxLab.MicroFramework.Logging
{
    public class Block : Log, IDisposable
    {
        protected Log Log { get; private set; }

        internal Block(Log log)
        {
            Log = log;
            log.Level++;

        }

        internal Block(Log log, LogType type, params object[] data)
        {
            Log = log;
            log.Level++;

            log.Write(type, data);
        }


        public virtual void Dispose()
        {
            Log.Level--;
        }
    }
}
