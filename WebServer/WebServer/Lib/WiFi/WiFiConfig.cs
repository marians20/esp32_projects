namespace WebServer.Lib
{
    public sealed class WiFiConfig
    {
        public WiFiConfig(string ssid, string password)
        {
            Ssid = ssid;
            Password = password;
        }

        public string Ssid { get; }

        public string Password { get; }
    }
}
