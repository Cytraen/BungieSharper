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

namespace BungieSharper.Generator.Parsing
{
    internal static class JsonToCsharpMapping
    {
        public static string Type(dynamic schema)
        {
            return schema["type"] switch
            {
                "string" => schema.ContainsKey("format") ? StringFormat(schema["format"]) : "string",
                "integer" => IntegerFormat(schema["format"]),
                "number" => NumberFormat(schema["format"]),
                "array" => Type(schema["items"]) + "[]",
                "boolean" => "bool",
                "object" => ObjectParser(schema),
                _ => throw new NotSupportedException($"Type: {schema["type"]}")
            };
        }
        
        public static string StringFormat(string? bungieFormat)
        {
            return bungieFormat switch
            {
                "date-time" => "DateTime",
                null => "string",
                _ => throw new NotSupportedException($"Format: {bungieFormat}")
            };
        }
        
        public static string IntegerFormat(string? bungieFormat)
        {
            return bungieFormat switch
            {
                "byte" => "byte",
                "int16" => "short",
                "int32" => "int",
                "int64" => "long",
                "sbyte" => "sbyte",
                "uint16" => "ushort",
                "uint32" => "uint",
                "uint64" => "ulong",
                _ => throw new NotSupportedException($"Format: {bungieFormat}")
            };
        }
        
        public static string NumberFormat(string? bungieFormat)
        {
            return bungieFormat switch
            {
                "float" => "float",
                "double" => "double",
                _ => throw new NotSupportedException($"Format: {bungieFormat}")
            };
        }

        public static string ObjectParser(dynamic objectDetails)
        {
            ushort numOfDetails = 0;
            if (objectDetails.ContainsKey("allOf"))
            {
                numOfDetails += 1;
                if (objectDetails["allOf"].Count != 1)
                    throw new NotSupportedException();
                return ((IEnumerable<string>)objectDetails["allOf"][0]["$ref"].Split('/')).Last();
            }
            throw new NotSupportedException();
        }
    }
}
