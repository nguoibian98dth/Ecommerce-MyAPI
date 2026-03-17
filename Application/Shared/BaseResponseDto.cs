namespace Application.Shared;

public class BaseResponseDto<T> where T : IEquatable<T>
{
    public T Id { get; set; }
}
