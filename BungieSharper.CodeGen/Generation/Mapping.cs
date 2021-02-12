using BungieSharper.CodeGen.Entities.Common;
using System;

namespace BungieSharper.CodeGen.Generation
{
    internal class Mapping
    {
        internal static string TypeToCSharp(TypeEnum type)
        {
            return type switch
            {
                TypeEnum.Array => "IEnumerable<",
                TypeEnum.Boolean => "bool",
                TypeEnum.Integer => "int",
                TypeEnum.Number => "float",
                TypeEnum.Object => "dynamic",
                TypeEnum.String => "string",
                _ => throw new NotSupportedException(),
            };
        }

        internal static string FormatToCSharp(FormatEnum format)
        {
            return format switch
            {
                FormatEnum.Byte => "byte",
                FormatEnum.DateTime => "System.DateTime",
                FormatEnum.Double => "double",
                FormatEnum.Float => "float",
                FormatEnum.Int32 => "int",
                FormatEnum.Int64 => "long",
                FormatEnum.Uint32 => "uint",
                _ => throw new NotSupportedException(),
            };
        }
    }
}