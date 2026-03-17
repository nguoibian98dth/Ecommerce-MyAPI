using System.ComponentModel.DataAnnotations;

namespace Domain.BaseModel;

public class BaseEntity<TKey> where TKey : IEquatable<TKey>
{
    [Key]
    public TKey Id { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    //public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; }
}
