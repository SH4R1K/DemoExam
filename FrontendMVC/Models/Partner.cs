namespace FrontendMVC.Models;

public partial class Partner
{
    public int IdPartner { get; set; }

    public int IdPartnerType { get; set; }

    public int IdPartnerDirector { get; set; }

    public string Name { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Rating { get; set; }
    public virtual int Discount
    {
        get
        {
            var orderedAmount = OrderedProducts.Sum(p => p.Amount);
            switch (orderedAmount)
            {
                case > 300000:
                    return 15;
                case > 50000:
                    return 10;
                case > 10000:
                    return 5;
                default:
                    return 0;
            }
        }
    }
    public virtual List<PartnerProduct> OrderedProducts { get; set; } = new List<PartnerProduct>();

    public virtual PartnerDirector IdPartnerDirectorNavigation { get; set; } = null!;

    public virtual PartnerType IdPartnerTypeNavigation { get; set; } = null!;
}
