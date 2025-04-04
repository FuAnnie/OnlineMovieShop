namespace ApplicationCore.Models;

public class PaginatedResultSet<T>
{
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public int TotalItems { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    public bool HasPrevious => Page > 1;
    public bool HasNext => Page < TotalPages;

    public PaginatedResultSet(IEnumerable<T> items, int totalItems, int page, int pageSize)
    {
        Items = items;
        TotalItems = totalItems;
        Page = page;
        PageSize = pageSize;
    }
}
