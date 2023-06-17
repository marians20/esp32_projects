using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using nanoFramework.Networking;

namespace WebServer.Lib
{
    public class WiFi
    {
        private readonly WiFiConfig config;

        public WiFi(WiFiConfig config)
        {
            this.config = config;
        }

        public string MacAddress =>
            BitConverter.ToString(NetworkInterface.GetAllNetworkInterfaces()[0].PhysicalAddress);

        public string IpAddress =>
            NetworkInterface.GetAllNetworkInterfaces()[0].IPv4Address;

        public bool Connect()
        {
            CancellationTokenSource cs = new(60000);

            var success = WifiNetworkHelper.ConnectDhcp(
                config.Ssid,
                config.Password,
                requiresDateTime: true,
                token: cs.Token);

            if (!success)
            {
                // Something went wrong, you can get details with the ConnectionError property:
                Debug.WriteLine($"Can't connect to the network, error: {WifiNetworkHelper.Status}");
                if (WifiNetworkHelper.HelperException != null)
                {
                    Debug.WriteLine($"ex: {WifiNetworkHelper.HelperException}");
                }
            }

            String macString = BitConverter.ToString(NetworkInterface.GetAllNetworkInterfaces()[0].PhysicalAddress);

            return success;
        }
    }
}
