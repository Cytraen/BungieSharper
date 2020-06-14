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

namespace BungieSharper.Generator.Generation.Schema
{
    internal static class GenerateSchema
    {
        public static string GetFileContent(string schemaName, Dictionary<string, dynamic> schemaDetails)
        {
            var nameSpace = GenerateNamespace.CreateSchemaNamespace(schemaName);

            if (schemaDetails["type"] == "array")
                return "";
            if (schemaDetails["type"] == "integer")
                return GenerateEnum.CreateEnum(nameSpace, schemaName.Split('.').Last(), schemaDetails["format"], schemaDetails["x-enum-values"], schemaDetails["x-enum-is-bitmask"]);
            if (schemaDetails["type"] == "object")
                return GenerateClass.CreateClass(schemaDetails);

            throw new NotSupportedException();
        }
    }
}
