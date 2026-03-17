namespace Domain.Exceptions
{
    public class CustomException
    {
    }

    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }

    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class ConflictException : DomainException
    {
        public ConflictException(string message) : base(message) { }
    }

    public class ValidationException : DomainException
    {
        public ValidationException(string message) : base(message) { }
    }
}
