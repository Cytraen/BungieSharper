using BungieSharper.CodeGen.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BungieSharper.CodeGen
{
    internal class Program
    {
        internal static string BaseClientNamespace = "BungieSharper";
        internal static string BaseEntityNamespace = "BungieSharper.Entities";

        private static async Task Main(string[] args)
        {
            const string openApiDefUrl = "https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json";

            var bungieSharperPath =
                Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\BungieSharper\"));

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