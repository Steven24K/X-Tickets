using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class EventsSubEventsLnk
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int? InvEventId { get; set; }

    public double? EventOrd { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Event? InvEvent { get; set; }
}
