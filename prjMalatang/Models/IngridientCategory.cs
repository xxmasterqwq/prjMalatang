using System;
using System.Collections.Generic;

namespace prjMalatang.Models;

public partial class IngridientCategory
{
    public int IngridientCatId { get; set; }

    public string IngCatName { get; set; } = null!;

    public virtual ICollection<Ingridient> Ingridients { get; set; } = new List<Ingridient>();
}
