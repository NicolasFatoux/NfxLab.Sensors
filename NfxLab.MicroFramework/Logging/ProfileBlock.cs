using System;
using Microsoft.SPOT;
using System.Diagnostics;

namespace NfxLab.MicroFramework.Logging
{
    public class ProfileBlock : Block
    {
        Stopwatch stopwatch;

        internal ProfileBlock(Log log, LogType logType, object[] datas):base(log, logType, datas)
        {
            stopwatch = Stopwatch.StartNew();
        }

        public override void Dispose()
        {
            stopwatch.Stop();
            Log.Profile("Ellapsed time :", stopwatch.ElapsedMilliseconds);

            base.Dispose();
        }
    }
}
