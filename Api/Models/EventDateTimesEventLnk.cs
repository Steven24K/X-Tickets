using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class EventDateTimesEventLnk
{
    public int Id { get; set; }

    public int? EventDateTimeId { get; set; }

    public int? EventId { get; set; }

    public double? EventDateTimeOrd { get; set; }

    public virtual Event? Event { get; set; }

    public virtual EventDateTime? EventDateTime { get; set; }
}
