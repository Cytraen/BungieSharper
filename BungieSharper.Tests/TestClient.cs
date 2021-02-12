using BungieSharper.Client;
using System;

namespace BungieSharper.Tests
{
    public class TestClientFixture : IDisposable
    {
        public BungieApiClient TestClient { get; }

        private readonly string BungieApiKey = Environment.GetEnvironmentVariable("TEST_BUNGIE_API_KEY"); // YOUR BUNGIE.NET API KEY HERE

        private readonly string BungieUserAgent =
            $"BungieSharper.Tests/{typeof(TestClientFixture).Assembly.GetName().Version!.ToString(3)} (+github.com/ashakoor/BungieSharper)";

        public TestClientFixture()
        {
            if (string.IsNullOrWhiteSpace(BungieApiKey))
                throw new Exception();

            TestClient = new BungieApiClient();
            TestClient.SetApiKey(BungieApiKey);
            TestClient.SetUserAgent(BungieUserAgent);
            TestClient.SetRateLimit(10);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            TestClient.Dispose();
        }
    }
}