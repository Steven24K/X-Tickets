using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class EventDateTime
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public DateTime? DateTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<EventDateTimesEventLnk> EventDateTimesEventLnks { get; set; } = new List<EventDateTimesEventLnk>();

    public virtual ICollection<EventDateTimesVenueLnk> EventDateTimesVenueLnks { get; set; } = new List<EventDateTimesVenueLnk>();

    public virtual ICollection<OrdersEventDateTimeLnk> OrdersEventDateTimeLnks { get; set; } = new List<OrdersEventDateTimeLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
