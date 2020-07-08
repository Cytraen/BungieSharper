using System;
using System.Reflection;
using BungieSharper.Client;

namespace BungieSharper.Tests
{
    public class TestClientFixture : IDisposable
    {
        public BungieApiClient TestClient { get; }

        public TestClientFixture()
        {
            TestClient = new BungieApiClient(
                Environment.GetEnvironmentVariable("TEST_BUNGIE_API_KEY"),
                // "YOUR API KEY HERE",
                $"BungieSharper.Tests/{Assembly.GetExecutingAssembly().GetName().Version} (+https://github/ashakoor/BungieSharper)",
                10
                );
        }

        public void Dispose()
        {
            TestClient.Dispose();
        }
    }
}