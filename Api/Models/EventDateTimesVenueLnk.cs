using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class EventDateTimesVenueLnk
{
    public int Id { get; set; }

    public int? EventDateTimeId { get; set; }

    public int? VenueId { get; set; }

    public virtual EventDateTime? EventDateTime { get; set; }

    public virtual Venue? Venue { get; set; }
}
