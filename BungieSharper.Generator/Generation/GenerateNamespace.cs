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

using System.Linq;

namespace BungieSharper.Generator.Generation
{
    internal static class GenerateNamespace
    {
        private const string BaseSchemaNamespace = "BungieSharper.Schema.";
        private const string BaseEndpointNamespace = "BungieSharper.Endpoint.";

        public static string CreateSchemaNamespace(string pathSummaryOrSchemaKey)
        {
            var path = (BaseSchemaNamespace + pathSummaryOrSchemaKey).Split('.').SkipLast(1);
            return string.Join('.', path);
        }

        public static string CreateEndpointNamespace(string pathSummaryOrSchemaKey)
        {
            var path = (BaseEndpointNamespace + pathSummaryOrSchemaKey).Split('.').SkipLast(1);
            return string.Join('.', path);
        }
    }
}