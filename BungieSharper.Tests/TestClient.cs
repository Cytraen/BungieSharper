using BungieSharper.Client;
using System;

namespace BungieSharper.Tests
{
    public class TestClientFixture : IDisposable
    {
        public BungieApiClient TestClient { get; }

        public TestClientFixture()
        {
            var config = new BungieClientConfig
            {
                ApiKey = Environment.GetEnvironmentVariable("TEST_BUNGIE_API_KEY") ?? throw new NullReferenceException(),
                UserAgent = $"BungieSharper.Tests/{typeof(TestClientFixture).Assembly.GetName().Version!.ToString(3)} (+github.com/ashakoor/BungieSharper)",
                RequestsPerSecond = 50
            };

            TestClient = new BungieApiClient(config);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            TestClient.Dispose();
        }
    }
}