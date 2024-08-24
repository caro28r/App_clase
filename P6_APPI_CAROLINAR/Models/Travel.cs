using System;
using System.Collections.Generic;

namespace P6_APPI_CAROLINAR.Models;

public partial class Travel
{
    public int TravelId { get; set; }

    public DateTime DepartureDate { get; set; }

    public short DepartureHour { get; set; }

    public DateTime? ArrivalDate { get; set; }

    public short? ArrivalHour { get; set; }

    public string? Notes { get; set; }

    public int TransportId { get; set; }

    public int DestionationId { get; set; }

    public int TourId { get; set; }

    public virtual Destination Destionation { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Tour Tour { get; set; } = null!;

    public virtual Transport Transport { get; set; } = null!;
}
