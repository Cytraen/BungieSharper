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
    internal static class GenerateClass
    {
        public static string CreateClass(Dictionary<string, dynamic> details)
        {
            var propertyDetails = new List<Tuple<string, string, string>>();

            foreach (KeyValuePair<string, dynamic> property in details["properties"])
            {
                propertyDetails.Add(new Tuple<string, string, string>(property.Key, JsonToCsharpMapping.Type(property.Value), property.Value["description"]));
            }

            return "";
        }
    }
}
