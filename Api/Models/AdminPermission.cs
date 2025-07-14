using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class AdminPermission
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Action { get; set; }

    public string? ActionParameters { get; set; }

    public string? Subject { get; set; }

    public string? Properties { get; set; }

    public string? Conditions { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual ICollection<AdminPermissionsRoleLnk> AdminPermissionsRoleLnks { get; set; } = new List<AdminPermissionsRoleLnk>();

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual ICollection<StrapiWorkflowsStagesPermissionsLnk> StrapiWorkflowsStagesPermissionsLnks { get; set; } = new List<StrapiWorkflowsStagesPermissionsLnk>();

    public virtual AdminUser? UpdatedBy { get; set; }
}
