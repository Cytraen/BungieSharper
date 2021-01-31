namespace BungieSharper.Schema.Destiny.Misc
{
    /// <summary>
    /// Represents a color whose RGBA values are all represented as values between 0 and 255.
    /// </summary>
    public class DestinyColor
    {
        public byte red { get; set; }

        public byte green { get; set; }

        public byte blue { get; set; }

        public byte alpha { get; set; }
    }
}