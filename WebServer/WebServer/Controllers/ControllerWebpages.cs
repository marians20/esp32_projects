using System;
using System.Diagnostics;
using WebServer.Lib;
using WebServer.Resources;
using WS = nanoFramework.WebServer;

namespace WebServer.Controllers
{
    public class ControllerWebpages
    {
        [WS.Route("favicon.ico")]
        public void Favico(WS.WebServerEventArgs e)
        {
            WS.WebServer.SendFileOverHTTP(
                e.Context.Response,
                "favico.ico",
                Resource.GetBytes(Resource.BinaryResources.favicon),
                "image/ico");
        }

        [WS.Route("script.js")]
        public void Script(WS.WebServerEventArgs e)
        {
            e.Context.Response.ContentType = "text/javascript";
            WS.WebServer.OutPutStream(
                e.Context.Response,
                Resource.GetString(Resource.StringResources.script_js));
        }

        [WS.Route("image.png")]
        public void Image(WS.WebServerEventArgs e)
        {
            WS.WebServer.SendFileOverHTTP(
                e.Context.Response,
                "image.png",
                Resource.GetBytes(Resource.BinaryResources.Semnatura_prelucrata),
                "image/png");
        }

        [WS.Route("default.html"), WS.Route("index.html"), WS.Route("/")]
        public void Default(WS.WebServerEventArgs e)
        {
            e.Context.Response.ContentType = "text/html";
            var data = Resource.GetString(Resource.StringResources.index_html);
            WS.WebServer.OutPutStream(e.Context.Response, data);
        }
    }
}
