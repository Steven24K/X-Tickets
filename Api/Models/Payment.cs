using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Reference { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<OrdersPaymentLnk> OrdersPaymentLnks { get; set; } = new List<OrdersPaymentLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
