using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ContactInfosCustomersLnk
{
    public int Id { get; set; }

    public int? ContactInfoId { get; set; }

    public int? CustomerId { get; set; }

    public double? CustomerOrd { get; set; }

    public double? ContactInfoOrd { get; set; }

    public virtual ContactInfo? ContactInfo { get; set; }

    public virtual Customer? Customer { get; set; }
}
