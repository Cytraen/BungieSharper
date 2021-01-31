using BungieSharper.Generator.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BungieSharper.Generator.Generation
{
    internal static class GenerateSchema
    {
        public static Dictionary<string, List<Tuple<string, string, string?>>> PropertyDictionary = new();

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

            PropertyDictionary.Add(schemaName, valuesList);

            List<string> finalValueList;
            string finalValueString;
            var isFlags = schemaDetails.ContainsKey("x-enum-is-bitmask") && schemaDetails["x-enum-is-bitmask"];

            // Key: base class, inner key: property name, inner value: type of property
            var baseClassDictionary = new Dictionary<string, Dictionary<string, string>>();

            baseClassDictionary.Add("Schema.Destiny.Definitions.DestinyDefinition", new()
            {
                { "hash", "uint" },
                { "index", "int" },
                { "redacted", "bool" }
            });

            baseClassDictionary.Add("Schema.Components.ComponentResponse", new()
            {
                { "privacy", "Schema.Components.ComponentPrivacySetting" },
                { "disabled", "bool?" }
            });

            baseClassDictionary.Add("Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeBaseDefinition", new()
            {
                { "presentationNodeType", "Schema.Destiny.DestinyPresentationNodeType" },
                { "traitIds", "IEnumerable<string>" },
                { "traitHashes", "IEnumerable<uint>" },
                { "parentNodeHashes", "IEnumerable<uint>" }
            });

            baseClassDictionary.Add("Schema.Destiny.Definitions.Presentation.DestinyScoredPresentationNodeBaseDefinition", new()
            {
                { "maxCategoryRecordScore", "int" },
                { "presentationNodeType", "Schema.Destiny.DestinyPresentationNodeType" },
                { "traitIds", "IEnumerable<string>" },
                { "traitHashes", "IEnumerable<uint>" },
                { "parentNodeHashes", "IEnumerable<uint>" }
            });

            baseClassDictionary.Add("Schema.Queries.SearchResult", new()
            {
                { "totalResults", "int" },
                { "hasMore", "bool" },
                { "query", "Schema.Queries.PagedQuery" },
                { "replacementContinuationToken", "string" },
                { "useTotalResults", "bool" }
            });

            baseClassDictionary.Add("Schema.Destiny.Requests.Actions.DestinyActionRequest", new()
            {
                { "membershipType", "Schema.BungieMembershipType" }
            });

            var inheritList = new List<string>();
            var valuesListRemove = new List<Tuple<string, string, string?>>();

            foreach (var (baseClass, classProperties) in baseClassDictionary)
            {
                if (baseClass.Split('.').Last() == className)
                {
                    break;
                }

                var filtered = valuesList.Where(x => classProperties.ContainsKey(x.Item1) && classProperties[x.Item1] == x.Item2).ToList();

                if (filtered.Count == classProperties.Count)
                {
                    foreach (var item in filtered)
                    {
                        valuesListRemove.Add(item!);
                    }

                    inheritList.Add(baseClass);
                }
            }

            if (inheritList.Contains("Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeBaseDefinition") && inheritList.Contains("Schema.Destiny.Definitions.DestinyDefinition"))
            {
                inheritList.Remove("Schema.Destiny.Definitions.DestinyDefinition");
            }

            if (inheritList.Contains("Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeBaseDefinition") && inheritList.Contains("Schema.Destiny.Definitions.Presentation.DestinyScoredPresentationNodeBaseDefinition"))
            {
                inheritList.Remove("Schema.Destiny.Definitions.Presentation.DestinyPresentationNodeBaseDefinition");
            }

            if (inheritList.Count > 1)
            {
                throw new NotImplementedException();
            }
            else if (inheritList.Count == 1)
            {
                if (inheritList[0] == "Schema.Destiny.Requests.Actions.DestinyActionRequest")
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