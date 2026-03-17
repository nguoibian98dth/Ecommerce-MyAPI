using Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class ProductImage : BaseEntity<Guid>
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public string Url { get; set; } = string.Empty;
    public bool IsPrimary { get; set; }
}
