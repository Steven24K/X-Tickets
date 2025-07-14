using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class I18nLocale
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual AdminUser? UpdatedBy { get; set; }
}
