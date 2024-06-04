using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFAdditiveApp;

public partial class Project
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime? DeadLine { get; set; }

    public virtual List<Employee> Employees { get; set; } = new List<Employee>();

    //[Timestamp]
    //public byte[]? Timestamp { get; set; }
}
