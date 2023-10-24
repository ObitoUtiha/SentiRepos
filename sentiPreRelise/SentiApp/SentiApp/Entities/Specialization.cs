using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class Specialization
{
    public int SpecializationId { get; set; }

    public string? SpecializationName { get; set; }

    public virtual ICollection<EmployeeSpecialization> EmployeeSpecializations { get; set; } = new List<EmployeeSpecialization>();
}
