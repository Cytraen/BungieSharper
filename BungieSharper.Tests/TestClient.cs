using BungieSharper.Client;
using System;

namespace BungieSharper.Tests;

public class TestClientFixture : IDisposable
{
    public TestClientFixture()
    {
        var config = new BungieClientConfig
        {
            ApiKey = Environment.GetEnvironmentVariable("TEST_BUNGIE_API_KEY") ?? throw new NullReferenceException(),
            UserAgent =
                $"BungieSharper.Tests/{typeof(TestClientFixture).Assembly.GetName().Version!.ToString(3)} (+github.com/Cytraen/BungieSharper)",
            RateLimit = 10
        };

        TestClient = new BungieApiClient(config);
    }

    public BungieApiClient TestClient { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        TestClient.Dispose();
    }
}