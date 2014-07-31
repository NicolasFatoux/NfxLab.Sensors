using System;
using Microsoft.SPOT;
using NfxLab.Framework.Logging;

namespace NfxLab.Framework.Tasks
{
    class Watchdog
    {
        public void Execute(Delegate method, int tries = -1)
        {
            for (int i = 0; i < tries; i++)
            {
                try
                {
                    method.Method.Invoke(null, null);
                    return;
                }
                catch(Exception e)
                {
                    FrameworkLogs.Multitasking.Info("Watchdog exception :",e);
                }
            }
        }

    }
}
