using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public double? Payment { get; set; }

    public int? RegistrationId { get; set; }

    public string? Comment { get; set; }

    public virtual Registration? Registration { get; set; }
}
