using System;
using BungieSharper.Client;

namespace BungieSharper.Tests
{
    public class TestClientFixture : IDisposable
    {
        public BungieApiClient TestClient { get; }

        private readonly string BungieUserAgent =
            $"BungieSharper.Tests/{typeof(TestClientFixture).Assembly.GetName().Version} (+https://github.com/ashakoor/BungieSharper) " +
            $"BungieSharper/{typeof(BungieApiClient).Assembly.GetName().Version} (+https://github.com/ashakoor/BungieSharper)";

        public TestClientFixture()
        {
            TestClient = new BungieApiClient(
                Environment.GetEnvironmentVariable("TEST_BUNGIE_API_KEY"),
                // "YOUR API KEY HERE",
                BungieUserAgent
                );
            TestClient.SetRateLimit(10);
        }

        public void Dispose()
        {
            TestClient.Dispose();
        }
    }
}