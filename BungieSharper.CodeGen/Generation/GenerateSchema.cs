using BungieSharper.CodeGen.Entities.Common;
using BungieSharper.CodeGen.Entities.Components.Schema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BungieSharper.CodeGen.Generation
{
    internal class GenerateSchema
    {
        internal static string GetSchemaFileContent(string name, SchemaObject def)
        {
            if (def.Type == TypeEnum.Integer)
            {
                if (def.Enum is null || def.XEnumValues is null || def.Enum.Length == 0 || def.Enum.Length != def.XEnumValues.Length)
                {
                    throw new Exception();
                }

                var enumContent = GetEnumFileContent(name, def);
            }

            return "";
        }

        internal static string GetEnumFileContent(string name, SchemaObject def)
        {
            var fileContent = "";
            const string enumFlagsString = "    [System.Flags]\n";

            fileContent += $"namespace {string.Join('.', name.Split('.')[..^1])}\n{{\n";

            if (!string.IsNullOrWhiteSpace(def.Description))
            {
                fileContent += FormatSummaries.Format(def.Description, 1, true);
            }
            if (def.XEnumIsBitmask == true)
            {
                fileContent += enumFlagsString;
            }

            var enumList = new List<string>();
            foreach (var enumVal in def.XEnumValues!)
            {
                var doc = string.IsNullOrWhiteSpace(enumVal.Description) ? "" : FormatSummaries.Format(enumVal.Description, 2);
                var enumDef = $"        {enumVal.Identifier} = {enumVal.NumericValue}";

                enumList.Add(doc + enumDef);
            }

            fileContent += $"    public enum {name.Split('.').Last()} : {Mapping.FormatToCSharp(def.Format!.Value)}\n    {{\n";

            fileContent += string.Join(",\n", enumList);
            // fileContent += string.Join(",\n", def.XEnumValues!.Select(x => $"        {x.Identifier} = {x.NumericValue}"));

            fileContent += "\n    }\n}";

            fileContent = fileContent.Replace(",\n        /// <summary>", ",\n\n        /// <summary>");

            return fileContent;
        }
    }
}