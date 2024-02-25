using System;
using System.Collections.Generic;

namespace prjMalatang.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Point { get; set; }

    public bool? Suspension { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
