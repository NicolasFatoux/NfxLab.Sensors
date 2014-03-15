using System;
using Microsoft.SPOT;

namespace NfxLab.MicroFramework.Logging
{
    public static class FrameworkLogs
    {
        static Log _display;
        static Log _drivers;
        static Log _network;
        static Log _multitasking;

        public static Log Display
        {
            get
            {
                if (_display == null)
                    _display = new Log()
                    {
                        Name = "Display",
                    };

                return _display;
            }

        }

        public static Log Driver
        {
            get
            {
                if (_drivers == null)
                    _drivers = new Log()
                    {
                        Name = "Driver",
                    };

                return _drivers;
            }

        }

        public static Log Network
        {
            get
            {
                if (_network == null)
                    _network = new Log()
                    {
                        Name = "Network",
                    };

                return _network;
            }

        }

        public static Log Multitasking
        {
            get
            {
                if (_multitasking == null)
                    _multitasking = new Log()
                    {
                        Name = "Multitasking",
                    };

                return _multitasking;
            }

        }
        
    }
}
