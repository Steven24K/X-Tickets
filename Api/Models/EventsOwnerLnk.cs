using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class EventsOwnerLnk
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int? UserId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual UpUser? User { get; set; }
}
