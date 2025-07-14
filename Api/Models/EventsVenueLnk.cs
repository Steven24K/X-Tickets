using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class EventsVenueLnk
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int? VenueId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Venue? Venue { get; set; }
}
