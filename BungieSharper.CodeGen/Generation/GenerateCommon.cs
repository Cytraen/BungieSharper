using BungieSharper.CodeGen.Entities.Common;

namespace BungieSharper.CodeGen.Generation
{
    internal class GenerateCommon
    {
        public static string ResolveItems(ItemClass items)
        {
            var propType = "IEnumerable<";

            if (items.XEnumReference?.Ref is not null)
            {
                propType += FormatStrings.ResolveRef(items.XEnumReference.Ref);
            }
            else if (items.Ref is not null)
            {
                propType += FormatStrings.ResolveRef(items.Ref);
            }
            else if (items.Format is not null)
            {
                propType += Mapping.FormatToCSharp(items.Format.Value);
            }
            else
            {
                propType += Mapping.TypeToCSharp(items.Type!.Value);
            }

            propType += ">";

            return propType;
        }
    }
}