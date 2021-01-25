using BungieSharper.Generator.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;

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
            {
                throw new NotSupportedException();
            }

            var parameterStringList = new List<string>();
            var paramList = new List<EndpointParameter>();

            var usingStatements =
                "using BungieSharper.Client;" +
                "\nusing System;" +
                "\nusing System.Collections.Generic;" +
                "\nusing System.Linq;" +
                "\nusing System.Net.Http;" +
                "\nusing System.Text.Json;" +
                "\nusing System.Threading;" +
                "\nusing System.Threading.Tasks;" +
                "\n\n";

            if (pathDetails.ContainsKey("get"))
            {
                httpMethodType = "Get";
                if (pathDetails["get"].ContainsKey("requestBody"))
                {
                    throw new NotSupportedException();
                }
            }
            else if (pathDetails.ContainsKey("post"))
            {
                httpMethodType = "Post";
            }
            else
            {
                throw new NotSupportedException();
            }

            var lowMethodType = httpMethodType.ToLowerInvariant();

            var httpMethodDetails = pathDetails[lowMethodType];

            var optionalParameterStringList = new List<string>();
            var requiredParameterStringList = new List<string>();

            EndpointParameter? requestBodyParam = null;

            if (httpMethodDetails.ContainsKey("requestBody"))
            {
                requestBodyParam = new EndpointParameter
                {
                    Name = "requestBody",
                    Type = JsonToCsharpMapping.Type(httpMethodDetails["requestBody"]["content"]["application/json"]["schema"]),
                    Description = null,
                    ParamLoc = ParameterLocation.RequestBody,
                    Required = httpMethodDetails["requestBody"].ContainsKey("required") ? httpMethodDetails["requestBody"]["required"] : false
                };
            }

            foreach (var param in httpMethodDetails["parameters"])
            {
                if (param is null)
                {
                    throw new NotSupportedException();
                }

                var paramObject = new EndpointParameter(
                    param["name"],
                    JsonToCsharpMapping.Type(param["schema"]),
                    param.ContainsKey("description") ? param["description"] : null,
                    EndpointParameter.StringToLocation(param["in"]),
                    param.ContainsKey("required") ? param["required"] : false
                    );

                paramList.Add(paramObject);
            }

            if (requestBodyParam != null)
            {
                paramList.Add(requestBodyParam);
            }

            foreach (var paramObject in paramList)
            {
                var shouldMakeNullable = (!paramObject.Required && paramObject.Type != "string" && !paramObject.Type.StartsWith("IEnumerable<"));

                parameterStringList.Add(paramObject.Type + (shouldMakeNullable ? "?" : "") + " " + paramObject.Name + (paramObject.Required ? "" : " = null"));

                optionalParameterStringList = parameterStringList.Where(x => x.Contains(" = null")).ToList();
                requiredParameterStringList = parameterStringList.Where(x => !x.Contains(" = null")).ToList();
            }
            optionalParameterStringList.Add("string authToken = null");
            optionalParameterStringList.Add("CancellationToken cancelToken = default");

            var queryStringParams = paramList.Where(x => x.ParamLoc == ParameterLocation.Query).ToList();

            if (httpMethodDetails.ContainsKey("deprecated"))
            {
                deprecatedEndpointText = httpMethodDetails["deprecated"] ? "        [System.Obsolete(\"Bungie have deprecated this endpoint.\")]\n" : "";
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

                    if (foundParams is null || foundParams.Count != 1) { throw new NotSupportedException(); }

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
                {
                    previewEndpointText = httpMethodDetails["x-preview"] ? "        /// <summary>This is a preview method.</summary>\n" : "";
                }
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

            var queryStringParamFinal = queryStringParamsNotEmpty ? $" + HttpRequestGenerator.MakeQuerystring({queryStringParamText})" : "";

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
                $"            return await _apiAccessor.ApiRequestAsync<{returnType}>(\n" +
                $"                new Uri($\"{endpointPath}\"{queryStringParamFinal}, UriKind.Relative),\n" +
                $"                {(requestBodyParam != null ? "new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, \"application/json\")" : "null")}," +
                $"                HttpMethod.{httpMethodType}, authToken, AuthHeaderType.Bearer, cancelToken\n" +
                "                ).ConfigureAwait(false);\n" +
                "        }\n" +
                "    }\n" +
                "}";

            return methodBase;
        }

        private static string GeneratePathReturn(Dictionary<string, dynamic> pathDetails)
        {
            string postOrGet;

            if (pathDetails.ContainsKey("get") && pathDetails.ContainsKey("post")) { throw new NotSupportedException(); }

            if (pathDetails.ContainsKey("get"))
            {
                postOrGet = "get";
            }
            else if (pathDetails.ContainsKey("post"))
            {
                postOrGet = "post";
            }
            else
            {
                throw new NotSupportedException();
            }

            if (!pathDetails[postOrGet].ContainsKey("responses"))
            {
                throw new NotSupportedException();
            }

            if (!pathDetails[postOrGet]["responses"].ContainsKey("200"))
            {
                throw new NotSupportedException();
            }

            if (pathDetails[postOrGet]["responses"].Count != 1)
            {
                throw new NotSupportedException();
            }

            return JsonToCsharpMapping.Type(pathDetails[postOrGet]["responses"]["200"]);
        }
    }
}