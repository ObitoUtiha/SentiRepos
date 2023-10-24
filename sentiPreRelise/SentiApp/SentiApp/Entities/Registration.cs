using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class Registration
{
    public int RegistrationId { get; set; }

    public int? EmployeeId { get; set; }

    public int? ClientId { get; set; }

    public DateTime? DateTime { get; set; }

    public string? Status { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Client? Client { get; set; }

    public virtual EmployeeInfo? Employee { get; set; }
}
