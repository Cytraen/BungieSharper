namespace BungieSharper.Schema.Ignores
{
    public class IgnoreResponse
    {
        public bool isIgnored { get; set; }
        public Schema.Ignores.IgnoreStatus ignoreFlags { get; set; }
    }

    [System.Flags]
    public enum IgnoreStatus
    {
        NotIgnored = 0,
        IgnoredUser = 1,
        IgnoredGroup = 2,
        IgnoredByGroup = 4,
        IgnoredPost = 8,
        IgnoredTag = 16,
        IgnoredGlobal = 32
    }

    public enum IgnoreLength
    {
        None = 0,
        Week = 1,
        TwoWeeks = 2,
        ThreeWeeks = 3,
        Month = 4,
        ThreeMonths = 5,
        SixMonths = 6,
        Year = 7,
        Forever = 8,
        ThreeMinutes = 9,
        Hour = 10,
        ThirtyDays = 11
    }
}