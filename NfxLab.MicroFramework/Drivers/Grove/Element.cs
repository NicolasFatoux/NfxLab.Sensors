using System;
using Microsoft.SPOT;

namespace NfxLab.MicroFramework.Drivers.Grove
{
    public abstract class Element
    {
        public abstract void Start();
        public abstract void Stop();
    }
}
