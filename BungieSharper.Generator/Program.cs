/*
   Copyright (C) 2020 ashakoor
   
   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU Affero General Public License as
   published by the Free Software Foundation, either version 3 of the
   License or any later version.
   
   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU Affero General Public License for more details.
   
   You should have received a copy of the GNU Affero General Public License
   along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using BungieSharper.Generator.Generation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BungieSharper.Generator
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            if (args.Contains("downloadNewDefinitions=true") || !File.Exists("openApi.json"))
            {
                Console.Write("Downloading new OpenAPI definitions from Bungie.net... ");
                await DownloadNewOpenApiTask();
                Console.WriteLine("done.");
            }
            else
            {
                Console.WriteLine("Using provided OpenAPI definitions.");
            }

            var bungieSharperPath =
                Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\BungieSharper\"));

            dynamic deserialized = JsonHelper.Deserialize(await File.ReadAllTextAsync("./openApi.json"));

            // TODO: WORK GOES HERE

            foreach (KeyValuePair<string, dynamic> schema in deserialized["components"]["schemas"])
            {
                if (schema.Value["type"] == "array")
                    continue;

                if (schema.Key == "Content.ContentItemPublicContract")
                    continue;

                var fileFolder = bungieSharperPath + "Schema\\" + string.Join('\\', schema.Key.Split('.').SkipLast(1));
                string fileContent = GenerateSchema.GenerateSchemaFileContent(schema.Key, schema.Value);
                
                if (fileContent.Contains("Dictionary<") || fileContent.Contains("IEnumerable<"))
                    fileContent = "using System.Collections.Generic;\n" + fileContent;
                if (fileContent.Contains("DateTime"))
                    fileContent = "using System;\n" + fileContent;

                if (fileContent.Contains("\nnamespace"))
                    fileContent = fileContent.Replace("\nnamespace", "\n\nnamespace");

                FileWriter.WriteFileWithContent(fileFolder, schema.Key.Split('.').Last() + ".cs", fileContent);
            }

            // TODO: WORK ENDS HERE

            Console.WriteLine("Done with work.");

            if (args.Contains("deleteDefinitions=true"))
            {
                Console.WriteLine("Deleting OpenAPI definitions.");
                File.Delete("./openApi.json");
            }

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }

        private static async Task DownloadNewOpenApiTask()
        {
            using var downloadJsonClient = new WebClient();

            var openApiJson = new Uri("https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json?raw=true");

            await downloadJsonClient.DownloadFileTaskAsync(openApiJson, "./openApi.json");
        }
    }
}
