using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Venue
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Name { get; set; }

    public int? Capacity { get; set; }

    public string? Adress { get; set; }

    public string? PostCode { get; set; }

    public string? City { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<EventDateTimesVenueLnk> EventDateTimesVenueLnks { get; set; } = new List<EventDateTimesVenueLnk>();

    public virtual ICollection<EventsVenueLnk> EventsVenueLnks { get; set; } = new List<EventsVenueLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
