using System;
using Microsoft.SPOT;

namespace NfxLab.Sensors
{
    static class Configuration
    {
        public const string LogPath = @"\SD\NfxLab.Sensors.log";
        
        public const string XivelyApiKey = "";
        public const string XivelyFeedId = "";        
        public static readonly TimeSpan UpdateInterval = new TimeSpan(0, 0, 5);

        public const string TimeServer = "pool.ntp.org";
        public const int TimeZone = 2;
    }
}
