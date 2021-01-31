using BungieSharper.Generator.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BungieSharper.Generator.Generation
{
    internal static class GenerateSchema
    {
        public static Dictionary<string, List<Tuple<string, string, string?>>> PropertyDictionary = new();
        public static Dictionary<string, List<Tuple<string, string, string?>>> BasePropertyDictionary = new();

        public static readonly List<string> BaseTypeList = new()
        {
            "Components.ComponentResponse",
            "Destiny.Definitions.DestinyDefinition",
            "User.UserMembership",
            "User.CrossSaveUserMembership",
            "User.UserInfoCard",
            "Queries.SearchResult",
            "Destiny.DestinyItemQuantity",
            "Destiny.Definitions.Presentation.DestinyPresentationNodeBaseDefinition",
            "Destiny.Definitions.Presentation.DestinyScoredPresentationNodeBaseDefinition"
        };

        public static void GetProperties(string schemaName, Dictionary<string, dynamic> schemaDetails)
        {
            var valuesList = new List<Tuple<string, string, string?>>();

            if (schemaDetails["type"] == "integer")
            {
                return;
            }
            else if (schemaDetails["type"] == "object")
            {
                if (!schemaDetails.ContainsKey("properties"))
                {
                    return;
                }

                foreach (KeyValuePair<string, dynamic> propertyPair in schemaDetails["properties"])
                {
                    string? usableSummary = propertyPair.Value.ContainsKey("description") ? propertyPair.Value["description"] : null;
                    bool isNullable = propertyPair.Value.ContainsKey("nullable") ? propertyPair.Value["nullable"] : false;

                    if (usableSummary != null)
                    {
                        usableSummary = FormatSummaries.FormatSummary(propertyPair.Value["description"], 8);
                    }

                    string classType = (propertyPair.Value.ContainsKey("x-enum-reference")
                        ? (string)JsonToCsharpMapping.GetReferenceFromRef(propertyPair.Value["x-enum-reference"]["$ref"])
                        : (string)JsonToCsharpMapping.Type(propertyPair.Value))
                        + (isNullable ? "?" : "");

                    valuesList.Add(new Tuple<string, string, string?>(propertyPair.Key, classType, usableSummary));
                }
            }
            else
            {
                throw new NotSupportedException();
            }

            if (BaseTypeList.Contains(schemaName))
            {
                BasePropertyDictionary.Add(schemaName, valuesList);
            }
            // PropertyDictionary.Add(schemaName, valuesList);
        }

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
                    bool isNullable = propertyPair.Value.ContainsKey("nullable") ? propertyPair.Value["nullable"] : false;

                    if (usableSummary != null)
                    {
                        usableSummary = FormatSummaries.FormatSummary(propertyPair.Value["description"], 8);
                    }

                    string classType = (propertyPair.Value.ContainsKey("x-enum-reference")
                        ? (string)JsonToCsharpMapping.GetReferenceFromRef(propertyPair.Value["x-enum-reference"]["$ref"])
                        : (string)JsonToCsharpMapping.Type(propertyPair.Value))
                        + (isNullable ? "?" : "");

                    valuesList.Add(new Tuple<string, string, string?>(propertyPair.Key, classType, usableSummary));
                }
            }
            else
            {
                throw new NotSupportedException();
            }

            var className = schemaName.Split('.').Last();

            if (!isEnum)
            {
                // PropertyDictionary.Add(schemaName, valuesList);
            }

            List<string> finalValueList;
            string finalValueString;
            var isFlags = schemaDetails.ContainsKey("x-enum-is-bitmask") && schemaDetails["x-enum-is-bitmask"];

            var inheritList = new List<string>();
            var valuesListRemove = new List<Tuple<string, string, string?>>();

            foreach (var (baseClass, classProperties) in BasePropertyDictionary)
            {
                if (baseClass.Split('.').Last() == className)
                {
                    break;
                }

                var filtered = valuesList.Where(x => classProperties.Contains(x)).ToList();

                if (filtered.Count == classProperties.Count)
                {
                    foreach (var item in filtered)
                    {
                        valuesListRemove.Add(item!);
                    }

                    inheritList.Add(baseClass);
                }
            }

            if (inheritList.Contains("Destiny.Definitions.Presentation.DestinyPresentationNodeBaseDefinition") && inheritList.Contains("Destiny.Definitions.DestinyDefinition"))
            {
                inheritList.Remove("Destiny.Definitions.DestinyDefinition");
            }

            if (inheritList.Contains("Destiny.Definitions.Presentation.DestinyPresentationNodeBaseDefinition") && inheritList.Contains("Destiny.Definitions.Presentation.DestinyScoredPresentationNodeBaseDefinition"))
            {
                inheritList.Remove("Destiny.Definitions.Presentation.DestinyPresentationNodeBaseDefinition");
            }

            if (inheritList.Contains("Queries.SearchResult") && inheritList.Contains("SearchResultOfGroupMembership"))
            {
                inheritList.Remove("Queries.SearchResult");
            }

            if (inheritList.Contains("User.UserMembership") && inheritList.Contains("User.CrossSaveUserMembership"))
            {
                inheritList.Remove("User.UserMembership");
            }

            if (inheritList.Contains("User.CrossSaveUserMembership") && inheritList.Contains("User.UserInfoCard"))
            {
                inheritList.Remove("User.CrossSaveUserMembership");
            }

            if (inheritList.Count > 1)
            {
                throw new NotImplementedException();
            }
            else if (inheritList.Count == 1)
            {
                if (inheritList[0] == "Destiny.Requests.Actions.DestinyActionRequest")
                {
                    if (className.Contains("ActionRequest") || className.Contains("TransferRequest"))
                    {
                        className += " : " + string.Join(", ", inheritList).Replace("Schema.", "");
                        foreach (var item in valuesListRemove)
                        {
                            valuesList.Remove(item!);
                        }
                    }
                }
                else
                {
                    className += " : " + string.Join(", ", inheritList).Replace("Schema.", "");
                    foreach (var item in valuesListRemove)
                    {
                        valuesList.Remove(item!);
                    }
                }
            }

            PropertyDictionary.Add(schemaName, valuesList);

            if (isEnum)
            {
                finalValueList = valuesList.Select(x => $"{x.Item3}        {x.Item1} = {x.Item2}").ToList();
                finalValueString = string.Join(",\n\n", finalValueList);
            }
            else
            {
                finalValueList = valuesList.Select(x => $"{x.Item3}        public {x.Item2.Replace("Schema.", "")} {x.Item1} {{ get; set; }}").ToList();
                finalValueString = string.Join("\n\n", finalValueList);
            }

            var almostFinalString = CreateDataTypeContent(isEnum, finalValueString, isFlags);

            if (isEnum)
            {
                almostFinalString = almostFinalString.Replace("{int!Type}", " : " + JsonToCsharpMapping.Type(schemaDetails)).Replace(" : int", "");
            }

            almostFinalString = almostFinalString.Replace("{name!Space}", GenerateNamespace.CreateSchemaNamespace(schemaName));
            almostFinalString = almostFinalString.Replace("{thingName}", className);

            if (schemaDetails.ContainsKey("description"))
            {
                almostFinalString = almostFinalString.Replace("{documentation}", FormatSummaries.FormatSummary(schemaDetails["description"], 4, true));
            }
            else
            {
                almostFinalString = almostFinalString.Replace("{documentation}", "");
            }

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