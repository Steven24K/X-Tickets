using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiApiTokenPermission
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Action { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<StrapiApiTokenPermissionsTokenLnk> StrapiApiTokenPermissionsTokenLnks { get; set; } = new List<StrapiApiTokenPermissionsTokenLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
