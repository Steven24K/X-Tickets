using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? FirstName { get; set; }

    public string? Insertion { get; set; }

    public string? LastName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual ICollection<ContactInfosCustomersLnk> ContactInfosCustomersLnks { get; set; } = new List<ContactInfosCustomersLnk>();

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<CustomersPrimaryContactLnk> CustomersPrimaryContactLnks { get; set; } = new List<CustomersPrimaryContactLnk>();

    public virtual ICollection<OrdersCustomerLnk> OrdersCustomerLnks { get; set; } = new List<OrdersCustomerLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
