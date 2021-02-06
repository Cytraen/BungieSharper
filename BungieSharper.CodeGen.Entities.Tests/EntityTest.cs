using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace BungieSharper.CodeGen.Entities.Tests
{
    public class EntityTest
    {
        [Fact]
        public async Task DeserializeAndSerializeTest()
        {
            var webClient = new WebClient();
            webClient.DownloadFile(new Uri("https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json", UriKind.Absolute), "openapi.json");

            var _serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            _serializerOptions.Converters.Add(new JsonLongConverter());
            _serializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            var fileContent = await File.ReadAllTextAsync("openapi.json");

            var openApiObj = JsonSerializer.Deserialize<OpenApiObject>(fileContent, _serializerOptions);

            var serialized = JsonSerializer.Serialize(openApiObj, _serializerOptions);

            var removeWhitespace = new Regex(@"\s+");

            await File.WriteAllTextAsync("testOutput.json", serialized);

            var noWhitespaceInput = removeWhitespace.Replace(fileContent, "").ToLowerInvariant();
            var noWhitespaceSerialized = removeWhitespace.Replace(serialized, "").ToLowerInvariant();

            Assert.Equal(noWhitespaceInput.Length, noWhitespaceSerialized.Length);
        }
    }
}