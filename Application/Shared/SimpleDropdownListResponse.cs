namespace Application.Shared;

public class SimpleDropdownListResponse<T> where T : notnull
{
    public T Value { get; set; }

    public string? Label { get; set; }
}
