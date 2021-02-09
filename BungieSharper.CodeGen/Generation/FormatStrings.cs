using System.Linq;

namespace BungieSharper.CodeGen.Generation
{
    internal static class FormatStrings
    {
        public static string FormatSummaries(string summary, int tabs, bool forceMultiline = false)
        {
            var spaces = tabs * 4;
            var formatted = "";
            var spacing = "".PadLeft(spaces, ' ');

            summary = summary.Replace("\r\n", "\n").Replace("\n\r", "\n");

            if (summary.Contains('\n') || forceMultiline)
            {
                formatted += $"{spacing}/// <summary>\n";
                formatted += string.Join("\n", summary.Split('\n').Select(x => spacing + "/// " + x.TrimEnd().TrimStart()));
                formatted += $"\n{spacing}/// </summary>\n";
            }
            else
            {
                formatted = $"{spacing}/// <summary>{summary.TrimEnd().TrimStart()}</summary>\n";
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

        public static string ResolveRef(string reference)
        {
            var className = reference.Split('/')[^1];

            return className;
        }
    }
}