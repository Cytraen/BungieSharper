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
    }
}