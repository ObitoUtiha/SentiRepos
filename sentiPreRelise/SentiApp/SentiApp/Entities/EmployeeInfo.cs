using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class EmployeeInfo
{
    public int EmployeeInfoId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public byte[]? EmployeePhoto { get; set; }

    public byte[]? EmployeeIdocument { get; set; }

    public DateTime? AcceptanceDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<EmployeeSpecialization> EmployeeSpecializations { get; set; } = new List<EmployeeSpecialization>();

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public virtual ICollection<Shedule> Shedules { get; set; } = new List<Shedule>();

    public virtual User? User { get; set; }
}
