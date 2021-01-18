using System;
using System.Linq;

namespace BungieSharper.Generator.Parsing
{
    internal static class JsonToCsharpMapping
    {
        public static string Type(dynamic schema)
        {
            if (schema.ContainsKey("$ref") && schema.ContainsKey("type"))
            {
                throw new NotSupportedException();
            }

            if (schema.ContainsKey("properties") && schema["properties"].ContainsKey("Response"))
            {
                return Type(schema["properties"]["Response"]);
            }

            if (schema.ContainsKey("$ref"))
            {
                return GetReferenceFromRef(schema["$ref"]);
            }

            if (schema.ContainsKey("x-enum-reference"))
            {
                return Type(schema["x-enum-reference"]);
            }

            return schema["type"] switch
            {
                "string" => schema.ContainsKey("format") ? StringFormat(schema["format"]) : "string",
                "integer" => IntegerFormat(schema["format"]),
                "number" => NumberFormat(schema["format"]),
                "array" => GetPrimitivesFromCollections.ArrayParser(schema),
                "boolean" => "bool",
                "object" => GetPrimitivesFromCollections.ObjectParser(schema),
                _ => throw new NotSupportedException($"Type: {schema["type"]}")
            };
        }

        private static string StringFormat(string? bungieFormat)
        {
            return bungieFormat switch
            {
                "byte" => "byte",
                "date-time" => "DateTime",
                null => "string",
                _ => throw new NotSupportedException($"Format: {bungieFormat}")
            };
        }

        private static string IntegerFormat(string? bungieFormat)
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

        private static string NumberFormat(string? bungieFormat)
        {
            return bungieFormat switch
            {
                "float" => "float",
                "double" => "double",
                _ => throw new NotSupportedException($"Format: {bungieFormat}")
            };
        }

        public static string GetReferenceFromRef(string jsonRef)
        {
            if (jsonRef.StartsWith("#/components/responses/"))
            {
                var resolvedRef = Program.ResolveReferences(jsonRef);
                string secondResolve = Type(resolvedRef["content"]["application/json"]["schema"]);
                if (secondResolve.StartsWith("SearchResultOf"))
                {
                    return "IEnumerable<" + secondResolve.Replace("SearchResultOf", "") + ">";
                }

                return secondResolve;
            }

            if (jsonRef == "#/components/responses/boolean")
            {
                return "bool";
            }

            if (jsonRef == "#/components/responses/int32")
            {
                return "int";
            }

            if (jsonRef == "#/components/responses/int64")
            {
                return "long";
            }

            return "Schema." + jsonRef.Split('/').Last();
        }
    }
}