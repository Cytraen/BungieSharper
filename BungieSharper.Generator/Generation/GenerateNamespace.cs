using System.Linq;

namespace BungieSharper.Generator.Generation
{
    internal static class GenerateNamespace
    {
        private const string BaseSchemaNamespace = "BungieSharper.Schema.";
        private const string BaseEndpointNamespace = "BungieSharper.Endpoint.";

        public static string CreateSchemaNamespace(string pathSummaryOrSchemaKey)
        {
            var path = (BaseSchemaNamespace + pathSummaryOrSchemaKey).Split('.').SkipLast(1);
            return string.Join('.', path);
        }

        public static string CreateEndpointNamespace(string pathSummaryOrSchemaKey)
        {
            var path = (BaseEndpointNamespace + pathSummaryOrSchemaKey).Split('.').SkipLast(1);
            return string.Join('.', path);
        }
    }
}