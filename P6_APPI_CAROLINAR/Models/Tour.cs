using System;
using System.Collections.Generic;

namespace P6_APPI_CAROLINAR.Models;

public partial class Tour
{
    public int TourId { get; set; }

    public string TourName { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime TourDate { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();

    public virtual User User { get; set; } = null!;
}
