using BungieSharper.Entities;
using BungieSharper.Entities.Destiny.Definitions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace BungieSharper.Tests
{
    public class BaseTests : IClassFixture<TestClientFixture>
    {
        private readonly TestClientFixture ClientFixture;

        public BaseTests(TestClientFixture clientFixture)
        {
            ClientFixture = clientFixture;
        }

        [Fact]
        public async Task GetManifestTask()
        {
            var manifestData = await ClientFixture.TestClient.Api.Destiny2_GetDestinyManifest();
            Assert.False(string.IsNullOrEmpty(manifestData.Version));
        }

        [Fact]
        public async Task SearchUserTest_Steam()
        {
            const BungieMembershipType expectedMembershipType = BungieMembershipType.TigerSteam;
            const long expectedMembershipId = 4611686018467948914;
            const string expectedDisplayName = "Cytraen";
            const short expectedDisplayNameCode = 2213;

            var actualCards = (await ClientFixture.TestClient.Api.Destiny2_SearchDestinyPlayer(
                $"{expectedDisplayName}#{expectedDisplayNameCode}", BungieMembershipType.All
                )).ToList();

            Assert.Equal(4, actualCards.Count);

            var userCard = actualCards.Single(x => x.MembershipType == BungieMembershipType.TigerSteam);

            Assert.NotEmpty(userCard.ApplicableMembershipTypes);
            Assert.Equal(expectedMembershipType, userCard.MembershipType);
            Assert.Equal(expectedMembershipId, userCard.MembershipId);
            Assert.Equal(expectedDisplayName, userCard.BungieGlobalDisplayName);
            Assert.Equal(expectedDisplayNameCode, userCard.BungieGlobalDisplayNameCode);
        }

        [Fact]
        public async Task DownloadStringAndDeserialize()
        {
            const string expectedName = "Midnight Coup";
            const string expectedFlavorText =
                "The conspirators were too afraid to kill me—rightly so. " +
                "I am the beloved father of the people, and the glorious mob would not suffer my death. " +
                "My sentence was exile.";
            const uint expectedDamageTypeHash = 3373582085;

            var manifestData = await ClientFixture.TestClient.Api.Destiny2_GetDestinyManifest();
            var str = await ClientFixture.TestClient.DownloadString(
                manifestData.JsonWorldComponentContentPaths["en"]["DestinyInventoryItemDefinition"]
            );
            var inventoryItems = JsonSerializer.Deserialize<Dictionary<uint, DestinyInventoryItemDefinition>>(str);
            var item = inventoryItems[1128225405];

            Assert.Equal(expectedName, item.DisplayProperties.Name);
            Assert.Equal(expectedFlavorText, item.FlavorText);
            Assert.Equal(expectedDamageTypeHash, item.DefaultDamageTypeHash);
        }

        [Fact]
        public async Task DownloadFileAndDeserialize()
        {
            const string fileName = "inventoryItems.json";
            const string expectedName = "Midnight Coup";
            const string expectedFlavorText =
                "The conspirators were too afraid to kill me—rightly so. " +
                "I am the beloved father of the people, and the glorious mob would not suffer my death. " +
                "My sentence was exile.";
            const uint expectedDamageTypeHash = 3373582085;

            var manifestData = await ClientFixture.TestClient.Api.Destiny2_GetDestinyManifest();

            await using var fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            await ClientFixture.TestClient.DownloadFile(
                manifestData.JsonWorldComponentContentPaths["en"]["DestinyInventoryItemDefinition"], fileStream
                );
            fileStream.Close();

            var fileText = await File.ReadAllTextAsync(fileName);

            var inventoryItems = JsonSerializer.Deserialize<Dictionary<uint, DestinyInventoryItemDefinition>>(fileText);
            var item = inventoryItems[1128225405];

            Assert.Equal(expectedName, item.DisplayProperties.Name);
            Assert.Equal(expectedFlavorText, item.FlavorText);
            Assert.Equal(expectedDamageTypeHash, item.DefaultDamageTypeHash);
        }
    }
}