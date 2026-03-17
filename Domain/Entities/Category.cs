using Domain.BaseModel;

namespace Domain.Entities;

public class Category : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;

    public Guid? ParentId { get; set; }

    public Category? Parent { get; set; }

    public ICollection<Category> Children { get; set; } = new List<Category>();

     //public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

}
