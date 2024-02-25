using System;
using System.Collections.Generic;

namespace prjMalatang.Models;

public partial class Flavor
{
    public int FlavorId { get; set; }

    public string FlavorName { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
