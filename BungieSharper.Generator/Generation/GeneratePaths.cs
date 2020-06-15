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

            string getOrPost;
            List<string> parameterList = new List<string>();

            var usings = "using System;\nusing System.Collections.Generic;\nusing System.Net.Http;\nusing System.Threading.Tasks;\n\n";

            var methodBase = usings +
                "namespace BungieSharper.Endpoints\n" +
                "{\n" +
                "    public partial class Endpoints\n" +
                "    {\n" +
                "        public async Task<{returnType}> {pathName}({parameters})\n" +
                "        {\n" +
                "            return await this._apiAccessor.ApiRequestAsync<{returnType}>(\n" +
                "                $\"{path without first slash}\", null, null, HttpMethod.{GetOrPost}\n" +
                "                );\n" +
                "        }\n" +
                "    }\n" +
                "}";

            var returnType = GeneratePathReturn(pathDetails);

            if (pathDetails.ContainsKey("get"))
            {
                getOrPost = "Get";
            }

            else if (pathDetails.ContainsKey("post"))
            {
                getOrPost = "Post";
            }

            else throw new NotSupportedException();

            foreach (var param in pathDetails[getOrPost.ToLower()]["parameters"])
            {
                parameterList.Add(JsonToCsharpMapping.Type(param["schema"]) + " " + param["name"]);
            }

            methodBase = methodBase.Replace("{returnType}", returnType).Replace("{path without first slash}", path.Remove(0, 1));
            methodBase = methodBase.Replace("{GetOrPost}", getOrPost);
            methodBase = methodBase.Replace("{parameters}", string.Join(", ", parameterList));
            methodBase = methodBase.Replace("{pathName}", ((string)pathDetails["summary"]).Replace('.', '_').TrimStart('_'));

            return methodBase;
        }

        private static string GeneratePathReturn(Dictionary<string, dynamic> pathDetails)
        {
            string postOrGet;

            if (pathDetails.ContainsKey("get") && pathDetails.ContainsKey("post"))
                throw new NotSupportedException();

            if (pathDetails.ContainsKey("get"))
                postOrGet = "get";

            else if (pathDetails.ContainsKey("post"))
                postOrGet = "post";

            else throw new NotSupportedException();

            if (!pathDetails[postOrGet].ContainsKey("responses"))
                throw new NotSupportedException();

            if (!pathDetails[postOrGet]["responses"].ContainsKey("200"))
                throw new NotSupportedException();

            if (pathDetails[postOrGet]["responses"].Count != 1)
                throw new NotSupportedException();

            return JsonToCsharpMapping.Type(pathDetails[postOrGet]["responses"]["200"]);
            
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