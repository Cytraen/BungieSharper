using BungieSharper.Schema;
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
        public async Task GetManifestTask()
        {
            var manifestData = await ClientFixture.TestClient.ApiEndpoints.Destiny2_GetDestinyManifest();
            Assert.False(string.IsNullOrEmpty(manifestData.version));
        }

        [Fact]
        public async Task SearchUserTest_Steam()
        {
            const BungieMembershipType expectedMembershipType = BungieMembershipType.TigerSteam;
            const long expectedMembershipId = 4611686018511231764;
            const string expectedDisplayName = "FlighterLuid";

            var actualCards = (await ClientFixture.TestClient.ApiEndpoints.Destiny2_SearchDestinyPlayer(
                "FlighterLuid", BungieMembershipType.All
                )).ToList();

            Assert.Single(actualCards);

            var userCard = actualCards[0];

            Assert.Equal(expectedMembershipType, userCard.membershipType);
            Assert.Equal(expectedMembershipId, userCard.membershipId);
            Assert.Equal(expectedDisplayName, userCard.displayName);
        }
    }
}