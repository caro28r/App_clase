using System;
using System.Collections.Generic;

namespace P6_APPI_CAROLINAR.Models;
public partial class Destination
{
    public int DestionationId { get; set; }

    public string DestinationName { get; set; } = null!;

    public int Ranking { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();
}
