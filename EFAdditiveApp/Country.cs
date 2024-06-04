using System;
using System.Collections.Generic;

namespace EFAdditiveApp;

public partial class Country
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
