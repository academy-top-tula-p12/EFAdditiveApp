using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFAdditiveApp;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public decimal? Salary { get; set; }

    public int? PositionId { get; set; }

    public int? CompanyId { get; set; }

    //public string Discriminator { get; set; } = null!;

    //public int? Quality { get; set; }

    //public double? SaleRate { get; set; }

    public virtual Company? Company { get; set; }

    public virtual Position? Position { get; set; }

    public virtual List<Project> Projects { get; set; } = new List<Project>();
}
