using System;
using System.Collections.Generic;

namespace TiendaIMark.Models;

public partial class Image
{
    public int IdImages { get; set; }

    public string? Url1 { get; set; }

    public string? Url2 { get; set; }

    public string? Url3 { get; set; }

    public string? Url4 { get; set; }

    public string? Url5 { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
