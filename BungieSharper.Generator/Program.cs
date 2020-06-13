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

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Utf8Json;

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

            var BungieSharperPath =
                Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\BungieSharper\"));

            var deserialized = JsonSerializer.Deserialize<dynamic>(await File.ReadAllBytesAsync("./openApi.json"));

            // TODO: WORK GOES HERE



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
