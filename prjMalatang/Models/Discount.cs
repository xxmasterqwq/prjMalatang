using System;
using System.Collections.Generic;

namespace prjMalatang.Models;

public partial class Discount
{
    public int DiscountCodeId { get; set; }

    public string DiscountCode { get; set; } = null!;

    public int? DiscountPercentage { get; set; }

    public int? DiscountAmount { get; set; }

    public DateTime UsageTimeStart { get; set; }

    public DateTime? UsageTimeEnd { get; set; }

    public int? UsageLimit { get; set; }
}
