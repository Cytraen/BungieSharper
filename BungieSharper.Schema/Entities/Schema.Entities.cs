namespace BungieSharper.Schema.Entities
{
    public class EntityActionResult
    {
        public long entityId { get; set; }

        public Schema.Exceptions.PlatformErrorCodes result { get; set; }
    }
}