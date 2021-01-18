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
                {
                    throw new NotSupportedException();
                }
                return JsonToCsharpMapping.GetReferenceFromRef(objectDetails["allOf"][0]["$ref"]);
            }

            if (objectDetails.ContainsKey("x-dictionary-key"))
            {
                return DictionaryCreator(objectDetails["x-dictionary-key"], objectDetails["additionalProperties"]);
            }

            return "dynamic";
        }

        public static string ArrayParser(dynamic arrayDetails)
        {
            dynamic items = arrayDetails["items"];

            if (items.ContainsKey("$ref"))
            {
                return $"IEnumerable<{JsonToCsharpMapping.GetReferenceFromRef(items["$ref"])}>";
            }

            if (items.ContainsKey("format") || items.ContainsKey("type"))
            {
                return $"IEnumerable<{JsonToCsharpMapping.Type(items)}>";
            }

            throw new NotSupportedException();
        }

        private static string DictionaryCreator(dynamic key, dynamic additionalProperties)
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
            {
                return JsonToCsharpMapping.Type(item);
            }

            if (item.ContainsKey("$ref"))
            {
                return JsonToCsharpMapping.GetReferenceFromRef(item["$ref"]);
            }

            throw new NotSupportedException();
        }
    }
}