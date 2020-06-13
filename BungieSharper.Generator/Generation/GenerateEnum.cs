using System.Collections.Generic;

namespace BungieSharper.Generator.Generation
{
    internal static class GenerateEnum
    {
        public static string CreateEnum()
        {


            return "";
        }

        private static string CreateEnumContent(string nameSpace, string enumName, string? numType, Dictionary<string, string> valuesDict)
        {
            if (numType != null)
                numType = " : " + numType;

            const string enumBase = "namespace {0}\n{{\n    public enum {1}{2}\n    {{\n{3}    }}\n\n}}";
            var valueStringList = new List<string>();

            foreach (var (key, value) in valuesDict)
            {
                valueStringList.Add($"        {key} = {value}");
            }

            return string.Format(enumBase, nameSpace, enumBase, numType ?? "", string.Join(',', valueStringList));
        }
    }
}
