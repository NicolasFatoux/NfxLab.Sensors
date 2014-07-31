using System;
using Microsoft.SPOT;
using System.Threading;

namespace NfxLab.Framework.Tasks
{
    public abstract class TimerTask : TaskBase
    {
        Timer timer;

        public TimeSpan Interval { get; set; }

        public override void Start()
        {
            timer = new Timer(TimerCallback, null, new TimeSpan(0,0,0), Interval);   
        }



        public override void Stop()
        {
            timer.Dispose();
            timer = null;
        }

        private void TimerCallback(object state)
        {
            DoExecute();
        }
    }
}
