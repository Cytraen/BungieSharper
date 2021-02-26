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
            const long expectedMembershipId = 4611686018511231764;
            const string expectedDisplayName = "FlighterLuid";

            var actualCards = (await ClientFixture.TestClient.Api.Destiny2_SearchDestinyPlayer(
                "FlighterLuid", BungieMembershipType.All
                )).ToList();

            Assert.Single(actualCards);

            var userCard = actualCards[0];

            Assert.Equal(expectedMembershipType, userCard.MembershipType);
            Assert.Equal(expectedMembershipId, userCard.MembershipId);
            Assert.Equal(expectedDisplayName, userCard.DisplayName);
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