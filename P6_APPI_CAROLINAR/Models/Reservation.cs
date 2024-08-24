using System;
using System.Collections.Generic;

namespace P6_APPI_CAROLINAR.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public string? Notes { get; set; }

    public int? RoomNumber { get; set; }

    public int HostingId { get; set; }

    public int TourId { get; set; }

    public virtual Hosting Hosting { get; set; } = null!;

    public virtual Tour Tour { get; set; } = null!;
}
