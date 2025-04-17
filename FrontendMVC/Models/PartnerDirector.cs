using System;
using System.Collections.Generic;

namespace FrontendMVC.Models;

public partial class PartnerDirector
{
    public int IdPartnerDirector { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
    public virtual string FullName => $"{Surname} {FirstName} {Patronymic}";
}
