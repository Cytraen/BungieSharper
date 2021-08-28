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
        internal const string BaseClientNamespace = "BungieSharper";
        internal const string BaseEntityNamespace = "BungieSharper.Entities";
        internal static readonly string BungieSharperPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\BungieSharper\"));
        internal static readonly string EntityFolder = BungieSharperPath.TrimEnd('\\') + ".Entities\\";
        internal static readonly string EndpointFolder = BungieSharperPath.TrimEnd('\\') + "\\Endpoints\\";

        internal static OpenApiObject OpenApiDefinition;

        private static void Main(string[] args)
        {
            const string openApiDefUrl = "https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json";

            if (args.Contains("--download-new-definitions") || !File.Exists("openApi.json"))
            {
                Console.Write($"Downloading new OpenAPI definitions from {openApiDefUrl}... ");
                var webClient = new WebClient();
                webClient.DownloadFile(new Uri(openApiDefUrl, UriKind.Absolute), "openapi.json");
                Console.WriteLine("done.");
            }
            else
            {
                Console.WriteLine("Using provided OpenAPI definitions.");
            }

            var fileContent = File.ReadAllText("openapi.json");
            OpenApiDefinition = JsonSerializer.Deserialize<OpenApiObject>(fileContent)!;
            var schemas = OpenApiDefinition.Components.Schemas;
            var paths = OpenApiDefinition.Paths;

            // entities

            foreach (var subDir in Directory.GetDirectories(EntityFolder))
            {
                Directory.Delete(subDir, true);
            }

            foreach (var file in Directory.GetFiles(EntityFolder))
            {
                var fileName = file.Split('\\').Last();

                if (fileName.EndsWith(".cs") && !fileName.StartsWith('_'))
                {
                    File.Delete(file);
                }
            }

            var schemaFileDict = new Dictionary<string, List<string>>();

            foreach (var (schemaName, schemaDef) in schemas)
            {
                if (schemaDef.Type == Entities.Common.TypeEnum.Array) continue;

                var fileFolder = string.Join('\\', schemaName.Split('.')[..^1]);

                if (!schemaFileDict.ContainsKey(fileFolder))
                {
                    schemaFileDict.Add(fileFolder, new List<string>());
                }

                schemaFileDict[fileFolder].Add(Generation.GenerateSchema.GetSchemaFileContent(schemaName, schemaDef));
            }

            foreach (var (location, classContents) in schemaFileDict)
            {
                var combinedContent = string.Join("\n", classContents);

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

                if (combinedContent.Length - combinedContent.Replace("[System.Flags]", "[Flags]").Replace("System.DateTime", "DateTime").Length >= 14)
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

                WriteFileWithContent(
                    EntityFolder + location.Replace(EntityFolder, "").Split('\\').First(),
                    ("Entities." + location.Replace(BungieSharperPath, "").Replace('\\', '.') + ".cs").Replace("..", "."),
                    combinedContent
                    );
            }

            // endpoints

            foreach (var subDir in Directory.GetDirectories(BungieSharperPath))
            {
                var folder = subDir.Split('\\').Last();
                if (folder == "bin" || folder == "obj")
                {
                    Directory.Delete(subDir, true);
                }
            }

            foreach (var file in Directory.GetFiles(EndpointFolder))
            {
                var fileName = file.Split('\\').Last();

                if (fileName.EndsWith(".cs") && !fileName.StartsWith('_'))
                {
                    File.Delete(file);
                }
            }

            var pathContentDict = new Dictionary<Entities.Common.TagEnum, List<string>>();

            foreach (var (pathUri, pathDef) in paths)
            {
                var tag = Entities.Common.TagEnum.None;

                if (pathDef.Get != null)
                {
                    var tagList = pathDef.Get.Tags.ToList();
                    tagList.Remove(Entities.Common.TagEnum.Preview);
                    tag = tagList[0];
                }
                if (pathDef.Post != null)
                {
                    var tagList = pathDef.Post.Tags.ToList();
                    tagList.Remove(Entities.Common.TagEnum.Preview);
                    tag = tagList[0];
                }

                if (!pathContentDict.ContainsKey(tag))
                {
                    pathContentDict[tag] = new List<string>();
                }

                var pathContent = Generation.GeneratePath.GeneratePathContent(pathUri, pathDef);
                pathContentDict[tag].Add(pathContent);
            }

            foreach (var (tag, methods) in pathContentDict)
            {
                var aggregateFile = "";

                aggregateFile +=
@"using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
";

                aggregateFile += string.Join("\n\n", methods);
                aggregateFile += "\n    }\n}";
                aggregateFile = aggregateFile.Replace("\r\n", "\n");

                if (!aggregateFile.Contains("JsonSerializer.Serialize("))
                {
                    aggregateFile = aggregateFile.Replace("using System.Text.Json;\n", "");
                }
                if (!aggregateFile.Contains("IEnumerable<") && !aggregateFile.Contains("Dictionary<"))
                {
                    aggregateFile = aggregateFile.Replace("using System.Collections.Generic;\n", "");
                }
                if (!aggregateFile.Contains(".Select(x => x.") && !aggregateFile.Contains(".Where(x => x."))
                {
                    aggregateFile = aggregateFile.Replace("using System.Linq;\n", "");
                }

                WriteFileWithContent(
                    EndpointFolder,
                    Generation.Mapping.TagToDescription(tag) + ".cs",
                    aggregateFile);
            }

            Console.WriteLine("Done. Press ENTER to exit.");
            Console.ReadLine();
        }

        public static void WriteFileWithContent(string fileFolder, string fileName, string fileContent)
        {
            Directory.CreateDirectory(fileFolder);

            File.WriteAllText(fileFolder + "\\" + fileName, fileContent.Replace("\r\n", "\n").Replace("\n", "\r\n"), Encoding.UTF8);
        }
    }
}