using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiHistoryVersion
{
    public int Id { get; set; }

    public string ContentType { get; set; } = null!;

    public string? RelatedDocumentId { get; set; }

    public string? Locale { get; set; }

    public string? Status { get; set; }

    public string? Data { get; set; }

    public string? Schema { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedById { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }
}
