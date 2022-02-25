using BungieSharper.Entities;
using System.Linq;
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
        public async Task GetManifestTest()
        {
            var manifestData = await ClientFixture.TestClient.Api.Destiny2_GetDestinyManifest();
            Assert.False(string.IsNullOrEmpty(manifestData.Version));
        }

        [Fact]
        public async Task PostUserSearchTest()
        {
            const BungieMembershipType expectedMembershipType = BungieMembershipType.TigerSteam;
            const long expectedMembershipId = 4611686018467948914;
            const string expectedDisplayName = "Cytraen";
            const short expectedDisplayNameCode = 2213;

            var actualCards = (await ClientFixture.TestClient.Api.Destiny2_SearchDestinyPlayerByBungieName(
                BungieMembershipType.All, new Entities.User.ExactSearchRequest { DisplayName = expectedDisplayName, DisplayNameCode = expectedDisplayNameCode }
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
        public async Task GetDefinitionTest()
        {
            const uint expectedCollectibleHash = 1296095691;
            const uint expectedBucketTypeHash = 1498876634;
            const uint expectedInfusionCategoryHash = 2601628231;
            const uint expectedDamageTypeHash = 3373582085;
            const string expectedName = "Midnight Coup";

            var actualDefinition = await ClientFixture.TestClient.Api.Destiny2_GetDestinyEntityDefinition<Entities.Destiny.Definitions.DestinyInventoryItemDefinition>("DestinyInventoryItemDefinition", 1128225405);

            Assert.Equal(expectedCollectibleHash, actualDefinition.CollectibleHash);
            Assert.Equal(expectedBucketTypeHash, actualDefinition.Inventory.BucketTypeHash);
            Assert.Equal(expectedInfusionCategoryHash, actualDefinition.Quality.InfusionCategoryHash);
            Assert.Equal(expectedDamageTypeHash, Assert.Single(actualDefinition.DamageTypeHashes));
            Assert.Equal(expectedName, actualDefinition.DisplayProperties.Name);
        }
    }
}