using System;
using System.Collections.Generic;

namespace EFAdditiveApp;

public partial class Position
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool Activity { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
