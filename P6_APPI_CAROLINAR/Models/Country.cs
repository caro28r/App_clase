using System;
using System.Collections.Generic;

namespace P6_APPI_CAROLINAR.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();

    public virtual ICollection<Hosting> Hostings { get; set; } = new List<Hosting>();
}
