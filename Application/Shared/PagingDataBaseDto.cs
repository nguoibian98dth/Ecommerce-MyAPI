namespace Application.Shared;

public class PagingDataBaseDto
{
    public int PageNo { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string? FilterKeyword { get; set; }

    public string? OrderBy { get; set; }

    public string? OrderType { get; set; } = "desc";
}
