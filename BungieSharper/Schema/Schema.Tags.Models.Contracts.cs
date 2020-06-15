namespace BungieSharper.Schema.Tags.Models.Contracts
{
    public class TagResponse
    {
        public string tagText { get; set; }
        public Schema.Ignores.IgnoreResponse ignoreStatus { get; set; }
    }
}