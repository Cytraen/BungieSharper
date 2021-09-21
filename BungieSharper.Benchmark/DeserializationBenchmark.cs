using BenchmarkDotNet.Attributes;
using BungieSharper.Entities;
using BungieSharper.Entities.Destiny.Config;
using BungieSharper.Entities.Destiny.Definitions;
using BungieSharper.Entities.User;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BungieSharper.Benchmark
{
    [MemoryDiagnoser(false)]
    public class DeserializationBenchmark
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
        };

        private static string InventoryDefsContent;
        private static string ManifestContent;
        private static string SearchContent;

        [GlobalSetup]
        public static void Setup()
        {
            InventoryDefsContent = File.ReadAllText("InventoryItemDefinitions_v2.12.1_97514.21.09.07.2012-2-bnet.40158.json");
            ManifestContent = File.ReadAllText("GetDestinyManifest_v2.12.1_97514.21.09.07.2012-2-bnet.40158.json");
            SearchContent = File.ReadAllText("SearchDestinyPlayer_v2.12.1.json");
        }

        [Benchmark]
        public Dictionary<uint, DestinyInventoryItemDefinition>? InventoryDefs() => JsonSerializer.Deserialize<Dictionary<uint, DestinyInventoryItemDefinition>>(InventoryDefsContent, Options);

        [Benchmark]
        public ApiResponse<DestinyManifest>? Manifest() => JsonSerializer.Deserialize<ApiResponse<DestinyManifest>>(ManifestContent, Options);

        [Benchmark]
        public ApiResponse<IEnumerable<UserInfoCard>>? Search() => JsonSerializer.Deserialize<ApiResponse<IEnumerable<UserInfoCard>>>(SearchContent, Options);
    }
}