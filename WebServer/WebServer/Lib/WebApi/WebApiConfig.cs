using System;
using System.Security.Cryptography.X509Certificates;

namespace WebServer.Lib
{
    public sealed class WebApiConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        /// <param name="useTls"></param>
        /// <param name="controllers"></param>
        /// <param name="certificate">
        /// X509Certificate _myWebServerCertificate509 = new X509Certificate2(_myWebServerCrt, _myWebServerPrivateKey, "1234");
        /// </param>
        public WebApiConfig(
            int port,
            bool useTls,
            Type[] controllers,
            X509Certificate certificate = null)
        {
            Port = port;
            UseTls = useTls;
            Controllers = controllers;
            Certificate = certificate;
        }

        public int Port { get; }

        public bool UseTls { get; }

        public Type[] Controllers { get; }

        /// <summary>
        /// X509Certificate _myWebServerCertificate509 = new X509Certificate2(_myWebServerCrt, _myWebServerPrivateKey, "1234");
        /// </summary>
        public X509Certificate Certificate { get; }
    }
}
