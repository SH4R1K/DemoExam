using System;
using System.Collections.Generic;

namespace FrontendMVC.Models;

public partial class PartnerType
{
    public int IdPartnerType { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
