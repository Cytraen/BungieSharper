using BungieSharper.CodeGen.Entities;
using BungieSharper.CodeGen.Entities.Common;
using BungieSharper.CodeGen.Generation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace BungieSharper.CodeGen;

internal static class Program
{
    internal const string BaseEntityNamespace = "BungieSharper.Entities";

    private static readonly string SolutionPath =
        Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"));

    private static readonly string EntityProjectFolder = Path.Combine(SolutionPath, "BungieSharper.Entities");
    private static readonly string ClientEndpointFolder = Path.Combine(SolutionPath, "BungieSharper", "Endpoints");
    internal static HashSet<string> PostBodyRequestTypes = new();

    internal static OpenApiObject OpenApiDefinition;

    private static void Main(string[] args)
    {
        var specJsonPath = Path.Combine(SolutionPath, "bnet-api-spec", "openapi.json");

        if (!File.Exists(specJsonPath))
        {
            Console.WriteLine("Please initialize submodules.");
            return;
        }

        var content = File.ReadAllText(specJsonPath);

        var serializerOptions = new JsonSerializerOptions
        { NumberHandling = JsonNumberHandling.AllowReadingFromString };

        OpenApiDefinition = JsonSerializer.Deserialize<OpenApiObject>(content, serializerOptions)!;
        var schemas = OpenApiDefinition.Components.Schemas;
        var paths = OpenApiDefinition.Paths;

        // entities

        foreach (var subDir in Directory.GetDirectories(EntityProjectFolder)) Directory.Delete(subDir, true);

        foreach (var file in Directory.GetFiles(EntityProjectFolder))
        {
            var fileName = file.Split('\\').Last();

            if (fileName.EndsWith(".cs") && !fileName.StartsWith('_')) File.Delete(file);
        }

        var schemaFileDict = new Dictionary<string, List<string>>();

        foreach (var (schemaName, schemaDef) in schemas)
        {
            if (schemaDef.Type == TypeEnum.Array) continue;

            var fileFolder = string.Join('\\', schemaName.Split('.')[..^1]);

            if (!schemaFileDict.ContainsKey(fileFolder)) schemaFileDict.Add(fileFolder, new List<string>());

            schemaFileDict[fileFolder].Add(GenerateSchema.GetSchemaFileContent(schemaName, schemaDef));
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

            if (combinedContent.Contains("[JsonPropertyName") || (combinedContent.Contains("JsonSerializable") &&
                                                                  combinedContent.Contains(
                                                                      "JsonSourceGenerationOptions") &&
                                                                  combinedContent.Contains("JsonSerializerContext")))
                combinedContent = "using System.Text.Json.Serialization;\n" + combinedContent;

            if (combinedContent.Contains("IEnumerable<") || combinedContent.Contains("Dictionary<"))
                combinedContent = "using System.Collections.Generic;\n" + combinedContent;

            if (combinedContent.Contains("using System.Collections.Generic;"))
            {
                combinedContent = combinedContent.Replace("using System.Collections.Generic;\n", "");
                combinedContent = "using System.Collections.Generic;\n" + combinedContent;
            }

            if (combinedContent.Length - combinedContent.Replace("[System.Flags]", "[Flags]")
                    .Replace("System.DateTime", "DateTime").Length >=
                14) combinedContent = "using System;\n" + combinedContent;

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
                Path.Combine(EntityProjectFolder, location.Split('\\').First()),
                ("Entities." + location.Replace(SolutionPath, "").Replace('\\', '.') + ".cs").Replace("..", "."),
                combinedContent
            );

            Console.WriteLine($"Wrote Entities.{location.Replace(SolutionPath, "").Replace('\\', '.')}");
        }

        // endpoints

        foreach (var subDir in Directory.GetDirectories(SolutionPath))
        {
            var folder = subDir.Split('\\').Last();
            if (folder is "bin" or "obj") Directory.Delete(subDir, true);
        }

        foreach (var file in Directory.GetFiles(ClientEndpointFolder))
        {
            var fileName = file.Split('\\').Last();

            if (fileName.EndsWith(".cs") && !fileName.StartsWith('_')) File.Delete(file);
        }

        var pathContentDict = new Dictionary<TagEnum, List<string>>();
        var returnResponseTypes = new HashSet<string>();

        foreach (var (pathUri, pathDef) in paths)
        {
            var tag = TagEnum.None;

            if (pathDef.Get != null)
            {
                var tagList = pathDef.Get.Tags.ToList();
                tagList.Remove(TagEnum.Preview);
                tag = tagList[0];
            }

            if (pathDef.Post != null)
            {
                var tagList = pathDef.Post.Tags.ToList();
                tagList.Remove(TagEnum.Preview);
                tag = tagList[0];
            }

            if (!pathContentDict.ContainsKey(tag)) pathContentDict[tag] = new List<string>();

            var pathContent = GeneratePath.GeneratePathContent(pathUri, pathDef, out var returnResponseType);
            pathContentDict[tag].Add(pathContent);
            returnResponseTypes.Add(returnResponseType);
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
                aggregateFile = aggregateFile.Replace("using System.Text.Json;\n", "");
            if (!aggregateFile.Contains("IEnumerable<") && !aggregateFile.Contains("Dictionary<"))
                aggregateFile = aggregateFile.Replace("using System.Collections.Generic;\n", "");
            if (!aggregateFile.Contains(".Select(x => x.") && !aggregateFile.Contains(".Where(x => x."))
                aggregateFile = aggregateFile.Replace("using System.Linq;\n", "");

            WriteFileWithContent(
                ClientEndpointFolder,
                Mapping.TagToDescription(tag) + ".cs",
                aggregateFile);

            Console.WriteLine($"Wrote {Mapping.TagToDescription(tag)}");
        }

        // response types

        var compiledContextTypes = returnResponseTypes.ToDictionary(x => x, x => true).Concat(PostBodyRequestTypes.ToDictionary(x => x, x => false)).ToDictionary(x => x.Key, x => x.Value);

        File.WriteAllText(Path.Combine(ClientEndpointFolder, "..", "Client", "JsonContext.cs"),
            "using BungieSharper.Entities;\nusing System.Collections.Generic;\nusing System.Text.Json.Serialization;\n\n" +
            "namespace BungieSharper.Endpoints;\n\n"
            + string.Join("\n", compiledContextTypes.Select(kvp => GenerateResponses.CreateResponseClass(kvp.Key, kvp.Value))) +
            "\n[JsonSerializable(typeof(ApiResponse))]\n[JsonSerializable(typeof(TokenResponse))]\ninternal partial class BungieSharperDeserializeJsonContext : JsonSerializerContext { }");

        Console.WriteLine("Done. Press ENTER to exit.");
        Console.ReadLine();
    }

    private static void WriteFileWithContent(string fileFolder, string fileName, string fileContent)
    {
        Directory.CreateDirectory(fileFolder);

        var regex = new Regex(@"^namespace ([\w.]*)\n{", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        var matches = regex.Matches(fileContent);

        fileContent = fileContent
            .Replace($"namespace {matches[0].Groups[1]}\n{{", $"namespace {matches[0].Groups[1]};\n")[..^2]
            .Replace("\n    ", "\n");

        var cleanContent = fileContent
            .Replace("\r\n", "\n")
            .Replace("\n\r", "\n")
            .Replace("\n", "\r\n")
            .Trim();

        File.WriteAllText(fileFolder + "\\" + fileName, cleanContent, Encoding.UTF8);
    }
}