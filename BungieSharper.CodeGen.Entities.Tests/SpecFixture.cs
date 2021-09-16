using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace BungieSharper.CodeGen.Entities.Tests
{
    public class SpecFixture
    {
        public string SpecFileContent { get; }

        public SpecFixture()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json").GetAwaiter().GetResult();
            SpecFileContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
}