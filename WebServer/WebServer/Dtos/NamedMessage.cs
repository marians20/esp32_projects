using System;
// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace WebServer.Dtos
{
    public class NamedMessage
    {
        public NamedMessage(string name, string message)
        {
            this.name = name;
            this.message = message;
            utcTimeStamp = DateTime.UtcNow;
        }


        public string name { get; }

        public string message { get; }

        public DateTime utcTimeStamp { get; }
    }
}

#pragma warning restore IDE1006 // Naming Styles