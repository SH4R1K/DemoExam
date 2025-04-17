using System;
using System.Collections.Generic;

namespace FrontendMVC.Models;

public partial class ProductType
{
    public int IdProductType { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
