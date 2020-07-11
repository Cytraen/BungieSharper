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
using BungieSharper.Generator.Parsing;

namespace BungieSharper.Generator.Generation
{
    internal static class GeneratePaths
    {
        public static string GeneratePathContent(string path, Dictionary<string, dynamic> pathDetails)
        {
            string httpMethodType;
            string previewEndpointText = "";
            string deprecatedEndpointText = "";

            if (pathDetails.ContainsKey("get") && pathDetails.ContainsKey("post"))
                throw new NotSupportedException();

            List<string> parameterList = new List<string>();

            var usings = "using System;\nusing System.Collections.Generic;\nusing System.Net.Http;\nusing System.Threading.Tasks;\n\n";

            if (pathDetails.ContainsKey("get"))
            {
                httpMethodType = "Get";
            }
            else if (pathDetails.ContainsKey("post"))
            {
                httpMethodType = "Post";
            }
            else throw new NotSupportedException();

            var httpMethodDetails = pathDetails[httpMethodType.ToLower()];

            foreach (var param in httpMethodDetails["parameters"])
            {
                parameterList.Add(JsonToCsharpMapping.Type(param?["schema"]) + " " + param?["name"]);
            }

            if (pathDetails[httpMethodType.ToLower()].ContainsKey("deprecated"))
            {
                deprecatedEndpointText = httpMethodDetails["deprecated"] ? "        [System.Obsolete(\"Bungie has deprecated this endpoint.\")]\n" : "";
            }

            var returnType = GeneratePathReturn(pathDetails);
            var pathName = ((string)pathDetails["summary"]).Replace('.', '_').TrimStart('_');
            var parameterString = string.Join(", ", parameterList);
            var endpointPath = path.Remove(0, 1);

            var documentation =
                !string.IsNullOrWhiteSpace((string)httpMethodDetails["description"]) ? FormatSummaries.FormatSummary((string)httpMethodDetails["description"], 8, true) :
                !string.IsNullOrWhiteSpace((string)pathDetails["description"]) ? FormatSummaries.FormatSummary((string)pathDetails["description"], 8, true) : "";

            if (httpMethodDetails.ContainsKey("x-preview"))
            {
                if (!string.IsNullOrWhiteSpace(documentation))
                {
                    documentation = documentation.Replace("        /// <summary>", "        /// <summary>\n        /// This is a preview method.");
                }
                else
                    previewEndpointText = pathDetails[httpMethodType.ToLower()]["x-preview"] ? "        /// <summary>This is a preview method.</summary>\n" : "";
            }

            var methodBase =
                usings +
                "namespace BungieSharper.Endpoints\n" +
                "{\n" +
                "    public partial class Endpoints\n" +
                "    {\n" +
                $"{documentation}" +
                $"{previewEndpointText}" +
                $"{deprecatedEndpointText}" +
                $"        public async Task<{returnType}> {pathName}({parameterString})\n" +
                "        {\n" +
                $"            return await this._apiAccessor.ApiRequestAsync<{returnType}>(\n" +
                $"                $\"{endpointPath}\", null, null, HttpMethod.{httpMethodType}\n" +
                "                );\n" +
                "        }\n" +
                "    }\n" +
                "}";

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