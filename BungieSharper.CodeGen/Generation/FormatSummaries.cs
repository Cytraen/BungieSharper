using System.Linq;

namespace BungieSharper.CodeGen.Generation
{
    internal static class FormatSummaries
    {
        public static string Format(string summary, int tabs, bool forceMultiline = false)
        {
            var spaces = tabs * 4;
            var formatted = "";
            var spacing = "".PadLeft(spaces, ' ');

            summary = summary.Replace("\r\n", "\n").Replace("\n\r", "\n");

            if (summary.Contains('\n') || forceMultiline)
            {
                formatted += $"{spacing}/// <summary>\n";
                formatted += string.Join("\n", summary.Split('\n').Select(x => spacing + "/// " + x.TrimEnd()));
                formatted += $"\n{spacing}/// </summary>\n";
            }
            else
            {
                formatted = $"{spacing}/// <summary>{summary.TrimEnd()}</summary>\n";
            }

            return formatted;
        }
    }
}