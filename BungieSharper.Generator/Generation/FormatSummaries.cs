using System.Linq;

namespace BungieSharper.Generator.Generation
{
    internal static class FormatSummaries
    {
        public static string FormatSummary(string summary, int spaces, bool forceMultiline = false)
        {
            var formatted = "";
            var spacing = "".PadLeft(spaces, ' ');

            summary = summary.Replace("\r\n", "\n");

            if (summary.Contains('\n') || forceMultiline)
            {
                formatted += $"{spacing}/// <summary>\n";
                formatted += string.Join("\n", summary.Split('\n').Select(x => spacing + "/// " + x));
                formatted += $"\n{spacing}/// </summary>\n";
            }
            else
            {
                formatted = $"{spacing}/// <summary>{summary}</summary>\n";
            }

            return formatted;
        }
    }
}