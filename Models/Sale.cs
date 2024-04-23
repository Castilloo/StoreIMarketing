using System;
using System.Collections.Generic;

namespace TiendaIMark.Models;

public partial class Sale
{
    public int IdSale { get; set; }

    public int? IdSeller { get; set; }

    public int? IdProduct { get; set; }

    public int? QuantitySold { get; set; }

    public decimal? SaleAmount { get; set; }

    public DateTime? SaleDate { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Seller? IdSellerNavigation { get; set; }
}
