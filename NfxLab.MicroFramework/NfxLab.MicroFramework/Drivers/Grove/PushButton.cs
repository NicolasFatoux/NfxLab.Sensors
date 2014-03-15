using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace NfxLab.MicroFramework.Drivers.Grove
{
    public class PushButton : DigitalElement
    {
        InterruptPort port;


        public override void Start()
        {
            port = new InterruptPort(this.Pin1, true, Port.ResistorMode.PullDown, Port.InterruptMode.InterruptNone);
            port.OnInterrupt += port_OnInterrupt;
        }

        void port_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            if (Push != null)
                Push();
        }

        public override void Stop()
        {
            port.Dispose();
            port = null;
        }

        public delegate void PushEventHandler();

        public event PushEventHandler Push;
    }
}
