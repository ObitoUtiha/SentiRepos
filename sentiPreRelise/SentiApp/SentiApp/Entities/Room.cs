using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class Room
{
    public int RoomId { get; set; }

    public string? RoomNumber { get; set; }

    public virtual ICollection<Shedule> Shedules { get; set; } = new List<Shedule>();
}
