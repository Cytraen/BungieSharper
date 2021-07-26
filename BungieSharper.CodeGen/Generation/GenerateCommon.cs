using BungieSharper.CodeGen.Entities.Common;

namespace BungieSharper.CodeGen.Generation
{
    internal class GenerateCommon
    {
        public static string ResolveItems(ItemClass items, bool appendEntities, string? parentNameSpace = null)
        {
            var propType = "IEnumerable<";

            if (items.XEnumReference?.Ref is not null)
            {
                propType += FormatStrings.ResolveRef(items.XEnumReference.Ref, appendEntities, parentNameSpace);
            }
            else if (items.Ref is not null)
            {
                propType += FormatStrings.ResolveRef(items.Ref, appendEntities, parentNameSpace);
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