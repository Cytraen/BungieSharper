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

   BungieSharper accesses an API under the BSD 3-Clause License.
   See BUNGIE-SDK-LICENSE for more information.
   The Bungie API/SDK is copyright (c) 2017, Bungie, Inc.
*/

using System;

namespace BungieSharper.Generator.Parsing
{
    internal static class GetPrimitivesFromCollections
    {
        public static string ObjectParser(dynamic objectDetails)
        {
            if (objectDetails.ContainsKey("allOf"))
            {
                if (objectDetails["allOf"].Count != 1)
                    throw new NotSupportedException();
                return JsonToCsharpMapping.GetReferenceFromRef(objectDetails["allOf"][0]["$ref"]);
            }

            if (objectDetails.ContainsKey("x-dictionary-key"))
                return DictionaryCreator(objectDetails["x-dictionary-key"], objectDetails["additionalProperties"]);

            return "dynamic";
            throw new NotSupportedException();
        }

        public static string ArrayParser(dynamic arrayDetails)
        {
            dynamic items = arrayDetails["items"];

            if (items.ContainsKey("$ref"))
                return $"IEnumerable<{JsonToCsharpMapping.GetReferenceFromRef(items["$ref"])}>";

            if (items.ContainsKey("format") || items.ContainsKey("type"))
                return $"IEnumerable<{JsonToCsharpMapping.Type(items)}>";

            throw new NotSupportedException();
        }

        public static string DictionaryCreator(dynamic key, dynamic additionalProperties)
        {
            return $"Dictionary<{ParseDictionaryItem(key)}, {ParseDictionaryItem(additionalProperties)}>";
        }

        private static string ParseDictionaryItem(dynamic item)
        {
            if (item.ContainsKey("x-enum-reference"))
                return JsonToCsharpMapping.GetReferenceFromRef(item["x-enum-reference"]["$ref"]);

            if (item.ContainsKey("format"))
                return JsonToCsharpMapping.Type(item);

            if (item.ContainsKey("additionalProperties"))
                return DictionaryCreator(item["x-dictionary-key"], item["additionalProperties"]);

            if (item.ContainsKey("type"))
                return JsonToCsharpMapping.Type(item);

            if (item.ContainsKey("$ref"))
                return JsonToCsharpMapping.GetReferenceFromRef(item["$ref"]);

            throw new NotSupportedException();
        }
    }
}