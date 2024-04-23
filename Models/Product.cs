using System;
using System.Collections.Generic;

namespace TiendaIMark.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public string? Brand { get; set; }

    public string? Descripcion { get; set; }

    public bool? IsNew { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public int? IdImages { get; set; }

    public int? IdCategory { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Image? IdImagesNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
