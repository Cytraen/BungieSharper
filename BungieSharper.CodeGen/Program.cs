using BungieSharper.CodeGen.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace BungieSharper.CodeGen
{
    internal class Program
    {
        internal static string BaseClientNamespace = "BungieSharper";
        internal static string BaseEntityNamespace = "BungieSharper.Entities";

        internal static OpenApiObject OpenApiDefinition;

        private static void Main(string[] args)
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
            OpenApiDefinition = JsonSerializer.Deserialize<OpenApiObject>(fileContent, _serializerOptions)!;
            var schemas = OpenApiDefinition.Components.Schemas;
            var paths = OpenApiDefinition.Paths;

            var schemaFileDict = new Dictionary<string, List<string>>();

            foreach (var (schemaName, schemaDef) in schemas)
            {
                if (schemaDef.Type == Entities.Common.TypeEnum.Array) continue;

                var fileFolder = string.Join('\\', schemaName.Split('.')[..^1]);

                if (!schemaFileDict.ContainsKey(fileFolder))
                {
                    schemaFileDict.Add(fileFolder, new());
                }

                schemaFileDict[fileFolder].Add(Generation.GenerateSchema.GetSchemaFileContent(schemaName, schemaDef));
            }

            foreach (var (location, classContents) in schemaFileDict)
            {
                var combinedContent = string.Join("\n", classContents);
                var topFolder = location.Replace(bungieSharperPath, "").Replace("Schema\\", "").Split('\\').First();

                var regex = new Regex(@"^namespace (.*)\n[{]", RegexOptions.Multiline);
                var matches = regex.Matches(combinedContent);

                combinedContent = combinedContent.Replace("\n{", "");
                combinedContent = combinedContent.Replace("\n}", "");
                combinedContent = combinedContent.Replace("\n\n\n", "");

                combinedContent = combinedContent.Replace($"namespace {matches[0].Groups[1]}", "");
                combinedContent = $"namespace {matches[0].Groups[1]}\n{{" + combinedContent + "\n}";

                if (combinedContent.Contains("[JsonPropertyName(\""))
                {
                    combinedContent = "using System.Text.Json.Serialization;\n" + combinedContent;
                }

                if (combinedContent.Contains("IEnumerable<") || combinedContent.Contains("Dictionary<"))
                {
                    combinedContent = "using System.Collections.Generic;\n" + combinedContent;
                }

                if (combinedContent.Contains("using System.Collections.Generic;"))
                {
                    combinedContent = combinedContent.Replace("using System.Collections.Generic;\n", "");
                    combinedContent = "using System.Collections.Generic;\n" + combinedContent;
                }

                if ((combinedContent.Length - combinedContent.Replace("[System.Flags]", "[Flags]").Replace("System.DateTime", "DateTime").Length) >= 14)
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
                    combinedContent = combinedContent.Replace("[System.Flags]", "[Flags]");
                    combinedContent = combinedContent.Replace("System.DateTime", "DateTime");
                }

                if (!string.IsNullOrWhiteSpace(topFolder))
                {
                    Directory.CreateDirectory(bungieSharperPath.TrimEnd('\\') + ".Schema\\" + topFolder);
                }

                WriteFileWithContent(
                    bungieSharperPath.TrimEnd('\\') + ".Entities\\" + topFolder,
                    ("Entities." + location.Replace(bungieSharperPath, "").Replace('\\', '.') + ".cs").Replace("..", "."),
                    combinedContent
                    );
            }

            foreach (var (pathUri, pathDef) in paths)
            {
                var pathContent = Generation.GeneratePath.GeneratePathContent(pathUri, pathDef);

                if (!pathContent.Contains("System.DateTime"))
                {
                    pathContent = pathContent.Replace("using System;\n", "");
                }
                else
                {
                    pathContent = pathContent.Replace("System.DateTime", "DateTime");
                }

                if (!pathContent.Contains("IEnumerable<") && !pathContent.Contains("Dictionary<"))
                {
                    pathContent = pathContent.Replace("using System.Collections.Generic;\n", "");
                }

                WriteFileWithContent(
                    bungieSharperPath + "Endpoints\\",
                    (pathDef.Summary.Replace('.', '_') + ".cs").Replace("..", ".").TrimStart('_'),
                    pathContent);
            }
        }

        public static void WriteFileWithContent(string fileFolder, string fileName, string fileContent)
        {
            Directory.CreateDirectory(fileFolder);

            File.WriteAllText(fileFolder + "\\" + fileName, fileContent.Replace("\r\n", "\n").Replace("\n", "\r\n"), Encoding.UTF8);
        }
    }
}