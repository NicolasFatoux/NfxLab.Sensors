using System;
using Microsoft.SPOT;

namespace NfxLab.Sensors
{
    static class Configuration
    {
        public const string LogPath = @"\SD\NfxLab.Sensors.log";
        public const string XivelyApiKey = "";
        public const string XivelyFeedId = "";
        public static readonly TimeSpan Interval = new TimeSpan(0, 0, 30);
    }
}
