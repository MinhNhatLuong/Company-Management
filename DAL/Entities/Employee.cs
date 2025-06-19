using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public int? Age { get; set; }

    public int? DepartmentId { get; set; }
    //navigation property
    public virtual Department? Department { get; set; }
}
