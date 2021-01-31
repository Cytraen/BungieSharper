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

            // WORK STARTS HERE

            var fileDictionary = new Dictionary<string, List<string>>();

            foreach (KeyValuePair<string, dynamic> schema in Deserialized["components"]["schemas"])
            {
                if (schema.Value["type"] == "array")
                {
                    continue;
                }

                GenerateSchema.GetProperties(schema.Key, schema.Value);
            }

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
                    var topFolder = location.Replace(bungieSharperPath, "").Replace("Schema\\", "").Split('\\').First();

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

                    if ((combinedContent.Length - combinedContent.Replace("[System.Flags]", "").Count()) / 14 > 2)
                    {
                        combinedContent = "using System;\n" + combinedContent;
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
                    combinedContent = combinedContent.Replace("    }\n    [Flags", "    }\n\n    [Flags");
                    combinedContent = combinedContent.Replace("    }\n    /// <summary>", "    }\n\n    /// <summary>");
                    combinedContent = combinedContent.Replace("\n{\n\n    /// <summary>", "\n{\n    /// <summary>");
                    combinedContent = combinedContent.Replace("\n\n\n\n", "\n\n");
                    combinedContent = combinedContent.Replace("\n\n\n", "\n\n");

                    combinedContent = combinedContent.Replace("\n    {\n\n    }\n", " { }\n");

                    if (combinedContent.Contains("using System;"))
                    {
                        combinedContent = combinedContent.Replace("[System.Flags", "[Flags");
                    }

                    if (!string.IsNullOrWhiteSpace(topFolder))
                    {
                        Directory.CreateDirectory(bungieSharperPath.TrimEnd('\\') + ".Schema\\" + topFolder);
                    }

                    FileWriter.WriteFileWithContent(
                        bungieSharperPath.TrimEnd('\\') + ".Schema\\" + topFolder,
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

            foreach (var (topSchemaName, topSchemaProperties) in GenerateSchema.PropertyDictionary)
            {
                if (topSchemaProperties.Count == 0)
                {
                    continue;
                }

                foreach (var (bottomSchemaName, bottomSchemaProperties) in GenerateSchema.PropertyDictionary)
                {
                    var hasDocumentation = false;
                    var match = true;

                    if (bottomSchemaProperties.Count == 0)
                    {
                        continue;
                    }

                    if (topSchemaName == bottomSchemaName)
                    {
                        continue;
                    }

                    if (topSchemaProperties.Where(x => x.Item3 != null).Count() > 0)
                    {
                        hasDocumentation = true;
                    }

                    foreach (var property in topSchemaProperties)
                    {
                        if (!bottomSchemaProperties.Contains(property))
                        {
                            match = false;
                        }
                    }

                    if (match & hasDocumentation)
                    {
                        Console.WriteLine(topSchemaName.Trim() + " may be the base of " + bottomSchemaName.Trim());
                    }
                }
            }

            // WORK ENDS HERE

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