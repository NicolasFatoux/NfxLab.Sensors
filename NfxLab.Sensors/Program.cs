using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using NfxLab.MicroFramework.Logging;
using NfxLab.MicroFramework.Drivers.Grove;
using NfxLab.MicroFramework.Network;

namespace NfxLab.Sensors
{
    public class Program
    {
        static Log Log;
        static TemperatureHumiditySensorPro Sensor;
        static XivelyClient XivelyClient;
        static Timer Timer;

        public static void Main()
        {
            try
            {
                Log = new Log(
                    //new FileAppender(Configuration.LogPath), 
                    new DebugAppender()
                    );
                Log.Info("Starting");

                Log.Info("Initializing sensor");
                Sensor = new TemperatureHumiditySensorPro();
                Sensor.Plug(BaseShield.DigitalPorts.Digital1);

                Log.Info("Initializing Xively client");
                XivelyClient = new XivelyClient(Configuration.XivelyApiKey, Configuration.XivelyFeedId);

                Log.Info("Starting the timer");
                Timer = new Timer(SendUpdate, null, new TimeSpan(0, 0, 1), Configuration.Interval);

                Log.Info("Started");
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                Log.Error("Fatal exception", e);
            }
        }

        private static void SendUpdate(object state)
        {
            using (Log.ProfileBlock("Reading sensor"))
            Sensor.Read();

            Log.Info("Temperature:", Sensor.Temperature, "Humidity:", Sensor.Humidity);

            using (Log.ProfileBlock("Sending sensors data to Xively"))
                XivelyClient.Put(
                    new string[] { "Temperature", "Humidity" },
                    new object[] { Sensor.Temperature, Sensor.Humidity });

            Log.Info("Sensors data sent");
        }
    }
}
