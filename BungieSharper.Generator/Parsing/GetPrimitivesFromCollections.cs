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
    internal static class GetPrimitivesFromCollections
    {
        public static string ObjectParser(dynamic objectDetails)
        {
            ushort numOfDetails = 0;
            if (objectDetails.ContainsKey("allOf"))
            {
                numOfDetails += 1;
                if (objectDetails["allOf"].Count != 1)
                    throw new NotSupportedException();
                return JsonToCsharpMapping.GetReferenceFromRef(objectDetails["allOf"][0]["$ref"]);
                // return ((IEnumerable<string>)objectDetails["allOf"][0]["$ref"].Split('/')).Last();
            }

            if (objectDetails.ContainsKey("x-dictionary-key"))
                return DictionaryCreator(objectDetails["x-dictionary-key"], objectDetails["additionalProperties"]);
                // return $"Dictionary<{JsonToCsharpMapping.Type(objectDetails["x-dictionary-key"])}, {JsonToCsharpMapping.GetReferenceFromRef(objectDetails["additionalProperties"]["$ref"])}>";
            throw new NotSupportedException();
        }

        public static string OldArrayParser(dynamic arrayDetails)
        {
            ushort numOfDetails = 0;
            if (arrayDetails.ContainsKey("items"))
            {
                numOfDetails += 1;
                if (arrayDetails["items"].Count != 1)
                    if (arrayDetails["items"].ContainsKey("x-enum-reference"))
                        return JsonToCsharpMapping.GetReferenceFromRef(arrayDetails["items"]["x-enum-reference"]["$ref"]);
                    else
                        throw new NotSupportedException();
                return JsonToCsharpMapping.GetReferenceFromRef(arrayDetails["items"]["$ref"]);
                // return ((IEnumerable<string>)arrayDetails["items"]["$ref"].Split('/')).Last();
            }
            throw new NotSupportedException();

            // JsonToCsharpMapping.Type(schema["items"]) + "[]"
        }

        public static string ArrayParser(dynamic arrayDetails)
        {
            dynamic items = arrayDetails["items"];

            if (items.ContainsKey("$ref"))
                return JsonToCsharpMapping.GetReferenceFromRef(items["$ref"]) + "[]";

            if (items.ContainsKey("format") || items.ContainsKey("type"))
                return JsonToCsharpMapping.Type(items);

            throw new NotSupportedException();
        }

        public static string DictionaryCreator(dynamic key, dynamic additionalProperties)
        {
            return $"Dictionary<{ParseDictionaryItem(key)}, {ParseDictionaryItem(additionalProperties)}>";
        }

        private static string ParseDictionaryItem(dynamic item)
        {
            if (item.ContainsKey("x-enum-reference"))
            {
                return JsonToCsharpMapping.GetReferenceFromRef(item["x-enum-reference"]["$ref"]);
            }

            if (item.ContainsKey("format"))
            {
                return JsonToCsharpMapping.Type(item);
            }

            if (item.ContainsKey("additionalProperties"))
            {
                return DictionaryCreator(item["x-dictionary-key"], item["additionalProperties"]);
            }

            if (item.ContainsKey("type"))
                return item["type"];

            if (item.ContainsKey("$ref"))
                return JsonToCsharpMapping.GetReferenceFromRef(item["$ref"]);

            throw new NotSupportedException();
        }
    }
}
