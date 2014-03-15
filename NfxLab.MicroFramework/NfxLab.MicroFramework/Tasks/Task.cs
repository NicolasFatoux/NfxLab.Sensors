using System;
using Microsoft.SPOT;
using System.Threading;

namespace NfxLab.Framework.Tasks
{
    public abstract class Task : TaskBase
    {
        Thread thread;

        public ThreadPriority Priority { get; set; }
        
        public override void Start()
        {
            Debug.Print("& " + Name + " Start - Priority=" + Priority);

            thread = new Thread(DoExecute);
            thread.Priority = Priority;
            thread.Start();
        }

        public override void Stop()
        {
            Debug.Print("& " + Name + " Stop");

            thread.Suspend();
            thread = null;
        }
    }
}
