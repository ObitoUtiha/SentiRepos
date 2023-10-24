using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class Shedule
{
    public int SheduleId { get; set; }

    public int? EmployeeId { get; set; }

    public int? RoomId { get; set; }

    public DateTime? Day { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public virtual EmployeeInfo? Employee { get; set; }

    public virtual Room? Room { get; set; }

    public virtual ICollection<TimeSlotGroup> TimeSlotGroups { get; set; } = new List<TimeSlotGroup>();
}
