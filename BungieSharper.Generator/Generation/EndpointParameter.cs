using System;

namespace BungieSharper.Generator.Generation
{
    internal class EndpointParameter
    {
        internal string Name;
        internal string Type;
        internal string? Description;
        internal ParameterLocation ParamLoc;
        internal bool Required = true;

        internal EndpointParameter()
        {
            Name = "";
            Type = "";
            Description = null;
            ParamLoc = ParameterLocation.None;
        }

        internal EndpointParameter(string name, string type, ParameterLocation parameterLocation)
        {
            Name = name;
            Type = type;
            ParamLoc = parameterLocation;
        }

        internal EndpointParameter(string name, string type, ParameterLocation parameterLocation, bool required)
        {
            Name = name;
            Type = type;
            ParamLoc = parameterLocation;
            Required = required;
        }

        internal EndpointParameter(string name, string type, string description, ParameterLocation parameterLocation)
        {
            Name = name;
            Type = type;
            Description = description;
            ParamLoc = parameterLocation;
        }

        internal EndpointParameter(string name, string type, string description, ParameterLocation parameterLocation, bool required)
        {
            Name = name;
            Type = type;
            Description = description;
            ParamLoc = parameterLocation;
            Required = required;
        }

        internal static ParameterLocation StringToLocation(string location)
        {
            return location switch
            {
                "path" => ParameterLocation.Path,
                "query" => ParameterLocation.Query,
                _ => throw new NotSupportedException(),
            };
        }
    }

    internal enum ParameterLocation : byte
    {
        None = 0,
        Path = 1,
        Query = 2,
        RequestBody = 3
    }
}