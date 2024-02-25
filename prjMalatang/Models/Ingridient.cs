using System;
using System.Collections.Generic;

namespace prjMalatang.Models;

public partial class Ingridient
{
    public int IngridientId { get; set; }

    public int IngridientCatId { get; set; }

    public string IngridientName { get; set; } = null!;

    public int Price { get; set; }

    public virtual IngridientCategory IngridientCat { get; set; } = null!;

    public virtual ICollection<Malatang> Malatangs { get; set; } = new List<Malatang>();
}
