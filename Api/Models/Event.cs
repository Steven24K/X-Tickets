using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public decimal? Price { get; set; }

    public string? Slug { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<DiscountCodesEventLnk> DiscountCodesEventLnks { get; set; } = new List<DiscountCodesEventLnk>();

    public virtual ICollection<EventDateTimesEventLnk> EventDateTimesEventLnks { get; set; } = new List<EventDateTimesEventLnk>();

    public virtual ICollection<EventsOwnerLnk> EventsOwnerLnks { get; set; } = new List<EventsOwnerLnk>();

    public virtual ICollection<EventsSubEventsLnk> EventsSubEventsLnkEvents { get; set; } = new List<EventsSubEventsLnk>();

    public virtual ICollection<EventsSubEventsLnk> EventsSubEventsLnkInvEvents { get; set; } = new List<EventsSubEventsLnk>();

    public virtual ICollection<EventsVenueLnk> EventsVenueLnks { get; set; } = new List<EventsVenueLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
