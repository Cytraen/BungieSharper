using BungieSharper.CodeGen.Entities.Common;
using BungieSharper.CodeGen.Entities.Paths;
using System.Collections.Generic;
using System.Linq;

namespace BungieSharper.CodeGen.Generation
{
    internal static class FormatStrings
    {
        public static string FormatPropertySummaries(string summary)
        {
            var formatted = "";
            var spacing = "".PadLeft(8, ' ');

            summary = summary.Replace("\r\n", "\n").Replace("\n\r", "\n");

            if (summary.Contains('\n'))
            {
                formatted += $"{spacing}/// <summary>\n";
                formatted += string.Join("\n", summary.Split('\n').Select(x => spacing + "/// " + x.Trim()));
                formatted += $"\n{spacing}/// </summary>\n";
            }
            else
            {
                formatted = $"{spacing}/// <summary>{summary.Trim()}</summary>\n";
            }

            return formatted;
        }

        public static string FormatClassSummaries(string summary)
        {
            var formatted = "";
            var spacing = "".PadLeft(4, ' ');

            summary = summary.Replace("\r\n", "\n").Replace("\n\r", "\n");

            formatted += $"{spacing}/// <summary>\n";
            formatted += string.Join("\n", summary.Split('\n').Select(x => spacing + "/// " + x.Trim()));
            formatted += $"\n{spacing}/// </summary>\n";

            return formatted;
        }

        public static string FormatMethodSummaries(string summary, IEnumerable<PathResponseMethodParameterClass> parameters, bool preview, bool deprecated, IEnumerable<OAuthScopeEnum>? oauthScopes)
        {
            var formatted = "";
            var spacing = "".PadLeft(8, ' ');

            summary = summary.Replace("\r\n", "\n").Replace("\n\r", "\n");

            formatted += $"{spacing}/// <summary>\n";

            if (preview)
            {
                // existing documentation appears to already account for preview methods
                // formatted += $"{spacing}/// This is marked as a preview endpoint. Its complete-ness or ready-ness will vary.\n";
            }

            formatted += string.Join("\n", summary.Split('\n').Select(x => spacing + "/// " + x.Trim())) + "\n";

            if (oauthScopes != null && oauthScopes.Any())
            {
                formatted += $"{spacing}/// Requires OAuth2 scope(s): {string.Join(", ", oauthScopes)}\n";
            }

            formatted += $"{spacing}/// </summary>\n";

            var paramsWithDescriptions = parameters.Where(x => !string.IsNullOrWhiteSpace(x.Description));

            if (paramsWithDescriptions.Any())
            {
                formatted += string.Join("\n", paramsWithDescriptions.Select(x => spacing + "/// <param name=\"" + x.Name + "\">" + x.Description.Trim() + "</param>"));
                formatted += "\n";
            }

            if (deprecated)
            {
                formatted += $"{spacing}[System.Obsolete(\"Bungie have marked this endpoint as deprecated.\", true)]\n";
            }

            return formatted;
        }

        public static void FormatNamespace(string name, out string className, out string nameSpace)
        {
            var splitName = name.Split('.');
            var parentName = splitName[..^1];
            className = splitName[^1];

            nameSpace = Program.BaseEntityNamespace + (splitName.Length == 1 ? "" : ".") + string.Join('.', parentName);
        }

        public static string ResolveRef(string reference, bool appendEntities, string? baseNameSpace)
        {
            var className = reference.Split('/')[^1];

            if (!string.IsNullOrWhiteSpace(baseNameSpace))
            {
                foreach (var part in baseNameSpace.Split('.').Select(x => x + "."))
                {
                    if (!string.IsNullOrWhiteSpace(part) && className.Length > part.Length && className[0..part.Length] == part)
                    {
                        className = className.Remove(0, part.Length);
                    }
                }
            }

            if (appendEntities)
            {
                return "Entities." + className;
            }

            return className;
        }
    }
}