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

   BungieSharper accesses an API under the BSD 3-Clause License.
   See BUNGIE-SDK-LICENSE for more information.
   The Bungie API/SDK is copyright (c) 2017, Bungie, Inc.
*/

using BungieSharper.Generator.Generation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BungieSharper.Generator
{
    internal static class Program
    {
        internal const string OpenApiDefinitionUrl = "https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json?raw=true";

        private static dynamic? Deserialized { get; set; }

        private static async Task Main(string[] args)
        {
            if (args.Contains("--download-new-definitions") || !File.Exists("openApi.json"))
            {
                Console.Write($"Downloading new OpenAPI definitions from {OpenApiDefinitionUrl}... ");
                await DownloadNewOpenApiTask().ConfigureAwait(false);
                Console.WriteLine("done.");
            }
            else
            {
                Console.WriteLine("Using provided OpenAPI definitions.");
            }

            var bungieSharperPath =
                Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\BungieSharper\"));

            Deserialized = JsonHelper.Deserialize(await File.ReadAllTextAsync("./openApi.json"));

            // TODO: WORK GOES HERE

            var fileDictionary = new Dictionary<string, List<string>>();

            foreach (KeyValuePair<string, dynamic> schema in Deserialized["components"]["schemas"])
            {
                if (schema.Value["type"] == "array")
                {
                    continue;
                }

                var fileFolder = bungieSharperPath + "Schema\\" + string.Join('\\', schema.Key.Split('.').SkipLast(1));
                string fileContent = GenerateSchema.GenerateSchemaFileContent(schema.Key, schema.Value);

                if (fileContent.Contains("Dictionary<") || fileContent.Contains("IEnumerable<"))
                {
                    fileContent = "using System.Collections.Generic;\n" + fileContent;
                }

                if (fileContent.Contains("DateTime"))
                {
                    fileContent = "using System;\n" + fileContent;
                }

                if (fileContent.Contains("\nnamespace"))
                {
                    fileContent = fileContent.Replace("\nnamespace", "\n\nnamespace");
                }

                if (args.Contains("--verbose"))
                {
                    FileWriter.WriteFileWithContent(fileFolder, schema.Key.Split('.').Last() + ".cs", fileContent);
                }
                else
                {
                    if (!fileDictionary.ContainsKey(fileFolder))
                    {
                        fileDictionary[fileFolder] = new List<string>();
                    }
                    fileDictionary[fileFolder].Add(fileContent);
                }
            }

            if (!args.Contains("--verbose"))
            {
                foreach (var (location, classes) in fileDictionary)
                {
                    var combinedContent = string.Join("\n\n", classes);

                    var regex = new Regex(@"^namespace (.*)\n[{]", RegexOptions.Multiline);
                    var matches = regex.Matches(combinedContent);

                    combinedContent = combinedContent.Replace("\n{", "");
                    combinedContent = combinedContent.Replace("\n}", "");
                    combinedContent = combinedContent.Replace("\n\n\n", "");

                    combinedContent = combinedContent.Replace($"namespace {matches[0].Groups[1]}", "");
                    combinedContent = $"namespace {matches[0].Groups[1]}\n{{" + combinedContent + "}";

                    if (combinedContent.Contains("using System.Collections.Generic;"))
                    {
                        combinedContent = combinedContent.Replace("using System.Collections.Generic;\n", "");
                        combinedContent = "using System.Collections.Generic;\n" + combinedContent;
                    }
                    if (combinedContent.Contains("using System;"))
                    {
                        combinedContent = combinedContent.Replace("using System;\n", "");
                        combinedContent = "using System;\n" + combinedContent;
                    }

                    combinedContent = combinedContent.Replace(";\nnamespace ", ";\n\nnamespace ");
                    combinedContent = combinedContent.Replace("    }\n    public", "    }\n\n    public");
                    combinedContent = combinedContent.Replace("{\n\n    public", "{\n    public");
                    combinedContent = combinedContent.Replace("    }\n    [System.Flags", "    }\n\n    [System.Flags");
                    combinedContent = combinedContent.Replace("    }\n    /// <summary>", "    }\n\n    /// <summary>");

                    FileWriter.WriteFileWithContent(
                        bungieSharperPath + "Schema\\",
                        (location.Replace(bungieSharperPath, "").Replace('\\', '.') + ".cs").Replace("..", "."),
                        combinedContent
                        );
                }
            }

            foreach (KeyValuePair<string, dynamic> path in Deserialized["paths"])
            {
                var pathContent = GeneratePaths.GeneratePathContent(path.Key, path.Value);

                FileWriter.WriteFileWithContent(
                    bungieSharperPath + "Endpoints\\",
                    ((string)(path.Value["summary"].Replace('.', '_') + ".cs").Replace("..", ".")).TrimStart('_'),
                    pathContent);
            }

            // TODO: WORK ENDS HERE

            Console.WriteLine("Done with work.");

            if (args.Contains("--delete-definitions"))
            {
                Console.WriteLine("Deleting OpenAPI definitions.");
                File.Delete("./openApi.json");
            }
        }

        private static async Task DownloadNewOpenApiTask()
        {
            using var downloadJsonClient = new WebClient();

            var openApiJson = new Uri(OpenApiDefinitionUrl);

            await downloadJsonClient.DownloadFileTaskAsync(openApiJson, "./openApi.json");
        }

        public static dynamic ResolveReferences(string reference)
        {
            reference = reference.Remove(0, 2);
            var location = Deserialized;

            foreach (string key in reference.Split('/'))
            {
                location = location?[key];
            }

            return location!;
        }
    }
}