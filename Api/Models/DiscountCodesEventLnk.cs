using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class DiscountCodesEventLnk
{
    public int Id { get; set; }

    public int? DiscountCodeId { get; set; }

    public int? EventId { get; set; }

    public virtual DiscountCode? DiscountCode { get; set; }

    public virtual Event? Event { get; set; }
}
