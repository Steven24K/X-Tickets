using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ContactInfo
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual ICollection<ContactInfosCustomersLnk> ContactInfosCustomersLnks { get; set; } = new List<ContactInfosCustomersLnk>();

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<CustomersPrimaryContactLnk> CustomersPrimaryContactLnks { get; set; } = new List<CustomersPrimaryContactLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
