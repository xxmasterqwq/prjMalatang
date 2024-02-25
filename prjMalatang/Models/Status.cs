﻿using System;
using System.Collections.Generic;

namespace prjMalatang.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string Status1 { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
