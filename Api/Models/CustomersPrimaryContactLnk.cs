using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class CustomersPrimaryContactLnk
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? ContactInfoId { get; set; }

    public virtual ContactInfo? ContactInfo { get; set; }

    public virtual Customer? Customer { get; set; }
}
