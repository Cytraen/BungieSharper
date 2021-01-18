using BungieSharper.Generator.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BungieSharper.Generator.Generation
{
    internal static class GenerateSchema
    {
        public static string GenerateSchemaFileContent(string schemaName, Dictionary<string, dynamic> schemaDetails)
        {
            var valuesList = new List<Tuple<string, string, string?>>();
            var isEnum = false;

            if (schemaDetails["type"] == "integer")
            {
                isEnum = true;
                foreach (var enumVal in schemaDetails["x-enum-values"])
                {
                    string? usableSummary = enumVal!.ContainsKey("description") ? enumVal["description"] : null;

                    if (usableSummary != null)
                    {
                        usableSummary = FormatSummaries.FormatSummary(enumVal["description"], 8);
                    }

                    valuesList.Add(new Tuple<string, string, string?>(enumVal!["identifier"], enumVal["numericValue"], usableSummary));
                }
            }
            else if (schemaDetails["type"] == "object")
            {
                if (!schemaDetails.ContainsKey("properties"))
                {
                    return "";
                }

                foreach (KeyValuePair<string, dynamic> propertyPair in schemaDetails["properties"])
                {
                    string? usableSummary = propertyPair.Value.ContainsKey("description") ? propertyPair.Value["description"] : null;

                    if (usableSummary != null)
                    {
                        usableSummary = FormatSummaries.FormatSummary(propertyPair.Value["description"], 8);
                    }

                    string classType = propertyPair.Value.ContainsKey("x-enum-reference")
                        ? (string)JsonToCsharpMapping.GetReferenceFromRef(propertyPair.Value["x-enum-reference"]["$ref"])
                        : (string)JsonToCsharpMapping.Type(propertyPair.Value);

                    valuesList.Add(new Tuple<string, string, string?>(propertyPair.Key, classType, usableSummary));
                }
            }
            else
            {
                throw new NotSupportedException();
            }

            List<string> finalValueList;
            string finalValueString;
            var isFlags = schemaDetails.ContainsKey("x-enum-is-bitmask") && schemaDetails["x-enum-is-bitmask"];

            if (isEnum)
            {
                finalValueList = valuesList.Select(x => $"{x.Item3}        {x.Item1} = {x.Item2},").ToList();
                finalValueString = string.Join('\n', finalValueList).TrimEnd(',');
            }
            else
            {
                finalValueList = valuesList.Select(x => $"{x.Item3}        public {x.Item2} {x.Item1} {{ get; set; }}").ToList();
                finalValueString = string.Join('\n', finalValueList);
            }

            var almostFinalString = CreateDataTypeContent(isEnum, finalValueString, isFlags);

            if (isEnum)
            {
                almostFinalString = almostFinalString.Replace("{int!Type}", " : " + JsonToCsharpMapping.Type(schemaDetails)).Replace(" : int", "");
            }

            almostFinalString = almostFinalString.Replace("{name!Space}", GenerateNamespace.CreateSchemaNamespace(schemaName));
            almostFinalString = almostFinalString.Replace("{thingName}", schemaName.Split('.').Last());

            almostFinalString = almostFinalString.Replace("{documentation}",
                schemaDetails.ContainsKey("description")
                    ? FormatSummaries.FormatSummary(schemaDetails.ContainsKey("description")
                        ? schemaDetails["description"]
                        : "", 4, true)
                    : ""
                );
            return almostFinalString;
        }

        private static string CreateDataTypeContent(bool isEnum, string propertiesWithSummaries, bool isEnumFlags = false)
        {
            var content = "";

            content += "namespace {name!Space}\n";
            content += "{\n";

            content += "{documentation}";

            if (isEnumFlags)
            {
                content += "    [System.Flags]\n";
            }

            content += "    public " + (isEnum ? "enum {thingName}{int!Type}" : "class {thingName}") + "\n";
            content += "    {\n";

            content += propertiesWithSummaries + '\n';

            content += "    }\n";
            content += "}\n";

            return content;
        }
    }
}