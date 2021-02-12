using System;
using System.IO;
using System.Net;

namespace BungieSharper.CodeGen.Entities.Tests
{
    public class SpecFixture
    {
        public string SpecFileContent { get; }

        public SpecFixture()
        {
            var webClient = new WebClient();
            webClient.DownloadFile(new Uri("https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json", UriKind.Absolute), "openapi.json");

            SpecFileContent = File.ReadAllText("openapi.json");
        }
    }
}