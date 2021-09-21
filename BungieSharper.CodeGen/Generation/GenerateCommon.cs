using BungieSharper.CodeGen.Entities.Common;

namespace BungieSharper.CodeGen.Generation
{
    internal class GenerateCommon
    {
        public static string ResolveItems(ItemClass items, bool appendEntities)
        {
            var propType = "IEnumerable<";

            if (items.XEnumReference?.Ref is not null)
            {
                propType += FormatStrings.ResolveRef(items.XEnumReference.Ref, appendEntities);
            }
            else if (items.Ref is not null)
            {
                propType += FormatStrings.ResolveRef(items.Ref, appendEntities);
            }
            else if (items.Format.HasValue)
            {
                propType += Mapping.FormatToCSharp(items.Format.Value);
            }
            else
            {
                propType += Mapping.TypeToCSharp(items.Type);
            }

            propType += ">";

            return propType;
        }
    }
}