using System;
using System.Collections.Generic;

namespace P6_APPI_CAROLINAR.Models;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public string UserRoleDescription { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
