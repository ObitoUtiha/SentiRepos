using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class Client
{
    public int ClientId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public string? ContactInfo { get; set; }

    public string? Comment { get; set; }

    public string? MedHistory { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
