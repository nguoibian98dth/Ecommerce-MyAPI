namespace Application.Shared;

public class PagingDataResponse<T>
{
    public int PageNo { get; set; }

    public int PageSize { get; set; }

    public long TotalRecords { get; set; }

    public IList<T>? Data { get; set; } = [];

    public string? Message { get; set; }
}
