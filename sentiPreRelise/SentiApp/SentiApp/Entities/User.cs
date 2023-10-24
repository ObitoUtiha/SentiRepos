using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Password { get; set; } = null!;

    public string Login { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual EmployeeInfo UserNavigation { get; set; } = null!;
}
