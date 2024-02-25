using System;
using System.Collections.Generic;

namespace prjMalatang.Models;

public partial class Product
{
    public int PId { get; set; }

    public int OrderId { get; set; }

    public int FlavorId { get; set; }

    public int PQuantity { get; set; }

    public virtual Flavor Flavor { get; set; } = null!;

    public virtual ICollection<Malatang> Malatangs { get; set; } = new List<Malatang>();

    public virtual Order Order { get; set; } = null!;
}
