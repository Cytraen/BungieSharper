using System.Collections.Generic;
using System.Threading.Tasks;
using BungieSharper.Schema;
using BungieSharper.Schema.User;
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
        public async Task GetManifestTest()
        {
            const BungieMembershipType expectedMembershipType = BungieMembershipType.TigerSteam;
            const long expectedMembershipId = 4611686018467948914;
            const string expectedDisplayName = "Cytraen";
            const int expectedNumOfCards = 3;

            var actualCards = (List<UserInfoCard>)await ClientFixture.TestClient.ClientEndpoints.Destiny2_SearchDestinyPlayer(
                "Cytraen", BungieMembershipType.All, false
                );

            Assert.Equal(expectedNumOfCards, actualCards.Count);

            Assert.Collection(actualCards, 
                card => Assert.Equal(expectedMembershipType, card.membershipType), 
                card => Assert.Equal(expectedMembershipId, card.membershipId), 
                card => Assert.Equal(expectedDisplayName, card.displayName)
                );
        }
    }
}
