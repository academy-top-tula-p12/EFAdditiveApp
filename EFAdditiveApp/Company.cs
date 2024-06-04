using System;
using System.Collections.Generic;

namespace EFAdditiveApp;

public partial class Company
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    //public byte[]? Timestamp { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
