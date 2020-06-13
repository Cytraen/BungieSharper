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

using System.Collections.Generic;
using BungieSharper.Generator.Parsing;

namespace BungieSharper.Generator.Generation.Schema
{
    internal static class GenerateEnum
    {
        public static string CreateEnum(string nameSpace, string enumName, string intType, List<dynamic> xEnumValues)
        {
            var valuesDict = new Dictionary<string, string>();

            foreach (var enumVal in xEnumValues)
            {
                valuesDict[enumVal["identifier"]] = (string)enumVal["numericValue"];
            }

            return CreateEnumContent(nameSpace, enumName, intType == "int32" ? "" : $" : {JsonToCsharpMapping.IntegerFormat(intType)}", valuesDict);
        }

        private static string CreateEnumContent(string nameSpace, string enumName, string intType, Dictionary<string, string> valuesDict)
        {
            var valueStringList = new List<string>();

            foreach (var (key, value) in valuesDict)
            {
                valueStringList.Add($"        {key} = {value}");
            }

            return $"namespace {nameSpace}\n{{\n    public enum {enumName}{intType}\n    {{\n{string.Join(",\n", valueStringList)}\n    }}\n}}";
        }
    }
}
