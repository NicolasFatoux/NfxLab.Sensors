using Microsoft.SPOT;
using NfxLab.Framework.Logging;
using System;
namespace NfxLab.Framework.Tasks
{
    public abstract class TaskBase
    {
        public string Name { get; set; }

        public abstract void Start();
        public abstract void Stop();

        protected abstract void Execute();

        internal virtual void DoExecute()
        {
            FrameworkLogs.Multitasking.Info(Name + " execution");

            try
            {
                Execute();
            }
            catch (Exception e)
            {
                FrameworkLogs.Multitasking.Warning(Name + " exception", e);
                if (Exception != null)
                    Exception(this, e);
            }

            FrameworkLogs.Multitasking.Info(Name + " done");
        }

        public delegate void TaskExceptionEventHandler(TaskBase task, Exception e);
        public event TaskExceptionEventHandler Exception;
    }
}
