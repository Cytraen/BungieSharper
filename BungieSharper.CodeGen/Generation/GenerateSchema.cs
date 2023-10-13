using BungieSharper.CodeGen.Entities.Common;
using BungieSharper.CodeGen.Entities.Components.Properties;
using BungieSharper.CodeGen.Entities.Components.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using AdditionalPropertiesClass = BungieSharper.CodeGen.Entities.Components.Properties.AdditionalPropertiesClass;
using XDictionaryKeyClass = BungieSharper.CodeGen.Entities.Components.Properties.XDictionaryKeyClass;

namespace BungieSharper.CodeGen.Generation;

internal static class GenerateSchema
{
    internal static string GetSchemaFileContent(string name, SchemaObject def)
    {
        return def.Type switch
        {
            TypeEnum.Integer when def.Enum is null || def.XEnumValues is null || !def.Enum.Any() ||
                                  def.Enum.Length != def.XEnumValues.Length => throw new NotSupportedException(),
            TypeEnum.Integer => GetEnumFileContent(name, def),
            TypeEnum.Object => GetObjectFileContent(name, def),
            TypeEnum.None => throw new NotSupportedException(),
            TypeEnum.Array => throw new NotSupportedException(),
            TypeEnum.Boolean => throw new NotSupportedException(),
            TypeEnum.Number => throw new NotSupportedException(),
            TypeEnum.String => throw new NotSupportedException(),
            _ => throw new NotSupportedException()
        };
    }

    private static string GetEnumFileContent(string name, SchemaObject def)
    {
        var fileContent = "";
        const string enumFlagsString = "    [System.Flags]\n";

        FormatStrings.FormatNamespace(name, out var className, out var nameSpace);

        fileContent += $"namespace {nameSpace}\n{{\n";

        if (!string.IsNullOrWhiteSpace(def.Description))
            fileContent += FormatStrings.FormatClassSummaries(def.Description);
        if (def.XEnumIsBitmask == true) fileContent += enumFlagsString;

        var enumList = (from enumVal in def.XEnumValues!
                        let doc =
                            string.IsNullOrWhiteSpace(enumVal.Description)
                                ? ""
                                : FormatStrings.FormatPropertySummaries(enumVal.Description)
                        let enumDef = $"        {enumVal.Identifier} = {enumVal.NumericValue}"
                        select doc + enumDef).ToList();

        fileContent += $"    public enum {className} : {Mapping.FormatToCSharp(def.Format!.Value)}\n    {{\n";
        fileContent += string.Join(",\n", enumList);
        fileContent += "\n    }\n}";
        fileContent = fileContent.Replace(",\n        /// <summary>", ",\n\n        /// <summary>");

        return fileContent;
    }

    private static string GetObjectFileContent(string name, SchemaObject def)
    {
        var fileContent = "";

        var properties = def.Properties;

        FormatStrings.FormatNamespace(name, out var className, out var nameSpace);

        fileContent += $"namespace {nameSpace}\n{{\n";

        if (!string.IsNullOrWhiteSpace(def.Description))
            fileContent += FormatStrings.FormatClassSummaries(def.Description);

        var propertyList = new List<string>();

        if (properties is not null)
            foreach (var (propName, propDef) in properties)
                propertyList.Add(ResolveProperty(propName, propDef));

        fileContent += $"    public class {className}\n    {{\n";
        fileContent += string.Join("\n\n", propertyList);
        fileContent += "\n    }";

        //fileContent += $"\n\n    [JsonSerializable(typeof({className}))]\n";
        //fileContent += "    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]\n";
        //fileContent += $"    internal partial class {className}JsonContext : JsonSerializerContext {{ }}\n}}";

        return fileContent;
    }

    private static string ResolveProperty(string name, PropertiesObject def)
    {
        var propListing = "";
        var propType = "";

        if (def.AllOf is not null)
            propType += FormatStrings.ResolveRef(def.AllOf[0].Ref, false);
        else if (def.Items is not null)
            propType += GenerateCommon.ResolveItems(def.Items, false);
        else if (def.AdditionalProperties is not null)
            propType += ResolvePropertyDictionary(def.XDictionaryKey!, def.AdditionalProperties);
        else if (def.Ref is not null)
            propType += FormatStrings.ResolveRef(def.Ref, false);
        else if (def.XEnumReference is not null)
            propType += FormatStrings.ResolveRef(def.XEnumReference.Ref, false);
        else if (def.Format is not null)
            propType += Mapping.FormatToCSharp(def.Format.Value);
        else
            propType += Mapping.TypeToCSharp(def.Type!.Value);

        if (def.Description is not null) propListing += FormatStrings.FormatPropertySummaries(def.Description);

        if (def.Nullable == true)
        {
            propType += "?";
            propListing += $"{"",8}[JsonPropertyName(\"{name}\")]\n";
            propListing += $"{"",8}[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]\n";
        }
        else
        {
            propListing += $"{"",8}[JsonPropertyName(\"{name}\")]\n";
        }

        propListing += $"{"",8}public {propType} {char.ToUpper(name[0]) + name[1..]} {{ get; set; }}";

        return propListing;
    }

    private static string ResolvePropertyDictionary(XDictionaryKeyClass dictKey,
        AdditionalPropertiesClass additionalProps)
    {
        var classType = "Dictionary<";

        if (dictKey.XEnumReference is not null)
            classType += FormatStrings.ResolveRef(dictKey.XEnumReference.Ref, false);
        else if (dictKey.Format is not null)
            classType += Mapping.FormatToCSharp(dictKey.Format.Value);
        else
            classType += Mapping.TypeToCSharp(dictKey.Type!.Value);

        classType += ", ";

        if (additionalProps.AdditionalProperties is not null)
        {
            if (additionalProps.XDictionaryKey is null) throw new NullReferenceException();
            classType +=
                ResolvePropertyDictionary(additionalProps.XDictionaryKey, additionalProps.AdditionalProperties);
        }
        else if (additionalProps.Items is not null)
        {
            classType += GenerateCommon.ResolveItems(additionalProps.Items, false);
        }
        else if (additionalProps.Ref is not null)
        {
            classType += FormatStrings.ResolveRef(additionalProps.Ref, false);
        }
        else if (additionalProps.XEnumReference is not null)
        {
            classType += FormatStrings.ResolveRef(additionalProps.XEnumReference.Ref, false);
        }
        else if (additionalProps.Format is not null)
        {
            classType += Mapping.FormatToCSharp(additionalProps.Format.Value);
        }
        else
        {
            classType += Mapping.TypeToCSharp(additionalProps.Type!.Value);
        }

        classType += ">";

        return classType;
    }
}