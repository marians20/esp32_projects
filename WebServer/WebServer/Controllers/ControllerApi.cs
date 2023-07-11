using System.Diagnostics;
using WebServer.Dtos;
using WebServer.Lib.Extensions;
using Windows.Storage;
using WS=nanoFramework.WebServer;

namespace WebServer.Controllers
{
    public sealed class ControllerApi
    {
        private readonly StorageFolder storage;

        public ControllerApi(StorageFolder storage)
        {
            this.storage = storage;
        }

        [WS.Route("api/message")]
        [WS.Method("GET")]
        public void Test(WS.WebServerEventArgs e)
        {
            Debug.WriteLine(e.Context.Request.RawUrl);
            e.Ok(new NamedMessage("Marian", "Hello"));
        }
    }
}
