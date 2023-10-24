using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public int? AccessLevel { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
