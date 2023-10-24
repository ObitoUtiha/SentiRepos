using System;
using System.Collections.Generic;

namespace SentiApp.Entities;

public partial class TimeSlotGroup
{
    public int TimeSlotsGroupId { get; set; }

    public TimeSpan? TimeSlot { get; set; }

    public int? SheduleId { get; set; }

    public virtual Shedule? Shedule { get; set; }
}
