using BungieSharper.CodeGen.Entities;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.CodeGen
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            const string openApiDefUrl = "https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json";

            if (args.Contains("--download-new-definitions") || !File.Exists("openApi.json"))
            {
                Console.Write($"Downloading new OpenAPI definitions from {openApiDefUrl}... ");
                var webClient = new WebClient();
                webClient.DownloadFile(new Uri("https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json", UriKind.Absolute), "openapi.json");
                Console.WriteLine("done.");
            }
            else
            {
                Console.WriteLine("Using provided OpenAPI definitions.");
            }

            var _serializerOptions = new JsonSerializerOptions();
            _serializerOptions.Converters.Add(new JsonLongConverter());

            var fileContent = File.ReadAllText("openapi.json");
            var openApi = JsonSerializer.Deserialize<OpenApiObject>(fileContent, _serializerOptions);
            var schemas = openApi.Components.Schemas;
            var paths = openApi.Paths;

            foreach (var (schemaName, schemaDef) in schemas)
            {
                if (schemaDef.Type == Entities.Common.TypeEnum.Array) continue;

                var test = Generation.GenerateSchema.GetSchemaFileContent(schemaName, schemaDef);
            }
        }
    }
}