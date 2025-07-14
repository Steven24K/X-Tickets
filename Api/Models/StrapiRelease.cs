using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiRelease
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Name { get; set; }

    public DateTime? ReleasedAt { get; set; }

    public DateTime? ScheduledAt { get; set; }

    public string? Timezone { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<StrapiReleaseActionsReleaseLnk> StrapiReleaseActionsReleaseLnks { get; set; } = new List<StrapiReleaseActionsReleaseLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
