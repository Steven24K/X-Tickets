using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class OrdersEventDateTimeLnk
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? EventDateTimeId { get; set; }

    public virtual EventDateTime? EventDateTime { get; set; }

    public virtual Order? Order { get; set; }
}
