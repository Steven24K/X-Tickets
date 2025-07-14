using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class AdminRole
{
    public int Id { get; set; }

    public string? DocumentId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public string? Locale { get; set; }

    public virtual ICollection<AdminPermissionsRoleLnk> AdminPermissionsRoleLnks { get; set; } = new List<AdminPermissionsRoleLnk>();

    public virtual ICollection<AdminUsersRolesLnk> AdminUsersRolesLnks { get; set; } = new List<AdminUsersRolesLnk>();

    public virtual AdminUser? CreatedBy { get; set; }

    public virtual AdminUser? UpdatedBy { get; set; }
}
