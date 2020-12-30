using System.Linq;
using System.Threading.Tasks;
using BungieSharper.Schema;
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
            var manifestData = await ClientFixture.TestClient.ApiEndpoints.Destiny2_GetDestinyManifest();
            Assert.False(string.IsNullOrEmpty(manifestData.version));
        }

        [Fact]
        public async Task SearchUserTest_Steam()
        {
            const BungieMembershipType expectedMembershipType = BungieMembershipType.TigerSteam;
            const long expectedMembershipId = 4611686018467948914;
            const string expectedDisplayName = "Cytraen";
            const int expectedNumOfCards = 3;

            var actualCards = (await ClientFixture.TestClient.ApiEndpoints.Destiny2_SearchDestinyPlayer(
                "Cytraen", BungieMembershipType.All
                )).ToList();

            Assert.Equal(expectedNumOfCards, actualCards.Count);

            Assert.Collection(actualCards,
                card => Assert.Equal(expectedMembershipType, card.membershipType),
                card => Assert.Equal(expectedMembershipId, card.membershipId),
                card => Assert.Equal(expectedDisplayName, card.displayName)
                );
        }
    }
}