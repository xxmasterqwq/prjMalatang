using System;
using System.Collections.Generic;

namespace prjMalatang.Models;

public partial class Malatang
{
    public int Id { get; set; }

    public int PId { get; set; }

    public int IngredientId { get; set; }

    public int Iquantity { get; set; }

    public virtual Ingridient Ingredient { get; set; } = null!;

    public virtual Product PIdNavigation { get; set; } = null!;
}
