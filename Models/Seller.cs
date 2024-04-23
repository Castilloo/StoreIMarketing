using System;
using System.Collections.Generic;

namespace TiendaIMark.Models;

public partial class Seller
{
    public int IdSeller { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Department { get; set; }

    public string? Country { get; set; }

    public bool? IsGoodAssessment { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
