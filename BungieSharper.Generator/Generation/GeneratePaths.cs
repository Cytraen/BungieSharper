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

using BungieSharper.Generator.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BungieSharper.Generator.Generation
{
    internal class PathParameter
    {
        internal string Name;
        internal string Type;
        internal string? Description = null;
        internal ParameterLocation ParamLoc;
        internal bool Required = true;

        internal PathParameter(string name, string type, ParameterLocation parameterLocation)
        {
            Name = name;
            Type = type;
            ParamLoc = parameterLocation;
        }

        internal PathParameter(string name, string type, ParameterLocation parameterLocation, bool required)
        {
            Name = name;
            Type = type;
            ParamLoc = parameterLocation;
            Required = required;
        }

        internal PathParameter(string name, string type, string description, ParameterLocation parameterLocation)
        {
            Name = name;
            Type = type;
            Description = description;
            ParamLoc = parameterLocation;
        }

        internal PathParameter(string name, string type, string description, ParameterLocation parameterLocation, bool required)
        {
            Name = name;
            Type = type;
            Description = description;
            ParamLoc = parameterLocation;
            Required = required;
        }

        internal static ParameterLocation StringToLocation(string location)
        {
            switch (location)
            {
                case "path":
                    return ParameterLocation.Path;

                case "query":
                    return ParameterLocation.Query;

                default:
                    throw new NotSupportedException();
            }
        }
    }

    internal enum ParameterLocation : byte
    {
        Path = 0,
        Query = 1
    }

    internal static class GeneratePaths
    {
        public static string GeneratePathContent(string path, Dictionary<string, dynamic> pathDetails)
        {
            string httpMethodType;
            string previewEndpointText = "";
            string deprecatedEndpointText = "";

            if (pathDetails.ContainsKey("get") && pathDetails.ContainsKey("post"))
                throw new NotSupportedException();

            var parameterStringList = new List<string>();
            var paramList = new List<PathParameter>();

            var usingStatements = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Net.Http;\nusing System.Threading.Tasks;\n\n";

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

            var optionalParameterStringList = new List<string>();
            var requiredParameterStringList = new List<string>();

            foreach (var param in httpMethodDetails["parameters"])
            {
                if (param is null)
                    throw new NotSupportedException();

                var paramObject = new PathParameter(
                    param["name"],
                    JsonToCsharpMapping.Type(param["schema"]),
                    param.ContainsKey("description") ? param["description"] : null,
                    PathParameter.StringToLocation(param["in"]),
                    param.ContainsKey("required") ? param["required"] : false
                    );

                paramList.Add(paramObject);

                var shouldMakeNullable = (!paramObject.Required && paramObject.Type != "string" && !paramObject.Type.StartsWith("IEnumerable<"));

                parameterStringList.Add(paramObject.Type + (shouldMakeNullable ? "?" : "") + " " + paramObject.Name + (paramObject.Required ? "" : " = null"));

                optionalParameterStringList = parameterStringList.Where(x => x.Contains(" = null")).ToList();
                requiredParameterStringList = parameterStringList.Where(x => !x.Contains(" = null")).ToList();
            }

            var queryStringParams = paramList.Where(x => x.ParamLoc == ParameterLocation.Query).ToList();

            if (pathDetails[httpMethodType.ToLower()].ContainsKey("deprecated"))
            {
                deprecatedEndpointText = httpMethodDetails["deprecated"] ? "        [System.Obsolete(\"Bungie has deprecated this endpoint.\")]\n" : "";
            }

            var returnType = GeneratePathReturn(pathDetails);
            var pathName = ((string)pathDetails["summary"]).TrimStart('.').Replace('.', '_');

            var optionalParameterString = string.Join(", ", optionalParameterStringList);
            var requiredParameterString = string.Join(", ", requiredParameterStringList);

            var parameterString = string.Join(", ", requiredParameterString, optionalParameterString);

            parameterString = parameterString.TrimEnd(' ', ',').TrimStart(' ', ',');

            var stockEndpointPath = path.Remove(0, 1);
            var splitStockPath = stockEndpointPath.Split('/');

            var rebuiltPathParts = new List<string>();

            foreach (var pathSection in splitStockPath)
            {
                var usableSection = pathSection;

                if (pathSection.StartsWith('{') && pathSection.EndsWith('}'))
                {
                    var pathParamName = pathSection.TrimStart('{').TrimEnd('}');
                    var foundParams = paramList.Where(x => x.Name == pathParamName).ToList();

                    if (foundParams is null || foundParams.Count != 1) throw new NotSupportedException();

                    if (foundParams[0].Type == "string")
                    {
                        usableSection = $"{{Uri.EscapeDataString({foundParams[0].Name})}}";
                    }
                }

                rebuiltPathParts.Add(usableSection);
            }

            var rebuiltPath = string.Join('/', rebuiltPathParts);
            var endpointPath = rebuiltPath;

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

            var queryStringParamsNotEmpty = queryStringParams.Count > 0;
            var queryParamTextList = new List<string>();

            foreach (var queryParam in queryStringParams)
            {
                var escapedParamEntry = queryParam.Name;
                if (queryParam.Type == "string")
                {
                    escapedParamEntry = $"Uri.EscapeDataString({queryParam.Name})";
                }
                if (queryParam.Type.StartsWith("IEnumerable<"))
                {
                    escapedParamEntry = $"string.Join(\",\", {queryParam.Name}.Select(x => x.ToString()))";
                }

                var textParam = $"{queryParam.Name} != null ? $\"{queryParam.Name}={{{escapedParamEntry}}}\" : null";
                queryParamTextList.Add(textParam);
            }

            var queryStringParamText = queryStringParamsNotEmpty ? string.Join(", ", queryParamTextList) : "";

            var methodBase =
                usingStatements +
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
                $"                $\"{endpointPath}\", null, null, HttpMethod.{(queryStringParamsNotEmpty ? httpMethodType + ',' : httpMethodType)}\n" +
                $"                {queryStringParamText});\n" +
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
    }
}