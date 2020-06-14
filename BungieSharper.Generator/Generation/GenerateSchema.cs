/*
   Copyright (C) 2020 ashakoor
   
   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU Affero General Public License as
   published by the Free Software Foundation, either version 3 of the
   License or any later version.
   
   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU Affero General Public License for more details.
   
   You should have received a copy of the GNU Affero General Public License
   along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using BungieSharper.Generator.Parsing;

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
                        usableSummary = usableSummary?.Replace("\r\n", "\n").Replace("\n", "\n        ///");
                        usableSummary = $"        /// <summary>{usableSummary}</summary>\n";
                    }

                    valuesList.Add(new Tuple<string, string, string?>(enumVal!["identifier"], enumVal["numericValue"], usableSummary));
                }
            }

            else if (schemaDetails["type"] == "object")
            {
                if (!schemaDetails.ContainsKey("properties"))
                    return "";

                foreach (KeyValuePair<string, dynamic> propertyPair in schemaDetails["properties"])
                {
                    string? usableSummary = propertyPair.Value.ContainsKey("description") ? propertyPair.Value["description"] : null;

                    if (usableSummary != null)
                    {
                        usableSummary = usableSummary?.Replace("\r\n", "\n").Replace("\n", "\n        ///");
                        usableSummary = $"        /// <summary>{usableSummary}</summary>\n";
                    }

                    string classType;

                    if (propertyPair.Value.ContainsKey("x-enum-reference"))
                    {
                        classType = JsonToCsharpMapping.GetReferenceFromRef(propertyPair.Value["x-enum-reference"]["$ref"]);
                    }
                    else
                    {
                        classType = JsonToCsharpMapping.Type(propertyPair.Value);
                    }

                    if (propertyPair.Key == "failureIndexes")
                    {

                    }

                    valuesList.Add(new Tuple<string, string, string?>(propertyPair.Key, classType, usableSummary));
                }
            }

            else
            {
                throw new NotSupportedException();
            }

            List<string> finalValueList;
            string finalValueString;

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
            

            var almostFinalString = CreateDataTypeContent(isEnum, finalValueString);

            if (isEnum)
            {
                almostFinalString = almostFinalString.Replace("{int!Type}", " : " + JsonToCsharpMapping.Type(schemaDetails)).Replace(" : int", "");
            }

            almostFinalString = almostFinalString.Replace("{name!Space}", GenerateNamespace.CreateSchemaNamespace(schemaName));
            almostFinalString = almostFinalString.Replace("{thingName}", schemaName.Split('.').Last());

            return almostFinalString;
        }



        private static string CreateDataTypeContent(bool isEnum, string propertiesWithSummaries)
        {
            var content = "";

            content += "namespace {name!Space}\n";
            content += "{\n";
            content += "    public " + (isEnum ? "enum {thingName}{int!Type}" : "class {thingName}") + "\n";
            content += "    {\n";

            content += propertiesWithSummaries + '\n';

            content += "    }\n";
            content += "}\n";

            return content;
        }
    }
}
