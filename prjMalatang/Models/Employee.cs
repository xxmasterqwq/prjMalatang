using System;
using System.Collections.Generic;

namespace prjMalatang.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Permission { get; set; }
}
