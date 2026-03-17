using Application.Shared;

namespace Application.Requests;

public class ProductListRequest : PagingDataBaseDto
{
    public Guid? CategoryId { get; set; }
}
