using System;
using System.Collections.Generic;

namespace FrontendMVC.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public int IdProductType { get; set; }

    public string Name { get; set; } = null!;

    public int Article { get; set; }

    public decimal MinimalPrice { get; set; }
    public virtual List<PartnerProduct> OrderedProducts { get; set; } = new List<PartnerProduct>();
    public virtual ProductType IdProductTypeNavigation { get; set; } = null!;
}
