using System;
using System.Collections.Generic;

namespace prjMalatang.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly Datetime { get; set; }

    public bool IsTakeOut { get; set; }

    public int? Table { get; set; }

    public int StatusId { get; set; }

    public int? DiscountCodeId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Status Status { get; set; } = null!;
}
