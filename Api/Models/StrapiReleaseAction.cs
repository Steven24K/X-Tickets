using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiReleaseAction
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Type { get; set; }

    public string? ContentType { get; set; }

    public string? EntryDocumentId { get; set; }

    public string? Locale { get; set; }

    public bool? IsEntryValid { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<StrapiReleaseActionsReleaseLnk> StrapiReleaseActionsReleaseLnks { get; set; } = new List<StrapiReleaseActionsReleaseLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
