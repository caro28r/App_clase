using System;
using System.Collections.Generic;

namespace P6_APPI_CAROLINAR.Models;

public partial class Schedule
{
    public int ActivityId { get; set; }

    public string ActivityName { get; set; } = null!;

    public DateTime ActivityDateAndTime { get; set; }

    public int? EstimatedDuration { get; set; }

    public string? Notes { get; set; }

    public bool IsTour { get; set; }

    public int? ParticipantNumber { get; set; }

    public int TravelId { get; set; }

    public virtual Travel Travel { get; set; } = null!;
}
