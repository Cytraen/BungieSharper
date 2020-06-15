namespace BungieSharper.Schema.Queries
{
    public class SearchResult
    {
        public int totalResults { get; set; }
        public bool hasMore { get; set; }
        public Schema.Queries.PagedQuery query { get; set; }
        public string replacementContinuationToken { get; set; }
        /// <summary>
        /// If useTotalResults is true, then totalResults represents an accurate count.
        /// If False, it does not, and may be estimated/only the size of the current page.
        /// Either way, you should probably always only trust hasMore.
        /// This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
        /// </summary>
        public bool useTotalResults { get; set; }
    }

    public class PagedQuery
    {
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }
        public string requestContinuationToken { get; set; }
    }
}