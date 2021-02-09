using BungieSharper.CodeGen.Entities.Common;
using BungieSharper.CodeGen.Entities.Components.Properties;
using BungieSharper.CodeGen.Entities.Components.Schema;
using System;
using System.Collections.Generic;

namespace BungieSharper.CodeGen.Generation
{
    internal class GenerateSchema
    {
        internal static string GetSchemaFileContent(string name, SchemaObject def)
        {
            var fileContent = "";

            if (def.Type == TypeEnum.Integer)
            {
                if (def.Enum is null || def.XEnumValues is null || def.Enum.Length == 0 || def.Enum.Length != def.XEnumValues.Length)
                {
                    throw new Exception();
                }

                fileContent = GetEnumFileContent(name, def);
            }
            if (def.Type == TypeEnum.Object)
            {
                fileContent = GetObjectFileContent(name, def);
            }

            return fileContent;
        }

        internal static string GetEnumFileContent(string name, SchemaObject def)
        {
            var fileContent = "";
            const string enumFlagsString = "    [System.Flags]\n";

            FormatStrings.FormatNamespace(name, out var className, out var nameSpace);

            fileContent += $"namespace {nameSpace}\n{{\n";

            if (!string.IsNullOrWhiteSpace(def.Description))
            {
                fileContent += FormatStrings.FormatSummaries(def.Description, 1, true);
            }
            if (def.XEnumIsBitmask == true)
            {
                fileContent += enumFlagsString;
            }

            var enumList = new List<string>();
            foreach (var enumVal in def.XEnumValues!)
            {
                var doc = string.IsNullOrWhiteSpace(enumVal.Description) ? "" : FormatStrings.FormatSummaries(enumVal.Description, 2);
                var enumDef = $"        {enumVal.Identifier} = {enumVal.NumericValue}";

                enumList.Add(doc + enumDef);
            }

            fileContent += $"    public enum {className} : {Mapping.FormatToCSharp(def.Format!.Value)}\n    {{\n";
            fileContent += string.Join(",\n", enumList);
            fileContent += "\n    }\n}";
            fileContent = fileContent.Replace(",\n        /// <summary>", ",\n\n        /// <summary>");

            return fileContent;
        }

        internal static string GetObjectFileContent(string name, SchemaObject def)
        {
            var fileContent = "";

            var properties = def.Properties;

            FormatStrings.FormatNamespace(name, out var className, out var nameSpace);

            fileContent += $"namespace {nameSpace}\n{{\n";

            if (!string.IsNullOrWhiteSpace(def.Description))
            {
                fileContent += FormatStrings.FormatSummaries(def.Description, 1, true);
            }

            var propertyList = new List<string>();

            if (properties is not null)
            {
                foreach (var (propName, propDef) in properties)
                {
                    propertyList.Add(ResolveProperty(propName, propDef));
                }
            }

            fileContent += $"    public class {className}\n    {{\n";
            fileContent += string.Join("\n\n", propertyList);
            fileContent += "\n    }\n}";

            return fileContent;
        }

        internal static string ResolveProperty(string name, PropertiesObject def)
        {
            var propListing = "";
            var propType = "";

            if (def.AllOf is not null)
            {
                propType += FormatStrings.ResolveRef(def.AllOf[0].Ref, false);
            }
            else if (def.Items is not null)
            {
                propType += GenerateCommon.ResolveItems(def.Items);
            }
            else if (def.AdditionalProperties is not null)
            {
                propType += ResolvePropertyDictionary(def.XDictionaryKey!, def.AdditionalProperties);
            }
            else if (def.Ref is not null)
            {
                propType += FormatStrings.ResolveRef(def.Ref, false);
            }
            else if (def.XEnumReference is not null)
            {
                propType += FormatStrings.ResolveRef(def.XEnumReference.Ref, false);
            }
            else if (def.Format is not null)
            {
                propType += Mapping.FormatToCSharp(def.Format.Value);
            }
            else
            {
                propType += Mapping.TypeToCSharp(def.Type!.Value);
            }

            // TODO: use def.XDestinyComponentTypeDependency
            if (def.Description is not null)
            {
                propListing += FormatStrings.FormatSummaries(def.Description, 2);
            }

            if (def.Nullable == true)
            {
                propType += "?";
                propListing += $"        [JsonPropertyName(\"{name}\"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]\n";
            }
            else
            {
                propListing += $"        [JsonPropertyName(\"{name}\")]\n";
            }

            propListing += $"        public {propType} {char.ToUpper(name[0]) + name[1..]} {{ get; set; }}";

            return propListing;
        }

        internal static string ResolvePropertyDictionary(Entities.Components.Properties.XDictionaryKeyClass dictKey, Entities.Components.Properties.AdditionalPropertiesClass additionalProps)
        {
            var classType = "Dictionary<";

            if (dictKey.XEnumReference is not null)
            {
                classType += FormatStrings.ResolveRef(dictKey.XEnumReference.Ref, false);
            }
            else if (dictKey.Format is not null)
            {
                classType += Mapping.FormatToCSharp(dictKey.Format.Value);
            }
            else
            {
                classType += Mapping.TypeToCSharp(dictKey.Type!.Value);
            }

            classType += ", ";

            if (additionalProps.AdditionalProperties is not null)
            {
                classType += ResolvePropertyDictionary(additionalProps.XDictionaryKey, additionalProps.AdditionalProperties);
            }
            else if (additionalProps.Items is not null)
            {
                classType += GenerateCommon.ResolveItems(additionalProps.Items);
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
}