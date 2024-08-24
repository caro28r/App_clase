using System;
using System.Collections.Generic;

namespace P6_APPI_CAROLINAR.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string LoginPassword { get; set; } = null!;

    public int UserRoleId { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();

    public virtual UserRole? UserRole { get; set; } = null!;
}
