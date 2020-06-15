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
using System.Collections.Generic;
using System.Linq;
using BungieSharper.Generator.Parsing;

namespace BungieSharper.Generator.Generation
{
    internal static class GeneratePaths
    {
        public static string GeneratePathContent(string path, Dictionary<string, dynamic> pathDetails)
        {
            if (pathDetails.ContainsKey("get") && pathDetails.ContainsKey("post"))
                throw new NotSupportedException();

            string returnType;
            string pathContent;
            string getOrPost;
            List<string> parameterList = new List<string>();

            var methodBase = "        public async Task<{returnType}> {pathName}({parameters}) => await this._apiAccessor.ApiRequestAsync<{returnType}>(\"{path without first slash}\", null, null, HttpMethod.{GetOrPost});\"";

            if (pathDetails.ContainsKey("get"))
            {
                pathContent = GenerateGetPath(pathDetails, out returnType);
                getOrPost = "Get";

                foreach (var param in pathDetails["get"]["parameters"])
                {
                    parameterList.Add(JsonToCsharpMapping.Type(param["schema"]) + " " + param["name"]);
                }
            }

            else if (pathDetails.ContainsKey("post"))
            {

                pathContent = GeneratePostPath(pathDetails, out returnType);
                getOrPost = "Post";

                foreach (var param in pathDetails["post"]["parameters"])
                {
                    parameterList.Add(JsonToCsharpMapping.Type(param["schema"]) + " " + param["name"]);
                }
            }

            else throw new NotSupportedException();

            methodBase = methodBase.Replace("{returnType}", returnType).Replace("{path without first slash}", path.Remove(0, 1));
            methodBase = methodBase.Replace("{GetOrPost}", getOrPost);
            methodBase = methodBase.Replace("{parameters}", string.Join(", ", parameterList));
            methodBase = methodBase.Replace("{pathName}", ((string)pathDetails["summary"]).Split('.').Last());

            return methodBase;
        }

        private static string GenerateGetPath(Dictionary<string, dynamic> pathDetails, out string finalReturnType)
        {
            if (!pathDetails["get"].ContainsKey("responses"))
                throw new NotSupportedException();

            if (!pathDetails["get"]["responses"].ContainsKey("200"))
                throw new NotSupportedException();

            if (pathDetails["get"]["responses"].Count != 1)
                throw new NotSupportedException();

            var returnType = JsonToCsharpMapping.Type(pathDetails["get"]["responses"]["200"]);
            finalReturnType = returnType;

            return "";
        }

        private static string GeneratePostPath(Dictionary<string, dynamic> pathDetails, out string finalReturnType)
        {
            finalReturnType = "";
            return "";
        }
    }
}