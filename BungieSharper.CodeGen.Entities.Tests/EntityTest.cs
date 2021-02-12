using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace BungieSharper.CodeGen.Entities.Tests
{
    public class EntityTest : IClassFixture<SpecFixture>
    {
        private readonly string SpecStringContent;

        public EntityTest(SpecFixture specStringFixture)
        {
            SpecStringContent = specStringFixture.SpecFileContent;
        }

        [Fact]
        public async Task DeserializeAndSerializeTest()
        {
            var _serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            _serializerOptions.Converters.Add(new JsonLongConverter());
            _serializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            var openApiObj = JsonSerializer.Deserialize<OpenApiObject>(SpecStringContent, _serializerOptions);

            var serialized = JsonSerializer.Serialize(openApiObj, _serializerOptions);

            var removeWhitespace = new Regex(@"\s+");

            await File.WriteAllTextAsync("testOutput.json", serialized);

            var noWhitespaceInput = removeWhitespace.Replace(SpecStringContent, "").ToLowerInvariant();
            var noWhitespaceSerialized = removeWhitespace.Replace(serialized, "").ToLowerInvariant();

            Assert.Equal(noWhitespaceInput.Length, noWhitespaceSerialized.Length);
        }
    }
}