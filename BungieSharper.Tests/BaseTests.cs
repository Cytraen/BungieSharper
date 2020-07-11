using System.Linq;
using System.Threading.Tasks;
using BungieSharper.Schema;
using Xunit;

namespace BungieSharper.Tests
{
    public class BaseTests : IClassFixture<TestClientFixture>
    {
        public TestClientFixture ClientFixture;

        public BaseTests(TestClientFixture clientFixture)
        {
            ClientFixture = clientFixture;
        }

        [Fact]
        public async Task GetManifestTask()
        {
            var manifestData = await ClientFixture.TestClient.ClientEndpoints.Destiny2_GetDestinyManifest();
            Assert.False(string.IsNullOrEmpty(manifestData.version));
        }

        [Fact]
        public async Task SearchUserTest_Steam()
        {
            const BungieMembershipType expectedMembershipType = BungieMembershipType.TigerSteam;
            const long expectedMembershipId = 4611686018467948914;
            const string expectedDisplayName = "Cytraen";
            const int expectedNumOfCards = 3;

            var actualCards = (await ClientFixture.TestClient.ClientEndpoints.Destiny2_SearchDestinyPlayer(
                "Cytraen", BungieMembershipType.All
                )).ToList();

            Assert.Equal(expectedNumOfCards, actualCards.Count);

            Assert.Collection(actualCards,
                card => Assert.Equal(expectedMembershipType, card.membershipType),
                card => Assert.Equal(expectedMembershipId, card.membershipId),
                card => Assert.Equal(expectedDisplayName, card.displayName)
                );
        }

        [Fact]
        public async Task SearchUserTest_Blizzard()
        {
            const BungieMembershipType expectedMembershipType = BungieMembershipType.TigerBlizzard;
            const long expectedMembershipId = 4611686018472399666;
            const string expectedDisplayName = "prism#11555";

            var actualCards = (await ClientFixture.TestClient.ClientEndpoints.Destiny2_SearchDestinyPlayer(
                "prism#11555", BungieMembershipType.All, false
                )).ToList();

            Assert.Single(actualCards);

            var card = actualCards[0];

            Assert.Equal(expectedMembershipType, card.membershipType);
            Assert.Equal(expectedMembershipId, card.membershipId);
            Assert.Equal(expectedDisplayName, card.displayName);
        }
    }
}