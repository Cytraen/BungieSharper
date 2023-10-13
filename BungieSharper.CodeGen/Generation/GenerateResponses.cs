using System;
using System.Linq;

namespace BungieSharper.CodeGen.Generation;

internal static class GenerateResponses
{
    internal static string CreateResponseClass(string responseName, bool isApiResponse)
    {
        var fileContent = "";

        // fileContent += $"public class {className} : ApiResponse<{responseName}> {{ }}\n\n";
        // //fileContent += "[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]\n";

        // var className = ResponseNameToAlphanumeric(responseName) + "Response";
        // fileContent += $"[JsonSerializable(typeof({className}))]\n";
        // fileContent += $"internal partial class {className}JsonContext : JsonSerializerContext {{ }}";

        if (isApiResponse)
        {
            fileContent += $"[JsonSerializable(typeof(ApiResponse<{responseName}>))]";
        }
        else
        {
            fileContent += $"[JsonSerializable(typeof({responseName}))]";
        }

        return fileContent;
    }

    internal static string ResponseNameToAlphanumeric(string response)
    {
        if (string.IsNullOrWhiteSpace(response)) return response;

        if (response.StartsWith("IEnumerable<"))
            return "IEnumerable" + ResponseNameToAlphanumeric(response.Remove(0, "IEnumerable<".Length)[..^1]);

        if (response.StartsWith("Dictionary<"))
        {
            var dictSplit = response.Remove(0, "Dictionary<".Length)[..^1];
            var firstComma = dictSplit.IndexOf(',');
            return "Dictionary" + ResponseNameToAlphanumeric(dictSplit[..firstComma]) +
                   ResponseNameToAlphanumeric(dictSplit[(firstComma + 1)..].Trim());
        }

        if (response.Contains('.')) return response.Split('.').Last();

        return BasicTypeToName(response);
    }

    private static string BasicTypeToName(string basicType)
    {
        return basicType switch
        {
            "bool" => "Boolean",
            "object" => "Object",
            "byte" => "Byte",
            "sbyte" => "SByte",
            "short" => "Int16",
            "ushort" => "UInt16",
            "int" => "Int32",
            "uint" => "UInt32",
            "long" => "Int64",
            "ulong" => "UInt64",
            "string" => "String",
            _ => throw new NotSupportedException()
        };
    }
}