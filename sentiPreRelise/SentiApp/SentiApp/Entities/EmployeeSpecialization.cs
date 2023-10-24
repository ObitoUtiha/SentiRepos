using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class EmployeeSpecialization
{
    public int EmployeeSpecializationsId { get; set; }

    public int? SpecializationId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual EmployeeInfo? Employee { get; set; }

    public virtual Specialization? Specialization { get; set; }
}
