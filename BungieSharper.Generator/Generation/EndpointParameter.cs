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