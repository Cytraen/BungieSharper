using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Queries;

public class SearchResult
{
    [JsonPropertyName("totalResults")]
    public int TotalResults { get; set; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; set; }

    [JsonPropertyName("query")]
    public Queries.PagedQuery Query { get; set; }

    [JsonPropertyName("replacementContinuationToken")]
    public string ReplacementContinuationToken { get; set; }

    /// <summary>
    /// If useTotalResults is true, then totalResults represents an accurate count.
    /// If False, it does not, and may be estimated/only the size of the current page.
    /// Either way, you should probably always only trust hasMore.
    /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
    /// </summary>
    [JsonPropertyName("useTotalResults")]
    public bool UseTotalResults { get; set; }
}

public class PagedQuery
{
    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; set; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("requestContinuationToken")]
    public string RequestContinuationToken { get; set; }
}