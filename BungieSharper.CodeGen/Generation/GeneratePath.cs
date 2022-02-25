using BungieSharper.CodeGen.Entities.Components.Response;
using BungieSharper.CodeGen.Entities.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BungieSharper.CodeGen.Generation
{
    internal static class GeneratePath
    {
        public static string GeneratePathContent(string path, PathObject pathDef)
        {
            var httpMethod = "";
            var content = "";

            if (pathDef.Get is not null && pathDef.Post is not null)
            {
                throw new NotSupportedException();
            }

            var parameters = new List<PathResponseMethodParameterClass>();
            var responseType = "";
            var pathName = pathDef.Summary.Replace('.', '_').TrimStart('_');
            ResponseMethodClass? responseMethodInfo = null;

            if (pathDef.Get is not null)
            {
                httpMethod = "Get";
                responseMethodInfo = pathDef.Get;
            }

            if (pathDef.Post is not null)
            {
                httpMethod = "Post";
                responseMethodInfo = pathDef.Post;
            }

            if (responseMethodInfo is null)
            {
                throw new NotSupportedException();
            }

            // parameters = responseMethodInfo.Parameters.Where(x => x.Deprecated != true).ToList();
            parameters = responseMethodInfo.Parameters.ToList();

            var requiredScopes = responseMethodInfo.Security != null ? responseMethodInfo.Security.Any() ? responseMethodInfo.Security[0].OAuth2 : null : null;

            content += FormatStrings.FormatMethodSummaries(pathDef.Description, parameters, responseMethodInfo.XPreview ?? false, responseMethodInfo.Deprecated, requiredScopes);
            content += "        /// <param name=\"authToken\">The OAuth access token to authenticate the request with.</param>\n";
            content += "        /// <param name=\"cancelToken\">The <see cref=\"CancellationToken\" /> to observe.</param>\n";

            var responseRef = responseMethodInfo.Responses[200].Ref;

            responseType = responseRef.Contains("/components/responses/") ? GetResponseRef(responseRef) : FormatStrings.ResolveRef(responseRef, true);

            var requiredParams = parameters.Where(x => x.Required == true);
            var optionalParams = parameters.Where(x => x.Required != true);

            var declareParams = new List<string>();
            var queryParamTextList = new List<string>();

            foreach (var param in requiredParams)
            {
                var paramTypeText = ParseParameterSchema(param.Schema, param.Required);
                declareParams.Add(paramTypeText + " " + param.Name);

                switch (param.In)
                {
                    case ParameterInEnum.Query:
                        {
                            var name = param.Name;
                            var escapedParamEntry = "";
                            if (paramTypeText.StartsWith("string"))
                            {
                                escapedParamEntry = $"Uri.EscapeDataString({name})";
                            }
                            if (paramTypeText.StartsWith("IEnumerable<"))
                            {
                                escapedParamEntry = $"string.Join(\",\", {name}.Select(x => x.ToString()))";
                            }

                            if (param.Required != true)
                            {
                                var textParam = $"{name} != null ? $\"{name}={{{escapedParamEntry}}}\" : null";
                                queryParamTextList.Add(textParam);
                            }
                            else
                            {
                                var textParam = $"$\"{name}={{{escapedParamEntry}}}\"";
                                queryParamTextList.Add(textParam);
                            }

                            break;
                        }
                    case ParameterInEnum.Path when paramTypeText.StartsWith("string"):
                        path = path.Replace($"{{{param.Name}}}", $"{{Uri.EscapeDataString({param.Name})}}");
                        break;

                    case ParameterInEnum.Path:
                        break;

                    case ParameterInEnum.Header:
                        throw new NotSupportedException();
                    case ParameterInEnum.None:
                        throw new NotSupportedException();
                    default:
                        throw new NotSupportedException();
                }
            }
            foreach (var param in optionalParams)
            {
                var paramTypeText = ParseParameterSchema(param.Schema, param.Required);
                declareParams.Add(paramTypeText + " " + param.Name + " = null");

                if (param.In != ParameterInEnum.Query) continue;
                var name = param.Name;
                var escapedParamEntry = "";
                if (paramTypeText.StartsWith("string"))
                {
                    escapedParamEntry = $"Uri.EscapeDataString({name})";
                }
                else if (paramTypeText.StartsWith("IEnumerable<"))
                {
                    escapedParamEntry = $"string.Join(\",\", {name}.Select(x => x.ToString()))";
                }
                else
                {
                    escapedParamEntry = name;
                }

                if (param.Required != true)
                {
                    var textParam = $"{name} != null ? $\"{name}={{{escapedParamEntry}}}\" : null";
                    queryParamTextList.Add(textParam);
                }
                else
                {
                    var textParam = $"$\"{name}={{{escapedParamEntry}}}\"";
                    queryParamTextList.Add(textParam);
                }
            }
            if (responseMethodInfo.RequestBody is not null)
            {
                var requestBodyInfo = responseMethodInfo.RequestBody;
                var paramTypeText = ParseRequestBodySchema(requestBodyInfo.Content.ApplicationJson.Schema, requestBodyInfo.Required);
                declareParams.Add(paramTypeText + " requestBody" + (requestBodyInfo.Required == false ? " = null" : ""));
            }

            var queryStringParamsNotEmpty = parameters.Any(x => x.In == ParameterInEnum.Query);

            var queryStringParamText = queryStringParamsNotEmpty ? string.Join(", ", queryParamTextList) : "";

            var queryStringParamFinal = queryStringParamsNotEmpty ? $" + HttpRequestGenerator.MakeQuerystring({queryStringParamText})" : "";

            declareParams.Add("string? authToken = null");
            declareParams.Add("CancellationToken cancelToken = default");

            content += $"        public Task<{responseType}> {pathName}({string.Join(", ", declareParams)})\n        {{\n";
            content += $"            return _apiAccessor.ApiRequestAsync<{responseType}>(\n";
            content += $"                new Uri($\"{path.TrimStart('/')}\"{queryStringParamFinal}, UriKind.Relative),\n";

            content += $"                {(responseMethodInfo.RequestBody != null ? "new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, \"application/json\")" : "null")}, HttpMethod.{httpMethod}, authToken, cancelToken\n";
            content += "                );\n        }";

            content += "\n\n";

            content += $"        /// <inheritdoc cref=\"{pathName}({string.Join(", ", declareParams.Select(x => x.Split(' ').First()))})\" />\n";
            content += $"        /// <typeparam name=\"T\">The custom type to deserialize to.</typeparam>\n";
            content += $"        public Task<T> {pathName}<T>({string.Join(", ", declareParams)})\n        {{\n";
            content += $"            return _apiAccessor.ApiRequestAsync<T>(\n";
            content += $"                new Uri($\"{path.TrimStart('/')}\"{queryStringParamFinal}, UriKind.Relative),\n";

            content += $"                {(responseMethodInfo.RequestBody != null ? "new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, \"application/json\")" : "null")}, HttpMethod.{httpMethod}, authToken, cancelToken\n";
            content += "                );\n        }";

            return content.Replace("System.DateTime", "DateTime");
        }

        private static string ParseParameterSchema(ParameterSchemaClass paramSchema, bool? required)
        {
            var paramType = "";

            if (paramSchema.Items is not null)
            {
                paramType += GenerateCommon.ResolveItems(paramSchema.Items, true);
            }
            else if (paramSchema.XEnumReference is not null)
            {
                paramType += FormatStrings.ResolveRef(paramSchema.XEnumReference.Ref, true);
            }
            else if (paramSchema.Format is not null)
            {
                paramType += Mapping.FormatToCSharp(paramSchema.Format.Value);
            }
            else
            {
                paramType += Mapping.TypeToCSharp(paramSchema.Type);
            }

            if (required is not true)
            {
                paramType += "?";
            }

            return paramType;
        }

        private static string ParseRequestBodySchema(Entities.Paths.ContentApplicationJsonSchemaClass paramSchema, bool? required)
        {
            var paramType = "";

            if (paramSchema.Items is not null)
            {
                paramType += GenerateCommon.ResolveItems(paramSchema.Items, true);
            }
            else if (paramSchema.Ref is not null)
            {
                paramType += FormatStrings.ResolveRef(paramSchema.Ref, true);
            }
            else
            {
                paramType += Mapping.TypeToCSharp(paramSchema.Type!.Value);
            }

            if (required is not true)
            {
                paramType += "?";
            }

            return paramType;
        }

        private static string GetResponseRef(string refString)
        {
            var openApi = Program.OpenApiDefinition;

            var objRef = refString.Replace("#/components/responses/", "");

            var respObj = openApi.Components.Responses[objRef].Content.ApplicaionJson.Schema.Properties.Response;

            var respType = "";

            if (respObj.Items is not null)
            {
                respType += "IEnumerable<" + FormatStrings.ResolveRef(respObj.Items.Ref, true) + ">";
            }
            else if (respObj.AdditionalProperties is not null)
            {
                respType += ResolvePropertyDictionary(respObj.XDictionaryKey!, respObj.AdditionalProperties);
            }
            else if (respObj.Ref is not null)
            {
                respType += FormatStrings.ResolveRef(respObj.Ref, true);
            }
            else if (respObj.Format is not null)
            {
                respType += Mapping.FormatToCSharp(respObj.Format.Value);
            }
            else
            {
                respType += Mapping.TypeToCSharp(respObj.Type!.Value);
            }

            return respType;
        }

        private static string ResolvePropertyDictionary(PropertiesResponseXDictionaryKeyClass dictKey, PropertiesResponseAdditionalPropertiesClass additionalProps)
        {
            var classType = "Dictionary<";

            if (dictKey.Format is not null)
            {
                classType += Mapping.FormatToCSharp(dictKey.Format.Value);
            }
            else
            {
                classType += Mapping.TypeToCSharp(dictKey.Type!.Value);
            }

            classType += ", ";

            if (additionalProps.AdditionalProperties is not null)
            {
                classType += ResolvePropertyDictionary(additionalProps.XDictionaryKey!, additionalProps.AdditionalProperties);
            }
            else if (additionalProps.Ref is not null)
            {
                classType += FormatStrings.ResolveRef(additionalProps.Ref, true);
            }
            else
            {
                classType += Mapping.TypeToCSharp(additionalProps.Type!.Value);
            }

            classType += ">";

            return classType;
        }
    }
}