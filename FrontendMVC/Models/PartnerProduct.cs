using System;
using System.Collections.Generic;

namespace FrontendMVC.Models;

public partial class PartnerProduct
{
    public int IdPartnerProduct { get; set; }
    public int IdProduct { get; set; }

    public int IdPartner { get; set; }

    public int Amount { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual Partner IdPartnerNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
