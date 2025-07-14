using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class DiscountCode
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Code { get; set; }

    public decimal? TotalDiscountPercentage { get; set; }

    public int? TimesValid { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<DiscountCodesEventLnk> DiscountCodesEventLnks { get; set; } = new List<DiscountCodesEventLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
