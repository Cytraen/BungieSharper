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
using BungieSharper.Generator.Parsing;

namespace BungieSharper.Generator.Generation.Schema
{
    internal static class GenerateEnum
    {
        public static string CreateEnum(string nameSpace, string enumName, string intType, List<dynamic> xEnumValues, bool isFlag)
        {
            var valuesDict = new Dictionary<string, Tuple<string, string?>>();

            foreach (var enumVal in xEnumValues)
            {
                valuesDict[enumVal["identifier"]] = new Tuple<string, string?>((string)enumVal["numericValue"], enumVal.ContainsKey("description") ? enumVal["description"] : null);
            }

            return CreateEnumContent(nameSpace, enumName, intType == "int32" ? "" : " : " + JsonToCsharpMapping.IntegerFormat(intType), valuesDict, isFlag);
        }

        private static string CreateEnumContent(string nameSpace, string enumName, string intType, Dictionary<string, Tuple<string, string?>> valuesDict, bool isFlag)
        {
            var valueStringList = new List<string>();

            foreach (var (name, (value, description)) in valuesDict)
            {
                valueStringList.Add(description != null
                    ? $"        /// <summary>{description.Replace("\n", "\n        /// ")}</summary>\n        {name} = {value}"
                    : $"        {name} = {value}"
                );
            }

            return $"namespace {nameSpace}\n{{\n    {(isFlag ? "[System.Flags]\n    " : "")}public enum {enumName}{intType}\n    {{\n{string.Join(",\n", valueStringList)}\n    }}\n}}";
        }
    }
}
