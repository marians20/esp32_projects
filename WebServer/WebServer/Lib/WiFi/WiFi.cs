using System;
using System.Device.Wifi;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using nanoFramework.Networking;

namespace WebServer.Lib
{
    public class WiFi
    {
        private readonly WiFiConfig config;

        private WifiAvailableNetwork[] availableNetworks;
        private bool isScanning = false;

        public WiFi(WiFiConfig config)
        {
            this.config = config;
            WifiAdapter.AvailableNetworksChanged += WifiAdapter_AvailableNetworksChanged;
        }

        public string MacAddress => BitConverter.ToString(NetworkInterface.PhysicalAddress);

        public string IpAddress => NetworkInterface.IPv4Address;

        public bool Connect() => Connect(config.Ssid, config.Password);

        public bool Connect(string ssid, string password)
        {
            CancellationTokenSource cs = new(60000);

            var success = WifiNetworkHelper.ConnectDhcp(
                ssid,
                password,
                requiresDateTime: true,
                token: cs.Token);

            if (success)
            {
                Debug.WriteLine($"IP Address: {IpAddress}");
                return true;
            }

            Debug.WriteLine($"Can't connect to the network, error: {WifiNetworkHelper.Status}");
            if (WifiNetworkHelper.HelperException != null)
            {
                Debug.WriteLine($"ex: {WifiNetworkHelper.HelperException}");
            }

            return false;
        }

        public void ScanNetworks()
        {
            if (isScanning)
            {
                return;
            }

            isScanning = true;
            Thread.Sleep(10_000);
            try
            {
                Debug.WriteLine("starting Wi-Fi scan");
                WifiAdapter.ScanAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failure starting a scan operation: {ex}");
            }

            while (isScanning)
            {
                Thread.Sleep(100);
            }
        }

        private void WifiAdapter_AvailableNetworksChanged(WifiAdapter sender, object e)
        {
            availableNetworks = sender.NetworkReport.AvailableNetworks;
            foreach (var net in availableNetworks)
            {
                Debug.WriteLine($"Net SSID :{net.Ssid},  BSSID : {net.Bsid},  rssi : {net.NetworkRssiInDecibelMilliwatts.ToString()},  signal : {net.SignalBars.ToString()}");
            }

            isScanning = false;
        }

        private static WifiAdapter WifiAdapter => WifiAdapter.FindAllAdapters()[0];

        private static NetworkInterface NetworkInterface => NetworkInterface.GetAllNetworkInterfaces()[0];
    }
}
